using System;
using System.Reflection.Emit;
using kanban_backed.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace kanban_backed.Infra
{
	public class ApiContext : DbContext
	{
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring
        //       (DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>(c => { c.Property(p => p.Id).HasValueGenerator<OrderIdValueGenerator>(); });

        }
        public DbSet<Card> Cards { get; set; }
    }
}

