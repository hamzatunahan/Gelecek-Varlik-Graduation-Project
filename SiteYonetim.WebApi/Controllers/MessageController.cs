using SiteYonetim.WebApi.Base;
using SiteYonetim.Entity.Base;
using SiteYonetim.Entity.Dto.DtoMessage;
using SiteYonetim.Entity.IBase;
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
    public class MessageController : ApiBaseController<IMessageService, Message, DtoViewMessage>
    {
        private readonly IMessageService messageService;
        public MessageController(IMessageService messageService) : base(messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet("GetDetail")]
        public IResponse<List<DtoViewMessage>> GetDetail(int receiverId, int senderId)
        {
            try
            {
                return messageService.GetDetail(receiverId, senderId);
            }
            catch (Exception)
            {

                return new Response<List<DtoViewMessage>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Mesaj Yok",
                    Data = null
                };
            }
            
        }

        [HttpPost("MesageInsert")]
        public IResponse<bool> Insert(DtoInsertMessage newMessage)
        {
            try
            {
                return messageService.InsertMessage(newMessage);
            }
            catch (Exception)
            {

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Mesaj Gönderilemedi",
                    Data = false
                };
            }
        }

    }
}
