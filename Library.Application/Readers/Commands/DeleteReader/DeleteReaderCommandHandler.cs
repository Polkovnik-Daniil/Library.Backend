using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Readers.Commands.DeleteReader
{
    public class DeleteReaderCommandHandler :
        IRequest<DeleteReaderCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteReaderCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteReaderCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Readers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Reader), request.Id);
            }
            _dbContext.Readers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
