using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ConexionWeb.Bussiness
{
    public class MatrizControlesPorAprobarBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<MatrizControlesPorAprobar> ObtenerTodosMatrizControlesPorAprobar()
        {
            var query = ctx.MatrizControlesPorAprobar;
            return query;
        }

        public MatrizControlesPorAprobar ObtenerMatrizControlesPorAprobar(string codigo)
        {
            return ctx.MatrizControlesPorAprobar.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarMatrizControlesPorAprobar(MatrizControlesPorAprobar MatrizControlesPorAprobar)
        {
            try
            {
                var MatrizControlesPorAprobarExistente = ctx.MatrizControlesPorAprobar.SingleOrDefault(c => c.Codigo == MatrizControlesPorAprobar.Codigo);
                if (MatrizControlesPorAprobarExistente == null)
                {
                    ctx.MatrizControlesPorAprobar.Add(MatrizControlesPorAprobar);
                }
                else
                {
                    ctx.Entry(MatrizControlesPorAprobarExistente).CurrentValues.SetValues(MatrizControlesPorAprobar);
                }
                if(MatrizControlesPorAprobar.ModificacionFechaAprobacion != null &&
                    MatrizControlesPorAprobar.ModificacionFechaAprobacion.HasValue &&
                    MatrizControlesPorAprobar.ModificacionFechaAprobacion.Value.DayOfYear == DateTime.Now.DayOfYear)
                {
                    ctx.MatrizControlesPorAprobar.Remove(MatrizControlesPorAprobar);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Matriz con código " + MatrizControlesPorAprobar.Codigo + " actualizada correctamente.";
        }

        private string GuardarArchivoLocal(string nombreArchivo, byte[] bytes)
        {
            string path = Path.Combine(ConfigurationManager.AppSettings["RutaEvidencias"], nombreArchivo);
            File.WriteAllBytes(path, bytes);
            return path;
        }

    }
}
