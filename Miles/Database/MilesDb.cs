using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using Miles.Dto;


namespace Miles.Database
{
    public class MilesDb : DbContext
    {

        public DbSet<Location> Locations { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<JourneyLog> JourneyLogs { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        // This method connects the context with the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "miles.sqlite" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasKey(l => l.Id);
            modelBuilder.Entity<Journey>().HasKey(l => l.Id);
            modelBuilder.Entity<JourneyLog>().HasKey(l => l.Id);
            modelBuilder.Entity<Profile>().HasKey(l => l.Id);



            modelBuilder.Entity<Journey>()
                .HasOne(l => l.StartLocation);
 
            
            modelBuilder.Entity<Journey>()
                .HasOne(l =>  l.EndLocation);

            modelBuilder.Entity<JourneyLog>()
                .HasOne(l => l.Journey);

            modelBuilder.Entity<Profile>()
                .HasOne(l => l.HomeLocation);

            modelBuilder.Entity<Profile>()
               .HasOne(l => l.WorkLocation);


            modelBuilder.Entity<Journey>()
                .HasOne(j => j.StartLocation)
                .WithMany(l => l.StartJourneys);

            modelBuilder.Entity<Journey>()
                .HasOne(j => j.EndLocation)
                .WithMany(l => l.EndJourneys);



        }

    }
}
