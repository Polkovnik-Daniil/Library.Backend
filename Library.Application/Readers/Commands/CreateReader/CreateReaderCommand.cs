using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Readers.Commands.CreateReader
{
    public class CreateReaderCommand : IRequest<Guid>
    {
        #region Fields
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PlaceOfResidence { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Book>? Books { get; set; }
        #endregion
    }
}
