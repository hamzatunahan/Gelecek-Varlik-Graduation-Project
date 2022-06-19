using SiteYonetim.Entity.Dto.DtoUser;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Interface
{
    public interface IUserService:IGenericService<User,DtoViewUser>
    {
        public IResponse<DtoUserLoginResp> Login(DtoUserLoginRequest loginUser);

        IResponse<DtoViewUser> InsertUser(DtoInsertUser insertUser, bool saveChanges = true);

        IResponse<DtoViewUser> UpdateUser(DtoViewUser updateUser, bool saveChanges = true);
        IResponse<List<DtoViewUser>> GetListUser();
        IResponse<DtoViewUser> GetByIdUser(int id);
        IResponse<bool> DeleteUser(int id, bool saveChanges = true);
    }
}
