using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rakuten.Test.WebService.Enum;

namespace Rakuten.Test.WebService.Model
{
    public class ServiceResponse
    {

        public ServiceResponse()
        {
            Status = ServiceResponseStatus.No;
        }

        public ServiceResponseStatus Status { get; set; }

    }
}