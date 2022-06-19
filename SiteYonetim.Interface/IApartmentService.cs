using SiteYonetim.Entity.Dto.DtoApartman;
using SiteYonetim.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Interface
{
    public interface IApartmanService:IGenericService<Apartman,DtoViewApartman>
    {
    }
}
