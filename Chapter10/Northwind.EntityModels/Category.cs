using System.ComponentModel.DataAnnotations.Schema; // Tu use [Column]
namespace Northwind.EntityModels;

public class Category
{
  public int CategoryId { get; set; } // the primary key

  public string CategoryName { get; set; } = null!;

  [Column(TypeName = "nText")]
  public string? Description { get; set; }

  public virtual ICollection<Product> Products { get; set; }
  = new HashSet<Product>(); // una categoria tiene varios productos.
}
