using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Core.Model.Attendance;
using FSMChildVersion.Core.Services;
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
