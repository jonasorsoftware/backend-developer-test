using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rakuten.Test.WebService.Model
{
    public class ServiceResult<T> where T : class
    {

        public T Data { get; set; }

        public bool HasError { get; set; }

        public string ErrorMessage { get; set; }

    }
}