<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultarMatrizControles.aspx.cs" Inherits="ConexionWeb.MatrizControles.ConsultarMatrizControles" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de controles</h2>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvMatrizControles" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvMatrizControles_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción de matriz" />
            <asp:BoundField DataField="Autor" HeaderText="Creada por" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="ModificacionAprobado" HeaderText="Aprobado?" />
            <asp:BoundField DataField="ModificacionFechaAprobacion" HeaderText="Fecha de creación del control" />
            <asp:BoundField DataField="ModificacionObservaciones" HeaderText="Observaciones aprobación/rechazo" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton  CssClass="gridButton" ID="showButton" runat="server" ImageUrl="~/Images/search.png" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton  CssClass="gridButton" ID="editButton" runat="server" ImageUrl="~/Images/edit.png" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton  CssClass="gridButton" ID="approveButton" runat="server" ImageUrl="~/Images/approve.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>