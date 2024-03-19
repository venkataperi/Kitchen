using Kitchen.DataAccess.Repository.IRepository;
using Kitchen.Models;
 
using VassuKitchen.DataAccess.Data;

namespace Kitchen.DataAccess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(FoodType obj)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
            //objFromDb.DisplayOrder = category.DisplayOrder;

        }
    }
}
