using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoApartman
{
    public class DtoInsertApartman:DtoBase
    {
        [Required]
        [RegularExpression("^([A-Z]{1})$", ErrorMessage = "Error")]
        public string Blok { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Daire no 1 ile 100 arasında olmalı")]
        public int ApNo { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Hatalı Daire")]
        public int? DaireId { get; set; }

        [Required]
        [RegularExpression("^([0-6]{1})[+]([1-2]{1})$", ErrorMessage = "Daire bulunmamaktadır")]
        public string Tip { get; set; }
        public bool IsEmpty { get; set; }
    }
}
