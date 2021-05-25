
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellenceServer.Entities;

namespace ExcellenceServer.DAL
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessPartner>()
            .HasOne<City>(a => a.City)
            .WithMany(u => u.BusinessPartners)
            .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<City>().HasData(new City[] {
                new City{CityId=1,Name="חיפה"},
                new City{CityId=2,Name="תל אביב"},
                new City{CityId=3,Name="נתניה"},
                new City{CityId=4,Name="רמת גן"},
                new City{CityId=5,Name="הרצליה"},
            });
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
    }
}
