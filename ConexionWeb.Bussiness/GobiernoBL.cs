using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class GobiernoBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<Gobierno> ObtenerListadoGobierno()
        {
            var query = ctx.Gobierno;
            return query;
        }

        public Gobierno ObtenerRegistroGobierno(string codigo)
        {
            return ctx.Gobierno.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarRegistroGobierno(Gobierno gobierno)
        {
            try
            {
                var gobiernoExistente = ctx.Gobierno.SingleOrDefault(c => c.Codigo == gobierno.Codigo);
                if (gobiernoExistente == null)
                {
                    ctx.Gobierno.Add(gobierno);
                }
                else
                {
                    ctx.Entry(gobiernoExistente).CurrentValues.SetValues(gobierno);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Gobierno con código " + gobierno.Codigo + " actualizado correctamente.";
        }
    }
}
