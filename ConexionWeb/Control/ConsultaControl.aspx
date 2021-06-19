<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ConsultaControl.aspx.cs" Inherits="ConexionWeb.Control.ConsultaControl" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de Control</h2>
    <div class="form-horizontal">
        <div class ="form-group">
            <div class="col-md-2">
                <asp:FileUpload  CssClass="btn btn-default" runat="server" ID="cargarControl" />
            </div>
         </div>
        <div class ="form-group">
        <div class="col-md-2">
                <asp:Button runat="server"  CssClass="btn btn-default" ID="btnCargarControl" Text="Cargar registros" OnClick="btnCargarControl_Click" />
            </div>
            </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvControl" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvControl_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="sControl" HeaderText="Nombre del control" />
            <asp:BoundField DataField="InicialesControl" HeaderText="Iniciales del control" />
            <asp:BoundField DataField="Objetivo" HeaderText="Objetivo del Control" />
            <asp:BoundField DataField="UsuarioModificador" HeaderText="Usuario que modifica" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="editButton" CssClass="gridButton" runat="server" ImageUrl="~/Images/edit.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>