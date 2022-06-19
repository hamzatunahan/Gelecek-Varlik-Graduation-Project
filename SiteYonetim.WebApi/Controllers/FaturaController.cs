using SiteYonetim.WebApi.Base;
using SiteYonetim.Entity.Dto.DtoFatura;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Entity.Models;
using SiteYonetim.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteYonetim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ApiBaseController<IFaturaService, Fatura, DtoViewFatura>
    {
        private readonly IFaturaService faturaService;
        public FaturaController(IFaturaService faturaService) : base(faturaService)
        {
            this.faturaService = faturaService;
        }

        
        [HttpGet("GetListFatura")]
        public IResponse<List<DtoViewFatura>> GetListFatura(int apartmanId, bool isPaid)
        {
                return faturaService.GetListFatura(apartmanId,isPaid);
        }




    }
}
