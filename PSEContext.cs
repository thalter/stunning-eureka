
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary key 
            modelBuilder.Entity<MediaTag>()
            .HasKey(mt => new { mt.media_id, mt.tag_id });

            // Composite primary key 
            modelBuilder.Entity<MediaMetadata>()
            .HasKey(mt => new { mt.media_id, mt.metadata_id });
        }

        public DbSet<Media> Medias { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<MediaTag> MediaTags { get; set; }

        public DbSet<MetadataInteger> MetadataIntegers { get; set; }

        public DbSet<MetadataString> MetadataStrings { get; set; }

        public DbSet<MetadataDateTime> MetadataDateTime { get; set; }

        public DbSet<MetadataDecimal> MetadataDecimals { get; set; }

        public DbSet<MetadataDescription> MetadataDescriptions { get; set; }

    }
}