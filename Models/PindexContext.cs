using Microsoft.EntityFrameworkCore;
using PindexBackend.Models;

namespace PindexBackend.Models {
    public class PindexContext : DbContext{

        public readonly IConfiguration Configuration;
        public PindexContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseNpgsql(Configuration.GetConnectionString("PindexDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Item>()
                .Property(f => f.ItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Canorg>()
                .Property(f => f.CanorgId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Office>()
                .Property(f => f.OfficeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Location>()
                .Property(f => f.LocationId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Issue>()
                .Property(f => f.IssueId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Categorization>()
                .Property(f => f.CategorizationId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Canorg>()
                .HasOne(o => o.Item)
                .WithMany(i => i.Canorgs)
                .HasForeignKey(o => o.ItemId);

            modelBuilder.Entity<Office>()
                .HasOne(o => o.Item)
                .WithMany(i => i.Offices)
                .HasForeignKey(o => o.ItemId);

            modelBuilder.Entity<Location>()
                .HasOne(o => o.Item)
                .WithMany(i => i.Locations)
                .HasForeignKey(o => o.ItemId);

            modelBuilder.Entity<Party>()
                .HasOne(o => o.Item)
                .WithMany(i => i.Parties)
                .HasForeignKey(o => o.ItemId);

            modelBuilder.Entity<Item>()
                .HasMany(o => o.Categorizations)
                .WithMany(i => i.Items)
                .UsingEntity(o => o.ToTable("ItemCategorizations"));

            modelBuilder.Entity<Item>()
                .HasMany(o => o.Issues)
                .WithMany(i => i.Items)
                .UsingEntity(o => o.ToTable("ItemIssues"));



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Canorg> Canorgs { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Categorization> Categorization { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
