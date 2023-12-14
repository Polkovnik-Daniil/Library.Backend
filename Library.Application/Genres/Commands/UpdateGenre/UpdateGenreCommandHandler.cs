using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequest<UpdateGenreCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdateGenreCommandHandler(ILibraryDbContext dbContext) => 
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateGenreCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Genres.FirstOrDefaultAsync(genre =>
                genre.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }
            entity.Name = request.Name;
            entity.EditDate = DateTime.Now;
            //TODO: изменить реализацию по обновлению данных Books в UpdateGenreCommandHandler
            entity.Books = request.Books;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
