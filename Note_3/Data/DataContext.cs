using Microsoft.EntityFrameworkCore;
using Note_3.Entities;

namespace Note_3.Data
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Entities.Notes> Notes { get; set; }
        public DbSet<Entities.User> User { get; set; }
        public DbSet<Entities.NoteList> NoteList { get; set; }
        public DbSet<Entities.UserSecurity> UserSecurity { get; set; }

    }
}