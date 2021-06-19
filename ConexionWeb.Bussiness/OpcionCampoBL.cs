using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class OpcionCampoBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<OpcionCampoMatriz> ObtenerOpcionCampoMatriz()
        {
            var query = ctx.Opciones;
            return query;
        }

        public OpcionCampoMatriz ObtenerOpciones(string codigo)
        {
            return ctx.Opciones.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarOpciones(OpcionCampoMatriz Opciones)
        {
            try
            {
                var OpcionesExistente = ctx.Opciones.SingleOrDefault(c => c.Codigo == Opciones.Codigo);
                if (OpcionesExistente == null)
                {
                    ctx.Opciones.Add(Opciones);
                }
                else
                {
                    ctx.Entry(OpcionesExistente).CurrentValues.SetValues(Opciones);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Opción con código " + Opciones.Codigo + " actualizada correctamente.";
        }
    }
}
