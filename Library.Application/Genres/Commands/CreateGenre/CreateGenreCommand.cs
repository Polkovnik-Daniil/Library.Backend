using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<Guid>
    {
        #region Fields
        public string Name { get; set; }
        //TODO: необходимо реализовать Books в CreateGenreCommand
        public IList<Book>? Books { get; set; }
        #endregion
    }
}
