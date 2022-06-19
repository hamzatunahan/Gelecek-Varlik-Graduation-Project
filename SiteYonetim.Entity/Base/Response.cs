using SiteYonetim.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Entity.Base
{
    public class Response:IResponse//sadece bir değer döndürüceksem sistem generik olan clası çalıştırmasın diye yazdık
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
    public  class Response<T> : IResponse<T>//Tdto da olabilir.Komplex datalar için bura çalışır.
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
