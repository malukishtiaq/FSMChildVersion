using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FSMChildVersion.Core.Model;
using FSMChildVersion.Core.Model.Login;
using FSMChildVersion.Core.Model.Settings;
using FSMChildVersion.Core.Validations;
using MediatR;
using MvvmCross.Commands;
using Plugin.FluentValidationRules;

namespace FSMChildVersion.Core.ViewModels
{

    public class LoginViewModel : ValidationHandler<LoginRequest>
    {
        #region Initializations
        private readonly IMediator mediator;
        public LoginViewModel(IMediator mediator) : base(new LoginValidator())
        {
            this.mediator = mediator;
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
        public Validatable<string> Username { get; set; } = new Validatable<string>(nameof(LoginRequest.Username));
        public Validatable<string> Password { get; set; } = new Validatable<string>(nameof(LoginRequest.Password));
        #endregion

        #region Commands
        public ICommand LoginCommand => new MvxCommand(async () => await RunSafeAsync(LoginMethodAsync()));
        #endregion

        #region Public Properties
        #endregion

        #region Command Actions
        private async Task LoginMethodAsync()
        {
            try
            {
                LoginRequest login = RefrenceTypeValidatables.Populate<LoginRequest>();
                if (Validate(login).IsValidOverall && Validator.Validate(login).IsValid)
                {
                    LoginResponse result = await mediator.Send(login).ConfigureAwait(false);
                    if (result == null)
                    {
                        ResponseMessage = ConstantsViewModel.LoginResponseNull;
                        IsResponseVisible = false;
                    }
                    else
                    {
                        if (result.Success)
                        {
                            IsResponseVisible = false;
                            var item = AddSettingsRequest.CreateSettingRequest(ConstantFlags.LoginFlag, true.ToString());
                            AddSettingsResponse response = await mediator.Send(item).ConfigureAwait(false);

                            if (!response.Success)
                            {
                                Console.WriteLine(ConstantsViewModel.SettingSaveFailure);
                            }

                            await NavigationService.Navigate<MasterDetailViewModel>();
                            await NavigationService.Close(this);
                        }
                        else
                        {
                            ResponseMessage = result.Message;
                            IsResponseVisible = true;
                        }
                    }
                }
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            return;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
