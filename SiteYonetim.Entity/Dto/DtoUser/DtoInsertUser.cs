using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoUser
{
    public class DtoInsertUser : DtoBase
    {
        [Required]
        [StringLength(50, ErrorMessage = "Karakter siniri asildi")]
        public string FullName { get; set; }
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Karakter siniri asildi")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Hatalı giris")]
        public string TCNo { get; set; }

        [RegularExpression("^([0-9]{2})([A-Z]{1,3})([0-9]{2,4})$", ErrorMessage = "Hatalı giris")]
        public string Plaka { get; set; }
        public int? ApartmanId { get; set; }
        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız.")]
        public bool IsAdmin { get; set; }
    }
}
