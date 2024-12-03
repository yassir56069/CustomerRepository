using Microsoft.EntityFrameworkCore;

namespace CustomerRepo.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        // DbSet properties map to your database tables
        public required DbSet<BCO_User> BCO_Users { get; set; }
        public required DbSet<Customer> Customers { get; set; }
        public required DbSet<Token> Tokens { get; set; }
        public required DbSet<APKInfo> APKInfos { get; set; }

        // Fluent API configurations (optional for advanced setups)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Unique constraint on UserName
            modelBuilder.Entity<BCO_User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            // Example: Foreign key relationship
            modelBuilder.Entity<APKInfo>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(a => a.CustomerID);
        }
    }

    // Define your entity classes to match database schema
    public class BCO_User
    {
        public int UserID { get; set; }
        public required string UserName { get; set; }
        public required string UserPass { get; set; }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public required string CustomerCode { get; set; }
        public required string CustomerKey { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerNote { get; set; }
    }

    public class Token
    {
        public int TokenID { get; set; }
        public required string TokenValue { get; set; }
        public DateTime TokenInitDate { get; set; }
        public DateTime? TokenExpiry { get; set; }
    }

    public class APKInfo
    {
        public int APKID { get; set; }
        public required string APKName { get; set; }
        public required string APKPath { get; set; }
        public required string ApkVerNumber { get; set; }
        public int CustomerID { get; set; }
    }
}
