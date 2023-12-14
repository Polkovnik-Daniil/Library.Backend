using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Genre
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public IList<Book>? Books { get; set; }
        #endregion
    }
}
