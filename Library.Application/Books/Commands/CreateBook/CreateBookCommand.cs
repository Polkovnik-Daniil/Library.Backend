using MediatR;
using Library.Domain.Entities;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Genres.Commands.CreateGenre;
using Library.Application.Readers.Commands.CreateReader;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        #region Fields
        public string Title { get; set; }
        public DateTime Realise { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfPage { get; set; }
        public string PublishHouse { get; set; }
        //TODO: реализовать Books в CreateBookCommand
        public IList<CreateAuthorCommand>? Authors { get; set; }
        public IList<CreateGenreCommand>? Genres { get; set; }
        public IList<CreateReaderCommand>? Readers { get; set; }
        #endregion
    }
}
