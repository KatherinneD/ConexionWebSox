<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="CrearCampo.aspx.cs" Inherits="ConexionWeb.CamposMatriz.CrearCampo" Async="true" %>
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
            <div class="col-md-2"><span class="control-label">Código de campo:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtCodigo"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Nombre de campo:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtNombre"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Categoría:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control" runat="server" ID="listCategoria">
                <asp:ListItem Text="Control ITGC´s" Value="ControlITGC"></asp:ListItem>
                <asp:ListItem Text="Identificación Control" Value="IdentificacionControl"></asp:ListItem>
                <asp:ListItem Text="Evidencia" Value="Evidencia"></asp:ListItem>
                <asp:ListItem Text="Calidad de la evidencia" Value="CalidadEvidencia"></asp:ListItem>
                <asp:ListItem Text="Control compensatorio" Value="ControlCompensatorio"></asp:ListItem>
                                   </asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Campo Padre:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control" DataValueField="Codigo" DataTextField="Nombre" runat="server" ID="listCampoPadre"></asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Opciones:</span></div>
            <div class="col-md-10"><asp:CheckBoxList DataValueField="Valor" DataTextField="Valor" runat="server" ID="listOpciones"></asp:CheckBoxList> </div>
        </div>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><asp:Button ID="btnActualizar"  CssClass="btn btn-default" Text="Crear" OnClick="btnActualizar_Click" runat="server" /></div>
            <div class="col-md-2"><asp:Button ID="btnCancelar"  CssClass="btn btn-default" Text="Cancelar" OnClick="btnCancelar_Click" runat="server" /></div>
        </div>
        
    </div>
</asp:Content>