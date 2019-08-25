using System;
using Acr.UserDialogs;
using FluentValidation;
using FSMChildVersion.Common.RequestResponseModel.Settings;
using FSMChildVersion.Core.Validations;
using FSMChildVersion.Core.ViewModels;
using FSMChildVersion.Repository.EntityFramework;
using FSMChildVersion.Repository.EntityFramework.GenericHandler;
using FSMChildVersion.Service;
using MediatR;
//using Matcha.BackgroundService;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core
{
    public class App : MvxApplication
    {

        public static string User = "Rendy";

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Handler")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMediator, Mediator>();

            Mvx.IoCProvider.RegisterSingleton<ServiceFactory>((Type serviceType) =>
            {
                IMvxIoCProvider resolver = Mvx.IoCProvider.Resolve<IMvxIoCProvider>();

                if (resolver.CanResolve(serviceType))
                    return resolver.Resolve(serviceType);

                return Array.CreateInstance(serviceType.GenericTypeArguments[0], 0);
            });

            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            MvxBootstrap.Initialize();

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
