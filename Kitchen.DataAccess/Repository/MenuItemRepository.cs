using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
using VassuKitchen.DataAccess.Data;


namespace Kitchen.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(MenuItem obj)
        {
            var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == obj.Id);
			objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.Price = obj.Price;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.FoodTypeId = obj.FoodTypeId;
            if(objFromDb.Image != null)
            {
                objFromDb.Image = obj.Image;
            }

        }
    }
}
