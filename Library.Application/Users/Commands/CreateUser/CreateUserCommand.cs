using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        #region Fields
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public Role? Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public bool IsLocked { get; set; }
        #endregion
    }
}
