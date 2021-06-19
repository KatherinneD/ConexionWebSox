using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Linq;
using System.Data.Entity;

namespace ConexionWeb.Bussiness
{
    public class RiesgoCorporativoBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<RiesgoCorporativo> ObtenerRiesgos()
        {
            var query = ctx.RiesgosCorporativos;
            return query;
        }

        public void CrearRiesgo(RiesgoCorporativo riesgo)
        {
            var riesgoExistente = ctx.RiesgosCorporativos.SingleOrDefault(c => c.Codigo == riesgo.Codigo);
            if(riesgoExistente == null)
            {
                riesgoExistente = new RiesgoCorporativo
                {
                    Codigo = riesgo.Codigo,
                    Descripcion = riesgo.Descripcion,
                    Nivel = riesgo.Nivel,
                    Tipo = riesgo.Tipo
                };
                ctx.RiesgosCorporativos.Add(riesgoExistente);
                ctx.SaveChanges();
                
            }
        }
    }
}
