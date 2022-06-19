using SiteYonetim.WebApi.Base;
using SiteYonetim.Entity.Dto.DtoApartman;
using SiteYonetim.Entity.Models;
using SiteYonetim.Interface;
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
    public class ApartmanController : ApiBaseController<IApartmanService, Apartman, DtoViewApartman>
    {
        private readonly IApartmanService apartmanService;
        public ApartmanController(IApartmanService apartmanService) : base(apartmanService)
        {
            this.apartmanService = apartmanService;
        }
    }
}
