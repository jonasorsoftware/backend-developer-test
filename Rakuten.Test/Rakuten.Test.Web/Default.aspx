<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Rakuten.Test.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Bem vindo a aplicação de teste da Rakuten</h1>
        <p>Segue abaixo alguns pontos que devem estar funcionando corretamente nesta aplicação e que serão avaliados por nós:</p>
        <ul>
            <li>
                <h3>Tela de usuários</h3>
                <small>A tela de usuários precisa estar com as ações de listar, inserir, alterar e remover funcionando corretamente</small>
            </li>
            <li>
                <h3>Inserir usuário</h3>
                <small>Adicionar verificação se o CPF já está cadastrado na base de dados (semelhante a verificação do e-mail)</small>
            </li>
            <li>
                <h3>Webservice de pedidos (Order.asmx)</h3>
                <small>Será necessário criar um serviço que exiba apenas os pedidos que não estão marcados como <strong>integrados</strong></small>
            </li>
        </ul>
        <p class="pull-right">Boa sorte!</p>
    </div>

</asp:Content>
