using System.Configuration;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Entities;

namespace PharmacyManagementSystem.DAL;

public class AppDbContext : DbContext
{
    private const string ConnectionStringName = "PharmacyDb";
    private const string DefaultConnectionString =
        @"Data Source=DESKTOP-S0CA04B;Initial Catalog=PharmacyManagementSystemDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Medicine> Medicines => Set<Medicine>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        var connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = DefaultConnectionString;
        }

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureUser(modelBuilder);
        ConfigureMedicine(modelBuilder);
    }

    private static void ConfigureUser(ModelBuilder modelBuilder)
    {
        var user = modelBuilder.Entity<User>();

        user.ToTable("Users");
        user.HasKey(item => item.Id);
        user.HasIndex(item => item.Username).IsUnique();

        user.Property(item => item.Username)
            .HasMaxLength(50)
            .IsRequired();

        user.Property(item => item.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();

        user.Property(item => item.FullName)
            .HasMaxLength(100)
            .IsRequired();

        user.Property(item => item.Email)
            .HasMaxLength(100)
            .IsRequired();

        user.Property(item => item.Phone)
            .HasMaxLength(20)
            .IsRequired();

        user.Property(item => item.Role)
            .HasMaxLength(20)
            .HasDefaultValue("Staff")
            .IsRequired();

        user.Property(item => item.IsActive)
            .HasDefaultValue(true);

        user.Property(item => item.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        user.Property(item => item.UpdatedAt);
    }

    private static void ConfigureMedicine(ModelBuilder modelBuilder)
    {
        var medicine = modelBuilder.Entity<Medicine>();

        medicine.ToTable("Medicines");
        medicine.HasKey(item => item.Id);
        medicine.HasIndex(item => item.Code).IsUnique();

        medicine.Property(item => item.Code)
            .HasMaxLength(50)
            .IsRequired();

        medicine.Property(item => item.Name)
            .HasMaxLength(150)
            .IsRequired();

        medicine.Property(item => item.Unit)
            .HasMaxLength(30)
            .IsRequired();

        medicine.Property(item => item.Manufacturer)
            .HasMaxLength(150);

        medicine.Property(item => item.ImportPrice)
            .HasPrecision(18, 2);

        medicine.Property(item => item.SellPrice)
            .HasPrecision(18, 2);

        medicine.Property(item => item.Quantity)
            .HasDefaultValue(0);

        medicine.Property(item => item.Description)
            .HasMaxLength(500);

        medicine.Property(item => item.IsActive)
            .HasDefaultValue(true);

        medicine.Property(item => item.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
    }
}
