using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FSMChildVersion.Core.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.ViewModels
{
    public class FarmerDashboardPageViewModel : BaseViewModel
    {
        #region Initializations
        public FarmerDashboardPageViewModel()
        {
        }
        public override void Prepare()
        {
        }

        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        #endregion

        #region Commands
        public ICommand FarmerVisitCommand => new MvxCommand(async () => await RunSafeAsync(FarmerVisit()));
        public ICommand NewInformationCommand => new MvxCommand(async () => await RunSafeAsync(NewInformation()));
        public ICommand CustomerJobsCommand => new MvxCommand(async () => await RunSafeAsync(CustomerJobs()));
        #endregion

        #region Command Actions
        private Task FarmerVisit() => NavigationService.Navigate<FarmerVisitViewModel>();
        private Task NewInformation() => NavigationService.Navigate<NewInformationViewModel>();
        private Task CustomerJobs() => NavigationService.Navigate<CustomJobsViewModel>();

        #endregion

        #region Private Methods
        #endregion
    }
}
