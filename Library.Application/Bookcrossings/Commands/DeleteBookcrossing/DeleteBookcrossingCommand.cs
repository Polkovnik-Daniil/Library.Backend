using MediatR;

namespace Library.Application.Bookcrossings.Commands.DeleteBookcrossing
{
    public class DeleteBookcrossingCommand : IRequest
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
