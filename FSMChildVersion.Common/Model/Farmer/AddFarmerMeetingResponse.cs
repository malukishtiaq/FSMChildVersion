using System;
using System.Collections.Generic;
using System.Text;

namespace FSMChildVersion.Common.Model.Farmer
{
    public class AddFarmerMeetingResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private AddFarmerMeetingResponse(bool success)
        {
            Success = success;
        }

        private AddFarmerMeetingResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static AddFarmerMeetingResponse WithStatus(bool success)
        {
            return new AddFarmerMeetingResponse(success);
        }

        public static AddFarmerMeetingResponse WithStatusAndMessage(bool success, string message)
        {
            return new AddFarmerMeetingResponse(success, message);
        }
    }
}
