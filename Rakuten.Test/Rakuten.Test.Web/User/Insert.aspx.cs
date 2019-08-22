using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rakuten.Test.Web.User
{
    public partial class Insert : System.Web.UI.Page
    {

        private readonly UserService.UserSoap _userService;

        public Insert()
	    {
            _userService = new UserService.UserSoapClient();
	    }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {

            try
            {
                UserService.AddUserResponse _response = _userService.AddUser(new UserService.AddUserRequest
                {
                    Body = new UserService.AddUserRequestBody
                    {
                        user = new UserService.User
                        {
                            DocumentId = this.DocumentId.Value,
                            Email = this.Email.Value,
                            FirstName = this.FirstName.Value,
                            LastName = this.LastName.Value,
                            Password = this.Password.Value,
                            Gender = this.Male.Checked ? (UserService.GenderType)Convert.ToInt32(this.Male.Value) : (UserService.GenderType)Convert.ToUInt32(this.Female.Value),
                            Addresses = new UserService.AddressData[1] { 
                                new UserService.AddressData { 
                                    Address = this.Address.Value, 
                                    Cellphone = this.Cellphone.Value, 
                                    City = this.City.Value,
                                    Country = this.Country.Value,
                                    District = this.District.Value,
                                    PhoneNumber = this.PhoneNumber.Value,
                                    State = this.State.Value,
                                    Type = (UserService.AddressType)Convert.ToInt32(this.AddressType.Value),
                                    ZipCode = this.ZipCode.Value
                                } 
                            }
                        }
                    }
                });

                if (!_response.Body.AddUserResult.HasError)
                {
                    this.MessageStatus.Text = "<div class='alert alert-success alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Inserir Usuário</strong><br /> Dados inseridos com sucesso!</div>";
                }
                else
                {
                    this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Inserir Usuário</strong><br /> Ocorreu o seguinte problema na operação: " + _response.Body.AddUserResult.ErrorMessage + "</div>";
                }
                
            }
            catch (Exception ex)
            {
                this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Inserir Usuário</strong><br /> Ocorreu o seguinte problema na operação: " + ex.Message + "</div>";
            }

        }
    
    }
}