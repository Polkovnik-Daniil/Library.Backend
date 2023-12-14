using MediatR;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequest<UpdateBookCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdateBookCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateBookCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Books.FirstOrDefaultAsync(book =>
                book.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            entity.Title = request.Title;
            entity.Realise = request.Realise;
            entity.NumberOfPage = request.NumberOfPage;
            entity.NumberOfBooks = request.NumberOfBooks;
            entity.PublishHouse = request.PublishHouse;
            entity.EditDate = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
