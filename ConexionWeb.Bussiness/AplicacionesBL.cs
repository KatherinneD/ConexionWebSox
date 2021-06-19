using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class AplicacionesBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<Aplicaciones> ObtenerAplicaciones()
        {
            var query = ctx.Aplicaciones;
            return query;
        }

        public Aplicaciones ObtenerAplicacion(string codigo)
        {
            return ctx.Aplicaciones.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarAplicacion(Aplicaciones aplicacion)
        {
            try
            {
                var aplicacionExistente = ctx.Aplicaciones.SingleOrDefault(c => c.Codigo == aplicacion.Codigo);
                if (aplicacionExistente == null)
                {
                    ctx.Aplicaciones.Add(aplicacion);
                }
                else
                {
                    ctx.Entry(aplicacionExistente).CurrentValues.SetValues(aplicacion);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Aplicación con código " + aplicacion.Codigo + " actualizada correctamente.";
        }
    }
}
