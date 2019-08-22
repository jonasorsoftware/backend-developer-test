using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

namespace Rakuten.Test.Web.User
{
    public partial class Delete : System.Web.UI.Page
    {

        private readonly UserService.UserSoap _userService;

        public Delete()
        {
            _userService = new UserService.UserSoapClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : -1;

                if (id < 0)
                {
                    IList<string> segments = Request.GetFriendlyUrlSegments();

                    if (segments.Count > 0) int.TryParse(segments[0], out id);
                }

                if (id > 0)
                {
                    UserService.DeleteUserResponse _response = _userService.DeleteUser(new UserService.DeleteUserRequest { Body = new UserService.DeleteUserRequestBody { id = id } });

                    if (_response.Body.DeleteUserResult.Data.Status == UserService.ServiceResponseStatus.Yes)
                    {
                        this.MessageStatus.Text = "<div class='alert alert-success alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <p><strong>Remover Usuário</strong><br /> Dados removidos com sucesso!</p><p><a href=\"" + ResolveUrl("~/User/Index") + "\" class=\"btn btn-default\">Ok</a></p></div>";
                    }
                    else
                    {
                        this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <p><strong>Remover Usuário</strong><br /> Ocorreu o seguinte problema na operação: " + _response.Body.DeleteUserResult.ErrorMessage + "</p><p><a href=\"" + ResolveUrl("~/User/Index") + "\" class=\"btn btn-default\">Ok</a></p></div>";
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
            catch(Exception ex)
            {
                this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <p><strong>Remover Usuário</strong><br /> Ocorreu o seguinte problema na operação: " + ex.Message + "</p><p><a href=\"" + ResolveUrl("~/User/Index") + "\" class=\"btn btn-default\">Ok</a></p></div>";
            }
            
        }
    }
}