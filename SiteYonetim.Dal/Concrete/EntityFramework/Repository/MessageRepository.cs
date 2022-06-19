using SiteYonetim.Dal.Abstract;
using SiteYonetim.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Dal.Concrete.EntityFramework.Repository
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext context):base(context)
        {

        }

        public List<Message> GetDetail()
        {
            return dbset.ToList();
            
        }

        bool IMessageRepository.InsertMessage(Message newMessage)
        {
            try
            {
                _context.Entry(newMessage).State = EntityState.Added;
                dbset.Add(newMessage);
                return true;
            }
            catch 
            {

                return false;
            }
            
        }

        
    }
}
