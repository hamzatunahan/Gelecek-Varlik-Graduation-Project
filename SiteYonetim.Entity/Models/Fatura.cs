using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteYonetim.Entity.Models
{
    public partial class Fatura : EntityBase
    {
        public int Id { get; set; }
        public string FaturaTipi { get; set; }
        public decimal Price { get; set; }
        public int ApartmanId { get; set; }
        public bool IsPaid { get; set; }
        public int PayerId { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime InDateTime { get; set; } = DateTime.Now;
        public DateTime? UpDateTime { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; }

        public virtual User Payer { get; set; }
    }
}
