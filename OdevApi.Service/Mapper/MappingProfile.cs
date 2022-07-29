using AutoMapper;
using OdevApi.Data.Model;
using OdevApi.Dto;

namespace OdevApi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
        }

    }
}
