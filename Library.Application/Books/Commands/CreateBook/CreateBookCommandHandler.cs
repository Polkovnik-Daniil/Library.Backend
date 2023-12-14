using MediatR;
using Library.Domain.Entities;
using Library.Application.Interfaces;

namespace Library.Application.Books.Commands.CreateBook
{ 
    public class CreateBookCommandHandler 
        : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreateBookCommandHandler(ILibraryDbContext dbContext) => 
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateBookCommand request, 
            CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Realise = request.Realise,
                NumberOfBooks = request.NumberOfBooks,
                NumberOfPage = request.NumberOfPage,
                PublishHouse = request.PublishHouse,
                CreationDate = DateTime.Now,
                EditDate = null,
                //TODO: сделать Author и Genres и Readers
                Authors = request.Authors,
                Genres = request.Genres,
                Readers = request.Readers,
            };
            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
