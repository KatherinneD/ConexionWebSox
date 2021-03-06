<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministrarPerfiles.aspx.cs" MasterPageFile="~/Site.Master" Async="true" Inherits="ConexionWeb.Perfiles.AdministrarPerfiles" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de perfiles y usuarios asociados</h2>
    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-md-2">
                <asp:FileUpload CssClass="btn btn-default" runat="server" ID="cargarUsuarios" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2">
                <asp:Button runat="server" CssClass="btn btn-default" ID="btnCargarUsuarios" Text="Cargar usuarios" OnClick="btnCargarUsuarios_Click" />
            </div>
        </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <div style="text-align: right; margin-bottom: 20px;">
        <asp:Button runat="server" CssClass="btn btn-success right" ID="btnCrearUsuario" Text="Crear un usuario" OnClick="btnCrearUsuario_Click" />
    </div>
    <asp:GridView ID="gvUsuarios" DataKeyNames="Id" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvUsuarios_RowDataBound" OnRowCommand="gvUsuarios_RowCommand">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Identificacion" HeaderText="Identificación" />
            <asp:BoundField DataField="UserName" HeaderText="Usuario" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="Jefatura" HeaderText="Jefatura" />
            <asp:BoundField DataField="Area" HeaderText="Área" />
            <asp:TemplateField HeaderText="Roles">
                <ItemTemplate>
                    <asp:ListBox ID="listRoles" runat="server"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="editButton" CssClass="gridButton" runat="server" ToolTip="Editar" ImageUrl="~/Images/edit.png" />
                    <asp:ImageButton ID="statusButton" CssClass="gridButton" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" 
                            CommandName="EnableUser" runat="server" ToolTip="Activar / Desactivar" ImageUrl="~/Images/approve.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
    <asp:GridView Visible="false" ID="gvRoles" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvRoles_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Rol" />
            <asp:TemplateField HeaderText="Usuarios">
                <ItemTemplate>
                    <asp:ListBox ID="listUsuarios" runat="server"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="editButton" CssClass="gridButton" runat="server" ToolTip="Editar" ImageUrl="~/Images/edit.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>
