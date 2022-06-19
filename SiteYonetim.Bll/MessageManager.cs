using SiteYonetim.Dal.Abstract;
using SiteYonetim.Entity.Dto.DtoMessage;
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
    public class MessageManager : GenericManager<Message, DtoViewMessage>, IMessageService
    {
        private readonly IMessageRepository messageRepository;
        public MessageManager(IServiceProvider service) : base(service)
        {
            messageRepository = service.GetService<IMessageRepository>();
        }
        public IResponse<List<DtoViewMessage>> GetDetail(int receiverId, int senderId)
        {
            try
            {
                
                var data = messageRepository.GetDetail();           
                var result = data.Where(x => (x.AlanId == receiverId) && x.GonderenId == senderId  || (x.AlanId == senderId && x.GonderenId == receiverId)).OrderBy(y => y.InDateTime);
                var veri = result.Select(z => ObjectMapper.Mapper.Map<DtoViewMessage>(z)).ToList();
                return new Response<List<DtoViewMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "GetDetail Başarılı",
                    Data = veri
                };
            }
            catch (Exception)
            {

                return new Response<List<DtoViewMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "GetDetail Başarısız",
                    Data = null
                };
            }
        }

        public IResponse<bool> InsertMessage(DtoInsertMessage newMessage, bool saveChanges = true)
        {
            try
            {
                var result = messageRepository.InsertMessage( ObjectMapper.Mapper.Map<Message>(newMessage));
                if (saveChanges)
                {
                    Save();
                }
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "InsertMessage Başarılı",
                    Data = true
                };
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "InsertMessage Başarısız.",
                    Data = false
                };

            }
        }
    }
}
