using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class ActividadControlBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<ActividadControl> ObtenerActividadControles()
        {
            var query = ctx.ActividadesControl;
            return query;
        }

        public ActividadControl ObtenerActividadControl(string codigo)
        {
            return ctx.ActividadesControl.SingleOrDefault(c => c.Codigo == codigo);
        }
        public string CrearActualizarActividadControl(ActividadControl ActividadControl)
        {
            try
            {
                var ActividadControlExistente = ctx.ActividadesControl.SingleOrDefault(c => c.Codigo == ActividadControl.Codigo);
                if (ActividadControlExistente == null)
                {
                    ctx.ActividadesControl.Add(ActividadControl);
                }
                else
                {
                    ctx.Entry(ActividadControlExistente).CurrentValues.SetValues(ActividadControl);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Actividad Control con código " + ActividadControl.Codigo + " actualizada correctamente.";
        }
    }
}
