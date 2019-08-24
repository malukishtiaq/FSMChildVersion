using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Common.Model.Feedback;
using FSMChildVersion.Service.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler.Feedback
{
    public class AddFeedbackHandler : IRequestHandler<AddFeedbackRequest, AddFeedbackResponse>
    {
        private readonly IFarmerService farmerService;

        public AddFeedbackHandler(IFarmerService farmerService)
        {
            this.farmerService = farmerService;
        }

        public async Task<AddFeedbackResponse> Handle(AddFeedbackRequest request, CancellationToken cancellationToken)
        {
            try
            {
                AddFeedbackRequest result = await farmerService.AddUpdateFeedbackAsync(request).ConfigureAwait(false);

                if (result == null)
                {
                    return AddFeedbackResponse.WithStatusAndMessage(false, ConstantHandlerMessages.AddNewFarmerFailure);
                }
                else
                {
                    return AddFeedbackResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AddNewFarmerSuccess);
                }
            }
            catch (System.Exception ex)
            {
                return AddFeedbackResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
