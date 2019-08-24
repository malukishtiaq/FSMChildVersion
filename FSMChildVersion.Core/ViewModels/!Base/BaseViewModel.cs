using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using FluentValidation;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Essentials;

namespace FSMChildVersion.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public readonly IMvxNavigationService NavigationService;
        public IUserDialogs PageDialog;
        public bool IsBusy { get; set; }
        public bool IsNotConnected { get; set; }

        private bool isResponseVisible = false;
        public bool IsResponseVisible
        {
            get => isResponseVisible;
            set
            {
                SetProperty(ref isResponseVisible, value);
                if (IsResponseVisible)
                {
                    _ = Task.Delay(5000).ContinueWith(t => UpdateIsResponseVisible());
                    void UpdateIsResponseVisible()
                    {
                        IsResponseVisible = false;
                    }
                }
            }
        }

        private string _responseMessage;
        public string ResponseMessage{  get => _responseMessage; set => SetProperty(ref _responseMessage, value); }
        public BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            InternetConnectionHandler();
            _ = Task.Delay(1000).ContinueWith(t => PageDialog = Mvx.IoCProvider.Resolve<IUserDialogs>());
        }

        #region Internet Connection
        private void InternetConnectionHandler()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
                UserDialogs.Instance.Toast("Oops, looks like you don't have Internet connection :(");
            else
                UserDialogs.Instance.Toast("Your Internet connection is back :)");
        }
        #endregion

        public async Task RunSafeAsync(Task task, bool showLoading = true, string loadinMessage = null)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                if (showLoading)
                    PageDialog.ShowLoading(loadinMessage ?? "Loading");

                await task;
            }
            catch (Exception e)
            {
                IsBusy = false;
                PageDialog.HideLoading();
                Debug.WriteLine(e.ToString());
                //await Application.Current.MainPage.DisplayAlert("Error", "Check your Internet connection", "OK");
            }
            finally
            {
                IsBusy = false;
                if (showLoading)
                    PageDialog.HideLoading();
            }
        }

    }
}
