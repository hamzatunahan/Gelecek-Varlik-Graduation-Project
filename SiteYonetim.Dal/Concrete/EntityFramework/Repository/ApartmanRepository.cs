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
    public class ApartmanRepository:GenericRepository<Apartman>,IApartmanRepository
    {
        public ApartmanRepository(DbContext context):base(context)
        {

        }
        
    }
}
