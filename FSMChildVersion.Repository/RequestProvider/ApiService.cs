using System;
using System.Net.Http;
using Fusillade;
using ModernHttpClient;
using Refit;

namespace FSMChildVersion.Repository.RequestProvider
{
    public class ApiService<T> : IApiService<T>
    {
        private Func<HttpMessageHandler, T> createClient;
        public ApiService()
        {
        }

        public void CreateClient(string apiBaseAddress)
        {
            createClient = messageHandler =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress)
                };

                return RestService.For<T>(client);
            };
        }

        private T Background
        {
            get
            {
                using (var v = new NativeMessageHandler())
                {
                    using (var vv = new RateLimitedHttpMessageHandler(v, Priority.Background))
                    {
                        return new Lazy<T>(() => createClient(vv)).Value;
                    }
                }
            }
        }

        private T UserInitiated
        {
            get
            {
                using (var handler = new NativeMessageHandler())
                {
                    using (var arg = new RateLimitedHttpMessageHandler(handler, Priority.UserInitiated))
                    {
                        return new Lazy<T>(() => createClient(arg)).Value;
                    }
                }
            }
        }

        private T Speculative
        {
            get
            {
                using (var handler = new NativeMessageHandler())
                {
                    using (var arg = new RateLimitedHttpMessageHandler(handler, Priority.Speculative))
                    {
                        return new Lazy<T>(() => createClient(arg)).Value;
                    }
                }
            }
        }

        public T GetApi(Priority priority)
        {
            switch (priority)
            {
                case Priority.Background:
                    return Background;
                case Priority.UserInitiated:
                    return UserInitiated;
                case Priority.Speculative:
                    return Speculative;
                default:
                    return UserInitiated;
            }
        }
    }
}

