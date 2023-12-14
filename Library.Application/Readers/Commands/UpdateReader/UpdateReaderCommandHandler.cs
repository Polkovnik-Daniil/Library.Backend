using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Readers.Commands.UpdateReader
{
    public class UpdateReaderCommandHandler : IRequest<UpdateReaderCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdateReaderCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateReaderCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Readers.FirstOrDefaultAsync(reader =>
                reader.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Reader), request.Id);
            }
            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Patronymic = request.Patronymic;
            entity.PlaceOfResidence = request.PlaceOfResidence;
            entity.PhoneNumber = request.PhoneNumber;
            entity.EditDate = DateTime.Now;
            //TODO: изменить реализацию по обновлению данных Books в UpdateGenreCommandHandler
            entity.Books = request.Books;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
