<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ConsultarDocumentos.aspx.cs" Inherits="ConexionWeb.Gobierno.ConsultarDocumentos" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de documentos de gobierno</h2>
    <div class="form-horizontal">
        <div class ="form-group">
            <div class="col-md-2">
                <asp:FileUpload  CssClass="btn btn-default" runat="server" ID="cargarGobierno" />
            </div>
         </div>
        <div class ="form-group">
        <div class="col-md-2">
                <asp:Button runat="server"  CssClass="btn btn-default" ID="btnCargarGobierno" Text="Cargar registros" OnClick="btnCargarGobierno_Click" />
            </div>
            </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvGobierno" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvGobierno_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código del proceso" />
            <asp:BoundField DataField="NombreProceso" HeaderText="Nombre del proceso" />
            <asp:BoundField DataField="URL" ItemStyle-CssClass="tdURL" HeaderText="URL" />
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