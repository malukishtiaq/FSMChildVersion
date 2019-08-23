using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Core.Model.Settings;
using FSMChildVersion.Core.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler
{
    public class AddSettingsHandler : IRequestHandler<AddSettingsRequest, AddSettingsResponse>
    {
        private readonly ISettingsService settingsService;

        public AddSettingsHandler(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public async Task<AddSettingsResponse> Handle(AddSettingsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await settingsService.AddOrUpdateValue(request.Key, request.Value).ConfigureAwait(false);
                await settingsService.AddOrUpdateValue(ConstantHandlerMessages.IsLoggedIn, true.ToString()).ConfigureAwait(false);

                var result = settingsService.GetValueOrDefault(request.Key, "");
                if (result == null || result == "")
                {
                    return AddSettingsResponse.WithStatusAndMessage(false, ConstantHandlerMessages.AddCheckInFalg);
                }
                else
                {
                    return AddSettingsResponse.WithStatus(true);
                }
            }
            catch (System.Exception ex)
            {
                return AddSettingsResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
