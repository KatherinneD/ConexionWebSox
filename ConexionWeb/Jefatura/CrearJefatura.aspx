<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearJefatura.aspx.cs" Inherits="ConexionWeb.Jefatura.CrearJefatura" Async="true" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <div class="form-horizontal">
        <br />
        <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
        <br />
        <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Código de célula:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtCodigo"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Nombre de célula:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtNombre"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Product Owner:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="col-md-2 form-control" runat="server" ID="listProductOwner"></asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Scrum Master:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="col-md-2 form-control" runat="server" ID="listScrumMaster"></asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Dirección:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="col-md-2 form-control" DataTextField="Direccion" DataValueField="Direccion" runat="server" ID="listDireccion"></asp:DropDownList></div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Estado:</span></div>
            <div  class="col-md-10">
                <asp:DropDownList runat="server" ID="lstEstados">
                    <asp:ListItem Value="Activo" Text="Activo"></asp:ListItem>
                    <asp:ListItem Value="Inactivo" Text="Inactivo"></asp:ListItem>
                    <asp:ListItem Value="EnUso" Text="En uso"></asp:ListItem>
                </asp:DropDownList> 
            </div>
        </div>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><asp:Button ID="btnActualizar"  CssClass="btn btn-default" Text="Crear" OnClick="btnActualizar_Click" runat="server" /></div>
            <div class="col-md-2"><asp:Button ID="btnCancelar"  CssClass="btn btn-default" Text="Cancelar" OnClick="btnCancelar_Click" runat="server" /></div>
        </div>
        
    </div>
</asp:Content>