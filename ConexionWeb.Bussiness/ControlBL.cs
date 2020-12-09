using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class ControlBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<Control> ObtenerControles()
        {
            var query = ctx.Control;
            return query;
        }

        public Control ObtenerControl(string codigo)
        {
            return ctx.Control.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarControl(Control control)
        {
            try
            {
                var ControlExistente = ctx.Control.SingleOrDefault(c => c.Codigo == control.Codigo);
                if (ControlExistente == null)
                {
                    ctx.Control.Add(control);
                }
                else
                {
                    ctx.Entry(ControlExistente).CurrentValues.SetValues(control);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Actividad Control con código " + control.Codigo + " actualizada correctamente.";
        }
    }
}
