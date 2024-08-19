using Microsoft.EntityFrameworkCore; // to use DbContext and so on.

namespace Northwind.EntityModels;

/*
  NOTA: Recordar que se uso un commando para crear las annotations
  ver Figure 10.6. page 536
*/
public class NorthwindDb : DbContext
{
  public DbSet<Category>? Categories { get; set; }
  public DbSet<Product>? Products { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    string databaseFile = "Northwind.db";
    string path = Path.Combine(
      Environment.CurrentDirectory, databaseFile);

    string connectionString = $"Data Source={path}";
    WriteLine($"Connection: {connectionString}");
    optionsBuilder.UseSqlite(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>()
      .Property(category => category.CategoryName)
      .IsRequired() // Not null
      .HasMaxLength(15);

    if (Database.ProviderName?.Contains("Sqlite") ?? false)
    {
      // to fix the lack of decimal support in SQLite
      modelBuilder.Entity<Product>()
        .Property(product => product.Cost)
        .HasConversion<double>();
    }
  }
}

// seguir desde Querying EF Core models
