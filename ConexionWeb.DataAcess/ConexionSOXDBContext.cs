using ConexionWeb.Models;
using System;
using System.Data.Entity;

namespace ConexionWeb.DataAcess
{
    public class ConexionSOXDBContext : System.Data.Entity.DbContext
    {
        public ConexionSOXDBContext() : base("ConexionSOX")
        {

        }

        public System.Data.Entity.DbSet<RiesgoCorporativo> RiesgosCorporativos { get; set; }

        public System.Data.Entity.DbSet<RiesgoSOX> RiesgosSOX { get; set; }

        public System.Data.Entity.DbSet<Gobierno> Gobierno { get; set; }

        public System.Data.Entity.DbSet<Jefatura> Jefaturas { get; set; }

        public System.Data.Entity.DbSet<ObjetivoControl> ObjetivosControl{ get; set; }
        
        public System.Data.Entity.DbSet<PuntoControl> PuntosControl { get; set; }
        
        public System.Data.Entity.DbSet<Aplicaciones> Aplicaciones { get; set; }
        public System.Data.Entity.DbSet<Servidores> Servidores { get; set; }
        public System.Data.Entity.DbSet<Control> Control { get; set; }
        public System.Data.Entity.DbSet<ActividadControl> ActividadesControl{ get; set; }

        public System.Data.Entity.DbSet<MatrizControles> MatrizControles { get; set; }
        public System.Data.Entity.DbSet<MatrizControlesPorAprobar> MatrizControlesPorAprobar { get; set; }
        public System.Data.Entity.DbSet<Roles> Roles { get; set; }
        public System.Data.Entity.DbSet<CampoMatriz> Campos { get; set; }
        public System.Data.Entity.DbSet<OpcionCampoMatriz> Opciones { get; set; }

    }
}
