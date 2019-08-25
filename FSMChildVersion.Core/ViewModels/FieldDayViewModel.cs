using System;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using FSMChildVersion.Core.Validations;
using MediatR;
using MvvmCross.Commands;
using Plugin.FluentValidationRules;

namespace FSMChildVersion.Core.ViewModels
{
    public class FieldDayViewModel : ValidationHandler<AddFieldDayRequest>
    {
        #region Private Fields
        private readonly IMediator mediator;
        #endregion

        #region Viewmodel Initialization
        public FieldDayViewModel(IMediator mediator) : base(new AddFieldDayValidator())
        {
            this.mediator = mediator;
            Validator = new AddFieldDayValidator();
            SetupForValidationRef(Crop, FarmerName, Product, MobileNo);
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
        public Validatable<string> Crop { get; set; } = new Validatable<string>(nameof(AddFieldDayRequest.Crop));
        public Validatable<string> FarmerName { get; set; } = new Validatable<string>(nameof(AddFieldDayRequest.FarmerName));
        public Validatable<string> Product { get; set; } = new Validatable<string>(nameof(AddFieldDayRequest.Product));
        public Validatable<string> MobileNo { get; set; } = new Validatable<string>(nameof(AddFieldDayRequest.MobileNo));

        private void ResetValidateableFields()
        {
            Crop.Value = string.Empty;
            FarmerName.Value = string.Empty;
            Product.Value = string.Empty;
            MobileNo.Value = string.Empty;
        }
        #endregion


        #region Public Fields




        #endregion


        #region Command

        public IMvxCommand AddFieldDayCommand => new MvxCommand(async () => await RunSafeAsync(AddFieldDayAsync()));

        #endregion


        #region Command Actions


        private async Task AddFieldDayAsync()
        {
            try
            {
                AddFieldDayRequest request = RefrenceTypeValidatables.Populate<AddFieldDayRequest>();
                if (Validate(request).IsValidOverall && Validator.Validate(request).IsValid)
                {
                    AddFieldDayResponse result = await mediator.Send(request).ConfigureAwait(false);
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
