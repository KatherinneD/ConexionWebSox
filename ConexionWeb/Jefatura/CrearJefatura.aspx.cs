using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Jefatura
{
    public partial class CrearJefatura : System.Web.UI.Page
    {
        private static bool Inactivable { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Jefatura"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                CargarUsuarios();
                CargarJefaturas();
                if (Request["Codigo"] != null)
                {
                    CargarInformacionJefatura(Request["Codigo"]);
                }
            }
        }

        private void CargarJefaturas()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var jefaturas = servicio.ObtenerJefaturas();
            this.listDireccion.DataSource = jefaturas;
            this.listDireccion.DataBind();
        }
        private void CargarInformacionJefatura(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var jefatura = servicio.ObtenerJefatura(codigo);
            if (jefatura.Estado == "EnUso")
                Inactivable = false;
            else
                Inactivable = true;

            if (jefatura != null)
            {
                this.txtCodigo.Text = jefatura.CodigoArea;
                this.listDireccion.SelectedValue = jefatura.Direccion;
                this.txtNombre.Text = jefatura.NombreArea;
                try
                {
                    this.listProductOwner.SelectedValue = jefatura.ProductOwner;
                    this.listScrumMaster.SelectedValue = jefatura.ScrumMaster;
                }
                catch { }
                this.lstEstados.SelectedValue = jefatura.Estado;
                this.btnActualizar.Text = "Actualizar";
            }
        }

        private void CargarUsuarios()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (var user in manager.Users)
            {
                ListItem po = new ListItem(user.UserName, user.UserName);
                ListItem sm = new ListItem(user.UserName, user.UserName);
                this.listProductOwner.Items.Add(po);
                this.listScrumMaster.Items.Add(sm);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtNombre.Text))
                errores.AppendLine("El campo nombre del área es obligatorio.");
            if (string.IsNullOrEmpty(listDireccion.SelectedValue))
                errores.AppendLine("El campo dirección es obligatorio.");
            if (string.IsNullOrEmpty(listProductOwner.SelectedValue))
                errores.AppendLine("El campo Product Owber es obligatorio.");
            if (string.IsNullOrEmpty(listScrumMaster.SelectedValue))
                errores.AppendLine("El campo Scrum Master es obligatorio.");
            if (string.IsNullOrEmpty(lstEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if(this.lstEstados.SelectedValue == "Inactivo" && !Inactivable)
            {
                this.lblMessage.Text = "No es posible inactivar una jefatura que se encuentre en uso";
                return;
            }
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarJefatura();
        }

        private void CrearActualizarJefatura()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var respuesta = servicio.CrearActualizarJefatura(new ConexionSOXService.Jefatura()
            {
                CodigoArea = this.txtCodigo.Text,
                Direccion = this.listDireccion.SelectedValue,
                NombreArea = this.txtNombre.Text,
                ProductOwner = this.listProductOwner.Text,
                ScrumMaster = this.listScrumMaster.Text,
                Estado = this.lstEstados.SelectedValue
            }); ;
            Response.Write("<script>alert('" + respuesta + "');location.href='/Jefatura/ConsultarJefaturas'</script>");
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Jefatura/ConsultarJefaturas");
        }
    }
}