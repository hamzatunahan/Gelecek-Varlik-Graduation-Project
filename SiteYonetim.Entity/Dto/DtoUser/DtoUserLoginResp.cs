using SiteYonetim.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Dto.DtoUser
{
    public class DtoUserLoginResp:DtoBase
    {
        public DtoLogin DtoLogin { get; set; }
        public object AccessToken { get; set; }
    }
}
