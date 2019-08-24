using System;
using System.Threading.Tasks;
using FSMChildVersion.Common.Model.Farmer;
using FSMChildVersion.Common.Model.Feedback;
using FSMChildVersion.Core.Model.Farmer;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.DomainModels;

namespace FSMChildVersion.Core.Services
{
    public class FarmerService : ApiManager, IFarmerService
    {
        public Task<AddNewFarmerRequest> AddUpdateNewFarmerAsync(AddNewFarmerRequest userModel)
        {
            if (userModel is null)
                throw new ArgumentNullException(nameof(userModel));

            Farmer farmer = AutoMapper.Map<Farmer>(userModel);

            farmer = UnitOfWork.GenericHandler<Farmer>().Insert(farmer);
            UnitOfWork.Save();

            return Task.FromResult(AutoMapper.Map<AddNewFarmerRequest>(farmer));
        }
        public Task<AddFarmerVisitRequest> AddUpdateFarmerVisitAsync(AddFarmerVisitRequest userModel)
        {
            if (userModel is null)
                throw new ArgumentNullException(nameof(userModel));

            FarmerVisit farmer = AutoMapper.Map<FarmerVisit>(userModel);

            farmer = UnitOfWork.GenericHandler<FarmerVisit>().Insert(farmer);
            UnitOfWork.Save();

            return Task.FromResult(AutoMapper.Map<AddFarmerVisitRequest>(farmer));
        }

        public Task<AddFarmerMeetingRequest> AddFarmerMeetingVisitAsync(AddFarmerMeetingRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            FarmerMeeting farmer = AutoMapper.Map<FarmerMeeting>(request);

            farmer = UnitOfWork.GenericHandler<FarmerMeeting>().Insert(farmer);
            UnitOfWork.Save();

            return Task.FromResult(AutoMapper.Map<AddFarmerMeetingRequest>(farmer));
        }
        public Task<AddFeedbackRequest> AddUpdateFeedbackAsync(AddFeedbackRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            Feedback feddback = AutoMapper.Map<Feedback>(request);

            feddback = UnitOfWork.GenericHandler<Feedback>().Insert(feddback);
            UnitOfWork.Save();

            return Task.FromResult(AutoMapper.Map<AddFeedbackRequest>(feddback));
        }

        public Task<AddFieldDayRequest> AddUpdateFieldDayAsync(AddFieldDayRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            FieldDay feddback = AutoMapper.Map<FieldDay>(request);

            feddback = UnitOfWork.GenericHandler<FieldDay>().Insert(feddback);
            UnitOfWork.Save();

            return Task.FromResult(AutoMapper.Map<AddFieldDayRequest>(feddback));
        }
    }
    public interface IFarmerService
    {
        Task<AddNewFarmerRequest> AddUpdateNewFarmerAsync(AddNewFarmerRequest userModel);
        Task<AddFarmerVisitRequest> AddUpdateFarmerVisitAsync(AddFarmerVisitRequest request);
        Task<AddFieldDayRequest> AddUpdateFieldDayAsync(AddFieldDayRequest request);
        Task<AddFarmerMeetingRequest> AddFarmerMeetingVisitAsync(AddFarmerMeetingRequest request);
        Task<AddFeedbackRequest> AddUpdateFeedbackAsync(AddFeedbackRequest request);
    }
}
