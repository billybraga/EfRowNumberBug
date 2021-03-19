using System;
using EfRowNumberBug.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfRowNumberBug
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<OptionalChild> OptionalChildren { get; set; } = null!;
        public DbSet<Parent> Parents { get; set; } = null!;

        public AppDbContext(string connectionString)
            : base(new DbContextOptions<AppDbContext>())
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(this.connectionString)
                .EnableSensitiveDataLogging()
                .LogTo(
                    message =>
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(message);
                        Console.ResetColor();
                    }
                );
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OptionalChild>()
                .Property(x => x.Version)
                .IsRowVersion()
                .HasConversion<byte[]>();
            
            modelBuilder
                .Entity<Parent>()
                .HasData(
                    new Parent()
                    {
                        Id = new("AF8451C3-61CB-4EDA-8282-92250D85EF03"),
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}