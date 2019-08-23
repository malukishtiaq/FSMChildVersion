using System;
using System.Collections.Generic;
using System.Text;

namespace FSMChildVersion.Core.Model.Attendance
{
    public class GetAttendanceResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private GetAttendanceResponse(bool success)
        {
            Success = success;
        }

        private GetAttendanceResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static GetAttendanceResponse WithStatus(bool success)
        {
            return new GetAttendanceResponse(success);
        }

        public static GetAttendanceResponse WithStatusAndMessage(bool success, string message)
        {
            return new GetAttendanceResponse(success, message);
        }
    }
}
