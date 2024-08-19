using System.ComponentModel.DataAnnotations; // to use [Required]
using System.ComponentModel.DataAnnotations.Schema; // to use [column]

namespace Northwind.EntityModels;

public class Product
{
  public int ProductId { get; set; } // the primary key

  [Required]
  [StringLength(40)]
  public string ProductName { get; set; } = null!;

  [Column("UnitPrice", TypeName = "money")]
  public decimal? Cost { get; set; }

  [Column("UnitsInStock")]
  public short? Stock { get; set; }

  public bool Discontinued { get; set; }

  // properties define the foreign key relationship
  // to the categories table.
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; } = null!;
}
