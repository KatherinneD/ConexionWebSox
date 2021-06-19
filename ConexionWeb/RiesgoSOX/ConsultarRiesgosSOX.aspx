<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ConsultarRiesgosSOX.aspx.cs" Inherits="ConexionWeb.RiesgoSOX.ConsultarRiesgosSOX" Async="true"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Riesgos SOX</h2>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvRiesgos" CssClass="table table-responsive table-striped table-hover table-bordered" format runat="server" AutoGenerateColumns="false" OnRowDataBound="gvRiesgos_RowDataBound">
        <Columns>
            <asp:BoundField DataField="CodigoRiesgoCorporativo" HeaderText="Código riesgo corporativo" />
            <asp:BoundField DataField="CodigoSOX" HeaderText="Código tipo riesgo SOX" />
            <asp:BoundField DataField="DescripcionSOX" HeaderText="Descripción del riesgo SOX" />
            <asp:BoundField DataField="NivelSOX" HeaderText="Nivel del riesgo SOX" />
            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creación" DataFormatString="{0:MM/dd/yyyy}"/>
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="AprobadoPor" HeaderText="Aprobado por" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton  CssClass="gridButton" ID="editButton" runat="server" ImageUrl="~/Images/edit.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>