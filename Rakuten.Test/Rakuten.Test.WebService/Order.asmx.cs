using Rakuten.Test.WebService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Rakuten.Test.Core.Model;
using Rakuten.Test.Core.Business;

namespace Rakuten.Test.WebService
{
    /// <summary>
    /// Summary description for Order
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Order : System.Web.Services.WebService
    {

        private readonly OrderBO _orderBO;

        public Order()
        {
            _orderBO = new OrderBO();
        }

        [WebMethod(Description = "Retorna um determinado pedido da loja")]
        public ServiceResult<Core.Model.Order> GetOrder(int id)
        {
            ServiceResult<Core.Model.Order> result = new ServiceResult<Core.Model.Order>();

            try
            {
                result.Data = _orderBO.GetById(id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        [WebMethod(Description = "Retorna a listagem de todos os pedidos realizados na loja")]
        public ServiceResult<List<Core.Model.Order>> GetOrders()
        {
            ServiceResult<List<Core.Model.Order>> result = new ServiceResult<List<Core.Model.Order>>();

            result.Data = new List<Core.Model.Order>();

            try
            {
                result.Data = _orderBO.GetAll();
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