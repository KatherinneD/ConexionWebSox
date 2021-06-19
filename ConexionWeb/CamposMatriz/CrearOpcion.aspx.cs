using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.CamposMatriz
{
    public partial class CrearOpcion : System.Web.UI.Page
    {
        private static bool EnUso { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtValor.Text))
                errores.AppendLine("El campo valor es obligatorio.");
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarOpcion();
        }

        private void CrearActualizarOpcion()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var respuesta = servicio.CrearActualizarOpcionCampo(new ConexionSOXService.OpcionCampoMatriz()
            {
                Codigo = this.txtCodigo.Text,
                Valor = this.txtValor.Text
            });
            Response.Write("<script>alert('" + respuesta + "');location.href='/CamposMatriz/ConsultarCampos'</script>");
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CamposMatriz/ConsultarCampos");
        }
    }
}