using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Author
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public IList<Book>? Books { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        #endregion
    }
}
