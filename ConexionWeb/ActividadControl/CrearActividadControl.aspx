<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearActividadControl.aspx.cs" Inherits="ConexionWeb.ActividadControl.CrearActividadControl" Async="true" %>

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
            <div class="col-md-2"><span class="control-label">Código de actividad de control:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtCodigo"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Nombre de actividad de control:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtNombre"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Objetivo de control:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control" DataValueField="Codigo" DataTextField="ObjetivoDeControl" runat="server" ID="listObjetivosControl"></asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Riesgo SOX:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control" DataValueField="CodigoSOX" DataTextField="CodigoSOX" runat="server" ID="listRiesgosSOX"></asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Subdominio:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control" runat="server" ID="listDominios">
                <asp:ListItem Text="Dominio 1" Value="Dominio 1"></asp:ListItem>
                <asp:ListItem Text="Dominio 2" Value="Dominio 3"></asp:ListItem>
                <asp:ListItem Text="Dominio 4" Value="Dominio 4"></asp:ListItem>
                                   </asp:DropDownList></div>
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