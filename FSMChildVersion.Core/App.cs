using Acr.UserDialogs;
using AutoMapper;
using FluentValidation;
using FSMChildVersion.Core.AutoMapper;
using FSMChildVersion.Core.Validations;
using FSMChildVersion.Core.ViewModels;
using FSMChildVersion.Repository.DomainModels;
using FSMChildVersion.Repository.EntityFramework;
using FSMChildVersion.Repository.EntityFramework.Database;
using FSMChildVersion.Repository.EntityFramework.GenericHandler;
using FSMChildVersion.Repository.EntityFramework.UnitOfWork;
using FSMChildVersion.Repository.RequestProvider;
using FSMChildVersion.Repository.SQLite;
//using Matcha.BackgroundService;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Plugin.Connectivity;

namespace FSMChildVersion.Core
{
    public class App : MvxApplication
    {

        public static string User = "Rendy";

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType(typeof(IApiService<>), typeof(ApiService<>));
            Mvx.IoCProvider.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            Mvx.IoCProvider.RegisterSingleton(() => SQLiteDatabase.Instance);

            Mvx.IoCProvider.RegisterSingleton(() => UserDialogs.Instance);
            Mvx.IoCProvider.RegisterSingleton(() => CrossConnectivity.Current);
            Mvx.IoCProvider.RegisterSingleton(theObject: new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper());

            Mvx.IoCProvider.RegisterType<SFMDatabaseContext>();
            Mvx.IoCProvider.RegisterType<IValidator, LoginValidator>();
            Mvx.IoCProvider.RegisterType<IUnitOfWork, UnitOfWork>();

            RegisterGenricRepo<MakeUp>();

            RegisterAppStart<LoginViewModel>();
        }
        private static void RegisterGenricRepo<T>() where T : class
        {
            Mvx.IoCProvider.RegisterType<IGenericHandler<T>, GenericHandler<T>>();
        }

    }
}
