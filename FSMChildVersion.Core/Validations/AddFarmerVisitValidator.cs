using FluentValidation;
using FSMChildVersion.Common.RequestResponseModel.Farmer;

namespace FSMChildVersion.Core.Validations
{
    public class AddFarmerVisitValidator : AbstractValidator<AddFarmerVisitRequest>
    {
        public AddFarmerVisitValidator()
        {
            RuleFor(c => c.FarmerName).NotEmpty().WithMessage("Farmer name should not be empty.");
            RuleFor(c => c.MobileNo).NotEmpty().WithMessage("Mobile no should not be empty.");
            RuleFor(c => c.Location).NotEmpty().WithMessage("Location should not be empty.");
            RuleFor(c => c.Crop).NotEmpty().WithMessage("Crop should not be empty.");
        }
    }
}
