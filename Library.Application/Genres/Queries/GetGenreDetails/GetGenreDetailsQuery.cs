using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Genres.Queries.GetGenreDetails
{
    public class GetGenreDetailsQuery : IRequest<GenreDetailsViewModel>
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
