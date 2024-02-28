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

public class IndexModel : PageModel
{

    private readonly ApplicationDbContext _db;
    public IEnumerable<FoodType> FoodTypes { get; set; }
    public IndexModel(ApplicationDbContext db)
    { 
        _db = db;
    }
    public void OnGet()
    {
        FoodTypes = _db.FoodType;
    }
}
