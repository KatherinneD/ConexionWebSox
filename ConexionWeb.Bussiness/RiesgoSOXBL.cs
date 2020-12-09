using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class RiesgoSOXBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<RiesgoSOX> ObtenerRiesgosSOX()
        {
            var query = ctx.RiesgosSOX;
            return query;
        }

        public string CrearActualizarRiesgoSOX(RiesgoSOX riesgo)
        {
            try
            {
                var riesgoExistente = ctx.RiesgosSOX.SingleOrDefault(c => c.CodigoSOX == riesgo.CodigoSOX);
                if (riesgoExistente == null)
                {
                    ctx.RiesgosSOX.Add(riesgo);
                }
                else
                {
                    ctx.Entry(riesgoExistente).CurrentValues.SetValues(riesgo);
                }
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return "Riesgo SOX " + riesgo.CodigoSOX + " actualizado correctamente.";
        }

        public RiesgoSOX ObtenerRiesgoSOX(string codigoRiesgo)
        {
            return ctx.RiesgosSOX.SingleOrDefault(c => c.CodigoSOX == codigoRiesgo);
        }
    }
}
