using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoApartman
{
    public class DtoViewApartman : DtoBase
    {
        public int Id { get; set; }
        public string Blok { get; set; }
        public int ApNo { get; set; }
        public int? DaireId { get; set; }
        public string Tip { get; set; }
        public bool IsEmpty { get; set; }
    }
}
