using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.ViewModels.MyTabbed
{
    public class MyTabbedViewModel : BaseViewModel
    {
        private IMvxNavigationService _navigationService;

        public MyTabbedViewModel()
        {
        }

        public MyTabbedViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
