using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VassuKitchen.Data;
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.Categories;
[BindProperties]
public class DeleteModel : PageModel
{
    private readonly IUnitOfWork _UnitOfWork;
    public Category Category { get; set; }

    public DeleteModel(IUnitOfWork UnitOfWork)
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
	var categoryFromDb = _UnitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
	if (categoryFromDb != null)
	{
        _UnitOfWork.Category.Remove(categoryFromDb);
        _UnitOfWork.Save();
		TempData["Success"] = "Category deleted successfully";
		return RedirectToPage("Index");
	}
            
        return Page();
		
	}
}
