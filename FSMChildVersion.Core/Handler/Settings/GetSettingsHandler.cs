using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Common.Model.Settings;
using FSMChildVersion.Service.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler
{
    public class GetSettingsHandler : IRequestHandler<GetSettingsRequest, GetSettingsResponse>
    {
        private readonly ISettingsService settingsService;

        public GetSettingsHandler(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public async Task<GetSettingsResponse> Handle(GetSettingsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = settingsService.GetValueOrDefault(request.Key, request.Value);
                return result == null || result == ""
                    ? GetSettingsResponse.WithStatusAndMessage(false, ConstantHandlerMessages.GetCheckInFalg)
                    : GetSettingsResponse.WithStatus(true);
            }
            catch (System.Exception ex)
            {
                return GetSettingsResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
