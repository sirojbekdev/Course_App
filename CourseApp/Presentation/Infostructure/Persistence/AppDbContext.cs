using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Entities;
using Presentation.Infostructure.Identity;

namespace Presentation.Infostructure.Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Collection> Collections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<CollectionCustomField> CollectionCustomFields { get; set; }
        public DbSet<CustomFieldMapper> CustomFieldMappers { get; set; }
        public DbSet<ItemCustomField> ItemCustomFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Items and tags many-to-many relationship
            modelBuilder.Entity<ItemTag>()
                .HasKey(cs => new { cs.ItemId, cs.TagId });
            modelBuilder.Entity<ItemTag>()
                .HasOne(cs => cs.Item)
                .WithMany(c => c.ItemTags)
                .HasForeignKey(bc => bc.ItemId);
            modelBuilder.Entity<ItemTag>()
                .HasOne(cs => cs.Tag)
                .WithMany(s => s.ItemTags)
                .HasForeignKey(cs => cs.TagId);
            modelBuilder.Entity<Item>()
                .HasMany<ItemCustomField>(e => e.ItemCustomFields)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Collection>()
                .HasOne(c => c.Topic)
                .WithMany(t => t.Collections)
                .HasForeignKey(c => c.TopicTitle)
                .HasPrincipalKey(s => s.Title);

            base.OnModelCreating(modelBuilder);
        }
    }
}
