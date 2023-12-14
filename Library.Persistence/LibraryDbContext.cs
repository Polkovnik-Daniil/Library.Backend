using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        #region Fields
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Bookcrossing> Bookcrossings { get; set; }
        #endregion
        #region Contructor
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
            : base(options) { }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new ReaderConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BookcrossingConfiguration());
            //TODO: указать отношения между сущностями
            
            base.OnModelCreating(builder);
        }
    }
}
