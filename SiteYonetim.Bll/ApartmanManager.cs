using SiteYonetim.Dal.Abstract;
using SiteYonetim.Entity.Dto.DtoApartman;
using SiteYonetim.Entity.Models;
using SiteYonetim.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace SiteYonetim.Bll
{
    public class ApartmanManager:GenericManager<Apartman,DtoViewApartman>,IApartmanService
    {
        private readonly IApartmanRepository apartmanRepository;
        public ApartmanManager(IServiceProvider service) : base(service)
        {
            apartmanRepository = service.GetService<IApartmanRepository>();
        }
    }
}
