<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="Rakuten.Test.Web.User.Insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Literal ID="MessageStatus" runat="server"></asp:Literal>
    <h3>Inserir Usuário</h3>
    <br />
    <div class="form-group">
        <label for="<%=this.FirstName.ClientID %>">Nome</label>
        <input type="text" class="form-control" id="FirstName" runat="server" placeholder="Nome" data-required="true" />
    </div>
    <div class="form-group">
        <label for="<%=this.LastName.ClientID %>">Sobrenome</label>
        <input type="text" class="form-control" id="LastName" runat="server" placeholder="Sobrenome" data-required="true" />
    </div>
    <div class="form-group">
        <label class="radio-inline">
            <input type="radio" name="Gender" id="Male" runat="server" value="0" checked /> Masculino
        </label>    
        <label class="radio-inline">
            <input type="radio" name="Gender" id="Female" runat="server" value="1" /> Feminino
        </label>
    </div>
    <div class="form-group">
        <label for="<%=this.DocumentId.ClientID %>">CPF</label>
        <input type="text" class="form-control" id="DocumentId" runat="server" placeholder="CPF" data-required="true" data-mask="cpf" />
    </div>
    <div class="form-group">
        <label for="<%=this.Email.ClientID %>">Email</label>
        <input type="email" class="form-control" id="Email" runat="server" placeholder="Email" data-required="true" />
    </div>
    <div class="form-group">
        <label for="<%=this.Password.ClientID %>">Senha</label>
        <input type="password" class="form-control" id="Password" runat="server" placeholder="Senha" data-required="true" />
    </div>
    <div class="form-group">
        <label for="<%=this.PasswordConfirm.ClientID %>">Confirmação da senha</label>
        <input type="password" class="form-control" id="PasswordConfirm" runat="server" placeholder="Confirmação da senha" data-required="true" />
    </div>
    <br />

    <input type="hidden" id="AddressType" runat="server" value="1" />
    <input type="hidden" id="Country" runat="server" value="Brasil" />
    <div class="form-group">
        <label for="<%=this.ZipCode.ClientID %>">CEP</label>
        <input type="text" class="form-control" id="ZipCode" runat="server" placeholder="CEP" data-required="true" data-mask="cep" />
    </div>
    <div class="form-group">
        <label for="<%=this.Address.ClientID %>">Logradouro</label>
        <input type="text" class="form-control" id="Address" runat="server" placeholder="Logradouro" data-required="true" />
    </div>
    <div class="form-group">
        <label for="<%=this.District.ClientID %>">Bairro</label>
        <input type="text" class="form-control" id="District" runat="server" placeholder="Bairro" data-required="true" />
    </div>
    <div class="form-group">
        <label for="<%=this.City.ClientID %>">Cidade</label>
        <input type="text" class="form-control" id="City" runat="server" placeholder="Cidade" data-required="true" />
    </div>
    <div class="form-group">
        <label for="<%=this.State.ClientID %>">Estado</label>
        <select id="State" runat="server" class="form-control" data-required="true">
            <option value="">-</option>
            <option value="AC">Acre</option>
            <option value="AP">Amapá</option>
            <option value="AM">Amazonas</option>
            <option value="AL">Alagoas</option>
            <option value="BA">Bahia</option>
            <option value="CE">Ceará</option>
            <option value="DF">Distrito Federal</option>
            <option value="ES">Espírito Santo</option>
            <option value="GO">Goiás</option>            
            <option value="MA">Maranhão</option>
            <option value="MT">Mato Grosso</option>
            <option value="MS">Mato Grosso do Sul</option>
            <option value="MG">Minas Gerais</option>
            <option value="PA">Pará</option>
            <option value="PB">Paraíba</option>
            <option value="PR">Paraná</option>
            <option value="PE">Pernambuco</option>
            <option value="PI">Piauí</option>            
            <option value="RJ">Rio de Janeiro</option>            
            <option value="RN">Rio Grande do Norte</option>
            <option value="RS">Rio Grande do Sul</option>
            <option value="RO">Rondônia</option>
            <option value="RR">Roraima</option>
            <option value="SC">Santa Catarina</option>
            <option value="SP">São Paulo</option>                        
            <option value="SE">Sergipe</option>
            <option value="TO">Tocantins</option>
        </select>
    </div>
    <div class="form-group">
        <label for="<%=this.PhoneNumber.ClientID %>">Telefone</label>
        <input type="text" class="form-control" id="PhoneNumber" runat="server" placeholder="Telefone" data-required="true" data-mask="phone" />
    </div>
    <div class="form-group">
        <label for="<%=this.Cellphone.ClientID %>">Celular</label>
        <input type="text" class="form-control" id="Cellphone" runat="server" placeholder="Celular" data-mask="cellphone" />
    </div>
    
    <asp:LinkButton ID="InsertButton" runat="server" CssClass="btn btn-default" Text="Inserir" OnClick="InsertButton_Click"></asp:LinkButton>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FooterContent" runat="server">
    <script type="text/javascript">
        
        var _emailExists = false;

        $(function () {

            $('#<%=this.InsertButton.ClientID%>').on('click', function () {                               

                var isValid = true;

                $('[data-required]').each(function (i) {
                    
                    $(this).parents('div.form-group').removeClass('has-error');

                    if ($(this).is('input')) {
                        if ($(this).val().trim().lenght == 0) {
                            isValid = false;
                            $(this).parents('div.form-group').addClass('has-error');
                        }                            
                    } else if ($(this).is('select')) {
                        if ($(this).find('option:selected').val().trim().length == 0) {
                            isValid = false;
                            $(this).parents('div.form-group').addClass('has-error');
                        }
                    }

                });

                if ($('#<%=this.Password.ClientID%>').val().trim() != $('#<%=this.PasswordConfirm.ClientID%>').val().trim()) {
                    isValid = false;
                    $('#<%=this.Password.ClientID%>').parents('div.form-group').addClass('has-error');
                    $('#<%=this.PasswordConfirm.ClientID%>').parents('div.form-group').addClass('has-error');
                }

                if (_emailExists) {
                    isValid = false;
                    $('#<%=this.Email.ClientID%>').parents('div.form-group').addClass('has-error');
                }
                
                if (isValid) {
                    __doPostBack('ctl00$MainContent$InsertButton', '');
                }

                return false;
                
            });            

            $('#<%=this.Email.ClientID%>').on('change', function (e) {

                var root = this;

                $.ajax({
                    url: '<%=ResolveUrl("~/Email.ashx") %>',
                    method: 'POST',
                    data: { email: $(root).val() },
                    success: function (data) {

                        _emailExists = data.status;

                        if (_emailExists) {
                            $(root).parents('div.form-group').addClass('has-error');
                        } else {
                            $(root).parents('div.form-group').removeClass('has-error');
                        }
                    }
                });
            });

            $('input[data-mask]').each(function () {
                var input = $(this);
                input.setMask(input.data('mask'));
            });

        });
    </script>
</asp:Content>