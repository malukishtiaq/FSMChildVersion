using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FSMChildVersion.Common.RequestResponseModel.Farmer;

namespace FSMChildVersion.Core.Validations
{
    public class AddFieldDayValidator : AbstractValidator<AddFieldDayRequest>
    {
        public AddFieldDayValidator()
        {
            RuleFor(c => c.MobileNo).NotEmpty().WithMessage("Mobile no should not be empty.");
            RuleFor(c => c.FarmerName).NotEmpty().WithMessage("Farmer name should not be empty.");
            RuleFor(c => c.Crop).NotEmpty().WithMessage("Crop should not be empty.");
            RuleFor(c => c.Product).NotEmpty().WithMessage("Product should not be empty.");
            //RuleFor(c => c.Image).NotEmpty().WithMessage("Image should not be empty.");
        }
    }
}
