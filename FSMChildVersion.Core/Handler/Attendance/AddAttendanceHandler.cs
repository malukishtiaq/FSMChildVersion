using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Attendance;
using FSMChildVersion.Service.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler
{
    public class AddAttendanceHandler : IRequestHandler<AddAttendanceRequest, AddAttendanceResponse>
    {
        private readonly IAttendanceService attendanceService;

        public AddAttendanceHandler(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        public async Task<AddAttendanceResponse> Handle(AddAttendanceRequest request, CancellationToken cancellationToken)
        {
            try
            {
                AddAttendanceRequest result = await attendanceService.CheckingInOut(request).ConfigureAwait(false);
                if (result == null)
                {
                    return AddAttendanceResponse.WithStatusAndMessage(false, ConstantHandlerMessages.AttandenceUpdateFailure);
                }
                else
                {
                    return request.Status switch
                    {
                        ConstantFlags.CheckIn => AddAttendanceResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AttandenceCheckInSuccess),
                        ConstantFlags.CheckOut => AddAttendanceResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AttandenceCheckOutSuccess),
                        _ => AddAttendanceResponse.WithStatusAndMessage(true, ConstantHandlerMessages.AttandenceUpdateSuccess),
                    };
                }
            }
            catch (System.Exception ex)
            {
                return AddAttendanceResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
