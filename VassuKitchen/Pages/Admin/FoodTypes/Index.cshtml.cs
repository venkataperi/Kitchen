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

namespace VassuKitchen.Pages.Admin.FoodTypes;
[BindProperties]
public class IndexModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public IEnumerable<FoodType> FoodTypes { get; set; }
  
    public IndexModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    } 
    public void OnGet()
    {
        FoodTypes = _unitOfWork.FoodType.GetAll();
    }
}
