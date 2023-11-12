using AutoMapper;
using CTrack.Shared.Models;
using CTrackServer.DAL.Entities;

namespace CTrackServer.DAL.Mappings
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserModel, UserEntity>()
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn))
                .ReverseMap()
                .ForMember(x => x.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn))
                ;
        }
    }
}
