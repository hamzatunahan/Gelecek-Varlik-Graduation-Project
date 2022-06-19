using SiteYonetim.Dal.Abstract;
using SiteYonetim.Dal.Concrete.EntityFramework.Repository;
using SiteYonetim.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Dal.Concrete.EntityFramework.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        #region Variables
        DbContext context;
        IDbContextTransaction transaction;
        bool dispose;//defaultu false
        #endregion
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;//transaction başladıysa true döner
            }
            catch (Exception)
            {

                return false;//transaction başlayamadıyda false döner
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//Garbage collector çalıştırır.Nesneleri öldürür.
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)//bu if blogunda true mu diye kontrol ediyoruz.
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            dispose = true;
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);//modele ait bir metodu tek bir context ile yönetebilmek için
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();//transactionu sıfırla.
                transaction = null;//daha önceki transectionu boşalt.
                return true;//başarılıysa true
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = transaction != null ? transaction : context.Database.BeginTransaction();
            using (_transaction)//işlem bittikten sonra _transactionu öldürür,siler,iptal eder.
            {
                try
                {
                    if (context == null)
                    {
                        throw new ArgumentException("context oluşmamıştır.");
                    }
                    int result = context.SaveChanges();//etkilenen satır sayısını döndürür.

                    _transaction.Commit();//onaylar commitler

                    return result;//etkilenen kayıt  sayısı döner

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("kayıt hatalı,yapılamadı.", ex);
                }
            }
        }
    }

}

