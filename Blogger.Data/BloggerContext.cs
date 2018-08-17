using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Domain;

namespace Blogger.Data
{
    public class BloggerContext:DbContext
    {

        public BloggerContext()
        {

        }

        public DbSet<Blogger.Domain.Blogger> Bloggers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
