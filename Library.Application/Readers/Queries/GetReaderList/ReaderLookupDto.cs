using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Users.Queries.GetUserList;
using Library.Domain.Entities;

namespace Library.Application.Readers.Queries.GetReaderList
{
    public class ReaderLookupDto : IMapWith<Reader>
    {
        #region Fields
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PlaceOfResidence { get; set; }
        #endregion
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reader, ReaderLookupDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(m => m.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(m => m.Name))
                .ForMember(dto => dto.Surname,
                    opt => opt.MapFrom(m => m.Surname))
                .ForMember(dto => dto.Patronymic,
                    opt => opt.MapFrom(m => m.Patronymic))
                .ForMember(dto => dto.PlaceOfResidence,
                    opt => opt.MapFrom(m => m.PlaceOfResidence));
        }
    }
}
