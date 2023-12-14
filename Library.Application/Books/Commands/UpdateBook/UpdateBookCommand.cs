using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        #region Fields
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Realise { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfPage { get; set; }
        public string PublishHouse { get; set; }
        //TODO: возможно в последствии будет необходимо добавить Author и Genres в UpdateBookCommand
        #endregion
    }
}
