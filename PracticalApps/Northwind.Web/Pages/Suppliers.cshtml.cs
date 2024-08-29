using Microsoft.AspNetCore.Mvc; // to use [bindproperty], IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels;

namespace Northwind.Web.Pages
{
  public class SuppliersModel : PageModel
  {
    private NorthwindContext _db;
    public IEnumerable<Supplier>? Suppliers { get; set; }

    [BindProperty]
    public Supplier? Supplier { get; set; }

    public SuppliersModel(NorthwindContext db)
    {
      _db = db;
    }

    public IActionResult OnPost()
    {
      if (Supplier is not null && ModelState.IsValid)
      {
        _db.Suppliers.Add(Supplier);
        _db.SaveChanges();

        return RedirectToPage("/suppliers");
      }
      else
      {
        return Page(); // return to original page.
      }
    }

    public void OnGet()
    {
      ViewData["Title"] = "Northwind B2B - Suppliers";

      Suppliers = _db.Suppliers
        .OrderBy(c => c.Country)
        .ThenBy(c => c.ContactName);
    }
  }
}
