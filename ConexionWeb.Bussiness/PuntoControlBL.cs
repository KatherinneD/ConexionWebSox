using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class PuntoControlBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<PuntoControl> ObtenerPuntosControl()
        {
            var query = ctx.PuntosControl;
            return query;
        }

        public PuntoControl ObtenerPuntoControl(string codigo)
        {
            return ctx.PuntosControl.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarPuntoControl(PuntoControl PuntoControl)
        {
            try
            {
                var PuntoControlExistente = ctx.PuntosControl.SingleOrDefault(c => c.Codigo == PuntoControl.Codigo);
                var roleStore = new RoleStore<IdentityRole>();
                var roleMngr = new RoleManager<IdentityRole>(roleStore);
                if (PuntoControlExistente == null)
                {
                    ctx.PuntosControl.Add(PuntoControl);
                }
                else
                {
                    ctx.Entry(PuntoControlExistente).CurrentValues.SetValues(PuntoControl);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Punto Control con código " + PuntoControl.Codigo + " actualizado correctamente.";
        }
    }
}
