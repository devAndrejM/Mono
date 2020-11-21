using Coreapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext()
        {
        }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
            

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VehicleAppDB;Trusted_Connection=True;MultipleActiveResultSets=true",
                    builder => builder.EnableRetryOnFailure());
            }
        }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>().ToTable("VehicleMake");
            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModel");


            modelBuilder.Entity<VehicleMake>().
                HasData(
                new VehicleMake { Id = 1, Name = "Bayerische Motoren Werke AG", Abrv = "BMW" },
                    new VehicleMake { Id = 2, Name = "Mercedes-Benz", Abrv = "Mercedes" },
                    new VehicleMake { Id=3, Name = "Ford Motor Company", Abrv = "Ford" },
                    new VehicleMake { Id=4, Name = "The Hyundai Motor Company", Abrv = "Hyundai" },
                    new VehicleMake { Id=5, Name = "Mazda Motor Corporation", Abrv = "Mazda" },
                    new VehicleMake { Id=6, Name = "Porsche AG", Abrv = "Porsche" }

                );

            modelBuilder.Entity<VehicleModel>().
           HasData(
               new VehicleModel { Id = 7,Abrv = "A-class", MakeId = 2, Name = "A180" },
           new VehicleModel { Id = 8, Abrv = "A-class", MakeId = 2, Name = "A160" },
           new VehicleModel { Id = 9,Abrv = "C-class", MakeId = 2, Name = "C43" },
           new VehicleModel { Id = 10,Abrv = "C-class", MakeId = 2, Name = "C300" },
           new VehicleModel { Id = 11,Abrv = "GLE", MakeId = 2, Name = "GLE580" },
           new VehicleModel { Id = 12,Abrv = "GLE", MakeId = 2, Name = "GLE350" },
           new VehicleModel { Id = 13,Abrv = "GLE", MakeId = 2, Name = "GLE400" },
           new VehicleModel { Id = 14,Abrv = "M-Class", MakeId = 2, Name = "ML350" },
           new VehicleModel { Id = 15,Abrv = "M-Class", MakeId = 2, Name = "ML400" }

           );

        }
    }
}
