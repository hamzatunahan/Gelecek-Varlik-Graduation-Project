using SiteYonetim.Dal.Abstract;
using SiteYonetim.Entity.Dto.DtoFatura;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Entity.Models;
using SiteYonetim.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SiteYonetim.Entity.Base;
using Microsoft.AspNetCore.Http;

namespace SiteYonetim.Bll
{
    public class FaturaManager : GenericManager<Fatura, DtoViewFatura>, IFaturaService
    {
        private readonly IFaturaRepository faturaRepository;
        public FaturaManager(IServiceProvider service) : base(service)
        {
            faturaRepository = service.GetService<IFaturaRepository>();
        }

        public IResponse<List<DtoViewFatura>> GetListFatura(int apartmanId, bool isPaid)
        {
            var data = faturaRepository.GetListFatura();
            //ödenmiş faturalar
            if (isPaid)
            {
                data = data.Where(b => b.IsPaid).ToList();
            }
           
            //Apatmana Ait faturalar
            if (apartmanId >0)
            {
                data=data.Where(b => b.ApartmanId == apartmanId).ToList();
            }
         

            if (!data.Any())
            {
                return new Response<List<DtoViewFatura>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "fatura bulunamadı.",
                    Data = null
                };
            }

            var resultList = ObjectMapper.Mapper.Map<List<DtoViewFatura>>(data.OrderBy(p => p.Id));

            return new Response<List<DtoViewFatura>>
            {
                StatusCode=StatusCodes.Status200OK,
                Message="İşlem Başarılı",
                Data=resultList
            };
        }

        public IResponse<DtoViewFatura> UpdateFatura(int id)
        {
            throw new NotImplementedException();
        }
    }
}
