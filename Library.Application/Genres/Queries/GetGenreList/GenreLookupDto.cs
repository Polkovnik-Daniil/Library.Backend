using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain.Entities;

namespace Library.Application.Genres.Queries.GetGenreList
{
    public class GenreLookupDto : IMapWith<Genre>
    {
        #region Fields
        //какие поля должны быть в таблице видны пользователю
        public Guid Id { get; set; }
        public string Name { get; set; }
        #endregion

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreLookupDto>()
                .ForMember(genreDto=>genreDto.Id,
                    opt=>opt.MapFrom(genre=>genre.Id))
                .ForMember(genreDto => genreDto.Name,
                    opt => opt.MapFrom(genre => genre.Name));
        }
    }
}
