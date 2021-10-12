using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro.WebApi.Models
{
    public class ApiResult
    {
        public object data { get; set; }
        public int code { get; set; }
    }
}