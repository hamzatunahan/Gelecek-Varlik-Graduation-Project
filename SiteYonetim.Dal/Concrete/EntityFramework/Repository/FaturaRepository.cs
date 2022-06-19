using SiteYonetim.Dal.Abstract;
using SiteYonetim.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Dal.Concrete.EntityFramework.Repository
{
    public class FaturaRepository:GenericRepository<Fatura>,IFaturaRepository
    {
        public FaturaRepository(DbContext context):base(context)
        {

        }

        public List<Fatura> GetListFatura()
        {
            return dbset.ToList();
        }

        public bool UpdateFatura(int id)
        {
            throw new NotImplementedException();
        }
    }
}
