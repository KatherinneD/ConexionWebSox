<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ConsultarRoles.aspx.cs" Inherits="ConexionWeb.Roles.ConsultarRoles" Async="true"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de Roles</h2>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvRoles" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvRoles_RowDataBound">
        <Columns>
            <asp:BoundField DataField="IdRol" HeaderText="ID del rol" />
            <asp:BoundField DataField="NombreRol" HeaderText="Nombre del proceso" />
            <asp:BoundField DataField="Permisos" HeaderText="Permisos" />
            <asp:BoundField DataField="Responsable" HeaderText="Responsable" />
            <asp:BoundField DataField="ResponsableDelegado" HeaderText="Responsable delegado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="editButton" CssClass="gridButton" runat="server" ImageUrl="~/Images/edit.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>