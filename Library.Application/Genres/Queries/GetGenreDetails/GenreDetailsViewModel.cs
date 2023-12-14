using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain.Entities;

namespace Library.Application.Genres.Queries.GetGenreDetails
{
    public class GenreDetailsViewModel : IMapWith<Genre>
    {
        #region Fields
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        //TODO: имеет смысл исспользовать CreateBookCommand
        public IList<Book>? Books { get; set; }
        #endregion
        public void Mapping(Profile profile)

        {
            //TODO: реализовать Books в GenreDetailsViewModel
            profile.CreateMap<Genre, GenreDetailsViewModel>()
                .ForMember(genreVM => genreVM.Name,
                    opt => opt.MapFrom(genre => genre.Name))
                .ForMember(genreVM => genreVM.CreationDate,
                    opt => opt.MapFrom(genre => genre.CreationDate))
                .ForMember(genreVM => genreVM.EditDate,
                    opt => opt.MapFrom(genre => genre.EditDate))
                .ForMember(genreVM => genreVM.Books,
                    opt => opt.MapFrom(genre => genre.Books))
                ;
        }
    }
}
