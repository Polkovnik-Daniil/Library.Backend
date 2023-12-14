using MediatR;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
