<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearControl.aspx.cs" Inherits="ConexionWeb.Control.CrearControl" Async="true" %>

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
            <div class="col-md-2"><span class="control-label">Código del control:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtCodigo"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Nombre del control:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtNombre"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Inciales del control:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" MaxLength="3" ID="txtIniciales"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Objetivo de control:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control" DataValueField="Codigo" DataTextField="ObjetivoDeControl" runat="server" ID="listObjetivosControl"></asp:DropDownList> </div>
        </div
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