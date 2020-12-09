<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarAplicaciones.aspx.cs" Inherits="ConexionWeb.Aplicaciones.ConsultarAplicaciones" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de Aplicaciones</h2>
    <div class="form-horizontal">
        <div class ="form-group">
            <div class="col-md-2">
                <asp:FileUpload  CssClass="btn btn-default" runat="server" ID="cargarAplicacion" />
            </div>
         </div>
        <div class ="form-group">
        <div class="col-md-2">
                <asp:Button runat="server"  CssClass="btn btn-default" ID="btnCargarAplicacion" Text="Cargar registros" OnClick="btnCargarAplicacion_Click" />
            </div>
            </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvAplicacion" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvAplicacion_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código de aplicación" />
            <asp:BoundField DataField="NombreAplicacion" HeaderText="Nombre de aplicación" />
            <asp:BoundField DataField="Servidores" HeaderText="Servidores" />
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