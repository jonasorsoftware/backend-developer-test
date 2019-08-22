using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

namespace Rakuten.Test.Web.User
{
    public partial class Update : System.Web.UI.Page
    {

        private readonly UserService.UserSoap _userService;
        public UserService.User _user = new UserService.User();

        public Update()
        {
            _userService = new UserService.UserSoapClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    int id = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : -1;

                    if (id < 0)
                    {
                        IList<string> segments = Request.GetFriendlyUrlSegments();

                        if (segments.Count > 0) int.TryParse(segments[0], out id);
                    }

                    if (id > 0)
                    {
                        UserService.GetUserResponse _response = _userService.GetUser(new UserService.GetUserRequest { Body = new UserService.GetUserRequestBody { id = id } });

                        var _user = _response.Body.GetUserResult.Data;
                        var _addressData = _user.Addresses.FirstOrDefault();

                        this.AddressId.Value = _addressData.Id.ToString();
                        this.Id.Value = _user.Id.ToString();
                        this.Address.Value = _addressData.Address;
                        this.AddressType.Value = ((int)_addressData.Type).ToString();
                        this.Cellphone.Value = _addressData.Cellphone;
                        this.City.Value = _addressData.City;
                        this.Country.Value = _addressData.Country;
                        this.District.Value = _addressData.District;
                        this.DocumentId.InnerText = _user.DocumentId;
                        this.Email.InnerText = _user.Email;
                        this.Female.Checked = _user.Gender == UserService.GenderType.Female;
                        this.FirstName.Value = _user.FirstName;
                        this.LastName.Value = _user.LastName;
                        this.Male.Checked = _user.Gender == UserService.GenderType.Male;
                        this.PhoneNumber.Value = _addressData.PhoneNumber;
                        this.State.Items.FindByValue(_addressData.State).Selected = true;
                        this.ZipCode.Value = _addressData.ZipCode;
                    }
                    else
                    {
                        Response.Redirect("~/");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Modificar Usuário</strong><br /> Ocorreu o seguinte problema na operação: " + ex.Message + "</div>";
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserService.UpdateUserResponse _response = _userService.UpdateUser(new UserService.UpdateUserRequest
                {
                    Body = new UserService.UpdateUserRequestBody
                    {
                        user = new UserService.User
                        {
                            Id = Convert.ToInt32(this.Id.Value),
                            FirstName = this.FirstName.Value,
                            LastName = this.LastName.Value,
                            Gender = this.Male.Checked ? (UserService.GenderType)Convert.ToInt32(this.Male.Value) : (UserService.GenderType)Convert.ToUInt32(this.Female.Value),
                            Addresses = new UserService.AddressData[1] { 
                                new UserService.AddressData { 
                                    Id = Convert.ToInt32(this.AddressId.Value),
                                    UserId = Convert.ToInt32(this.Id.Value),
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

                if (!_response.Body.UpdateUserResult.HasError)
                {
                    this.MessageStatus.Text = "<div class='alert alert-success alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Modificar Usuário</strong><br /> Dados modificados com sucesso!</div>";
                }
                else
                {
                    this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Modificar Usuário</strong><br /> Ocorreu o seguinte problema na operação: " + _response.Body.UpdateUserResult.ErrorMessage + "</div>";
                }

            }
            catch (Exception ex)
            {
                this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Modificar Usuário</strong><br /> Ocorreu o seguinte problema na operação: " + ex.Message + "</div>";
            }
        }
    }
}