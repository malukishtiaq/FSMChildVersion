using System.Threading.Tasks;
using FSMChildVersion.Core.Model.Farmer;
using FSMChildVersion.Core.Validations;
using MediatR;
using MvvmCross.Commands;
using Plugin.FluentValidationRules;

namespace FSMChildVersion.Core.ViewModels
{
    public class AddNewFarmerViewModel : ValidationHandler<AddNewFarmerRequest>
    {
        #region Viewmodel Initialization
        private readonly IMediator mediator;
        public AddNewFarmerViewModel(IMediator mediator) : base(new AddNewFarmerValidator())
        {
            this.mediator = mediator;
            SetupForValidationRef(Acre, FarmerName, Area, MobileNo);
        }
        public override void Prepare()
        {
        }
        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        #endregion

        #region Validation Setup
        public Validatable<string> Acre { get; set; } = new Validatable<string>(nameof(AddNewFarmerRequest.Acre));
        public Validatable<string> FarmerName { get; set; } = new Validatable<string>(nameof(AddNewFarmerRequest.FarmerName));
        public Validatable<string> Area { get; set; } = new Validatable<string>(nameof(AddNewFarmerRequest.Area));
        public Validatable<string> MobileNo { get; set; } = new Validatable<string>(nameof(AddNewFarmerRequest.MobileNo));
        #endregion

        #region Commands

        public IMvxCommand AddFarmerCommand => new MvxCommand(async () => await RunSafeAsync(AddFarmerAsync()));

        private async Task AddFarmerAsync()
        {
            AddNewFarmerRequest validObj = RefrenceTypeValidatables.Populate<AddNewFarmerRequest>();

            if (Validate(validObj).IsValidOverall && Validator.Validate(validObj).IsValid)
            {
                var addNewFarmerRequest = AddNewFarmerRequest.CreateAddNewFarmerRequest(validObj.MobileNo, validObj.FarmerName, validObj.Acre, validObj.Area);

                AddNewFarmerResponse result = await mediator.Send(addNewFarmerRequest).ConfigureAwait(false);
                if (result == null)
                {
                    ResponseMessage = ConstantsViewModel.AddFarmerResponseNull;
                }
                else if (result.Success)
                {
                    ResponseMessage = result.Message;
                }
                IsResponseVisible = false;
            }
        }
        #endregion
    }
}
