using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.Pages.Master
{
    public class MasterTestViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;

        public MasterTestViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
