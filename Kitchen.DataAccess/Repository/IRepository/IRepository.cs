using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


//This repository is created as middle ware to access database, so that no one can access applicationdbcontext directly and 
//this repository is used to do any changes in db
namespace Kitchen.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        //GET ALL, Get by Id first or default, ADD , REMOVE, REMOVERANGE
        //
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable <T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
    }
}
