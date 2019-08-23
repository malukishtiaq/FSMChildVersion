using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.ViewModels
{
    public class PerformanceTestingViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;

        public PerformanceTestingViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
