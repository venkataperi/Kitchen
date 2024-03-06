using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.DataAccess.Repository;
using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using VassuKitchen.Data;
//using VassuKitchen.Data;
//using VassuKitchen.Model;

namespace VassuKitchen.Pages.Admin.MenuItems;

//this bind property keyword used to bind category with create.cshtml page
//and obj category can be used anywhere in this page without redefining
[BindProperties]
public class UpsertModel : PageModel
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _hostEnvironment;
	
	public MenuItem MenuItem { get; set; }
	public IEnumerable<SelectListItem> CategoryList { get; set; }
	public IEnumerable<SelectListItem> FoodTypeList { get; set; }

	public UpsertModel(IUnitOfWork unitOfWork , IWebHostEnvironment hostEnvironment)
	{
        _unitOfWork = unitOfWork;
		_hostEnvironment = hostEnvironment;
		MenuItem = new MenuItem();
		
	}
	public void OnGet(int? Id)
	{
		if(Id!= null)
		{
			//Edit
			MenuItem =_unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id==Id);
		}
		CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
		{
			Text =i.Name,
			Value =i.Id.ToString()
		});
		FoodTypeList = _unitOfWork.FoodType.GetAll().Select(i => new SelectListItem()
		{
			Text = i.Name,
			Value = i.Id.ToString()
		});
	}

	public async Task<IActionResult> OnPost()
	{
		//these lines used for upload image
		string webRootPath = _hostEnvironment.WebRootPath;
		var files =HttpContext.Request.Form.Files;
		if(MenuItem.Id == 0 )
		{
			string fileName_new =Guid.NewGuid().ToString();
			var uploads =Path.Combine(webRootPath, @"Images\MenuItems");
			var extension =Path.GetExtension(files[0].FileName);

			using(var filestream =new FileStream(Path.Combine(uploads,fileName_new + extension), FileMode.Create))
			{
				files[0].CopyTo(filestream);
			}
			MenuItem.Image = @"\Images\MenuItmes" + fileName_new + extension;
			_unitOfWork.MenuItem.Add(MenuItem);
			_unitOfWork.Save();
		}
		else
		{
			//edit
			var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == MenuItem.Id);
			if(files.Count >0)
			{
				string fileName_new = Guid.NewGuid().ToString();
				var uploads = Path.Combine(webRootPath, @"Images\MenuItems");
				var extension = Path.GetExtension(files[0].FileName);

				//delete old image
				var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
				if(System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}
				//new upload
				using (var filestream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
				{
					files[0].CopyTo(filestream);
				}
				MenuItem.Image = @"\Images\MenuItmes" + fileName_new + extension;

			}
			else
			{
				MenuItem.Image = objFromDb.Image;
			}
			_unitOfWork.MenuItem.Update(MenuItem);
			_unitOfWork.Save();	

		}
		return RedirectToPage("./Index");

	}
}
