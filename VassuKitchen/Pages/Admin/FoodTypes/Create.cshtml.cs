using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.DataAccess.Repository;
using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
// 
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.FoodTypes;

//this bind property keyword used to bind category with create.cshtml page
//and obj category can be used anywhere in this page without redefining
[BindProperties]
public class CreateModel : PageModel
{
	private readonly IUnitOfWork _unitOfWork;
	
	public FoodType FoodType { get; set; }
	public CreateModel(IUnitOfWork unitOfWork)
	{
        _unitOfWork = unitOfWork;
	}
	public void OnGet()
	{
	}

	public async Task<IActionResult> OnPost()
	{
		//This is one of custom validation 
		if(FoodType.Name == FoodType.Id.ToString())
		{
			ModelState.AddModelError("FoodType.Name", "The ID and name cannot be same");
		}
		//this is used to validate server side validation
		if (ModelState.IsValid)
		{
            // This line is used to add category fields in database while creating new items
            _unitOfWork.FoodType.Add(FoodType);
            //this is used to save changes in database
            _unitOfWork.Save();
			TempData["Success"] = "FoodType created successfully";
			return RedirectToPage("Index");
		}
		return Page();
		
	}
}
