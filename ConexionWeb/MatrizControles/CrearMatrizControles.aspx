<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearMatrizControles.aspx.cs" MasterPageFile="~/Site.Master" Inherits="ConexionWeb.MatrizControles.CrearMatrizControles" Async="true" %>

<%@ Register Src="~/MatrizControles/Matriz.ascx" TagPrefix="csc" TagName="Matriz" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2 runat="server" id="tituloValoresAnteriores" visible="false">Valores Anteriores</h2>
    <csc:Matriz runat="server" ID="matrizNuevo"></csc:Matriz>
    <h2 runat="server" id="tituloValoresNuevos" visible="false">Valores Nuevos</h2>
    <csc:Matriz runat="server" ID="matrizComparativa" Visible="false"></csc:Matriz>
    
</asp:Content>
