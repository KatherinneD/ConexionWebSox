<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="CrearRiesgoSOX.aspx.cs" Inherits="ConexionWeb.RiesgoSOX.CrearRiesgoSOX" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <div class="form-horizontal">
        <br />
        <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
        <br />
        <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Código riesgo corporativo:</span></div>
            <div class="col-md-10"><asp:DropDownList  CssClass="col-md-2 form-control" runat="server" ID="lstRiesgosCorporativos" AutoPostBack="true" OnSelectedIndexChanged="lstRiesgosCorporativos_SelectedIndexChanged"></asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Código tipo riesgo SOX:</span></div>
            <div class="col-md-10"><span runat="server" ID="spanCodigo">SOX</span><asp:TextBox runat="server" CssClass="form-control" ID="txtRiesgoSOX"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Descripción del riesgo SOX:</span></div>
            <div class="col-md-10"><asp:TextBox  runat="server" CssClass="form-control" ID="txtDescripcionSOX" TextMode="MultiLine"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Nivel de riesgo SOX:</span></div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" CssClass="form-control"  ID="listNivel">
                    <asp:ListItem Value="Alto" Text="Alto"></asp:ListItem>
                    <asp:ListItem Value="Medio" Text="Medio"></asp:ListItem>
                    <asp:ListItem Value="Bajo" Text="Bajo"></asp:ListItem>
                </asp:DropDownList> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Fecha de creación:</span></div>
            <div class="col-md-10"><asp:TextBox TextMode="Date" CssClass="form-control" ID="txtFechaCreacion" runat="server" ></asp:TextBox></div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Estado:</span></div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" CssClass="form-control" ID="lstEstados">
                    <asp:ListItem Value="Activo" Text="Activo"></asp:ListItem>
                    <asp:ListItem Value="Aprobado" Text="Aprobado"></asp:ListItem>
                    <asp:ListItem Value="Inactivo" Text="Inactivo"></asp:ListItem>
                    <asp:ListItem Value="EnUso" Text="En uso"></asp:ListItem>
                </asp:DropDownList> 
            </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Aprobado por:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="col-md-2 form-control" runat="server" ID="listAprobadoPor"></asp:DropDownList></div>
        </div>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><asp:Button ID="btnActualizar" CssClass="btn btn-default" Text="Crear" OnClick="btnActualizar_Click" runat="server" /></div>
            <div class="col-md-2"><asp:Button ID="btnCancelar" CssClass="btn btn-default" Text="Cancelar" OnClick="btnCancelar_Click" runat="server" /></div>
        </div>
    </div>
</asp:Content>