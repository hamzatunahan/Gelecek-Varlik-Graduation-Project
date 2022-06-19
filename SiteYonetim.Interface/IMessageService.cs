using SiteYonetim.Entity.Dto.DtoMessage;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Interface
{
    public interface IMessageService:IGenericService<Message,DtoViewMessage>
    {
        public IResponse<List<DtoViewMessage>> GetDetail(int receiverId, int senderId);
        public IResponse<bool> InsertMessage(DtoInsertMessage newMessage, bool saveChanges = true);
    }
}
