<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="RiesgoCorporativo.aspx.cs" Inherits="ConexionWeb.RiesgoCorporativo.RiesgoCorporativo" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Riesgos corporativos</h2>
    <div class="form-horizontal">
        <div class ="form-group">
            <div class="col-md-2"><asp:FileUpload CssClass="btn btn-default" runat="server" ID="cargarRiesgos" /></div>
            
         </div>
        <div class ="form-group">
        <div class="col-md-2"><asp:Button CssClass="btn btn-default" runat="server" ID="btnCargarRiesgos" Text="Cargar riesgos" OnClick="btnCargarRiesgos_Click" /></div>
            </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />

    <asp:GridView ID="gvRiesgos" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción del riesgo" />
            <asp:BoundField DataField="Nivel" HeaderText="Nivel de riesgo" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo de riesgo" />
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>