using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class User
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid Password")]
        [MaxLength(100)]
        public string HashPassword { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        #endregion
    }
}
