using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler :
        IRequest<DeleteGenreCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteGenreCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteGenreCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Genres.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Reader), request.Id);
            }
            _dbContext.Genres.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
