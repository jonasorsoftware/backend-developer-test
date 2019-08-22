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
    public class AddressBO : IDisposable
    {

        private readonly SqlConnection _connection;

        public AddressBO()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        }

        public List<AddressData> GetAll()
        {
            List<AddressData> _result = new List<AddressData>();

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "GetAddresses";
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

        public AddressData GetById(int id)
        {
            AddressData _result = null;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "GetAddresses";
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

        public bool Add(AddressData model)
        {
            bool _result = false;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "AddAddress";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
                    cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                    cmd.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@District", model.District);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@Country", model.Country);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Cellphone", model.Cellphone);

                    _result = cmd.ExecuteNonQuery() > 0;
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

        public bool Update(AddressData model)
        {
            bool _result = false;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "UpdateAddress";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", model.UserId);
                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
                    cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                    cmd.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@District", model.District);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@Country", model.Country);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Cellphone", model.Cellphone);
                  
                    _result = cmd.ExecuteNonQuery() > 0;
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

        private AddressData BindDataReader(SqlDataReader dr)
        {
            return new AddressData { 
                DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString()),
                DateModified = Convert.ToDateTime(dr["DateModified"].ToString()),
                Address = dr["Address"].ToString(),
                Cellphone = dr["Cellphone"].ToString(),
                City = dr["City"].ToString(),
                Country = dr["Country"].ToString(),
                District = dr["District"].ToString(),
                Id = Convert.ToInt32(dr["Id"].ToString()),
                PhoneNumber = dr["PhoneNumber"].ToString(),
                State = dr["State"].ToString(),
                Type = (AddressType)Convert.ToInt16(dr["Type"].ToString()),
                UserId = Convert.ToInt32(dr["UserId"].ToString()),
                ZipCode = dr["ZipCode"].ToString()
            };
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

    }
}
