using SiteYonetim.Dal.Abstract;
using SiteYonetim.Entity.Dto.DtoMessage;
using SiteYonetim.Entity.Dto.DtoUser;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Entity.Models;
using SiteYonetim.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SiteYonetim.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SiteYonetim.Bll
{
    public class UserManager : GenericManager<User, DtoViewUser>, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IGenericRepository<Apartman> apartmanRepo;
        private IConfiguration configuration;
        public UserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            apartmanRepo = service.GetService<IGenericRepository<Apartman>>();
            this.configuration = configuration;
        }
        public static string GeneratePassword(int Length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder buildPass = new StringBuilder();
            Random randomVal = new Random();
            while (0 < Length--)
            {
                buildPass.Append(chars[randomVal.Next(chars.Length)]);
            }
            return buildPass.ToString();
        }

        public IResponse<bool> DeleteUser(int id, bool saveChanges = true)
        {
            try
            {
                userRepository.DeleteUser(id);
                if (saveChanges)
                {
                    Save();
                }

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Kullanıcı Silindi.",
                    Data = true
                };
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "DeleteUser Başarısız.",
                    Data = false
                };


            }
        }

        public IResponse<DtoViewUser> GetByIdUser(int id)
        {
            try
            {
                var result = ObjectMapper.Mapper.Map<DtoViewUser>(userRepository.GetByIdUser(id));

                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "GetByIdUser Başarılı",
                    Data = result
                };
            }
            catch (Exception)
            {
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "GetByIdUser Başarısız.",
                    Data = null
                };

            }
        }

        public IResponse<List<DtoViewUser>> GetListUser()
        {
            try
            {
                var list = userRepository.GetListUser();
                var result = list.Select(x => ObjectMapper.Mapper.Map<DtoViewUser>(x)).ToList();
                return new Response<List<DtoViewUser>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "GetListUser Başarılı",
                    Data = result
                };


            }
            catch (Exception)
            {

                return new Response<List<DtoViewUser>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "GetListUser Başarısız.",
                    Data = null
                };
            }
        }

        public IResponse<DtoViewUser> InsertUser(DtoInsertUser insertUser, bool saveChanges = true)
        {
            try
            {
                var result = userRepository.InsertUser(ObjectMapper.Mapper.Map<User>(insertUser));
               
                    //repository.Insert(ObjectMapper.Mapper.Map<T>(item));//DTO yu T ye dönüştürüp ekleme yapıyoruz.
                if (saveChanges)
                {
                    result.InDateTime = DateTime.Now;
                    result.IsActive = true;
                    result.IsDeleted = false;
                    result.Password = GeneratePassword(8);
                    Save();
                }
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Kullanıcı Ekleme İşlemi Başarılı.",
                    Data = ObjectMapper.Mapper.Map<DtoViewUser>(result)
                };
            }
            catch (Exception)
            {

                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "InsertUser Başarısız.",
                    Data = null
                };
            }

        }


        public IResponse<DtoUserLoginResp> Login(DtoUserLoginRequest loginUser)
        {
            var user = userRepository.Login(ObjectMapper.Mapper.Map<User>(loginUser));
            if (user !=null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLogin>(user);
                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);
                
                var userToken = new DtoUserLoginResp()
                {
                    DtoLogin=dtoUser,
                    AccessToken=token
                };

                return new Response<DtoUserLoginResp>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Login başarılı.",
                    Data=userToken
                    
                };
            }
            else
            {
                return new Response<DtoUserLoginResp>
                {
                    Message = "Email veya parola yanlış."
                };
            }
        }

        public IResponse<DtoViewUser> UpdateUser(DtoViewUser updateUser, bool saveChanges = true)
        {
            try
            {
                var result = userRepository.UpdateUser(ObjectMapper.Mapper.Map<User>(updateUser));
                if (saveChanges)
                {
                    Save();
                }
                if (result is null)
                {
                    return new Response<DtoViewUser>
                    {
                        Message = "Kullanıcı bulunamadı"
                    };
                }
                if (result.ApartmanId is not null && updateUser.ApartmanId == null)
                {
                    var apartman = apartmanRepo.GetById((int)result.ApartmanId);
                    apartman.IsEmpty = true;
                    apartman.DaireId = null;
                }

                result.UpDateTime = DateTime.Now;
                
                return new Response<DtoViewUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = " Başarılı.",
                    Data = ObjectMapper.Mapper.Map<DtoViewUser>(result)
                };
            }
            catch 
            {

                throw;
            }
            
        }
    }
}
