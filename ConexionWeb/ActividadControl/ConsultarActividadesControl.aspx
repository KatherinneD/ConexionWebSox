<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ConsultarActividadesControl.aspx.cs" Inherits="ConexionWeb.ActividadControl.ConsultarActividadesControl" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Consulta de Actividades de Control</h2>
    <div class="form-horizontal">
        <div class ="form-group">
            <div class="col-md-2">
                <asp:FileUpload  CssClass="btn btn-default" runat="server" ID="cargarActividadControl" />
            </div>
         </div>
        <div class ="form-group">
        <div class="col-md-2">
                <asp:Button runat="server"  CssClass="btn btn-default" ID="btnCargarActividadControl" Text="Cargar registros" OnClick="btnCargarActividadControl_Click" />
            </div>
            </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvActividadControl" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvActividadControl_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="NombreActividad" HeaderText="Actividad de control" />
            <asp:BoundField DataField="CodigoObjetivo" HeaderText="Código objetivo de control" />
            <asp:BoundField DataField="CodigoRiesgo" HeaderText="Código riesgo SOX" />
            <asp:BoundField DataField="CodigoSubDominio" HeaderText="Código subdominio" />
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