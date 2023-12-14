using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        #region Fields
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        //TODO: необходимо реализовать Books в UpdateAuthorCommand
        public IList<Book>? Books { get; set; }
        #endregion
    }
}
