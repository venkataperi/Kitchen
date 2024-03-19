using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.FoodTypes;
[BindProperties]
public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public FoodType FoodType { get; set; }
    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void OnGet(int Id)
	{
		FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == Id);
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
            _unitOfWork.FoodType.Update(FoodType);
            //this is used to save changes in database
            _unitOfWork.Save();
			TempData["Success"] = "FoodType updated successfully";
			return RedirectToPage("Index");
		}
		return Page();
		
	}
}
