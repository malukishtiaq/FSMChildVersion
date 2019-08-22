using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using FSMChildVersion.Core.Model;
using FSMChildVersion.Core.Services;
using FSMChildVersion.Core.Validations;
using MvvmCross.Commands;
using Plugin.FluentValidationRules;
using Xamarin.Forms;

namespace FSMChildVersion.Core.ViewModels
{

    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class LoginViewModel : ValidationHandler<LoginModel>
    {
        #region Initializations
        private readonly IMakeupLocalDbService makeupLocalDbService;
        public LoginViewModel(IMakeupLocalDbService makeupLocalDbService) : base(new LoginValidator())
        {
            this.makeupLocalDbService = makeupLocalDbService;
            SetupForValidationRef(Username, Password);
        }

        public override void Prepare()
        {
        }

        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        #endregion

        #region Validation Setup
        public Validatable<string> Username { get; set; } = new Validatable<string>(nameof(LoginModel.Username));
        public Validatable<string> Password { get; set; } = new Validatable<string>(nameof(LoginModel.Password));
        #endregion

        #region Commands
        public ICommand LoginCommand => new MvxCommand(async () => await RunSafeAsync(LoginMethod()));
        #endregion

        #region Public Properties
        public LoginModel Login { get; set; } = new LoginModel();
        #endregion

        #region Command Actions
        private Task LoginMethod()
        {
            LoginModel login = LoginValidatablesRef.Populate<LoginModel>();
            Task<List<MakeUpModel>> data;
            if (Validator.Validate(login).IsValid)
            {
                data = makeupLocalDbService.GetMakeupLocalUsingEFDataAsync();
            }
            else
            {
            }
            return Task.CompletedTask;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
