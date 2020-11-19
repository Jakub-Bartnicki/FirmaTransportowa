﻿using FirmaTransportowa.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FirmaTransportowa.DAL
{
    public class TransportContext : DbContext
    {
        public TransportContext() : base("TransportContext") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PersonDetails> PersonDetails { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Semitrailer> Semitrailers { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Employee>()
                .Property(p => p.Salary)
                .HasPrecision(10, 2);
            modelBuilder.Entity<Order>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(10, 2);
            modelBuilder.Entity<Product>()
                .Property(p => p.BuyPrice)
                .HasPrecision(10, 2);
            modelBuilder.Entity<Product>()
                .Property(p => p.Weight)
                .HasPrecision(10, 3);
            modelBuilder.Entity<Route>()
                .Property(p => p.Distance)
                .HasPrecision(9, 3);
            modelBuilder.Entity<Semitrailer>()
                .Property(p => p.Capacity)
                .HasPrecision(10, 3);
        }
    }
}