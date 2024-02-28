using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VassuKitchen.Data;
//using VassuKitchen.Data;
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.Categories;

public class CreateModel : PageModel
{
	private readonly ApplicationDbContext _db;
	//this bind property keyword used to bind category with create.cshtml page
	//and obj category can be used anywhere in this page without redefining
	[BindProperty]
	public Kitchen.Models.Category Category { get; set; }
	public CreateModel(ApplicationDbContext db)
	{
		_db = db;
	}
	public void OnGet()
	{
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
			await _db.Category.AddAsync(Category);
			//this is used to save changes in database
			await _db.SaveChangesAsync();
			TempData["Success"] = "Category created successfully";
			return RedirectToPage("Index");
		}
		return Page();
		
	}
}
