using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<Product> Products { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    string database = "Northwind.db";
    string dir = Environment.CurrentDirectory;
    string path = string.Empty;

    if (dir.EndsWith("net8.0"))
    {
      path = Path.Combine("..", "..", "..", database);
    }
    else
    {
      path = database;
    }

    path = Path.GetFullPath(path); // absolute path
    WriteLine($"SQLite database path: {path}");

    if (!File.Exists(path))
    {
      throw new FileNotFoundException(
        message: $"{path} not found.", fileName: path);
    }

    optionsBuilder.UseSqlite($"Data Source={path}");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    if (Database.ProviderName is not null &&
      Database.ProviderName.Contains("Sqlite"))
    {
      modelBuilder.Entity<Product>()
        .Property(product => product.UnitPrice)
        .HasConversion<double>();
    }
  }
}
