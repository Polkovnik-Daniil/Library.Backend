using MediatR;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;
using Library.Domain.Entities;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler :
        IRequest<DeleteAuthorCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteAuthorCommandHandler(ILibraryDbContext dbContext) => 
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteAuthorCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Authors.FindAsync(new object[] { request.Id }, cancellationToken);
            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }
            _dbContext.Authors.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
