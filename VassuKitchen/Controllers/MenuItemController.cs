using Kitchen.DataAccess.Repository;
using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace VassuKitchen.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuItemController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _hostEnvironment;
		public MenuItem MenuItem { get; set; }

		public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_hostEnvironment = hostEnvironment;

		}
		[HttpGet]		
		public IActionResult Get()
		{
			var MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties:"Category,FoodType");
			return Json(new {data = MenuItemList});

		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
			//delete old image
			var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}
			_unitOfWork.MenuItem.Remove(objFromDb);
			_unitOfWork.Save();
			return Json(new { success =true,message ="Delete Successful"});

		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
