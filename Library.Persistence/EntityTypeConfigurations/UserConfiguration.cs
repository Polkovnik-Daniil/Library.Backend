using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
 
namespace Library.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //TODO: указать связи между Entity
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>x.Id).IsUnique();
            builder.HasIndex(x=>x.Email).IsUnique();
        }
    } 
}
