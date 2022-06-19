using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoMessage
{
    public class DtoViewMessage : DtoBase
    {
        public int Id { get; set; }
        public string MessageIcerik { get; set; }
        public bool IsRead { get; set; }
        public DateTime InDateTime { get; set; }
        public int GonderenId { get; set; }
        public int AlanId { get; set; }
    }
}
