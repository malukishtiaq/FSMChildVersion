using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;

namespace FSMChildVersion.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Initializations
        public LoginViewModel()
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
        public ICommand LoginCommand => new MvxCommand(async () => await RunSafeAsync(Login()));
        #endregion

        #region Command Actions
        private Task Login()
        {
            return default;
        }
        #endregion

        #region Private Methods
        private Task OtherMethod()
        {
            return default;
        }
        #endregion
    }
}
