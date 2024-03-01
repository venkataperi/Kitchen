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
public class IndexModel : PageModel
{

    private readonly IUnitOfWork _UnitOfWork;
    public IEnumerable<Category> Categories { get; set; }
    public IndexModel(IUnitOfWork UnitOfWork)
    {
        _UnitOfWork = UnitOfWork;
    }
    public void OnGet()
    {
        Categories = _UnitOfWork.Category.GetAll();
    }
}
