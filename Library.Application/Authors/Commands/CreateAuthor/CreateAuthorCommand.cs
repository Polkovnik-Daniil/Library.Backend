using MediatR;
using Library.Domain.Entities;
using Library.Application.Books.Commands.CreateBook;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        #region Fields
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        //TODO: продумать Books в CreateAuthorCommand
        public IList<CreateBookCommand>? Books { get; set; }
        #endregion
    }
}
