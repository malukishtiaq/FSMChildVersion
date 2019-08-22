using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Repository;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.APIs;
using FSMChildVersion.Repository.RequestProvider;
using Fusillade;

namespace FSMChildVersion.Core.Services
{
    public class MakeUpService : ApiManager, IMakeUpService
    {
        private readonly IApiService<IMakeUpApiService> makeUpApi;

        public MakeUpService(IApiService<IMakeUpApiService> makeUpApi)
        {
            makeUpApi.CreateClient(Config.ApiUrl);
            this.makeUpApi = makeUpApi;
        }

        public async Task<HttpResponseMessage> GetMakeUpsAsync(string brand)
        {
            using (var cts = new CancellationTokenSource())
            {
                Task<HttpResponseMessage> task = RemoteRequestAsync(makeUpApi.GetApi(Priority.UserInitiated).GetMakeUps(brand));
                RunningTasks.Add(task.Id, cts);
                return await task;
            }
        }
    }
    public interface IMakeUpService
    {
        Task<HttpResponseMessage> GetMakeUpsAsync(string brand);
    }
}
