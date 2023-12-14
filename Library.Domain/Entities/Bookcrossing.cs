using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Bookcrossing
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid BookId { get; set; }   
        public Book Book { get; set; }

        public Guid ReaderId {  get; set; }
        public Reader Reader { get; set; }

        public DateTime? IssuedBook { get; set; }
        public DateTime? TimeOfDelivery { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        #endregion 
    }
}
