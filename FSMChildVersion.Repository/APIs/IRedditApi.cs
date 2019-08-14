using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace FSMChildVersion.Repository.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IRedditApi
    {
        [Get("/subreddit/new.json?sort=top&limit=20")]
        Task<HttpResponseMessage> GetNews(CancellationToken cancellationToken);
    }
}
