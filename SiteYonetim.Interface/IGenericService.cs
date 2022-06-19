using SiteYonetim.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Interface
{
    public interface IGenericService<T,TDto> where T:IEntityBase where TDto:IDtoBase
    {
        
        IResponse<List<TDto>> GetList();
        //filtreli listemele
        IResponse<List<TDto>> GetList(Expression<Func<T, bool>> expression);

        //Getirme tek kayıt
        IResponse<TDto> GetById(int id);

        //Kaydetme
        IResponse<TDto> Insert(TDto item, bool saveChanges = true);

        IResponse<TDto> Update(TDto item,bool saveChanges = true);
        IResponse<bool> Delete(int id, bool saveChanges = true);

        IResponse<IQueryable<TDto>> GetQueryable();

        void Save();
    }
}
