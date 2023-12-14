using MediatR;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<AuthorListViewModel>
    {
        #region Fields
        //public Guid Id { get; set; }
        #endregion
    }
}
