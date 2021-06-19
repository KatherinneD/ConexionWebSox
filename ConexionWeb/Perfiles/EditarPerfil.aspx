<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditarPerfil.aspx.cs" Inherits="ConexionWeb.Perfiles.EditarPerfil" Async="true"%>

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
            <div class="col-md-2"><span class="control-label">Nombre de rol:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ReadOnly="true" ID="txtRol"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Usuarios asignados:</span></div>
            <div class="col-md-10"><asp:CheckBoxList DataTextField="Email" runat="server" ID="listUsuariosSeleccionados"></asp:CheckBoxList></div>
        </div>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><asp:Button ID="btnActualizar"  CssClass="btn btn-default" Text="Actualizar" OnClick="btnActualizar_Click" runat="server" /></div>
            <div class="col-md-2"><asp:Button ID="btnCancelar"  CssClass="btn btn-default" Text="Cancelar" OnClick="btnCancelar_Click" runat="server" /></div>
        </div>
    </div>
</asp:Content>