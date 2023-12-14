using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Users.Queries.GetUserDetails;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Queries.GetBookDetails
{
    public class BookDetailsViewModel : IMapWith<Book>
    {
        #region Fields
        public string Title { get; set; }
        public DateTime Realise { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfPage { get; set; }
        public string PublishHouse { get; set; }
        public IList<Author>? Authors { get; set; }
        public IList<Genre>? Genres { get; set; }
        public IList<Reader>? Readers { get; set; }
        #endregion
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsViewModel>()
                .ForMember(Vm => Vm.Title,
                    opt => opt.MapFrom(m=>m.Title))
                .ForMember(Vm => Vm.Realise,
                    opt => opt.MapFrom(m => m.Realise))
                .ForMember(Vm => Vm.NumberOfBooks,
                    opt => opt.MapFrom(m => m.NumberOfBooks))
                .ForMember(Vm => Vm.NumberOfPage,
                    opt => opt.MapFrom(m => m.NumberOfPage))
                .ForMember(Vm => Vm.PublishHouse,
                    opt => opt.MapFrom(m => m.PublishHouse))
                //TODO: использовать вместо
                //Authors - CreateAuthorCommand,
                //Genres - CreateGenreCommand,
                //Readers - CreateReaderCommand
                .ForMember(Vm => Vm.Authors,
                    opt => opt.MapFrom(m => m.Authors))
                .ForMember(Vm => Vm.Genres,
                    opt => opt.MapFrom(m => m.Genres))
                .ForMember(Vm => Vm.Readers,
                    opt => opt.MapFrom(m => m.Readers));
        }
    }
}
