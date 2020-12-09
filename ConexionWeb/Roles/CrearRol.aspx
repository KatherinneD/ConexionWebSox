<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CrearRol.aspx.cs" Inherits="ConexionWeb.Roles.CrearRol" Async="true"%>

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
            <div class="col-md-2"><span class="control-label">Id del rol:</span></div>
            <div class="col-md-10"><asp:TextBox CssClass="form-control txtID" runat="server" ID="txtCodigo"></asp:TextBox> </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Nombre del rol:</span></div>
            <div class="col-md-10"><asp:DropDownList CssClass="form-control listNombreRol" runat="server" ID="listNombreRol">
                <asp:ListItem Value="Gobierno" Text="Gobierno"></asp:ListItem>
                <asp:ListItem Value="Riesgo" Text="Riesgo"></asp:ListItem>
                <asp:ListItem Value="MatrizControles" Text="Matriz de controles"></asp:ListItem>
                <asp:ListItem Value="Auditoria" Text="Auditoria"></asp:ListItem>
                <asp:ListItem Value="PlanAccion" Text="Plan acción"></asp:ListItem>
                <asp:ListItem Value="SegPlanAccion" Text="Seguridad Plan acción"></asp:ListItem>
                <asp:ListItem Value="ObjetivosControl" Text="Objetivos de Control"></asp:ListItem>
                <asp:ListItem Value="PuntoControl" Text="Parametrización Puntos de Control"></asp:ListItem>
                <asp:ListItem Value="Aplicaciones" Text="Parametrización aplicaciones"></asp:ListItem>
                <asp:ListItem Value="TablaMaestra" Text="Parametrización tabla maestra"></asp:ListItem>
                <asp:ListItem Value="Jefaturas" Text="Jefaturas - Areas responsables"></asp:ListItem>
                <asp:ListItem Value="Roles" Text="Roles"></asp:ListItem>
                <asp:ListItem Value="Soporte" Text="Soporte evidencias"></asp:ListItem>
                                   </asp:DropDownList></div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Permisos:</span></div>
            <div class="col-md-10">
                <asp:DropDownList CssClass="form-control Gobierno hideAtStart" runat="server" ID="listPermisosGobierno">
                    <asp:ListItem Value="Gobierno_Administrador" Text="Administrador"></asp:ListItem>
                    <asp:ListItem Value="Gobierno_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control Riesgo hideAtStart" runat="server" ID="listPermisosRiesgo">
                    <asp:ListItem Value="Riesgo_Sistema" Text="Sistema"></asp:ListItem>
                    <asp:ListItem Value="Riesgo_AdministradorAreaResponsable" Text="Administrador área responsable"></asp:ListItem>
                    <asp:ListItem Value="Riesgo_Auditoria" Text="Auditoría"></asp:ListItem>
                    <asp:ListItem Value="Riesgo_AreaRiesgos" Text="Área de riesgos"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control MatrizControles hideAtStart" runat="server" ID="listPermisoMatrizControles">
                    <asp:ListItem Value="MatrizControles_AdministradorAreaResponsable" Text="Administrador área responsable"></asp:ListItem>
                    <asp:ListItem Value="MatrizControles_JefeAreaResponsable" Text="Jefe área responsable"></asp:ListItem>
                    <asp:ListItem Value="MatrizControles_Comite" Text="Comité de seguridad"></asp:ListItem>
                    <asp:ListItem Value="MatrizControles_Auditoria" Text="Auditoría"></asp:ListItem>
                    <asp:ListItem Value="MatrizControles_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control Auditoria hideAtStart" runat="server" ID="listPermisoAuditoria">
                    <asp:ListItem Value="Auditoria_AuditorAreaResponsable" Text="Área responsable auditor"></asp:ListItem>
                    <asp:ListItem Value="Auditoria_JefeAuditoria" Text="Auditor jefe auditoría"></asp:ListItem>
                    <asp:ListItem Value="Auditoria_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control PlanAccion hideAtStart" runat="server" ID="listPermisoPlanAccion">
                    <asp:ListItem Value="PlanAccion_AreaResponsable" Text="Área responsable"></asp:ListItem>
                    <asp:ListItem Value="PlanAccion_JefeAuditoria" Text="Jefe de auditoría"></asp:ListItem>
                    <asp:ListItem Value="PlanAccion_Auditor" Text="Auditor"></asp:ListItem>
                    <asp:ListItem Value="PlanAccion_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control SegPlanAccion hideAtStart" runat="server" ID="listPermisoSegPlanAccion">
                    <asp:ListItem Value="SegPlanAccion_AreaResponsable" Text="Área responsable"></asp:ListItem>
                    <asp:ListItem Value="SegPlanAccion_JefeAuditoria" Text="Jefe de auditoría"></asp:ListItem>
                    <asp:ListItem Value="SegPlanAccion_Auditor" Text="Auditor"></asp:ListItem>
                    <asp:ListItem Value="SegPlanAccion_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control ObjetivosControl hideAtStart" runat="server" ID="listPermisoObjetivosControl">
                    <asp:ListItem Value="ObjetivosControl_AdministradorAreaResponsable" Text="Administrador Área responsable"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control PuntoControl hideAtStart" runat="server" ID="listPermisoPuntoControl">
                    <asp:ListItem Value="PuntoControl_Administrador" Text="Administrador, Auditor externo, Auditor interno, Auditor consultor"></asp:ListItem>
                    <asp:ListItem Value="PuntoControl_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control Aplicaciones hideAtStart" runat="server" ID="listPermisoAplicaciones">
                    <asp:ListItem Value="Aplicaciones_Administrador" Text="Administrador"></asp:ListItem>
                    <asp:ListItem Value="Aplicaciones_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control TablaMaestra hideAtStart" runat="server" ID="listPermisoTablaMaestra">
                    <asp:ListItem Value="TablaMaestra_Administrador" Text="Administrador"></asp:ListItem>
                    <asp:ListItem Value="TablaMaestra_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control Jefaturas hideAtStart" runat="server" ID="listPermisoJefaturas">
                    <asp:ListItem Value="Jefaturas_Administrador" Text="Administrador"></asp:ListItem>
                    <asp:ListItem Value="Jefaturas_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                <asp:DropDownList CssClass="form-control Roles hideAtStart" runat="server" ID="listPermisoRoles">
                    <asp:ListItem Value="Roles_Administrador" Text="Administrador"></asp:ListItem>
                    <asp:ListItem Value="Roles_Sistema" Text="Sistema"></asp:ListItem>
                </asp:DropDownList> 
                 <asp:DropDownList CssClass="form-control Soporte hideAtStart" runat="server" ID="listPermisoSoporte">
                    <asp:ListItem Value="Soporte_Administrador" Text="Administrador"></asp:ListItem>
                </asp:DropDownList> 
            </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Responsable:</span></div>
            <div class="col-md-10">
                <asp:DropDownList CssClass="form-control" runat="server" ID="listResponsable">
                </asp:DropDownList> 
            </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Responsable delegado:</span></div>
            <div class="col-md-10">
                <asp:DropDownList CssClass="form-control" runat="server" ID="listReponsableDelegado">
                </asp:DropDownList> 
            </div>
        </div>
        <div class ="form-group">
            <div class="col-md-2"><span class="control-label">Estado:</span></div>
            <div  class="col-md-10">
                <asp:DropDownList runat="server" ID="listEstados">
                    <asp:ListItem Value="Activo" Text="Activo"></asp:ListItem>
                    <asp:ListItem Value="Inactivo" Text="Inactivo"></asp:ListItem>
                    <asp:ListItem Value="EnUso" Text="En uso"></asp:ListItem>
                </asp:DropDownList> 
            </div>
        </div>
        <br />
        <div class ="form-group">
            <div class="col-md-2"><asp:Button ID="btnActualizar"  CssClass="btn btn-default" Text="Crear" OnClick="btnActualizar_Click" runat="server" /></div>
            <div class="col-md-2"><asp:Button ID="btnCancelar"  CssClass="btn btn-default" Text="Cancelar" OnClick="btnCancelar_Click" runat="server" /></div>
        </div>
    </div>
    <script type="text/javascript">
        $(".txtID").on("keydown", function (e) {
            return e.which !== 32;
        });
        $(document).ready(function () {
            $(".hideAtStart").hide();
            function mostrarRoles(nombreRol) {
                $(".hideAtStart").hide();
                $("." + nombreRol).show();
            }
            $(".listNombreRol").change(function () {
                mostrarRoles(this.value);
            })
            mostrarRoles($(".listNombreRol").val());
        });
    </script>
</asp:Content>