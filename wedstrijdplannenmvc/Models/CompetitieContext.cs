using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wedstrijdplannenmvc.Models
{
    public class CompetitieContext : DbContext
    {
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }
        public DbSet<TeamWedstrijd> TeamWedstrijd { get; set; }

      


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=CompetitieData;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamWedstrijd>().HasKey(sc => new { sc.TeamId, sc.WedstrijdId });
            //modelBuilder.Seed();
        }

       
    }
}
