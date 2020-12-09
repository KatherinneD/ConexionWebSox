using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class CampoMatrizBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<CampoMatriz> ObtenerCampoMatriz()
        {
            var query = ctx.Campos;
            return query;
        }

        public CampoMatriz ObtenerCampos(string codigo)
        {
            return ctx.Campos.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarCampos(CampoMatriz Campos)
        {
            try
            {
                var CamposExistente = ctx.Campos.SingleOrDefault(c => c.Codigo == Campos.Codigo);
                if (CamposExistente == null)
                {
                    ctx.Campos.Add(Campos);
                }
                else
                {
                    ctx.Entry(CamposExistente).CurrentValues.SetValues(Campos);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Campo con código " + Campos.Codigo + " actualizada correctamente.";
        }
    }
}
