using FSMChildVersion.Repository.EntityFramework.UnitOfWork;
using FSMChildVersion.Service.Services;
using MediatR;
using MvvmCross;

namespace FSMChildVersion.Core
{
    public class StaticLocator
    {
        public static IUnitOfWork GetUnitOfWorkInstance()
        {
            return Mvx.IoCProvider.Resolve<IUnitOfWork>();
        }
        public static ISettingsService GetSettingsServiceInstance()
        {
            return Mvx.IoCProvider.Resolve<ISettingsService>();
        }
        public static IMediator GetIMediatorInstance()
        {
            return Mvx.IoCProvider.Resolve<IMediator>();
        }
    }
}
