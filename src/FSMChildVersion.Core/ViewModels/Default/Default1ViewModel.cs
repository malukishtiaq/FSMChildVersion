using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.Core.Default
{
    public class Default1ViewModel : BaseViewModel
    {
        private IMvxNavigationService _navigationService;

        public Default1ViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
