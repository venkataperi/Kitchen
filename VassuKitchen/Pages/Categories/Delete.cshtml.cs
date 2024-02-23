using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VassuKitchen.Data;
using VassuKitchen.Model;

namespace VassuKitchen.Pages.Categories;

public class DeleteModel : PageModel
{
	private readonly ApplicationDbContext _db;
	[BindProperty]
	public Category Category { get; set; }
	public DeleteModel(ApplicationDbContext db)
	{
		_db = db;
	}
	public void OnGet(int Id)
	{
		Category = _db.Category.Find(Id);
		//Category = _db.Category.FirstOrDefault(u=>u.Id==Id);
		//Category = _db.Category.SingleOrDefault(u => u.Id == Id);
		//Category = _db.Category.Where(u => u.Id == Id).SingleOrDefault();
	}
	public async Task<IActionResult> OnPost() 
	{ 	
	var categoryFromDb = _db.Category.Find(Category.Id);
	if (categoryFromDb != null)
	{
		_db.Category.Remove(categoryFromDb);
		await _db.SaveChangesAsync();
		TempData["Success"] = "Category deleted successfully";
		return RedirectToPage("Index");
	}
            
        return Page();
		
	}
}
