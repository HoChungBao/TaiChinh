using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class UploadFileApi
    {
        public byte[] Data { get; set; }
        public string FileName { get; set; }

    }
    public class UploadFileApiResult
    {
        public string Url { get; set; }
        public string FileName { get; set; }
    }
}
