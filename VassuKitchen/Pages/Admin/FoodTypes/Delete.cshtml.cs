using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VassuKitchen.Data;
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.FoodTypes;

public class DeleteModel : PageModel
{
	private readonly ApplicationDbContext _db;
	[BindProperty]
	public FoodType FoodType { get; set; }
	public DeleteModel(ApplicationDbContext db)
	{
		_db = db;
	}
	public void OnGet(int Id)
	{
		FoodType = _db.FoodType.Find(Id);
		//Category = _db.Category.FirstOrDefault(u=>u.Id==Id);
		//Category = _db.Category.SingleOrDefault(u => u.Id == Id);
		//Category = _db.Category.Where(u => u.Id == Id).SingleOrDefault();
	}
	public async Task<IActionResult> OnPost() 
	{ 	
	var FoodTypeFromDb = _db.FoodType.Find(FoodType.Id);
	if (FoodTypeFromDb != null)
	{
		_db.FoodType.Remove(FoodTypeFromDb);
		await _db.SaveChangesAsync();
		TempData["Success"] = "FoodType deleted successfully";
		return RedirectToPage("Index");
	}
            
        return Page();
		
	}
}
