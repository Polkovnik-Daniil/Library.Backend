using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequest<UpdateUserCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdateUserCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(genre =>
                genre.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.HashPassword = request.HashPassword;
            //TODO: изменить реализацию по обновлению данных Books в UpdateGenreCommandHandler
            entity.Role = request.Role;
            entity.RefreshToken = request.RefreshToken;
            entity.RefreshTokenExpiryTime = request.RefreshTokenExpiryTime;
            entity.IsLocked = request.IsLocked;
            entity.EditDate = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
