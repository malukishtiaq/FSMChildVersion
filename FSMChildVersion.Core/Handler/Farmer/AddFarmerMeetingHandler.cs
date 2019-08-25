using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using FSMChildVersion.Service.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler.Farmer
{
    public class AddFarmerMeetingHandler : IRequestHandler<AddFarmerMeetingRequest, AddFarmerMeetingResponse>
    {
        private readonly IFarmerService farmerService;

        public AddFarmerMeetingHandler(IFarmerService farmerService)
        {
            this.farmerService = farmerService;
        }

        public async Task<AddFarmerMeetingResponse> Handle(AddFarmerMeetingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                AddFarmerMeetingRequest result = await farmerService.AddFarmerMeetingVisitAsync(request).ConfigureAwait(false);

                if (result == null)
                {
                    return AddFarmerMeetingResponse.WithStatusAndMessage(false, ConstantHandlerMessages.AddNewFarmerFailure);
                }
                else
                {
                    return AddFarmerMeetingResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AddNewFarmerSuccess);
                }
            }
            catch (System.Exception ex)
            {
                return AddFarmerMeetingResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
