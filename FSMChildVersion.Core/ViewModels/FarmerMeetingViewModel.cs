using System;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using FSMChildVersion.Core.Validations;
using MediatR;
using MvvmCross.Commands;
using Plugin.FluentValidationRules;

namespace FSMChildVersion.Core.ViewModels
{
    public class FarmerMeetingViewModel : ValidationHandler<AddFarmerMeetingRequest>
    {


        #region Private Fields
        private readonly IMediator mediator;
        #endregion

        #region Viewmodel Initialization
        public FarmerMeetingViewModel(IMediator mediator) : base(new AddFarmerMeetingValidator())
        {
            this.mediator = mediator;
            Validator = new AddFarmerMeetingValidator();
            SetupForValidationRef(Area, FarmerName, NoOfParticipent, MobileNo);
        }
        public override void Prepare()
        {
        }

        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        public override void ViewDisappeared()
        {
            Validator = null;
            base.ViewDisappeared();
        }
        #endregion

        #region Validations
        public Validatable<string> Area { get; set; } = new Validatable<string>(nameof(AddFarmerMeetingRequest.Area));
        public Validatable<string> FarmerName { get; set; } = new Validatable<string>(nameof(AddFarmerMeetingRequest.FarmerName));
        public Validatable<string> NoOfParticipent { get; set; } = new Validatable<string>(nameof(AddFarmerMeetingRequest.NoOfParticipent));
        public Validatable<string> MobileNo { get; set; } = new Validatable<string>(nameof(AddFarmerMeetingRequest.MobileNo));

        private void ResetValidateableFields()
        {
            Area.Value = string.Empty;
            FarmerName.Value = string.Empty;
            NoOfParticipent.Value = string.Empty;
            MobileNo.Value = string.Empty;
        }
        #endregion


        #region Public Fields




        #endregion


        #region Command

        public IMvxCommand AddFarmerMeetingCommand => new MvxCommand(async () => await RunSafeAsync(AddFarmerMeetingAsync()));

        #endregion


        #region Command Actions


        private async Task AddFarmerMeetingAsync()
        {
            try
            {
                AddFarmerMeetingRequest request = RefrenceTypeValidatables.Populate<AddFarmerMeetingRequest>();
                if (Validate(request).IsValidOverall && Validator.Validate(request).IsValid)
                {
                    AddFarmerMeetingResponse result = await mediator.Send(request).ConfigureAwait(false);
                    switch (result)
                    {
                        case null:
                            ResponseMessage = ConstantsViewModel.AddFarmerVisitResponseNull;
                            break;
                        default:
                            ResponseMessage = result.Message;
                            ResetValidateableFields();
                            break;
                    }
                    IsResponseVisible = true;
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
