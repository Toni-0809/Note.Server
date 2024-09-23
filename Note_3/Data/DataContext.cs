using Microsoft.EntityFrameworkCore;
using Note_3.Entities;

namespace Note_3.Data
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Notes> Notes { get; set; }
        public DbSet<NoteList> NoteList { get; set; }
        public DbSet<UserSecurity> UserSecurity { get; set; }

    }
}