using MediatR;

namespace FSMChildVersion.Common.RequestResponseModel.Attendance
{
    public class GetAttendanceRequest : IRequest<GetAttendanceResponse>
    {
        public long UserId { get; set; }

        public static GetAttendanceRequest CreateAttendanceRequest(long userId)
        {
            return new GetAttendanceRequest(userId);
        }
        public GetAttendanceRequest()
        {

        }

        public GetAttendanceRequest(long userId)
        {
            UserId = userId;
        }
    }
}
