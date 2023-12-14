using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Bookcrossings.Commands.DeleteBookcrossing
{
    public class DeleteBookcrossingCommandHandler :
        IRequest<DeleteBookcrossingCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteBookcrossingCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteBookcrossingCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Bookcrossings.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Bookcrossing), request.Id);
            }
            _dbContext.Bookcrossings.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
