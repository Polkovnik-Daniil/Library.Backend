using Library.Domain.Entities;

namespace Library.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        #region Fields
        public Guid Id { get; set; }
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
