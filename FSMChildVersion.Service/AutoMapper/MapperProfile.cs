using AutoMapper;
using FSMChildVersion.Common.RequestResponseModel;
using FSMChildVersion.Common.RequestResponseModel.Attendance;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using FSMChildVersion.Repository.DomainModels;

namespace FSMChildVersion.Service.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<Attendance, AddAttendanceRequest>();
            CreateMap<AddAttendanceRequest, Attendance>();

            CreateMap<FieldDay, AddFieldDayRequest>();
            CreateMap<AddFieldDayRequest, FieldDay>();

            CreateMap<Farmer, AddNewFarmerRequest>();
            CreateMap<AddNewFarmerRequest, Farmer>();

            CreateMap<FarmerMeeting, AddFarmerMeetingRequest>();
            CreateMap<AddFarmerMeetingRequest, FarmerMeeting>();
        }
    }
}
