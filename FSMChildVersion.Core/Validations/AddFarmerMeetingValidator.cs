using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FSMChildVersion.Common.RequestResponseModel.Farmer;

namespace FSMChildVersion.Core.Validations
{
    public class AddFarmerMeetingValidator : AbstractValidator<AddFarmerMeetingRequest>
    {
        public AddFarmerMeetingValidator()
        {
            RuleFor(c => c.MobileNo).NotEmpty().WithMessage("Mobile no should not be empty.");
            RuleFor(c => c.FarmerName).NotEmpty().WithMessage("Farmer name should not be empty.");
            RuleFor(c => c.NoOfParticipent).NotEmpty().WithMessage("No of participant should not be empty.");
            RuleFor(c => c.Area).NotEmpty().WithMessage("Area should not be empty.");
            //RuleFor(c => c.Image).NotEmpty().WithMessage("Image should not be empty.");
        }
    }
}
