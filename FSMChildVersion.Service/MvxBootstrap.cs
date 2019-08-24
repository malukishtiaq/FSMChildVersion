using System.Reflection;
using Acr.UserDialogs;
using AutoMapper;
using FSMChildVersion.Repository.EntityFramework.Database;
using FSMChildVersion.Repository.EntityFramework.UnitOfWork;
using FSMChildVersion.Service.AutoMapper;
using MvvmCross;
using MvvmCross.IoC;
using Plugin.Connectivity;

namespace FSMChildVersion.Service
{
    public static class MvxBootstrap
    {
        public static void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IUnitOfWork, UnitOfWork>();

            Mvx.IoCProvider.RegisterSingleton<IMapper>(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper());
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton(() => CrossConnectivity.Current);

            Mvx.IoCProvider.RegisterType<SFMDatabaseContext>();

            typeof(MvxBootstrap).GetTypeInfo().Assembly.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsSingleton();

            //typeof(MvxBootstrap).GetTypeInfo().Assembly.CreatableTypes()
            //    .EndingWith("Client")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();
        }
    }
}
