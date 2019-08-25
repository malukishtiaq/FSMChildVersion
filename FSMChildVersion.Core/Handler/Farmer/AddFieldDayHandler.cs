using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using FSMChildVersion.Service.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler.Farmer
{
    public class AddFieldDayHandler : IRequestHandler<AddFieldDayRequest, AddFieldDayResponse>
    {
        private readonly IFarmerService farmerService;

        public AddFieldDayHandler(IFarmerService farmerService)
        {
            this.farmerService = farmerService;
        }

        public async Task<AddFieldDayResponse> Handle(AddFieldDayRequest request, CancellationToken cancellationToken)
        {
            try
            {
                AddFieldDayRequest result = await farmerService.AddUpdateFieldDayAsync(request).ConfigureAwait(false);

                if (result == null)
                {
                    return AddFieldDayResponse.WithStatusAndMessage(false, ConstantHandlerMessages.AddNewFielddaySuccess);
                }
                else
                {
                    return AddFieldDayResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AddNewFielddaySuccess);
                }
            }
            catch (System.Exception ex)
            {
                return AddFieldDayResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
