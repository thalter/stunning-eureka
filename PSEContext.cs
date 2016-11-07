
using ImageExtrator.Model;
using Microsoft.EntityFrameworkCore;

namespace ImageExtrator
{
    /// <summary>
    /// Database Context
    /// </summary>
    public class PseContext : DbContext
    {
        public PseContext(string connectionString) : base()
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }

        public DbSet<Media> Medias { get; set; }
    }
}