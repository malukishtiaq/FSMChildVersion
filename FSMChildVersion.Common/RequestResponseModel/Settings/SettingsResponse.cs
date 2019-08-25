using System;
using System.Collections.Generic;
using System.Text;

namespace FSMChildVersion.Common.RequestResponseModel.Settings
{
    public class AddSettingsResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private AddSettingsResponse(bool success)
        {
            Success = success;
        }

        private AddSettingsResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static AddSettingsResponse WithStatus(bool success)
        {
            return new AddSettingsResponse(success);
        }

        public static AddSettingsResponse WithStatusAndMessage(bool success, string message)
        {
            return new AddSettingsResponse(success, message);
        }
    }
}
