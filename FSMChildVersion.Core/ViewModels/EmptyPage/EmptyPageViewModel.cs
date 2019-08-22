using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.ViewModels.EmptyPage
{
    public class EmptyPageViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;

        public EmptyPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Prepare()
        {
        }

        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        public ICommand NavigateToReminder => new MvxCommand(SomeMethodAsync);
        public async void SomeMethodAsync()
        {
            await _navigationService.Close(this);
        }
    }
}
