using System;
using MediatR;

namespace FSMChildVersion.Core.Model.Attendance
{
    public class AddAttendanceRequest : IRequest<AddAttendanceResponse>
    {
        public long SQId { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public static AddAttendanceRequest CreateAttendanceRequest(long userId, string status, DateTime createdOn, string createdBy)
        {
            return new AddAttendanceRequest(userId, status, createdOn, createdBy);
        }
        public AddAttendanceRequest()
        {

        }

        public AddAttendanceRequest(long userId, string status, DateTime createdOn, string createdBy)
        {
            UserId = userId;
            Status = status;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
        }
    }
}
