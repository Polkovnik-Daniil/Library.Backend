using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain.Entities;

namespace Library.Application.Users.Queries.GetUserDetails
{
    /// <summary>
    /// Класс содержащий подробное описание запрашиваемой информации
    /// </summary>
    public class UserDetailsViewModel : IMapWith<User>
    {
        #region Fields
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        #endregion
        #region Mapping
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsViewModel>()
                .ForMember(Vm => Vm.Id,
                    opt => opt.MapFrom(m => m.Id))
                .ForMember(Vm => Vm.Name,
                    opt => opt.MapFrom(m => m.Name))
                .ForMember(Vm => Vm.Email,
                    opt => opt.MapFrom(m => m.Email))
                .ForMember(Vm => Vm.HashPassword,
                    opt => opt.MapFrom(m => m.HashPassword))
                .ForMember(Vm => Vm.RoleId,
                    opt => opt.MapFrom(m => m.RoleId))
                .ForMember(Vm => Vm.Role,
                    opt => opt.MapFrom(m => m.Role))
                .ForMember(Vm => Vm.RefreshToken,
                    opt => opt.MapFrom(m => m.RefreshToken))
                .ForMember(Vm => Vm.RefreshTokenExpiryTime,
                    opt => opt.MapFrom(m => m.RefreshTokenExpiryTime))
                .ForMember(Vm => Vm.IsLocked,
                    opt => opt.MapFrom(m => m.IsLocked))
                .ForMember(Vm => Vm.CreationDate,
                    opt => opt.MapFrom(m => m.CreationDate))
                .ForMember(Vm => Vm.EditDate,
                    opt => opt.MapFrom(m => m.EditDate));
        }
        #endregion
    }
}
