using System;
using FluentValidation;
using FSMChildVersion.Core.Model;
using Plugin.FluentValidationRules;

namespace FSMChildVersion.Core.Validations
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(c => c.Username).Must(n => ValidateStringEmpty(n)).WithMessage("Username should not be empty.");
            RuleFor(c => c.Password).Must(n => ValidateStringEmpty(n)).WithMessage("Password should not be empty.");
        }
        private bool ValidateStringEmpty(string stringValue)
        {
            return !string.IsNullOrEmpty(stringValue);
        }
    }
}
