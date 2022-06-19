using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoUser
{
    public class DtoViewUser : DtoBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string TCNo { get; set; }
        public string Plaka { get; set; }
        public int? ApartmanId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
