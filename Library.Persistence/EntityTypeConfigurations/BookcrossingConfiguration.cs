using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BookcrossingConfiguration : IEntityTypeConfiguration<Bookcrossing>
    {
        public void Configure(EntityTypeBuilder<Bookcrossing> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}
