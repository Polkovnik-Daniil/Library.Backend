using MediatR;

namespace Library.Application.Genres.Queries.GetGenreList
{
    public class GetGenreListQuery : IRequest<GenreListViewModel>
    {
        #region Fields
        //TODO: какие нужно взять поля для того чтобы получить список жанров
        //public Guid Id { get; set; }
        #endregion
    }
}
