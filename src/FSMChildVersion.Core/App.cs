using Acr.UserDialogs;
using AutoMapper;
using FSMChildVersion.Core.AutoMapper;
using FSMChildVersion.Core.ViewModels;
using FSMChildVersion.Core.ViewModels.Page;
using FSMChildVersion.Repository.RequestProvider;
using FSMChildVersion.Repository.SQLite;
//using Matcha.BackgroundService;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace FSMChildVersion.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var SQLiteSetupInstance = new SQLiteSetup();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType(typeof(IApiService<>), typeof(ApiService<>));
            Mvx.IoCProvider.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            Mvx.IoCProvider.RegisterSingleton(() => UserDialogs.Instance);
            Mvx.IoCProvider.RegisterSingleton(() => CrossConnectivity.Current);
            Mvx.IoCProvider.RegisterSingleton(theObject: new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper());


            RegisterAppStart<MasterDetailViewModel>();
        }
    }
}
