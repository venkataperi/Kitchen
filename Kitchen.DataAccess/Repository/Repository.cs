﻿using Kitchen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VassuKitchen.Data;

namespace Kitchen.DataAccess.Repository.IRepository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
                
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.MenuItem.Include(u => u.FoodType).Include(u => u.Category);
            this.dbSet=db.Set<T>();
        }
        public void Add(T entity) 
        {
            dbSet.Add(entity);
        }
        public void Remove(T entity) 
        {
            dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null ,string ? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(
                    new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if(orderby != null)
            {
                return orderby(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null) 
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }
    }
}
