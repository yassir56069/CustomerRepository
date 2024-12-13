using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using CustomerRepo.Models;

namespace CustomerRepo.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        public DbSet<BCO_User> BCO_Users { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Device> Devices { get; set; } = null!;
        public DbSet<CustomerDevice> CustomerDevices { get; set; } = null!;
        public DbSet<Token> Tokens { get; set; } = null!;
        public DbSet<APKInfo> APKInfos { get; set; } = null!;

        // Fluent API configurations (optional for advanced setups)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BCO_Users
            modelBuilder.Entity<BCO_User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<BCO_User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            // Customers
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerKey)
                .IsUnique();

            // Devices
            modelBuilder.Entity<Device>()
                .HasKey(d => d.DeviceID);

            modelBuilder.Entity<Device>()
                .HasIndex(d => d.DeviceCode)
                .IsUnique();

            // CustomerDevices
            modelBuilder.Entity<CustomerDevice>()
                .HasKey(cd => new { cd.CustomerID, cd.DeviceID });

            modelBuilder.Entity<CustomerDevice>()
                .HasOne(cd => cd.Customer)
                .WithMany(c => c.CustomerDevices)
                .HasForeignKey(cd => cd.CustomerID);

            modelBuilder.Entity<CustomerDevice>()
                .HasOne(cd => cd.Device)
                .WithMany(d => d.CustomerDevices)
                .HasForeignKey(cd => cd.DeviceID);

            // Tokens
            modelBuilder.Entity<Token>()
                .HasKey(t => t.TokenID);

            modelBuilder.Entity<Token>()
                .HasIndex(t => t.TokenValue)
                .IsUnique();

            modelBuilder.Entity<Token>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Tokens)
                .HasForeignKey(t => t.CustomerKey)
                .HasPrincipalKey(c => c.CustomerKey);

            // APKInfo
            modelBuilder.Entity<APKInfo>()
                .HasKey(a => a.APKID);

            modelBuilder.Entity<APKInfo>()
                .HasOne(a => a.Device)
                .WithMany(d => d.APKInfos)
                .HasForeignKey(a => a.DeviceCode)
                .HasPrincipalKey(d => d.DeviceCode);

            modelBuilder.Entity<APKInfo>()
                .HasOne(a => a.Token)
                .WithMany()
                .HasForeignKey(a => a.TokenValue)
                .HasPrincipalKey(t => t.TokenValue);
        }
    }

}
     