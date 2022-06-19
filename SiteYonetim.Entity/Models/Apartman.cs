using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteYonetim.Entity.Models
{
    public partial class Apartman:EntityBase
    {
        public int Id { get; set; }
        public string Blok { get; set; }
        public int ApNo { get; set; }
        public int? DaireId { get; set; }
        public string Tip { get; set; }
        public bool IsEmpty { get; set; }
        public DateTime InDateTime { get; set; } = DateTime.Now;
        public DateTime? UpDateTime { get; set; }= DateTime.Now;
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User Resident { get; set; }
    }
}
