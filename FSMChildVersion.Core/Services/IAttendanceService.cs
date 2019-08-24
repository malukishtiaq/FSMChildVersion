using System;
using System.Linq;
using System.Threading.Tasks;
using FSMChildVersion.Common.Model.Attendance;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.DomainModels;

namespace FSMChildVersion.Core.Services
{
    public class AttendanceService : ApiManager, IAttendanceService
    {
        public Task<AddAttendanceRequest> CheckingInOut(AddAttendanceRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            Attendance model = AutoMapper.Map<Attendance>(request);
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            Attendance item = UnitOfWork.GenericHandler<Attendance>().Insert(model);
            UnitOfWork.Save();
            
            AddAttendanceRequest result = AutoMapper.Map<AddAttendanceRequest>(item);
            if (result is null)
                throw new ArgumentNullException(nameof(result));

            return Task.FromResult(result);
        }

        public Task<string> GetLastAttendanceStatus(GetAttendanceRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var result = UnitOfWork.GenericHandler<Attendance>().GetAsQuerable(x=>x.UserId == request.UserId).LastOrDefault()?.Status;
            return Task.FromResult(result);
        }
    }

    public interface IAttendanceService
    {
        Task<AddAttendanceRequest> CheckingInOut(AddAttendanceRequest request);
        Task<string> GetLastAttendanceStatus(GetAttendanceRequest request);
    }
}
