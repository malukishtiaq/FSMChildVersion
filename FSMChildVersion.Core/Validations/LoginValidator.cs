using FluentValidation;
using FSMChildVersion.Common.Model.Login;

namespace FSMChildVersion.Core.Validations
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            //RuleFor(e => e.Username).NotEmpty();
            //
            //When(e => e.Password != null, () =>
            //{
            //    RuleFor(e => e.Password).MinimumLength(3).WithMessage("How you bout to enter a FULL 'name' with less than 3 chars!?")
            //            .Must(name => name.Contains(" ")).WithMessage("Expecting at least first and last name separated by a space!");
            //});

            RuleFor(c => c.Username).NotEmpty().WithMessage("Username should not be empty.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Password should not be empty.");
        }
    }
}
