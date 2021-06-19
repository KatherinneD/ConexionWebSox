<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearAplicacion.aspx.cs" Inherits="ConexionWeb.Aplicaciones.CrearAplicacion" Async="true"%>

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
            <div class="col-md-2"><span class="control-label">Código de aplicación:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtCodigo"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Nombre de aplicación:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control" runat="server" ID="txtNombre"></asp:TextBox> </div>
        </div>
        <%--<div class ="form-group">
            <div class="col-md-2"><span class="control-label">Servidores:</span></div>
            <div class="col-md-10"><asp:CheckBoxList runat="server" ID="listServidores"></asp:CheckBoxList> </div>
        </div>--%>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Servidores:</span></div>
            <div class="col-md-10">
        <asp:GridView ID="gvServidores" CssClass="table table-responsive table-striped table-hover table-bordered" runat="server" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre de Servidor" />
            <asp:BoundField DataField="IP" HeaderText="IP Servidor" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo de Servidor" />
        </Columns>
        <HeaderStyle CssClass="thead-dark" />
    </asp:GridView>
                </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Clasificar SOX:</span></div>
            <div class="col-md-10"><asp:CheckBox CssClass="form-control" runat="server" ID="boolClasificarSOX" /> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Célula:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control" DataValueField="CodigoArea" DataTextField="CodigoArea" runat="server" ID="listCelula"></asp:DropDownList>  </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Herramienta de almacenamiento:</span></div>
            <div class="col-md-10"><asp:CheckBox CssClass="form-control" runat="server" ID="checkHerramienta"></asp:CheckBox></div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Estado:</span></div>
            <div  class="col-md-10">
                <asp:DropDownList runat="server" ID="lstEstados">
                    <asp:ListItem Value="Activo" Text="Activo"></asp:ListItem>
                    <asp:ListItem Value="Inactivo" Text="Inactivo"></asp:ListItem>
                </asp:DropDownList> 
            </div>
        </div>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><asp:Button ID="btnActualizar"  CssClass="btn btn-default" Text="Crear" OnClick="btnActualizar_Click" runat="server" /></div>
            <div class="col-md-2"><asp:Button ID="btnCancelar"  CssClass="btn btn-default" Text="Cancelar" OnClick="btnCancelar_Click" runat="server" /></div>
        </div>
        
    </div>
</asp:Content>