using Microsoft.EntityFrameworkCore;
using System;

namespace quotingDojo.Models
{
    public class quotingDojoContext : DbContext
    {
        public quotingDojoContext(DbContextOptions<quotingDojoContext> options) : base(options) {}

        public DbSet<Quote> quotes {get;set;}
        public DbSet<Author> authors {get;set;}
        public DbSet<Category> categories {get;set;}
        public DbSet<Meta> metas {get;set;}
        public DbSet<QuoteCat> quotecats {get;set;}
    }
}