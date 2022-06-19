using SiteYonetim.Entity.Dto.DtoFatura;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Interface
{
    public interface IFaturaService:IGenericService<Fatura,DtoViewFatura>
    {
        public IResponse<List<DtoViewFatura>> GetListFatura( int apartmanId, bool isPaid);
        public IResponse<DtoViewFatura> UpdateFatura(int id);
    }
}
