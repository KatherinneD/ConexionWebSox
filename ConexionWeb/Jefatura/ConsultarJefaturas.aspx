<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarJefaturas.aspx.cs" Inherits="ConexionWeb.Jefatura.ConsultarJefaturas" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de jefaturas y áreas</h2>
    <div class="form-horizontal">
        <div class ="form-group">
            <div class="col-md-2">
                <asp:FileUpload  CssClass="btn btn-default" runat="server" ID="cargarJefatura" />
            </div>
         </div>
        <div class ="form-group">
        <div class="col-md-2">
                <asp:Button runat="server"  CssClass="btn btn-default" ID="btnCargarJefatura" Text="Cargar registros" OnClick="btnCargarJefatura_Click" />
            </div>
            </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvJefatura" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvJefatura_RowDataBound">
        <Columns>
            <asp:BoundField DataField="CodigoArea" HeaderText="Área" />
            <asp:BoundField DataField="Direccion" HeaderText="Jefatura" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="editButton" CssClass="gridButton" runat="server" ImageUrl="~/Images/edit.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>