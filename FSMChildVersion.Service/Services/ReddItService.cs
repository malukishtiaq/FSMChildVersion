using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Repository;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.APIs;
using FSMChildVersion.Repository.RequestProvider;
using Fusillade;

namespace FSMChildVersion.Service.Services
{
    public class ReddItService : ApiManager, IReddItService
    {
        private readonly IApiService<IRedditApi> redditApi;

        public ReddItService(IApiService<IRedditApi> redditApi)
        {
            this.redditApi = redditApi;
            this.redditApi.CreateClient(Config.RedditApiUrl);
        }

        public async Task<HttpResponseMessage> GetNewsAsync()
        {
            using (var cts = new CancellationTokenSource())
            {
                RunningTasks.Add(RemoteRequestAsync(redditApi.GetApi(Priority.UserInitiated).GetNews(cts.Token)).Id, cts);
                return await RemoteRequestAsync(redditApi.GetApi(Priority.UserInitiated).GetNews(cts.Token));
            }
        }
    }

    public interface IReddItService
    {
        Task<HttpResponseMessage> GetNewsAsync();
    }
}
