using Microsoft.EntityFrameworkCore; // to use DbContext and so on.
using Microsoft.EntityFrameworkCore.Diagnostics; // to use relationaleventid

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

    optionsBuilder.LogTo(WriteLine,// this is the console method
      new[] { RelationalEventId.CommandExecuting })
    #if DEBUG
      .EnableSensitiveDataLogging() // Include SQL parameters.
      .EnableDetailedErrors()
    #endif
    ;

    optionsBuilder.UseLazyLoadingProxies();
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
        .HasQueryFilter(p => !p.Discontinued)
        .Property(product => product.Cost)
        .HasConversion<double>();
    }
  }
}

// uno de los capitulos mas densos y se tiene que practicar mucho.
