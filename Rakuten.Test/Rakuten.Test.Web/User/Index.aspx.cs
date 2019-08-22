using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rakuten.Test.Web.User
{
    public partial class Index : System.Web.UI.Page
    {

        private readonly UserService.UserSoap _userService;

        public Index()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserService.GetUsersResponse _response = _userService.GetUsers(new UserService.GetUsersRequest { Body = new UserService.GetUsersRequestBody() });
                UserService.User[] _users = _response.Body.GetUsersResult.Data;

                this.ListUsers.DataSource = _users;
                this.ListUsers.DataBind();
            }
            catch (Exception ex)
            {
                this.MessageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in' role='alert'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button> <strong>Listar Usuários</strong><br /> Ocorreu o seguinte problema na operação: " + ex.Message + "</div>";
            }            
        }
    }
}