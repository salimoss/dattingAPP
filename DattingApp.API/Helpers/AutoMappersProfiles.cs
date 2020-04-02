using System.Linq;
using AutoMapper;
using DattingApp.API.Dtos;
using DattingApp.API.Model;

namespace DattingApp.API.Helpers
{
    public class AutoMappersProfiles: Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<User, UserForListDto>().ForMember(dest => dest.PhotoUrl,opt 
            =>opt.MapFrom(src => src.Photos.FirstOrDefault(p =>p.IsMain).Url))
            .ForMember(dest => dest.Age,opt 
            =>opt.MapFrom(src => src.DateOfBirth.CalculateAge()))
            ;
            CreateMap<User, UserForDetaileDto>().ForMember(dest => dest.PhotoUrl,opt 
            =>opt.MapFrom(src => src.Photos.FirstOrDefault(p =>p.IsMain).Url)).ForMember(dest =>
             dest.Age,opt 
            =>opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
             CreateMap<Photo, PhotosForDetaileDto>();
        }
    }
}