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
}
