using CompanySolution.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Infra.Data.Context
{
    public class CompanySolutionContext : DbContext
    {
        public CompanySolutionContext(DbContextOptions<CompanySolutionContext> options) : base(options) { this.Database.EnsureCreated(); }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasKey(key => key.Id);
            modelBuilder.Entity<Company>().HasKey(key => key.Id);
            modelBuilder.Entity<Supplier>().HasKey(key => key.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
