using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rakuten.Test.Web
{
    /// <summary>
    /// Summary description for Email
    /// </summary>
    public class Email : IHttpHandler
    {

        private UserService.UserSoap _userService;

        public Email()
        {
            _userService = new UserService.UserSoapClient();
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            bool result = false;

            try
            {
                var _exists = _userService.EmailExists(new UserService.EmailExistsRequest { Body = new UserService.EmailExistsRequestBody { email = context.Request["email"] } });
                result = _exists.Body.EmailExistsResult.Data.Status == UserService.ServiceResponseStatus.Yes;
            }
            catch
            {
                result = false;
            }

            context.Response.Write(JsonConvert.SerializeObject(new { status = result }));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}