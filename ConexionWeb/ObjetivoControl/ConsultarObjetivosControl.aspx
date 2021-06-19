<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ConsultarObjetivosControl.aspx.cs" Inherits="ConexionWeb.ObjetivoControl.ConsultarObjetivosControl" Async="true"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="/Content/GridView.css" rel="stylesheet" type="text/css" />
    <br />
    <h2>Objetivos de control</h2>
    <div class="form-horizontal">
        <div class ="form-group">
            <div class="col-md-2"><asp:FileUpload CssClass="btn btn-default" runat="server" ID="cargarObjetivosControl" /></div>
            
         </div>
        <div class ="form-group">
        <div class="col-md-2"><asp:Button CssClass="btn btn-default" runat="server" ID="btnCargarObjetivosControl" Text="Cargar ObjetivosControl" OnClick="btnCargarObjetivosControl_Click" /></div>
            </div>
    </div>
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <asp:GridView ID="gvObjetivosControl" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvObjetivosControl_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="ObjetivoDeControl" HeaderText="Objetivo de control" />
            <asp:BoundField DataField="Autor" HeaderText="Usuario que lo creó" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton  CssClass="gridButton" ID="editButton" runat="server" ImageUrl="~/Images/edit.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
</asp:Content>