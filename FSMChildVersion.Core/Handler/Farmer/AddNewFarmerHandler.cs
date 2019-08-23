using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Core.Model.Farmer;
using FSMChildVersion.Core.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler.Farmer
{
    public class AddNewFarmerHandler : IRequestHandler<AddNewFarmerRequest, AddNewFarmerResponse>
    {
        private readonly IFarmerService farmerService;

        public AddNewFarmerHandler(IFarmerService farmerService)
        {
            this.farmerService = farmerService;
        }

        public async Task<AddNewFarmerResponse> Handle(AddNewFarmerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                AddNewFarmerRequest result = await farmerService.AddUpdateNewFarmerAsync(request).ConfigureAwait(false);

                if (result == null)
                {
                    return AddNewFarmerResponse.WithStatusAndMessage(false, ConstantHandlerMessages.AddNewFarmerFailure);
                }
                else
                {
                    return AddNewFarmerResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AddNewFarmerSuccess);
                }
            }
            catch (System.Exception ex)
            {
                return AddNewFarmerResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
