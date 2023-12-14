using Library.Domain.Entities;
using Library.Application.Common.Mappings;
using AutoMapper;

namespace Library.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        #region Fields
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        #endregion

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(dto => dto.Id,
                    opt=>opt.MapFrom(m=>m.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(m => m.Name))
                .ForMember(dto => dto.Email,
                    opt => opt.MapFrom(m => m.Email));
        }
    }
}
 