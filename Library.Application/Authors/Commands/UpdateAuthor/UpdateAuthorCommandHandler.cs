using MediatR;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequest<UpdateAuthorCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdateAuthorCommandHandler(ILibraryDbContext dbContext) => 
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateAuthorCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Authors.FirstOrDefaultAsync(author =>
                author.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }
            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Patronymic = request.Patronymic;
            entity.EditDate = DateTime.Now;
            //TODO: изменить реализацию по обновлению данных Books в UpdateAuthorCommandHandler
            entity.Books = request.Books;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
