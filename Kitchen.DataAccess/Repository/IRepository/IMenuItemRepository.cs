using Kitchen.Models;

namespace Kitchen.DataAccess.Repository.IRepository
{
	public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem obj);
        void Save();
    }
}
