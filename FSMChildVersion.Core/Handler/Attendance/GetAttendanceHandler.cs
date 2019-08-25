using System;
using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Attendance;
using FSMChildVersion.Service.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler.Attendance
{
    public class GetAttendanceHandler : IRequestHandler<GetAttendanceRequest, GetAttendanceResponse>
    {
        private readonly IAttendanceService attendanceService;

        public GetAttendanceHandler(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        public async Task<GetAttendanceResponse> Handle(GetAttendanceRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await attendanceService.GetLastAttendanceStatus(request).ConfigureAwait(false);
                return result == null
                    ? GetAttendanceResponse.WithStatusAndMessage(false, ConstantFlags.CheckIn)
                    : GetAttendanceResponse.WithStatusAndMessage(true, result);
            }
            catch (Exception ex)
            {
                return GetAttendanceResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
