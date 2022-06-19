using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoFatura
{
    public class DtoViewFatura : DtoBase
    {
        public int Id { get; set; }
        public string FaturaTipi { get; set; }
        public decimal Price { get; set; }
        public int ApartmanId { get; set; }
        public bool IsPaid { get; set; }
        public int PayerId { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public DateTime PaymentDueDate { get; set; }

    }
}
