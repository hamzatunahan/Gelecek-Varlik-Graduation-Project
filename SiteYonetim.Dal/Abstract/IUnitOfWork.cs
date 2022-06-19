using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Dal.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : EntityBase;//bll katmanında kullanılır
        bool BeginTransaction();//transaction başlatma
        bool RollBackTransaction();//hata durumunda işlemi geri alma
        int SaveChanges();//transactionu onaylar.
    }
}
