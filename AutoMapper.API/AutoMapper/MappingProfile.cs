using AutoMapper.API.DTO;
using AutoMapper.API.Entities;
using AutoMapper.API.HelperFunctions;

namespace AutoMapper.API.AutoMapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //Source -> Destination
            CreateMap<User, UserReadDto>()
                .ForMember(dest=>dest.FullName,
                opt=>opt.MapFrom(src=>src.FirstName+"----"+src.LastName))
                
                .ForMember(dest=>dest.Age,
                opt=>opt.MapFrom(src=>src.DateOfBirth.GetCurrentAge()));


            CreateMap<UserCreateDto,User>();
            
        }
    }
}
