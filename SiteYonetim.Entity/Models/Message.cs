using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SiteYonetim.Entity.Models
{
    public partial class Message : EntityBase
    {
        public int Id { get; set; }
        public string MessageIcerik { get; set; }
        public bool IsRead { get; set; }
        public DateTime InDateTime { get; set; } = DateTime.Now;
        public int GonderenId { get; set; }
        public int AlanId { get; set; }

        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
    }
}
