using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.Categories;
[BindProperties]
public class EditModel : PageModel
{
    private readonly IUnitOfWork _UnitOfWork;
    public Category Category { get; set; }

    public EditModel(IUnitOfWork UnitOfWork)
    {
        _UnitOfWork = UnitOfWork;
    }

	public void OnGet(int Id)
	{
		Category = _UnitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);
		//Category = _db.Category.FirstOrDefault(u=>u.Id==Id);
		//Category = _db.Category.SingleOrDefault(u => u.Id == Id);
		//Category = _db.Category.Where(u => u.Id == Id).SingleOrDefault();
	}

	public async Task<IActionResult> OnPost()
	{
		//This is one of custom validation 
		//if (Category.Name == Category.DisplayOrder.ToString())
		//{
		//	ModelState.AddModelError("Category.Name", "The Display order and name cannot be same");
		//}
		//this is used to validate server side validation
		if (ModelState.IsValid)
		{
            // This line is used to add category fields in database while creating new items
            _UnitOfWork.Category.Update(Category);
            //this is used to save changes in database
            _UnitOfWork.Save();
			TempData["Success"] = "Category updated successfully";
			return RedirectToPage("Index");
		}
		return Page();
		
	}
}
