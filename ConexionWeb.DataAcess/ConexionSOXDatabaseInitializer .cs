using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ConexionWeb.DataAcess
{
    public class ConexionSOXDatabaseInitializer : DropCreateDatabaseIfModelChanges<ConexionSOXDBContext>
    {
        protected override void Seed(ConexionSOXDBContext context)
        {
            ObtenerRiesgosCorporativos().ForEach(c => context.RiesgosCorporativos.Add(c));
            ObtenerRiesgosSOX().ForEach(c => context.RiesgosSOX.Add(c));
        }

        private static List<RiesgoCorporativo> ObtenerRiesgosCorporativos()
        {
            var riesgos = new List<RiesgoCorporativo> {
                new RiesgoCorporativo
                {
                    Codigo ="RS001",
                    Descripcion ="Riesgo Corporativo 1",
                    Nivel = "Nivel 1",
                    Tipo = "A"
                },new RiesgoCorporativo
                {
                    Codigo ="RS002",
                    Descripcion ="Riesgo Corporativo 2",
                    Nivel = "Nivel 2",
                    Tipo = "A"
                },new RiesgoCorporativo
                {
                    Codigo ="RS003",
                    Descripcion ="Riesgo Corporativo 3",
                    Nivel = "Nivel 3",
                    Tipo = "A"
                },new RiesgoCorporativo
                {
                    Codigo ="RS004",
                    Descripcion ="Riesgo Corporativo 4",
                    Nivel = "Nivel 4",
                    Tipo = "A"
                },new RiesgoCorporativo
                {
                    Codigo ="RS005",
                    Descripcion ="Riesgo Corporativo 5",
                    Nivel = "Nivel 5",
                    Tipo = "A"
                }
            };

            return riesgos;
        }

        private static List<RiesgoSOX> ObtenerRiesgosSOX()
        {
            var riesgos = new List<RiesgoSOX> {
                new RiesgoSOX
                {
                    AprobadoPor = "Pepito",
                    CodigoRiesgoCorporativo = "A",
                    CodigoSOX = "SOX1",
                    DescripcionSOX ="Descripcion SOX",
                    Estado = "Activo",
                    FechaCreacion = DateTime.Now,
                    NivelSOX = "Seguridad"
                }
            };

            return riesgos;
        }
    }
}
