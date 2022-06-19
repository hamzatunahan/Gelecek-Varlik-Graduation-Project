using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoFatura
{
    public class DtoInsertFatura : DtoBase
    {
        [Required]
        public string FaturaTipi { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ApartmanId { get; set; }

        [Required]
        public int PayerId { get; set; }

        [Required]
        public DateTime PaymentDueDate { get; set; }
    }
}
