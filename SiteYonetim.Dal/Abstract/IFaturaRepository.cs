using SiteYonetim.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Dal.Abstract
{
    public interface IFaturaRepository
    {
        public List<Fatura> GetListFatura();
        public bool UpdateFatura(int id);
    }
}
