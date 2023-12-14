using Library.Domain.Entities;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class AuthorLookupDto
    {
        #region Fields
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public IList<Book> Books {  get; set; } 
        #endregion
    }
}
