using System;
using System.Collections.Generic;
using System.Text;
using Fusillade;

namespace FSMChildVersion.Repository.RequestProvider
{
    public interface IApiService<T>
    {
        void CreateClient(string apiBaseAddress);
        T GetApi(Priority priority);

    }
}
