using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Aplicaciones
{
    public partial class CrearAplicacion : System.Web.UI.Page
    {
        private static string EstadoAuditoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Aplicacion"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                //CargarServidores();
                CargarCelulas();
                if (Request["Codigo"] != null)
                {
                    CargarInformacionAplicacion(Request["Codigo"]);
                }
                else
                {
                    Response.Redirect("/Aplicaciones/ConsultarAplicaciones");
                }
            }
        }

        private void CargarCelulas()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var celulas = servicio.ObtenerJefaturas();
            this.listCelula.DataSource = celulas;
            this.listCelula.DataBind();
        }

        //private void CargarServidores()
        //{
        //    var servicio = new ConexionSOXService.ConexionSOXServiceClient();
        //    var aplicaciones = servicio.ObtenerAplicaciones();
        //    List<string> servidores = new List<string>();
            
        //    foreach (var item in aplicaciones)
        //    {
        //        var servidoresElemento = item.Servidores.Split(',');
        //        foreach (var servidor in servidoresElemento)
        //        {
        //            if (!servidores.Contains(servidor))
        //                servidores.Add(servidor);
        //        }
        //    }
        //    this.listServidores.DataSource = servidores;
        //    this.listServidores.DataBind();
        //}

        private void CargarInformacionAplicacion(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var aplicacion = servicio.ObtenerAplicacion(codigo);
            List<ListItem> toBeRemoved = new List<ListItem>();

            if (aplicacion != null)
            {
                this.txtCodigo.Text = aplicacion.Codigo;
                this.listCelula.SelectedValue = aplicacion.Celula;
                this.txtNombre.Text = aplicacion.NombreAplicacion;

                var servidoresElemento = aplicacion.Servidores.Split(',');

                //this.listServidores.DataSource = servidoresElemento;
                //this.listServidores.DataBind();

                //foreach (ListItem item in this.listServidores.Items)
                //{
                //    item.Selected = true;
                //}

                List<ConexionSOXService.Servidores> data = new List<ConexionSOXService.Servidores>();
                foreach (var item in servidoresElemento)
                {
                    data.Add(servicio.ObtenerServidor(item));
                }
                gvServidores.DataSource = data;
                gvServidores.DataBind();

                EstadoAuditoria = aplicacion.EstadoAuditoria;
                this.lstEstados.SelectedValue = aplicacion.Estado;
                this.btnActualizar.Text = "Actualizar";
                this.checkHerramienta.Checked = Convert.ToBoolean(!string.IsNullOrEmpty(aplicacion.HerramientaAlmacenamiento) ? aplicacion.HerramientaAlmacenamiento : "False");
                this.boolClasificarSOX.Checked = aplicacion.ClasificarSOX;
                this.txtCodigo.Enabled = false;
                this.txtNombre.Enabled = false;
                //this.listServidores.Enabled = false;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtNombre.Text))
                errores.AppendLine("El campo nombre del área es obligatorio.");
            //if (string.IsNullOrEmpty(listServidores.SelectedValue))
            //    errores.AppendLine("El campo servidores es obligatorio.");
            if (string.IsNullOrEmpty(lstEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if (string.IsNullOrEmpty(listCelula.SelectedValue))
                errores.AppendLine("El campo célula es obligatorio.");
            if(EstadoAuditoria != "Cerrada" && lstEstados.SelectedValue == "Inactivo")
            {
                errores.AppendLine("No es posible inactivar una aplicación que no tenga la auditoría cerrada");
            }

            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarAplicacion();
        }

        private void CrearActualizarAplicacion()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var inactivadoPor = string.Empty;
            //List<string> servidoresSeleccionados = new List<string>();
            //foreach (ListItem item in listServidores.Items)
            //{
            //    if (item.Selected)
            //        servidoresSeleccionados.Add(item.Text);
            //}
            if (this.lstEstados.SelectedValue == "Inactivo")
                inactivadoPor = User.Identity.Name;

            var aplicacion = servicio.ObtenerAplicacion(this.txtCodigo.Text);
            aplicacion = aplicacion ?? new ConexionSOXService.Aplicaciones();
            aplicacion.Celula = this.listCelula.SelectedValue;
            aplicacion.ClasificarSOX = this.boolClasificarSOX.Checked;
            aplicacion.Codigo = this.txtCodigo.Text;
            aplicacion.Estado = this.lstEstados.SelectedValue;
            aplicacion.InactivadoPor = inactivadoPor;
            aplicacion.HerramientaAlmacenamiento = this.checkHerramienta.Checked.ToString();
            aplicacion.NombreAplicacion = this.txtNombre.Text;

            var respuesta = servicio.CrearActualizarAplicacion(aplicacion);
            Response.Write("<script>alert('" + respuesta + "');location.href='/Aplicaciones/ConsultarAplicaciones'</script>");
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Aplicaciones/ConsultarAplicaciones");
        }
    }
}