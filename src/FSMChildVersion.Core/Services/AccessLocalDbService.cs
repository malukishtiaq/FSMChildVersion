using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FSMChildVersion.Core.Model;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.DomainModels;
using FSMChildVersion.Repository.SQLite;
using Fusillade;

namespace FSMChildVersion.Core.Services
{
    public class MakeupLocalDbService : ApiManager, IMakeupLocalDbService
    {
        private readonly IRepository<MakeUp> makeUpApi;

        public MakeupLocalDbService(IRepository<MakeUp> makeUpApi)
        {
            this.makeUpApi = makeUpApi;
        }

        public async Task<List<MakeUpModel>> GetMakeupLocalDataAsync()
        {
            using (var cts = new CancellationTokenSource())
            {
                Task<List<MakeUp>> task = makeUpApi.Get();
                RunningTasks.Add(task.Id, cts);

                var makeUpModels = Task.Run(() => AutoMapper.Map<List<MakeUpModel>>(task.Result));
                RunningTasks.Add(makeUpModels.Id, cts);

                return await makeUpModels;
            }
        }
        public async Task<int> AddMakeupLocalDataAsync(List<MakeUpModel> makeUpModelList)
        {
            using (var cts = new CancellationTokenSource())
            {

                Task<int> task = makeUpApi.InsertAll(AutoMapper.Map<List<MakeUp>>(makeUpModelList));
                RunningTasks.Add(task.Id, cts);

                return await task;
            }
        }
    }
    public interface IMakeupLocalDbService
    {
        Task<List<MakeUpModel>> GetMakeupLocalDataAsync();
        Task<int> AddMakeupLocalDataAsync(List<MakeUpModel> makeUpModelList);
    }
}
