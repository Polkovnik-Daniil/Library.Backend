using MediatR;
using Library.Domain.Entities;
using Library.Application.Interfaces;
using Library.Application.Books.Commands.CreateBook;
using AutoMapper;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler
        : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(ILibraryDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<Guid> Handle(CreateAuthorCommand request,
            CancellationToken cancellationToken)    
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                CreationDate = DateTime.Now,
                EditDate = null,
                //TODO: изменить реализацию по добавлению Books в CreateAuthorCommandHandler
                Books = _mapper.Map<IList<Book>>(request.Books),
            };
            await _dbContext.Authors.AddAsync(author, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return author.Id;
        }
    }
}
