using Library.Domain.Entities;

namespace Library.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        #region Fields
        public Guid Id { get; set; }
        public string Name { get; set; }
        //TODO: необходимо реализовать Books в UpdateGenreCommand
        public IList<Book>? Books { get; set; }
        #endregion
    }
}
