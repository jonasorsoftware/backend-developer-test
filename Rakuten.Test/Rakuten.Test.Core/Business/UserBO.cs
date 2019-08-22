using Rakuten.Test.Core.Enum;
using Rakuten.Test.Core.Helpers;
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
    public class UserBO : IDisposable
    {

        private readonly SqlConnection _connection;

        public UserBO()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        }

        public List<User> GetAll()
        {
            List<User> _result = new List<User>();

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "GetUsers";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _result.Add(BindUserDataReader(dr));
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

        public User GetById(int id)
        {
            User _result = null;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "GetUsers";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _result = BindUserDataReader(dr);
                    }

                    dr.NextResult();

                    while (dr.Read())
                    {
                        _result.Addresses.Add(BindAddressDataReader(dr));
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

        public bool Exists(string email = null, string documentId = null)
        {
            bool _result = false;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "GetUsers";
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(email)) cmd.Parameters.AddWithValue("@Email", email);
                    else if (!string.IsNullOrEmpty(documentId)) cmd.Parameters.AddWithValue("@DocumentId", documentId);

                    SqlDataReader dr = cmd.ExecuteReader();

                    _result = dr.HasRows;

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

        public bool Add(User model)
        {
            bool _result = false;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {                    
                    cmd.CommandText = "AddUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Gender", (int)model.Gender);
                    cmd.Parameters.AddWithValue("@DocumentId", model.DocumentId);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Password", Security.HashSHA1(model.Password));

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        model.Id = Convert.ToInt32(dr["Id"].ToString());
                    }

                    dr.Close();
                    dr.Dispose();

                    _result = true;
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

        public bool Update(User model)
        {
            bool _result = false;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "UpdateUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Gender", (int)model.Gender);
                  
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

        public bool Delete(int id)
        {
            bool _result = false;

            try
            {
                _connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "DeleteUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

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

        private User BindUserDataReader(SqlDataReader dr)
        {
            return new User { 
                DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString()),
                DateModified = Convert.ToDateTime(dr["DateModified"].ToString()),
                DocumentId = dr["DocumentId"].ToString(),
                Email = dr["Email"].ToString(),
                FirstName = dr["FirstName"].ToString(),
                Gender = (GenderType)Convert.ToInt16(dr["Gender"].ToString()),
                Id = Convert.ToInt32(dr["Id"].ToString()),
                Integrated = Convert.ToBoolean(dr["Integrated"].ToString()),
                LastName = dr["LastName"].ToString()
            };
        }

        private AddressData BindAddressDataReader(SqlDataReader dr)
        {
            return new AddressData
            {
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
