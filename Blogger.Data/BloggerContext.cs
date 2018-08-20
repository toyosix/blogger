using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Blogger.Data
{
    public class BloggerContext:DbContext
    {

        public BloggerContext(DbContextOptions<BloggerContext> options):base(options)
        {

        }

        public DbSet<Blogger.Domain.User> Users { get; set; }
        public DbSet<Blogger.Domain.Blog> Blogs { get; set; }
        public DbSet<Blogger.Domain.Post> Posts { get; set; }
        public DbSet<Blogger.Domain.Comment> Comments { get; set; }
        public DbSet<Blogger.Domain.Tag> Tags { get; set; }
        public DbSet<Blogger.Domain.PostTag> PostTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>().HasKey(s => new { s.post_id, s.tag_id });
            modelBuilder.Entity<User>().HasOne(e => e.blog).WithOne(e => e.user).HasForeignKey<Blog>(b=>b.user_id);
            modelBuilder.Entity<Blog>().HasMany(e => e.posts).WithOne(e=>e.blog).HasForeignKey(p=>p.blog_id);
            modelBuilder.Entity<Post>().HasMany(e => e.comments).WithOne(e => e.post).HasForeignKey(c => c.post_id);

            // SEEDING : adding records to DB at creation time. [User Table]
            modelBuilder.Entity<User>().HasData(new { Name = "Toyosi Oyesola" }, new { Name = "John Doe" });

            /**
             SHADOW PROPERTIES
             */
            modelBuilder.Entity<User>().Property<DateTime>("created_at");
            modelBuilder.Entity<User>().Property<DateTime>("updated_at");

            modelBuilder.Entity<Blog>().Property<DateTime>("created_at");
            modelBuilder.Entity<Blog>().Property<DateTime>("updated_at");

            modelBuilder.Entity<Post>().Property<DateTime>("created_at");
            modelBuilder.Entity<Post>().Property<DateTime>("updated_at");

            modelBuilder.Entity<Comment>().Property<DateTime>("created_at");
            modelBuilder.Entity<Comment>().Property<DateTime>("updated_at");

            modelBuilder.Entity<Tag>().Property<DateTime>("created_at");
            modelBuilder.Entity<Tag>().Property<DateTime>("updated_at");

            modelBuilder.Entity<PostTag>().Property<DateTime>("created_at");
            modelBuilder.Entity<PostTag>().Property<DateTime>("updated_at");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();

            var timestamp = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("created_at").CurrentValue = timestamp; // adding shadow properties
                    entry.Property("updated_at").CurrentValue = timestamp; // adding shadow properties
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("updated_at").CurrentValue = timestamp; // adding shadow properties
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();

            var timestamp = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("created_at").CurrentValue = timestamp; // adding shadow properties
                    entry.Property("updated_at").CurrentValue = timestamp; // adding shadow properties
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("updated_at").CurrentValue = timestamp; // adding shadow properties
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var timestamp = DateTime.Now;

            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("created_at").CurrentValue = timestamp; // adding shadow properties
                    entry.Property("updated_at").CurrentValue = timestamp; // adding shadow properties
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("updated_at").CurrentValue = timestamp; // adding shadow properties
                }
            }

            return base.SaveChanges();
        }

    }
}
