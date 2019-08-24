using FluentValidation;
using FSMChildVersion.Common.Model.Farmer;

namespace FSMChildVersion.Core.Validations
{
    public class AddNewFarmerValidator : AbstractValidator<AddNewFarmerRequest>
    {
        public AddNewFarmerValidator()
        {
            RuleFor(c => c.MobileNo).NotEmpty().WithMessage("Mobile no should not be empty.");
            RuleFor(c => c.FarmerName).NotEmpty().WithMessage("Farmer name should not be empty.");
            RuleFor(c => c.Area).NotEmpty().WithMessage("Location should not be empty.");
            RuleFor(c => c.Acre).NotEmpty().WithMessage("Crop should not be empty.");
        }
    }
}
