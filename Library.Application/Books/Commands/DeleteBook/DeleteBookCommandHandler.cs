using MediatR;
using Library.Domain.Entities;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler :
        IRequest<DeleteBookCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteBookCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Books.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            _dbContext.Books.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
