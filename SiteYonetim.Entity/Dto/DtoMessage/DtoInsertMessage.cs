using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoMessage
{
    public class DtoInsertMessage : DtoBase
    {
        [Required(ErrorMessage = "Boş Geçilemez.")]
        [StringLength(250, ErrorMessage = "Karakter siniri asildi")]
        public string MessageIcerik { get; set; }
        [Required(ErrorMessage = "Lütfen Boş Bırakmayiniz.")]
        public int GonderenId { get; set; }
        [Required(ErrorMessage = "Lütfen Boş Bırakmayiniz.")]
        public int AlanId { get; set; }
    }
}
