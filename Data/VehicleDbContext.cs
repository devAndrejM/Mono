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
                    new VehicleMake { Id=6, Name = "Porsche AG", Abrv = "Porsche" },
                    new VehicleMake { Id = 7, Name = "Renault", Abrv = "Renault" },
                    new VehicleMake { Id = 8, Name = "Škoda Auto", Abrv = "Škoda" },
                    new VehicleMake { Id = 9, Name = "Audi AG", Abrv = "Audi" },
                    new VehicleMake { Id = 10, Name = "Volkswagen", Abrv = "VW" }

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
           new VehicleModel { Id = 15,Abrv = "M-Class", MakeId = 2, Name = "ML400" },
           new VehicleModel { Id = 16, Abrv = "i8", MakeId = 1, Name = "i8" },
           new VehicleModel { Id = 17, Abrv = "Series-3", MakeId = 1, Name = "316" },
           new VehicleModel { Id = 18, Abrv = "Focus", MakeId = 3, Name = "Focus" },
           new VehicleModel { Id = 19, Abrv = "Ka", MakeId = 3, Name = "Ka" },
           new VehicleModel { Id = 20, Abrv = "ix35", MakeId = 4, Name = "ix35" },
           new VehicleModel { Id = 21, Abrv = "Kona", MakeId = 4, Name = "Kona" },
           new VehicleModel { Id = 22, Abrv = "3", MakeId = 5, Name = "323" },
           new VehicleModel { Id = 23, Abrv = "6", MakeId = 5, Name = "6" },
           new VehicleModel { Id = 24, Abrv = "Cayenne", MakeId = 6, Name = "Cayenne" },
           new VehicleModel { Id = 25, Abrv = "911", MakeId = 6, Name = "911" },
           new VehicleModel { Id = 26, Abrv = "Captur", MakeId = 7, Name = "Captur" },
           new VehicleModel { Id = 27, Abrv = "Scenic", MakeId = 7, Name = "Scenic" },
           new VehicleModel { Id = 28, Abrv = "Superb", MakeId = 8, Name = "Superb" },
           new VehicleModel { Id = 29, Abrv = "Octavia", MakeId = 8, Name = "Octavia" },
           new VehicleModel { Id = 30, Abrv = "A3", MakeId = 9, Name = "A3" },
           new VehicleModel { Id = 31, Abrv = "A4", MakeId = 9, Name = "A4" },
           new VehicleModel { Id = 32, Abrv = "Passsat", MakeId = 10, Name = "Passat" },
           new VehicleModel { Id = 33, Abrv = "Arteon", MakeId = 10, Name = "Arteon" }


           );

        }
    }
}
