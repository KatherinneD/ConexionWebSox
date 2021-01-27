using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class ObjetivoControlBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<ObjetivoControl> ObtenerObjetivoControls()
        {
            var query = ctx.ObjetivosControl;
            return query;
        }

        public int ObtenerNuevoCodigoObjetivoControl()
        {
            return ctx.ObjetivosControl.Max(m => m.Codigo) + 1;
        }

        public ObjetivoControl ObtenerObjetivoControl(int codigo)
        {
            return ctx.ObjetivosControl.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarObjetivoControl(ObjetivoControl ObjetivoControl)
        {
            try
            {
                var ObjetivoControlExistente = ctx.ObjetivosControl.SingleOrDefault(c => c.Codigo == ObjetivoControl.Codigo);
                if (ObjetivoControlExistente == null)
                {
                    ctx.ObjetivosControl.Add(ObjetivoControl);
                }
                else
                {
                    ctx.Entry(ObjetivoControlExistente).CurrentValues.SetValues(ObjetivoControl);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Objetivo Control con código " + ObjetivoControl.Codigo + " actualizado correctamente.";
        }

    }
}
