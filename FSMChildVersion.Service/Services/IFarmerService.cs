using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using FSMChildVersion.Common.RequestResponseModel.Feedback;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.DomainModels;

namespace FSMChildVersion.Service.Services
{
    public class FarmerService : ApiManager, IFarmerService
    {
        public Task<AddNewFarmerRequest> AddUpdateNewFarmerAsync(AddNewFarmerRequest userModel)
        {
            if (userModel is null)
                throw new ArgumentNullException(nameof(userModel));

            var list = new List<Farmer>()
            {
                new Farmer() { FarmerName = "Farmer 1", Area = "England 1", MobileNo = "123456 1", Acre="1" },
                new Farmer() { FarmerName = "Farmer 2", Area = "England 2", MobileNo = "123456 2", Acre="2" },
                new Farmer() { FarmerName = "Farmer 3", Area = "England 3", MobileNo = "123456 3", Acre="3" },
                new Farmer() { FarmerName = "Farmer 4", Area = "England 4", MobileNo = "123456 4", Acre="4" },
                new Farmer() { FarmerName = "Farmer 5", Area = "England 5", MobileNo = "123456 5", Acre="5" },
                new Farmer() { FarmerName = "Farmer 6", Area = "England 6", MobileNo = "123456 6", Acre="6" },
                new Farmer() { FarmerName = "Farmer 7", Area = "England 7", MobileNo = "123456 7", Acre="7" },
            };

            Farmer farmer = AutoMapper.Map<Farmer>(userModel);

            farmer = UnitOfWork.GenericHandler<Farmer>().Insert(farmer);
            UnitOfWork.GenericHandler<Farmer>().InsertRange(list);
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
