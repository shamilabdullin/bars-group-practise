using Teams.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Teams.Data
{
    public class TeamsDbContext : DbContext
    {
        public TeamsDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne<Sport>(j => j.Sport)
                .WithMany(s => s.Teams);
        }

    }
}
