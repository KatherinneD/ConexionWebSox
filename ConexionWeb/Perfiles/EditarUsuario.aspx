<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditarUsuario.aspx.cs" Inherits="ConexionWeb.Perfiles.EditarUsuario" Async="true"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />

    <h2>Administración de usuarios</h2>

    <div class="form-horizontal">
        <h4>Editar usuario</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <br />
        <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
        <br />
        <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
        <br />
        <asp:HiddenField runat="server" ID="IdUser" /> 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Nombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nombre" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Identificacion" CssClass="col-md-2 control-label">Identificación</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Identificacion" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Cargo" CssClass="col-md-2 control-label">Cargo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Cargo" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Jefatura" CssClass="col-md-2 control-label">Jefatura</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Jefatura" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Area" CssClass="col-md-2 control-label">Área</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Area" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" ReadOnly="True" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="listRoles" CssClass="col-md-2 control-label">Roles</asp:Label>
            <div class="col-md-10">
                <asp:CheckBoxList DataTextField="Name" runat="server" ID="listRoles"></asp:CheckBoxList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="EditUser_Click" Text="Guardar" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
