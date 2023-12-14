using Library.Application.Genres.Commands.CreateGenre;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreateUserCommandHandler(ILibraryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                HashPassword = request.HashPassword,
                //TODO: изменить реализацию по добавлению Role в CreateUserCommandHandler
                Role = request.Role,
                RefreshToken = request.RefreshToken,
                RefreshTokenExpiryTime = request.RefreshTokenExpiryTime,
                IsLocked = request.IsLocked,
                CreationDate = DateTime.Now,
                EditDate = null,
            };
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
