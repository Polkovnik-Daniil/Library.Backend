using Library.Domain.Entities;

namespace Library.Application.Readers.Commands.UpdateReader
{
    public class UpdateReaderCommand
    {
        #region Fields
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PlaceOfResidence { get; set; }
        public string PhoneNumber { get; set; }
        //TODO: необходимо реализовать Books в UpdateReaderCommand
        public IList<Book>? Books { get; set; }
        #endregion
    }
}
