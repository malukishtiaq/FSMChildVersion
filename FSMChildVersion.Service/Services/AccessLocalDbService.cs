using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Common.Model;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.DomainModels;
using FSMChildVersion.Repository.SQLite;

namespace FSMChildVersion.Service.Services
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

        public async Task<List<MakeUpModel>> GetMakeupLocalUsingEFDataAsync()
        {
            using (var cts = new CancellationTokenSource())
            {
                var makeUp = new MakeUp()
                {
                    Brand = "xxxxx",
                    Category = "xxxxxxx"
                };

                MakeUp value = UnitOfWork.GenericHandler<MakeUp>().Insert(makeUp);
                UnitOfWork.Save();

                Task<List<MakeUp>> task = makeUpApi.Get();
                RunningTasks.Add(task.Id, cts);

                var makeUpModels = Task.Run(() => AutoMapper.Map<List<MakeUpModel>>(task.Result));
                RunningTasks.Add(makeUpModels.Id, cts);

                return await makeUpModels;
            }
        }
    }
    public interface IMakeupLocalDbService
    {
        Task<List<MakeUpModel>> GetMakeupLocalDataAsync();
        Task<int> AddMakeupLocalDataAsync(List<MakeUpModel> makeUpModelList);
        Task<List<MakeUpModel>> GetMakeupLocalUsingEFDataAsync();
    }
}
