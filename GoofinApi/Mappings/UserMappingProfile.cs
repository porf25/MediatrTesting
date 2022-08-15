using AutoMapper;
using GoofinApi.Dtos;
using GoofinApi.Models;

namespace GoofinApi.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}
