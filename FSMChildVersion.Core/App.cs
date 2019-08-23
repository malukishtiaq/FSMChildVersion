using System;
using Acr.UserDialogs;
using AutoMapper;
using FluentValidation;
using FSMChildVersion.Core.AutoMapper;
using FSMChildVersion.Core.Model.Settings;
using FSMChildVersion.Core.Validations;
using FSMChildVersion.Core.ViewModels;
using FSMChildVersion.Repository.EntityFramework;
using FSMChildVersion.Repository.EntityFramework.Database;
using FSMChildVersion.Repository.EntityFramework.GenericHandler;
using FSMChildVersion.Repository.EntityFramework.UnitOfWork;
using MediatR;
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


            CreatableTypes()
                .EndingWith("Handler")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterSingleton<IMapper>(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper());

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton(() => UserDialogs.Instance);
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton(() => CrossConnectivity.Current);

            Mvx.IoCProvider.RegisterType<SFMDatabaseContext>();

            Mvx.IoCProvider.RegisterType<IValidator, LoginValidator>();
            Mvx.IoCProvider.RegisterType<IUnitOfWork, UnitOfWork>();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMediator, Mediator>();

            Mvx.IoCProvider.RegisterSingleton<ServiceFactory>((Type serviceType) =>
            {
                IMvxIoCProvider resolver = Mvx.IoCProvider.Resolve<IMvxIoCProvider>();

                if (resolver.CanResolve(serviceType))
                    return resolver.Resolve(serviceType);

                return Array.CreateInstance(serviceType.GenericTypeArguments[0], 0);
            });

            if (!IsLoggedIn())
            {
                RegisterAppStart<LoginViewModel>();
            }
            else
            {
                RegisterAppStart<MasterDetailViewModel>();
            }
        }
        private static void RegisterGenricRepo<T>() where T : class
        {
            Mvx.IoCProvider.RegisterType<IGenericHandler<T>, GenericHandler<T>>();
        }

        private static bool IsLoggedIn()
        {
            var getSettingsRequest = GetSettingsRequest.CreateSettingRequest(ConstantHandlerMessages.IsLoggedIn, true.ToString());
            IMediator mediator = Mvx.IoCProvider.Resolve<IMediator>();
            GetSettingsResponse getSettingsResponse = mediator.Send(getSettingsRequest).Result;

            return getSettingsResponse == null ? false : getSettingsResponse.Success;
        }
    }
}
