using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Book
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public DateTime Realise { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfPage { get; set; } 
        //TODO: вместо места жительства можно сделать свою структуру места жительства (архитектура БД)
        public string PublishHouse { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public IList<Author>? Authors {  get; set; }
        public IList<Genre>? Genres { get; set; }
        public IList<Reader>? Readers { get; set; }
        #endregion
    }
}
