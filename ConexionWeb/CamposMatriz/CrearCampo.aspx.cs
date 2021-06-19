using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.CamposMatriz
{
    public partial class CrearCampo : System.Web.UI.Page
    {
        private static bool EnUso { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!this.IsPostBack)
            {
                CargarOpciones();
                CargarInformacionCampos();
                if (Request["Codigo"] != null)
                {
                    CargarInformacionCampo(Request["Codigo"]);
                }
            }
        }

        private void CargarOpciones()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.listOpciones.DataSource = servicio.ObtenerOpcionesCampo();
            this.listOpciones.DataBind();
        }

        private void CheckBoxListSeleccionados(string selecciones, CheckBoxList elemento)
        {
            if (!string.IsNullOrEmpty(selecciones))
            {
                var elementosSeleccionados = selecciones.Split(',');
                foreach (ListItem item in elemento.Items)
                {
                    foreach (var seleccion in elementosSeleccionados)
                    {
                        if (seleccion == item.Value)
                            item.Selected = true;
                    }
                }
            }
        }

        private void CargarInformacionCampo(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var campo = servicio.ObtenerCampo(codigo);

            if (campo != null)
            {
                this.txtCodigo.Text = campo.Codigo;
                this.txtNombre.Text = campo.Nombre;
                this.listCategoria.SelectedValue = campo.Categoria;
                CheckBoxListSeleccionados(campo.Opciones, this.listOpciones);
                this.txtCodigo.Enabled = false;
                this.txtNombre.Enabled = false;
                this.btnActualizar.Text = "Actualizar";
                this.listCampoPadre.SelectedValue = campo.CampoPadre;
                this.listCampoPadre.Items.Remove(this.listCampoPadre.Items.FindByValue(campo.Codigo));
            }
        }

        private void CargarInformacionCampos()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var registros = servicio.ObtenerCampos();
            this.listCampoPadre.DataSource = registros;
            this.listCampoPadre.DataBind();
            this.listCampoPadre.Items.Insert(0, new ListItem("N/A", "-1"));
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtNombre.Text))
                errores.AppendLine("El campo nombre del área es obligatorio.");
            if (string.IsNullOrEmpty(listCategoria.SelectedValue))
                errores.AppendLine("El campo categoría es obligatorio.");
            if (string.IsNullOrEmpty(listOpciones.SelectedValue))
                errores.AppendLine("El campo opciones es obligatorio.");
            
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarCampos();
        }
        private string ObtenerElementoSeleccionados(CheckBoxList elementoOrigen)
        {
            List<string> elementosSeleccionados = new List<string>();
            foreach (ListItem item in elementoOrigen.Items)
            {
                if (item.Selected)
                    elementosSeleccionados.Add(item.Value);
            }
            return String.Join(",", elementosSeleccionados);
        }

        private void CrearActualizarCampos()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var respuesta = servicio.CrearActualizarCampo(new ConexionSOXService.CampoMatriz()
            {
                Codigo = this.txtCodigo.Text,
                Nombre = this.txtNombre.Text,
                Categoria = this.listCategoria.SelectedValue,
                Opciones = ObtenerElementoSeleccionados(this.listOpciones),
                CampoPadre = listCampoPadre.SelectedValue
            });
            Response.Write("<script>alert('" + respuesta + "');location.href='/CamposMatriz/ConsultarCampos'</script>");
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CamposMatriz/ConsultarCampos");
        }
    }
}