using SiteYonetim.Dal.Abstract;
using SiteYonetim.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Dal.Concrete.EntityFramework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:EntityBase
    {

        #region Variables
        protected DbContext _context;
        protected DbSet<T> dbset;
        #endregion

        public GenericRepository(DbContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));    
        }

        public bool Delete(T item)
        {
            if (_context.Entry(item).State == EntityState.Detached)
            {
                _context.Attach(item);
            }
            return dbset.Remove(item) != null;//silme başarılıysa gönder.
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public List<T> GetList()
        {
            return dbset.ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return dbset.AsQueryable();
        }

        public T Insert(T item)
        {
            _context.Entry(item).State = EntityState.Added;
            dbset.Add(item);
            return item;
        }

        public T Update(T item)
        {
            dbset.Update(item);
            return item;
        }
    }
}
