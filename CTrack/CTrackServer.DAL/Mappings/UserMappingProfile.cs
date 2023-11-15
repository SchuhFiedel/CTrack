using AutoMapper;
using CTrack.Shared.Models.Entities;
using CTrack.Shared.Models.Models;

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
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                ;
           CreateMap<UserEntity, UserModel>()
                .ForMember(x => x.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                ;
        }
    }
}
