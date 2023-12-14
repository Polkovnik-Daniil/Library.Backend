using MediatR;

namespace Library.Application.Authors.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQuery 
        : IRequest<AuthorDetailsViewModel>
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
