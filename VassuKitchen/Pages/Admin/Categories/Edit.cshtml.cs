using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VassuKitchen.Data;
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.Categories;

public class EditModel : PageModel
{
	private readonly ApplicationDbContext _db;
	[BindProperty]
	public Category Category { get; set; }
	public EditModel(ApplicationDbContext db)
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
		//This is one of custom validation 
		if(Category.Name == Category.DisplayOrder.ToString())
		{
			ModelState.AddModelError("Category.Name", "The Display order and name cannot be same");
		}
		//this is used to validate server side validation
		if (ModelState.IsValid)
		{
			// This line is used to add category fields in database while creating new items
			_db.Category.Update(Category);
			//this is used to save changes in database
			await _db.SaveChangesAsync();
			TempData["Success"] = "Category updated successfully";
			return RedirectToPage("Index");
		}
		return Page();
		
	}
}
