using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer
{
    public class ParkBeheerContext : DbContext
    {
        public string connectionString;

        public DbSet<HuisEF> Huis { get; set; }
        public DbSet<HuurderEF> Huurder { get; set; }
        public DbSet<ParkEF> Park { get; set; }
        public DbSet<HuurcontractEF> Huurcontract { get; set; }


        public ParkBeheerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<ParkEF>().HasIndex(p => p.Huis);
            modelBuilder.Entity<ParkEF>()
                .HasMany(h => h.Huis).WithOne(p => p.parkEF);*/
                

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}