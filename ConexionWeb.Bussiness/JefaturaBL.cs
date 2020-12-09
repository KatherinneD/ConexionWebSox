using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class JefaturaBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<Jefatura> ObtenerJefaturas()
        {
            var query = ctx.Jefaturas;
            return query;
        }

        public Jefatura ObtenerJefatura(string codigoArea)
        {
            return ctx.Jefaturas.SingleOrDefault(c => c.CodigoArea == codigoArea);
        }

        public string CrearActualizarJefatura(Jefatura Jefatura)
        {
            try
            {
                var JefaturaExistente = ctx.Jefaturas.SingleOrDefault(c => c.CodigoArea == Jefatura.CodigoArea);
                if (JefaturaExistente == null)
                {
                    ctx.Jefaturas.Add(Jefatura);
                }
                else
                {
                    ctx.Entry(JefaturaExistente).CurrentValues.SetValues(Jefatura);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Jefatura con código " + Jefatura.CodigoArea + " actualizado correctamente.";
        }
    }
}
