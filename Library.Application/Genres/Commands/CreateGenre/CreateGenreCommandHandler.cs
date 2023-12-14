using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;


namespace Library.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler 
        : IRequestHandler<CreateGenreCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreateGenreCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateGenreCommand request,
            CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreationDate = DateTime.Now,
                EditDate = null,
                //TODO: изменить реализацию по добавлению Books в CreateGenreCommandHandler
                Books = request.Books,
            };
            await _dbContext.Genres.AddAsync(genre, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return genre.Id;
        }
    }
}
