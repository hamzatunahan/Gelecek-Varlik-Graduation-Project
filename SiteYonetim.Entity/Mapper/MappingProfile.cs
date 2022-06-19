using SiteYonetim.Entity.Dto.DtoApartman;
using SiteYonetim.Entity.Dto.DtoFatura;
using SiteYonetim.Entity.Dto.DtoMessage;
using SiteYonetim.Entity.Dto.DtoUser;
using SiteYonetim.Entity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DtoInsertUser>().ReverseMap();
            CreateMap<User, DtoViewUser>().ReverseMap();
            CreateMap<User, DtoUserLoginRequest>().ReverseMap();
            CreateMap<User, DtoUserLoginResp>().ReverseMap();
            CreateMap<User, DtoLogin>().ReverseMap();
            CreateMap<Apartman, DtoInsertApartman>().ReverseMap();
            CreateMap<Apartman, DtoViewApartman>().ReverseMap();
            CreateMap<Message, DtoInsertMessage>().ReverseMap();
            CreateMap<Message, DtoViewMessage>().ReverseMap();
            CreateMap<Fatura, DtoInsertFatura>().ReverseMap();
            CreateMap<Fatura, DtoViewFatura>().ReverseMap();

        }

    }
}
