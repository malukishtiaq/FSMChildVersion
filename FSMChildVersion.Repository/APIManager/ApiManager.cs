using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AutoMapper;
using FSMChildVersion.Repository.EntityFramework.UnitOfWork;
using MvvmCross;
using Plugin.Connectivity.Abstractions;
using Polly;
using Refit;

namespace FSMChildVersion.Repository.APIManager
{
    public abstract class ApiManager
    {
        public readonly IUserDialogs UserDialogs;
        public readonly IConnectivity Connectivity;
        public readonly IMapper AutoMapper;
        public readonly IUnitOfWork UnitOfWork;
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }

        public readonly Dictionary<int, CancellationTokenSource> RunningTasks = new Dictionary<int, CancellationTokenSource>();
        public readonly Dictionary<string, Task<HttpResponseMessage>> TaskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

        public ApiManager()
        {
            AutoMapper = Mvx.IoCProvider.Resolve<IMapper>();
            Connectivity = Mvx.IoCProvider.Resolve<IConnectivity>();
            IsConnected = Connectivity.IsConnected;
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
            UserDialogs = Mvx.IoCProvider.Resolve<IUserDialogs>();
            UnitOfWork = Mvx.IoCProvider.Resolve<IUnitOfWork>();
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.IsConnected;

            if (!e.IsConnected)
            {
                foreach (KeyValuePair<int, CancellationTokenSource> item in RunningTasks.ToList())
                {
                    item.Value.Cancel();
                    RunningTasks.Remove(item.Key);
                }
            }
        }
        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task) where TData : HttpResponseMessage, new()
        {
            var data = new TData();

            if (!IsConnected)
            {
                var strngResponse = "There's no network connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                UserDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            try
            {
                IsReachable = await Connectivity.IsRemoteReachable(Config.ApiHostName);
            }
            catch (Exception) { }

            if (!IsReachable)
            {
                var strngResponse = "There's no Internet connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                UserDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }
            data = await HitAndRetryAsync(task, data);

            return data;
        }

        private async Task<TData> HitAndRetryAsync<TData>(Task<TData> task, TData data) where TData : HttpResponseMessage, new()
        {
            data = await Policy.Handle<WebException>().Or<ApiException>().Or<TaskCanceledException>().WaitAndRetryAsync
            (
                retryCount: 1,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
            )
            .ExecuteAsync(action: async () =>
            {
                TData result = await task;

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Logout the user 
                }
                RunningTasks.Remove(task.Id);

                return result;
            });
            return data;
        }
    }
}
