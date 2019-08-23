using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Core.Model.Farmer;
using FSMChildVersion.Core.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler.Farmer
{
    public class AddFarmerVisitHandler : IRequestHandler<AddFarmerVisitRequest, AddFarmerVisitResponse>
    {
        private readonly IFarmerService farmerService;

        public AddFarmerVisitHandler(IFarmerService farmerService)
        {
            this.farmerService = farmerService;
        }

        public async Task<AddFarmerVisitResponse> Handle(AddFarmerVisitRequest request, CancellationToken cancellationToken)
        {
            try
            {
                AddFarmerVisitRequest result = await farmerService.AddUpdateFarmerVisitAsync(request).ConfigureAwait(false);

                if (result == null)
                {
                    return AddFarmerVisitResponse.WithStatusAndMessage(false, ConstantHandlerMessages.AddNewFarmerFailure);
                }
                else
                {
                    return AddFarmerVisitResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AddNewFarmerSuccess);
                }
            }
            catch (System.Exception ex)
            {
                return AddFarmerVisitResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
