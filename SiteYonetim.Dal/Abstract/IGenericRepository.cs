using SiteYonetim.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Dal.Abstract
{
    public interface IGenericRepository<T> where T:IEntityBase
    {
        List<T> GetList();
        //filtreli listemele
        List<T> GetList(Expression<Func<T, bool>> expression);

        //Getirme tek kayıt
        T GetById(int id);

        //Kaydetme
        T Insert(T item);

        T Update(T item);
        bool Delete(int id);

        bool Delete(T item);

        IQueryable<T> GetQueryable();

    }
}
