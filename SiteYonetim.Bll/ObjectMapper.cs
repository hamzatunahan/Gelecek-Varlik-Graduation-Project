using SiteYonetim.Entity.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Bll
{
    internal class ObjectMapper
    {
        //  Lazy loading aktif edersen order'ı çekersen detayları da gelir nesneye  ait baglatılı her sey lazyloading:true      performans sorunu
        //  Heiger loading    istenildiği yerde detayı dahil et
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile<MappingProfile>();

              });
            return config.CreateMapper();
        }
        );
        public static IMapper Mapper => lazy.Value;
    }
}
