using Library.Application.Users.Queries.GetUserDetails;
using MediatR;

namespace Library.Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQuery : IRequest<BookDetailsViewModel>
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
