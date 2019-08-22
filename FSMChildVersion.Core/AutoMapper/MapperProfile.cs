using AutoMapper;
using FSMChildVersion.Core.Model;
using FSMChildVersion.Repository.DomainModels;

namespace FSMChildVersion.Core.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MakeUpModel, MakeUp>();
            CreateMap<MakeUp, MakeUpModel>();
        }
    }
}
