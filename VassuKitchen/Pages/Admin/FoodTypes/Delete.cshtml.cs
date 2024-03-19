using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.DataAccess.Repository;
using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.FoodTypes;
[BindProperties]
public class DeleteModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public FoodType FoodType { get; set; }
    public DeleteModel(IUnitOfWork unitOfWork)
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
	var FoodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id==FoodType.Id);
	if (FoodTypeFromDb != null)
	{
        _unitOfWork.FoodType.Remove(FoodTypeFromDb);
        _unitOfWork.Save();
		TempData["Success"] = "FoodType deleted successfully";
		return RedirectToPage("Index");
	}
            
        return Page();
		
	}
}
