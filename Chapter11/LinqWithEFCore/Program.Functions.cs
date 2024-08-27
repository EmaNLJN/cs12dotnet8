using Northwind.EntityModels;
using Microsoft.EntityFrameworkCore;

partial class Program
{
  private static void FilterAndSort()
  {
    SectionTitle("Filter and sort");

    using NorthwindDb db = new();

    DbSet<Product> allProducts = db.Products;

    IQueryable<Product> filteredProducts =
      allProducts.Where(product => product.UnitPrice < 10M);

    IOrderedQueryable<Product> sortedAndFilteredProducts =
      filteredProducts.OrderByDescending(product => product.UnitPrice);

    // WriteLine("Products that cost less than $10:");
    // WriteLine(sortedAndFilteredProducts.ToQueryString());

    var projectedProducts = sortedAndFilteredProducts
      .Select(product => new // Anonymous type.
      {
        product.ProductId,
        product.ProductName,
        product.UnitPrice
      });

    WriteLine("Products that cost less than $10:");
    WriteLine(projectedProducts.ToQueryString());

    // se usa projection para que la consulta
    // en lugar de llamar todas las columnas
    // solo lo haga con las que uso.
    foreach (var p in projectedProducts)
    {
      WriteLine("{0}: {1} costs {2:$#,##0.00}",
        p.ProductId, p.ProductName, p.UnitPrice);
    }
    WriteLine();
  }

  private static void JoinCategoriesAndProducts()
  {
    SectionTitle("Join categories and products");

    using NorthwindDb db = new();

    // join every product to its category to return 77 matches.
    var queryJoin = db.Categories.Join(
      inner: db.Products,
      outerKeySelector: category => category.CategoryId,
      innerKeySelector: product => product.CategoryId,
      resultSelector: (c, p) =>
        new { c.CategoryName, p.ProductName, p.ProductId })
      .OrderBy(cp => cp.CategoryName);

    foreach (var p in queryJoin)
    {
      WriteLine($"{p.ProductId}: {p.ProductName} in {p.CategoryName}");
    }
  }

  private static void GroupJoinCategoriesAndProducts()
  {
    SectionTitle("Group join categories and products");

    using NorthwindDb db = new();

    var queryGroup = db.Categories.AsEnumerable().GroupJoin(
      inner: db.Products,
      outerKeySelector: category => category.CategoryId,
      innerKeySelector: product => product.CategoryId,
      resultSelector: (c, matchingProducts) => new
      {
        c.CategoryName,
        Products = matchingProducts.OrderBy(p => p.ProductName)
      });

    foreach (var c in queryGroup)
    {
      WriteLine($"{c.CategoryName} has {c.Products.Count()} products.");

      foreach (var product in c.Products)
      {
        WriteLine($"  {product.ProductName}");
      }
    }
  }
}
