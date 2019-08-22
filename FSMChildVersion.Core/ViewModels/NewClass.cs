using System;
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
    ////    public class CaleeViewModel : ValidationHandler<LoginModel>
    ////    {
    ////        public Validatable<string> Username { get; set; } = new Validatable<string>(nameof(LoginModel.Username));
    ////        public Validatable<string> Password { get; set; } = new Validatable<string>(nameof(LoginModel.Password));
    ////        public CaleeViewModel()
    ////        {
    ////            var validationRules = new LoginValidator();

    ////            SetUpForValidationObject(validationRules);
    ////            SetupForValidationRef(Username, Password);
    ////        }
    ////        public ICommand LoginCommand => new MvxCommand(async () => await RunSafeAsync(LoginMethod()));
    ////        private Task LoginMethod()
    ////        {
    ////            LoginModel login = LoginValidatablesRef.Populate<LoginModel>();

    ////            if (Validator.Validate(login).IsValid && Validator.Validate(login).IsValid)
    ////            {

    ////            }
    ////            else
    ////            {

    ////            }

    ////            var data = Task.Run(() => default);
    ////            return data;
    ////        }

    ////        public void ClearValidationForGroup(string className)
    ////        {
    ////            if (className == "loginGroup")
    ////            {
    ////                _loginValidatables.Clear();
    ////            }
    ////        }
    ////        public void ClearEverything()
    ////        {
    ////            _loginValidatables.Clear(false);

    ////            LoginWins = 0;
    ////            LoginFails = 0;
    ////        }

    ////    }
    ////}
}
