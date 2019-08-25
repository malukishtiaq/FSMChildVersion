namespace FSMChildVersion.Common.RequestResponseModel.Settings
{
    public class GetSettingsResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private GetSettingsResponse(bool success)
        {
            Success = success;
        }

        private GetSettingsResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static GetSettingsResponse WithStatus(bool success)
        {
            return new GetSettingsResponse(success);
        }

        public static GetSettingsResponse WithStatusAndMessage(bool success, string message)
        {
            return new GetSettingsResponse(success, message);
        }
    }
}
