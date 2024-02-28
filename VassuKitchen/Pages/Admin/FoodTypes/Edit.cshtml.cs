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

public class EditModel : PageModel
{
	private readonly ApplicationDbContext _db;
	[BindProperty]
	public FoodType FoodType { get; set; }
	public EditModel(ApplicationDbContext db)
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
		//This is one of custom validation 
		if(FoodType.Name == FoodType.Id.ToString())
		{
			ModelState.AddModelError("FoodType.Name", "The id and name cannot be same");
		}
		//this is used to validate server side validation
		if (ModelState.IsValid)
		{
			// This line is used to add category fields in database while creating new items
			_db.FoodType.Update(FoodType);
			//this is used to save changes in database
			await _db.SaveChangesAsync();
			TempData["Success"] = "FoodType updated successfully";
			return RedirectToPage("Index");
		}
		return Page();
		
	}
}
