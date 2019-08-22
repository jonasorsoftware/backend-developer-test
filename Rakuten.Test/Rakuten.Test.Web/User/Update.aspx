<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Rakuten.Test.Web.User.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Literal ID="MessageStatus" runat="server"></asp:Literal>
    <h3>Modificar Usuário</h3>
    <br />

    <input type="hidden" id="Id" runat="server" />
    <input type="hidden" id="AddressId" runat="server" />
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
        <label class="col-sm-2 control-label">CPF</label>
        <p class="form-control-static" id="DocumentId" runat="server"></p>
    </div>
    <div class="form-group">
        <label class="col-sm-2 control-label">Email</label>
        <p class="form-control-static" id="Email" runat="server"></p>
    </div>
    <br />

    <input type="hidden" id="AddressType" runat="server" />
    <input type="hidden" id="Country" runat="server" />
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
    
    <asp:LinkButton ID="UpdateButton" runat="server" CssClass="btn btn-default" Text="Modificar" OnClick="UpdateButton_Click"></asp:LinkButton>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FooterContent" runat="server">
    <script type="text/javascript">
        $(function () {

            $('#<%=this.UpdateButton.ClientID%>').on('click', function () {
                
                var isValid = true;

                $('[data-required]').each(function (i) {
                    
                    $(this).parents('div.form-group').removeClass('has-error');

                    if ($(this).is('input')) {
                        if ($(this).val().trim().length == 0) {
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

                if (isValid) {
                    __doPostBack('ctl00$MainContent$UpdateButton', '')_;
                }

                return false;
                
            });

            $('input[data-mask]').each(function () {
                var input = $(this);
                input.setMask(input.data('mask'));
            });

        });
    </script>
</asp:Content>