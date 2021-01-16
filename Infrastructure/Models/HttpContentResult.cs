using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class HttpContentResult<T>
    {
        public bool Result { get; set; }
        public string StatusCode { get; set; } = "";
        public string Message { get; set; } = "";
        public string SysMessage { get; set; } = "";
        public int TotalItem { get; set; } = 0;
        public T Data { get; set; }
        public HttpContentResult()
        {
            Fail();
            Message = MessageResultJson.Fail;
        }
        public void Success()
        {
            Result = true;
            StatusCode = "200";
        }

        public void Fail()
        {
            Result = false;
            StatusCode = "400";
        }
    }
    public class MessageResultJson
    {
        public static string Success { get; set; } = "Thành công";
        public static string Fail { get; set; } = "Thất bại";
    }
}
