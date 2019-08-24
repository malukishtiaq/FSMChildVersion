using System;
using System.Collections.Generic;
using System.Text;

namespace FSMChildVersion.Common.Model.Attendance
{
    public class AddAttendanceResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private AddAttendanceResponse(bool success)
        {
            Success = success;
        }

        private AddAttendanceResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static AddAttendanceResponse WithStatus(bool success)
        {
            return new AddAttendanceResponse(success);
        }

        public static AddAttendanceResponse WithStatusAndMessage(bool success, string message)
        {
            return new AddAttendanceResponse(success, message);
        }
    }
}
