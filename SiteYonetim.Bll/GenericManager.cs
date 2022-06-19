using SiteYonetim.Entity.Base;
using SiteYonetim.Entity.IBase;
using SiteYonetim.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using SiteYonetim.Dal.Abstract;
using Microsoft.AspNetCore.Http;

namespace SiteYonetim.Bll
{
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
         #region Variables
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        #endregion

        #region Constructor

        public GenericManager(IServiceProvider service)
        {
            this.service = service;
            unitOfWork = service.GetService<IUnitOfWork>();

            repository = unitOfWork.GetRepository<T>();
        }
        #endregion
        public IResponse<bool> Delete(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);
                if (saveChanges)
                {
                    Save();
                }

                return new Response<bool>
                {
                    StatusCode=StatusCodes.Status200OK,
                    Message=" Başarılı",
                    Data=true
                };
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = " Başarısız.",
                    Data=false
                };

                
            }
        }

        public IResponse<TDto> GetById(int id)
        {
            try
            {
                var result =ObjectMapper.Mapper.Map<TDto>(repository.GetById(id));

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = " Başarılı",
                    Data = result
                };
            }
            catch (Exception)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = " Başarısız.",
                    Data = null
                };
                
            }
        }

        public IResponse<List<TDto>> GetList()
        {
            try
            {
                var list = repository.GetList();
                var result = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = " Başarılı",
                    Data = result
                };


            }
            catch (Exception)
            {

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = " Başarısız.",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetList(Expression<Func<T, bool>> expression)
        {
            try
            {
                var list = repository.GetList(expression);
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = " Başarılı.",
                    Data = listDto
                };
            }
            catch (Exception)
            {

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = " Başarısız.",
                    Data = null
                };
            }
        }

        public IResponse<IQueryable<TDto>> GetQueryable()
        {
            try
            {
                var list = repository.GetQueryable();
                var result = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x));
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = " Başarılı",
                    Data = result
                };


            }
            catch (Exception)
            {

                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = " Başarısız.",
                    Data = null
                };
            }
        }

        public IResponse<TDto> Insert(TDto item, bool saveChanges = true)
        {
            try
            {
                var result = repository.Insert(ObjectMapper.Mapper.Map<T>(item));//DTO yu T ye dönüştürüp ekleme yapıyoruz.
                if (saveChanges)
                {
                    Save();
                }
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = " Başarılı.",
                    Data = ObjectMapper.Mapper.Map<TDto>(result)
                };
            }
            catch (Exception)
            {

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "İşlem Başarısız.",
                    Data = null
                };
            }
        }


        public IResponse<TDto> Update(TDto item,bool saveChanges = true)
        {
            try
            {
                var result = repository.Update(ObjectMapper.Mapper.Map<T>(item));//DTO yu T ye dönüştürüp ekleme yapıyoruz.
               
                if (saveChanges)
                {
                    Save();
                }
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = " Başarılı.",
                    Data = ObjectMapper.Mapper.Map<TDto>(result)
                };
            }
            catch (Exception)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = " Başarısız.",
                    Data = null
                };

            }
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }
    }
}
