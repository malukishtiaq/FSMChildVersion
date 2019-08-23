using AutoMapper;
using FSMChildVersion.Core.Model;
using FSMChildVersion.Core.Model.Attendance;
using FSMChildVersion.Repository.DomainModels;

namespace FSMChildVersion.Core.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<Attendance, AddAttendanceRequest>();
            CreateMap<AddAttendanceRequest, Attendance>();
        }
    }
}
