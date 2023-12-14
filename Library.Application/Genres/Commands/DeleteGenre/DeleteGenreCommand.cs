using MediatR;

namespace Library.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommand : IRequest
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
