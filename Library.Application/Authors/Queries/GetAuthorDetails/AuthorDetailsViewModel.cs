using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain.Entities;

namespace Library.Application.Authors.Queries.GetAuthorDetails
{
    public class AuthorDetailsViewModel : IMapWith<Author>
    {
        #region Fields
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public IList<Book>? Books { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        #endregion
        public void Mapping(Profile profile)
        {
            //TODO: реализовать добавление Books в AuthorDetailsViewModel
            profile.CreateMap<Author, AuthorDetailsViewModel>()
                .ForMember(authorVM => authorVM.Id,
                    opt => opt.MapFrom(author => author.Id))
                .ForMember(authorVM => authorVM.Surname,
                    opt => opt.MapFrom(author => author.Surname))
                .ForMember(authorVM => authorVM.Patronymic,
                    opt => opt.MapFrom(author => author.Patronymic))
                .ForMember(authorVM => authorVM.Books,
                    opt => opt.MapFrom(author => author.Books))
                .ForMember(authorVM => authorVM.CreationDate,
                    opt => opt.MapFrom(author => author.CreationDate))
                .ForMember(authorVM => authorVM.EditDate,
                    opt => opt.MapFrom(author => author.EditDate));
        }
    }
}
