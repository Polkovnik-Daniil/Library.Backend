using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Role
    {
        #region Fields
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        #endregion
    }
}
