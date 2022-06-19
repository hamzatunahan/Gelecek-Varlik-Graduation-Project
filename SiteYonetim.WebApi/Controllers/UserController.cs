using SiteYonetim.WebApi.Base;
using SiteYonetim.Bll;
using SiteYonetim.Entity.Base;
using SiteYonetim.Entity.Dto.DtoUser;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Entity.Models;
using SiteYonetim.Interface;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly TokenManager tokenManager;
        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        public IResponse<DtoUserLoginResp> Login(DtoUserLoginRequest loginRequest)
        {
            try
            {
                return userService.Login(loginRequest);
                
            }
            catch (Exception ex)
            {
                return new Response<DtoUserLoginResp>
                {
                    StatusCode=StatusCodes.Status500InternalServerError,
                    Message="işlem başarısız"+ex.Message,
                    Data=null
                    
                };
                
            }
        }


        [HttpPost("InsertUser")]
        public IResponse<DtoViewUser> InsertUser(DtoInsertUser insertUser) 
        {
            return userService.InsertUser(insertUser);
            
        }

        [HttpPut("UpdateUser")]
        public IResponse<DtoViewUser> UpdateUser(DtoViewUser updateUser)
        {
            return userService.UpdateUser(updateUser);

        }

        [HttpGet("GetByIdUser")]
        public IResponse<DtoViewUser> GetById(int id)
        {
            try
            {
                return userService.GetByIdUser(id);
            }
            catch (Exception)
            {
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "GetByIdUser Başarısız",
                    Data = null
                };
            }
        }

        [HttpDelete("Delete")]
        public IResponse<bool> Delete(int id)
        {
            try
            {
                return userService.DeleteUser(id);
            }
            catch (Exception)
            {

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Delete Başarısız",
                    Data = false

                };

            }
        }

        [HttpGet("GetList")]
        public IResponse<List<DtoViewUser>> GetList()
        {
            try
            {
                return userService.GetListUser();
            }
            catch (Exception)
            {
                return new Response<List<DtoViewUser>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "GetList Başarısız.",
                    Data = null
                };
            }
        }

    }
}
