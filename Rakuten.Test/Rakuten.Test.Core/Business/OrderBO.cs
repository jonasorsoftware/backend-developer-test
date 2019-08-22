using Rakuten.Test.Core.Enum;
using Rakuten.Test.Core.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakuten.Test.Core.Business
{
    public class OrderBO : IDisposable
    {

        private readonly SqlConnection _connection;

        public OrderBO()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        }

        public List<Order> GetAll()
        {
            List<Order> _result = new List<Order>();

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "GetOrders";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _result.Add(BindDataReader(dr));
                    }

                    dr.Close();
                    dr.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open) _connection.Close();
            }

            return _result;
        }

        public Order GetById(int id)
        {
            Order _result = null;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "GetOrders";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _result = BindDataReader(dr);
                    }

                    dr.Close();
                    dr.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open) _connection.Close();
            }

            return _result;
        }

        private Order BindDataReader(SqlDataReader dr)
        {
            return new Order { 
                DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString()),
                DateModified = Convert.ToDateTime(dr["DateModified"].ToString()),
                Address = dr["Address"].ToString(),
                City = dr["City"].ToString(),
                Country = dr["Country"].ToString(),
                District = dr["District"].ToString(),
                Id = Convert.ToInt32(dr["Id"].ToString()),
                PhoneNumber = dr["PhoneNumber"].ToString(),
                State = dr["State"].ToString(),
                AddressType = (AddressType)Convert.ToInt16(dr["AddressType"].ToString()),
                UserId = Convert.ToInt32(dr["UserId"].ToString()),
                ZipCode = dr["ZipCode"].ToString(),
                Amount = Convert.ToDecimal(dr["Amount"].ToString()),
                CurrentStatus = (OrderStatus)Convert.ToInt16(dr["CurrentStatus"].ToString()),
                Email = dr["Email"].ToString(),
                FirstName = dr["FirstName"].ToString(),
                Integrated = Convert.ToBoolean(dr["Integrated"].ToString()),
                LastName = dr["LastName"].ToString(),
                Shipping = Convert.ToDecimal(dr["Shipping"].ToString())
            };
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

    }
}
