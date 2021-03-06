using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FSMChildVersion.Repository.DomainModels;
using Refit;

namespace FSMChildVersion.Repository.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IMakeUpApiService
    {
        [Get("/api/v1/products.json?brand={brand}")]
        Task<HttpResponseMessage> GetMakeUps(string brand);

        [Post("/api/v1/addMakeUp")]
        Task<MakeUp> CreateMakeUp([Body] MakeUp makeUp, [Header("Authorization")] string token);
    }
}
