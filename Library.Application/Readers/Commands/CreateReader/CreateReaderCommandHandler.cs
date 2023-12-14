using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Readers.Commands.CreateReader
{
    public class CreateReaderCommandHandler :
        IRequestHandler<CreateReaderCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreateReaderCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateReaderCommand request,
            CancellationToken cancellationToken)
        {
            var reader = new Reader
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                PlaceOfResidence = request.PlaceOfResidence,
                PhoneNumber = request.PhoneNumber,
                CreationDate = DateTime.Now,
                EditDate = null,
                //TODO: изменить реализацию по добавлению Books в CreateReaderCommandHandler
                Books = request.Books,
            };
            await _dbContext.Readers.AddAsync(reader, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return reader.Id;
        }
    }
}
