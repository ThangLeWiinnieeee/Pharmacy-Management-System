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

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Invoice> Invoices => Set<Invoice>();

    public DbSet<InvoiceDetail> InvoiceDetails => Set<InvoiceDetail>();

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
        ConfigureCustomer(modelBuilder);
        ConfigureInvoice(modelBuilder);
        ConfigureInvoiceDetail(modelBuilder);
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

    private static void ConfigureCustomer(ModelBuilder modelBuilder)
    {
        var customer = modelBuilder.Entity<Customer>();

        customer.ToTable("Customers");
        customer.HasKey(c => c.Id);

        customer.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        customer.Property(c => c.Phone)
            .HasMaxLength(20);

        customer.Property(c => c.Address)
            .HasMaxLength(250);

        customer.Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
    }

    private static void ConfigureInvoice(ModelBuilder modelBuilder)
    {
        var invoice = modelBuilder.Entity<Invoice>();

        invoice.ToTable("Invoices");
        invoice.HasKey(i => i.Id);
        invoice.HasIndex(i => i.InvoiceCode).IsUnique();

        invoice.Property(i => i.InvoiceCode)
            .HasMaxLength(30)
            .IsRequired();

        invoice.Property(i => i.CustomerName)
            .HasMaxLength(100);

        invoice.Property(i => i.CustomerPhone)
            .HasMaxLength(20);

        invoice.Property(i => i.TotalAmount)
            .HasPrecision(18, 2)
            .HasDefaultValue(0m);

        invoice.Property(i => i.Discount)
            .HasPrecision(18, 2)
            .HasDefaultValue(0m);

        invoice.Property(i => i.FinalAmount)
            .HasPrecision(18, 2)
            .HasDefaultValue(0m);

        invoice.Property(i => i.Note)
            .HasMaxLength(500);

        invoice.Property(i => i.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Completed")
            .IsRequired();

        invoice.Property(i => i.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        invoice.HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        invoice.HasOne(i => i.CreatedByUser)
            .WithMany()
            .HasForeignKey(i => i.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureInvoiceDetail(ModelBuilder modelBuilder)
    {
        var detail = modelBuilder.Entity<InvoiceDetail>();

        detail.ToTable("InvoiceDetails");
        detail.HasKey(d => d.Id);

        detail.Property(d => d.MedicineCode)
            .HasMaxLength(50)
            .IsRequired();

        detail.Property(d => d.MedicineName)
            .HasMaxLength(150)
            .IsRequired();

        detail.Property(d => d.Unit)
            .HasMaxLength(30)
            .IsRequired();

        detail.Property(d => d.UnitPrice)
            .HasPrecision(18, 2);

        detail.Property(d => d.LineTotal)
            .HasPrecision(18, 2);

        detail.HasOne(d => d.Invoice)
            .WithMany(i => i.Details)
            .HasForeignKey(d => d.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        detail.HasOne(d => d.Medicine)
            .WithMany()
            .HasForeignKey(d => d.MedicineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
