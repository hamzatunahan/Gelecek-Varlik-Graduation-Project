using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteYonetim.Entity.Models
{
    public partial class User : EntityBase
    {
        public User()
        {
            Apartmans = new HashSet<Apartman>();
            Faturas = new HashSet<Fatura>();
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string TCNo { get; set; }
        public string Plaka { get; set; }
        public int? ApartmentId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime InDateTime { get; set; } 
        public DateTime? UpDateTime { get; set; } 
        public bool IsAdmin { get; set; }

        public virtual ICollection<Apartman> Apartmans { get; set; }
        public virtual ICollection<Fatura> Faturas { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
        public object ApartmanId { get; set; }
    }
}
