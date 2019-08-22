using Rakuten.Test.Core.Business;
using Rakuten.Test.WebService.Enum;
using Rakuten.Test.WebService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Rakuten.Test.WebService
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {

        private readonly UserBO _userBO;
        private readonly AddressBO _addressBO;

        public User()
        {
            _userBO = new UserBO();
            _addressBO = new AddressBO();
        }

        [WebMethod(Description = "Retorna um determinado usuário da loja")]
        public ServiceResult<Core.Model.User> GetUser(int id)
        {
            ServiceResult<Core.Model.User> result = new ServiceResult<Core.Model.User>();

            try
            {
                result.Data = _userBO.GetById(id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        [WebMethod(Description = "Retorna a listagem de todos os usuários existentes na loja")]
        public ServiceResult<List<Core.Model.User>> GetUsers()
        {
            ServiceResult<List<Core.Model.User>> result = new ServiceResult<List<Core.Model.User>>();

            result.Data = new List<Core.Model.User>();

            try
            {
                result.Data = _userBO.GetAll();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        [WebMethod(Description = "Insere um usuário na loja")]
        public ServiceResult<Core.Model.User> AddUser(Core.Model.User user)
        {
            ServiceResult<Core.Model.User> result = new ServiceResult<Core.Model.User>();

            try
            {
                _userBO.Add(user);

                var _address = user.Addresses.FirstOrDefault();
                _address.UserId = user.Id;

                _addressBO.Add(_address);

                result.Data = user;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        [WebMethod(Description = "Modifica um usuário da loja")]
        public ServiceResult<Core.Model.User> UpdateUser(Core.Model.User user)
        {
            ServiceResult<Core.Model.User> result = new ServiceResult<Core.Model.User>();

            try
            {                
                var address = user.Addresses.FirstOrDefault();

                _userBO.Update(user);
                _addressBO.Update(address);

                result.Data = user;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        [WebMethod(Description = "Remove um usuário da loja")]
        public ServiceResult<ServiceResponse> DeleteUser(int id)
        {
            ServiceResult<ServiceResponse> result = new ServiceResult<ServiceResponse>();

            try
            {
                result.Data = new ServiceResponse();
                result.Data.Status = (_userBO.Delete(id)) ? ServiceResponseStatus.Yes : ServiceResponseStatus.No;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        [WebMethod(Description = "Verifica se o email existe na base da loja")]
        public ServiceResult<ServiceResponse> EmailExists(string email)
        {
            ServiceResult<ServiceResponse> result = new ServiceResult<ServiceResponse>();

            try
            {
                result.Data = new ServiceResponse();
                result.Data.Status = _userBO.Exists(email.Trim(), null) ? ServiceResponseStatus.Yes : ServiceResponseStatus.No;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        [WebMethod(Description = "Verifica se o CPF existe na base da loja")]
        public ServiceResult<ServiceResponse> DocumentExists(string documentId)
        {
            ServiceResult<ServiceResponse> result = new ServiceResult<ServiceResponse>();
            
            try
            {
                result.Data = new ServiceResponse();
                result.Data.Status = _userBO.Exists(null, documentId.Trim()) ? ServiceResponseStatus.Yes : ServiceResponseStatus.No;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }


    }
}
