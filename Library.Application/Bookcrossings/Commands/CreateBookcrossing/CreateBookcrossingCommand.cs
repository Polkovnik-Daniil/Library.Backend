using MediatR;
using Library.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Library.Application.Authors.Commands.CreateAuthor;

namespace Library.Application.Bookcrossings.Commands.CreateBookcrossing
{
    public class CreateBookcrossingCommand : IRequest<Guid>
    {
        #region Fields
        #region Book
        public string Title { get; set; }
        public DateTime Realise { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfPage { get; set; }
        //TODO: вместо места жительства можно сделать свою структуру места жительства (архитектура БД)
        public string PublishHouse { get; set; }
        //TODO: нужен не просто лист авторов но авторов без Id т.е. другой объект!
        public IList<CreateAuthorCommand> Authors { get; set; }
        #endregion
        #region Reader
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PlaceOfResidence { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        #endregion
        #endregion
    }
}
