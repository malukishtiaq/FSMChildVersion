using System;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using FSMChildVersion.Core.Validations;
using MediatR;
using MvvmCross.Commands;
using Plugin.FluentValidationRules;

namespace FSMChildVersion.Core.ViewModels
{
    public class FarmerVisitViewModel : ValidationHandler<AddFarmerVisitRequest>
    {
        #region Private Fields
        private readonly IMediator mediator;
        #endregion

        #region Viewmodel Initialization
        public FarmerVisitViewModel(IMediator mediator) : base(new AddFarmerVisitValidator())
        {
            this.mediator = mediator;
            Validator = new AddFarmerVisitValidator();
            SetupForValidationRef(Crop, FarmerName, Location, MobileNo);
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
        public Validatable<string> Crop { get; set; } = new Validatable<string>(nameof(AddFarmerVisitRequest.Crop));
        public Validatable<string> FarmerName { get; set; } = new Validatable<string>(nameof(AddFarmerVisitRequest.FarmerName));
        public Validatable<string> Location { get; set; } = new Validatable<string>(nameof(AddFarmerVisitRequest.Location));
        public Validatable<string> MobileNo { get; set; } = new Validatable<string>(nameof(AddFarmerVisitRequest.MobileNo));

        private void ResetValidateableFields()
        {
            Crop.Value = string.Empty;
            FarmerName.Value = string.Empty;
            Location.Value = string.Empty;
            MobileNo.Value = string.Empty;
        }
        #endregion

        #region Public Fields




        #endregion


        #region Command
        public IMvxCommand AddFarmerVisitCommand => new MvxCommand(async () => await RunSafeAsync(AddFarmerVisitAsync()));




        #endregion


        #region Command Actions

        private async Task AddFarmerVisitAsync()
        {
            try
            {
                AddFarmerVisitRequest request = RefrenceTypeValidatables.Populate<AddFarmerVisitRequest>();
                if (Validate(request).IsValidOverall && Validator.Validate(request).IsValid)
                {
                    AddFarmerVisitResponse result = await mediator.Send(request).ConfigureAwait(false);
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
