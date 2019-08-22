<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Rakuten.Test.Web.User.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Literal ID="MessageStatus" runat="server"></asp:Literal>
    <h3>Listar Usuários</h3>
    <br />
    <p class="pull-right"><a href="<%=ResolveUrl("~/User/Insert") %>" class="btn btn-success"><span class="glyphicon glyphicon-plus-sign"></span> Inserir Usuário</a></p>
    <asp:Repeater ID="ListUsers" runat="server">    
        <HeaderTemplate>
            <table class="table table-striped table-bordered">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Sobrenome</th>
                        <th>CPF</th>
                        <th>Email</th>
                        <th>Ações</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                <td><%#DataBinder.Eval(Container.DataItem, "LastName") %></td>
                <td><%#DataBinder.Eval(Container.DataItem, "DocumentId") %></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Email") %></td>
                <td><a href="<%=ResolveUrl("~/User/Update/") %><%#DataBinder.Eval(Container.DataItem, "Id") %>" class="btn btn-primary"><span class="glyphicon glyphicon-pencil"></span> Editar</a>&nbsp;
                    <a href="javascript:Delete(<%#DataBinder.Eval(Container.DataItem, "Id") %>);" class="btn btn-danger"><span class="glyphicon glyphicon-trash"></span> Remover</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FooterContent" runat="server">
    <script type="text/javascript">

        function Delete(id) {

            if (confirm("Você tem certeza que deseja remover este usuário")) {
                document.location = '<%=ResolveUrl("~/User/Delete/")%>' + id;
            }

        }

    </script>
</asp:Content>