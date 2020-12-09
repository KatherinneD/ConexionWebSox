<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Matriz.ascx.cs" Inherits="ConexionWeb.MatrizControles.Matriz" %>
<script type="text/javascript" src="/Scripts/matrizControles.js"></script>
<br />
<br />
<div class="form-horizontal">
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="lblError"></asp:Label>
    <br />
    <asp:Label runat="server" ID="lblConfirmacion" CssClass="lblConfirmacion"></asp:Label>
    <br />
    <ul class="list-group">
        <!--Inicio Sección-->
        <a href="#menu0<%= this.IDAleatorioUI %>" data-toggle="collapse" aria-expanded="false" class="bg-dark list-group-item list-group-item-action flex-column align-items-start">
            <div class="d-flex w-100 justify-content-start align-items-center">
                <span class="menu-collapsed">Control ITGC's</span>
                <span class="submenu-icon ml-auto"></span>
            </div>
        </a>
        <div id='menu0<%= this.IDAleatorioUI %>' class="collapse sidebar-submenu">
            <br />
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Control ITGC's</span></div>
                <div class="col-md-10">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="listCriterios">
                        <asp:ListItem Text="Criterio 1" Value="Criterio1"></asp:ListItem>
                        <asp:ListItem Text="Criterio 1" Value="Criterio1"></asp:ListItem>
                        <asp:ListItem Text="Criterio 3" Value="Criterio3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Estado:</span></div>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="listEstados" Enabled="false">
                        <asp:ListItem Value="RevisionNuevo" Text="Revisión-Nuevo" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="RevisionModificacion" Text="Revisión-Modificación"></asp:ListItem>
                        <asp:ListItem Value="AprobadoNuevo" Text="Aprobado-Nuevo"></asp:ListItem>
                        <asp:ListItem Value="AprobacionModificacion" Text="Aprobación-Modificacion"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Control clave SOX?</span></div>
                <div class="col-md-10">
                    <input type="checkbox" onclick="MostrarSeccionDesdeCheckBox('controlSOX', this)" />
                </div>
            </div>
            <div class="form-group controlSOX">
                <div class="col-md-2"><span class="control-label">Riesgos SOX :</span></div>
                <div class="col-md-10">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="listRiesgos"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Punto de control :</span></div>
                <div class="col-md-10">
                    <asp:CheckBoxList runat="server" ID="listCodigoPuntoDeControl"></asp:CheckBoxList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Actividad de control :</span></div>
                <div class="col-md-10">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="listCodigoActividadControl"></asp:DropDownList>
                </div>
            </div>
        </div>
        <!--Fin Sección-->
        <!--Inicio Sección-->
        <a href="#menu1<%= this.IDAleatorioUI %>" data-toggle="collapse" aria-expanded="false" class="bg-dark list-group-item list-group-item-action flex-column align-items-start">
            <div class="d-flex w-100 justify-content-start align-items-center">
                <span class="menu-collapsed">Identificación control</span>
                <span class="submenu-icon ml-auto"></span>
            </div>

        </a>
        <div id='menu1<%= this.IDAleatorioUI %>' class="collapse sidebar-submenu">
            <br />
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Descripción de control:</span></div>
                <div class="col-md-10">
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtDescripcionControl" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Aplicación :</span></div>
                <div class="col-md-10">
                    <asp:CheckBoxList runat="server" ID="listCodigoAplicacion"></asp:CheckBoxList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Documento:</span></div>
                <div class="col-md-10">
                    <asp:CheckBoxList runat="server" ID="listCodigoDocumento">
                        <asp:ListItem Text="Política"></asp:ListItem>
                        <asp:ListItem Text="Proceso"></asp:ListItem>
                        <asp:ListItem Text="Procedimiento"></asp:ListItem>
                    </asp:CheckBoxList>

                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Tiempo de aplicación del control:</span></div>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="listCodigoTiempoAplicacion">
                        <asp:ListItem Value="Tiempo1" Text="Tiempo 1" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Tiempo2" Text="Tiempo 2"></asp:ListItem>
                        <asp:ListItem Value="Tiempo3" Text="Tiempo 3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Compartido con un tercero?</span></div>
                <div class="col-md-10">
                    <input type="checkbox" onclick="MostrarSeccionDesdeCheckBox('compartidoTercero', this)" />
                </div>
            </div>
            <div class="form-group compartidoTercero">
                <div class="col-md-2"><span class="control-label">Descripción de las actividades ejecutadas con el tercero:</span></div>
                <div class="col-md-10">
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtDescripcionActividadesTercero" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Se identificó deficiencia en este control el año anterior?:</span></div>
                <div class="col-md-10">
                    <asp:CheckBox CssClass="form-control" runat="server" ID="txtDeficienciaAnoAnterior"></asp:CheckBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Responsable control:</span></div>
                <div class="col-md-10">
                    <asp:CheckBoxList runat="server" ID="listResponsableControl"></asp:CheckBoxList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Frecuencia del control:</span></div>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="listFrecuenciaControl">
                        <asp:ListItem Value="Frecuencia1" Text="Frecuencia 1" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Frecuencia2" Text="Frecuencia 2"></asp:ListItem>
                        <asp:ListItem Value="Frecuencia3" Text="Frecuencia 3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Naturaleza  del control:</span></div>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="listNaturalezaControl">
                        <asp:ListItem Value="Manual" Text="Manual" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Automatico" Text="Automático"></asp:ListItem>
                        <asp:ListItem Value="DependienteTI" Text="Manual dependiente de TI"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"><span class="control-label">Tipo de control:</span></div>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="listTipoControl">
                        <asp:ListItem Value="Preventivo" Text="Preventivo" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Detectivo" Text="Detectivo"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <!--Fin Sección-->
        <!--Inicio Sección-->
        
            <a href="#menu3<%= this.IDAleatorioUI %>" data-toggle="collapse" aria-expanded="false" class="bg-dark list-group-item list-group-item-action flex-column align-items-start">
                <div class="d-flex w-100 justify-content-start align-items-center">
                    <span class="menu-collapsed">Evidencias</span>
                    <span class="submenu-icon ml-auto"></span>
                </div>
            </a>
            <div id='menu3<%= this.IDAleatorioUI %>' class="collapse sidebar-submenu">
                <br />
                <div id="divEvidencias" runat="server">
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Evidencia:</span></div>
                    <div class="col-md-10">
                        <asp:FileUpload runat="server" ID="listEvidencias" AllowMultiple="true"></asp:FileUpload>
                        <asp:Label CssClass="form-control" runat="server" ID="txtEvidenciasArchivos"></asp:Label>
                    </div>
                </div>    
                    </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Descripción de la evidencia se deja:</span></div>
                    <div class="col-md-10">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtEvidenciaDescripcion" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Descripción de cómo se evidencia la revisión o aprobación del control:</span></div>
                    <div class="col-md-10">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtEvidenciaDescripcionRevision" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Asociar el código de la herramienta donde se almacena:</span></div>
                    <div class="col-md-10">
                        <asp:DropDownList runat="server" ID="listEvidenciaCodigoHerramientaAlmacenamiento" DataValueField="NombreAplicacion" DataTextField="NombreAplicacion">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Descripción de las restricciones de seguridad en la evidencia:</span></div>
                    <div class="col-md-10">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtEvidenciaDescripcionRestricciones" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Tiempo de permanencia de archivo:</span></div>
                    <div class="col-md-10">
                        <asp:DropDownList runat="server" ID="listEvidenciaCodigoTiempoPermanencia">
                            <asp:ListItem Value="PermanenciaA" Text="Permanencia A" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="PermanenciaB" Text="Permanencia B"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                
            </div>
        
        <!--Fin Sección-->
        <!--Inicio Sección-->
        <a href="#menu2<%= this.IDAleatorioUI %>" data-toggle="collapse" aria-expanded="false" class="bg-dark list-group-item list-group-item-action flex-column align-items-start">
            <div class="d-flex w-100 justify-content-start align-items-center">
                <span class="menu-collapsed">Calidad de la evidencia</span>
                <span class="submenu-icon ml-auto"></span>
            </div>
        </a>
        <div id='menu2<%= this.IDAleatorioUI %>' class="collapse sidebar-submenu">
            <br />
            <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Calidad de la evidencia – Reporte generado (Si/No)?</span></div>
                    <div class="col-md-10">
                        <input type="checkbox" onclick="MostrarSeccionDesdeCheckBox('calidadEvidencia', this)" />
                    </div>
                </div>
            <div class="calidadEvidencia">
                    <!--Inicio calidad evidencia-->
                    <div class="form-group">
                        <div class="col-md-2"><span class="control-label">Descripción del reporte:</span></div>
                        <div class="col-md-10">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtCalidadEvidenciaDescripcion" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-2"><span class="control-label">Aplicacion:</span></div>
                        <div class="col-md-10">
                            <asp:DropDownList CssClass="form-control" runat="server" ID="listCalidadEvidenciaCodigoAplicacion"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2"><span class="control-label">Descripción de la transacción por medio de la que se genera el reporte:</span></div>
                        <div class="col-md-10">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtCalidadEvidenciaDescripcionTransaccion" TextMode="MultiLine"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group">
                        <div class="col-md-2"><span class="control-label">Tipo de reporte:</span></div>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="listCalidadEvidenciaCodigoTipoReporte">
                                <asp:ListItem Value="Estandar" Text="Estándar" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="Personalizado" Text="Personalizado"></asp:ListItem>
                                <asp:ListItem Value="Query" Text="Query"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2"><span class="control-label">Importancia del reporte para la ejecución del control:</span></div>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="listCalidadEvidenciaCodigoImportanciaReporte">
                                <asp:ListItem Value="Importante" Text="Importante" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="NoRelevante" Text="No es relevante"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2"><span class="control-label">Descripción de ¿Como se asegura la integridad de la Data?:</span></div>
                        <div class="col-md-10">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtCalidadEvidenciaDescripcionIntegridad" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2"><span class="control-label">Descripción de ¿Qué revisiones realiza la gerencia sobre la data utilizada para la ejecución del control?:</span></div>
                        <div class="col-md-10">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtCalidadEvidenciaDescripcionRevisionesGerencia" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <!--Fin calidad evidencia-->
                    </div>
                </div>
        </div>
        <!--Fin Sección-->

        <br />
        <div class="form-group">
            <div class="col-md-5"><span class="control-label">Requiere control compensatorio (Si/No)?</span></div>
            <div class="col-md-5">
                <input type="checkbox" onclick="MostrarSeccionDesdeCheckBox('controlCompensatorio', this)" />
            </div>
        </div>
        <!--Inicio Sección-->
        <div class="controlCompensatorio">
            <a href="#menu4<%= this.IDAleatorioUI %>" data-toggle="collapse" aria-expanded="false" class="bg-dark list-group-item list-group-item-action flex-column align-items-start">
                <div class="d-flex w-100 justify-content-start align-items-center">
                    <span class="menu-collapsed">Control compensatorio</span>
                    <span class="submenu-icon ml-auto"></span>
                </div>
            </a>
            <div id='menu4<%= this.IDAleatorioUI %>' class="collapse sidebar-submenu">
                <br />
                <!--Inicio control compensatorio-->
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Descripción control compensatorio:</span></div>
                    <div class="col-md-10">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtControlCompensatorioDescripcion" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Descripción de ¿que evidencia se deja?:</span></div>
                    <div class="col-md-10">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtControlCompensatorioDescripcionEvidencia" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Aplicación donde se deja la evidencia:</span></div>
                    <div class="col-md-10">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="listControlCompensatorioCodigoAplicacion"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"><span class="control-label">Fecha en la que se empieza a ejecutar el control:</span></div>
                    <div class="col-md-10">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtControlCompensatorioFechaInicio" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <!--Fin control compensatorio-->

            </div>
        </div>
        <!--Fin Sección-->

    </ul>
    <div runat="server" id="seccionAprobador" visible="false">
        <div class="form-group">
            <div class="col-md-2"><span class="control-label">Aprobar los cambios:</span></div>
            <div class="col-md-10">
                <asp:DropDownList CssClass="form-control" runat="server" ID="listAprobarCambios">
                    <asp:ListItem Value="Si" Text="Si"></asp:ListItem>
                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"><span class="control-label">Observaciones:</span></div>
            <div class="col-md-10">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtObservacionesAprobacion" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-2">
            <asp:Button ID="btnActualizar" CssClass="btn btn-default" Text="Crear" runat="server" OnClick="btnActualizar_Click" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnCancelar" CssClass="btn btn-default" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
        </div>
    </div>
</div>
