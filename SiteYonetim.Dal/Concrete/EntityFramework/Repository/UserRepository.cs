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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context):base(context)//base kalıtım aldığımız yere arguman göndermek için kullanılır.
        {

        }

        public User Login(User loginUser)
        {
            var user = dbset.Where(u => u.Email == loginUser.Email && u.Password == loginUser.Password).SingleOrDefault();
            return user;
        }

        public User InsertUser(User insertUser)
        {
            _context.Entry(insertUser).State = EntityState.Added;
            dbset.Add(insertUser);
            return insertUser;
        }

        public User UpdateUser(User item)
        {
            dbset.Update(item);
            return item;
        }

        public bool DeleteUser(int id)
        {
            return Delete(GetById(id));
        }

        public bool DeleteUser(User item)
        {
            if (_context.Entry(item).State == EntityState.Detached)
            {
                _context.Attach(item);
            }
            return dbset.Remove(item) != null;//silme başarılıysa gönder.
        }
        public User GetByIdUser(int id)
        {
            return dbset.Find(id);
        }

        public List<User> GetListUser()
        {
            return dbset.ToList();
        }

    }
}
