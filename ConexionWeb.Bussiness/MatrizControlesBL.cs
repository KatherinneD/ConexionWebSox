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
    public class MatrizControlesBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<MatrizControles> ObtenerTodosMatrizControles()
        {
            var query = ctx.MatrizControles;
            return query;
        }

        public MatrizControles ObtenerMatrizControles(string codigo)
        {
            return ctx.MatrizControles.SingleOrDefault(c => c.Codigo == codigo);
        }

        public string CrearActualizarMatrizControles(MatrizControles matrizControles)
        {
            try
            {
                var matrizControlesExistente = ctx.MatrizControles.SingleOrDefault(c => c.Codigo == matrizControles.Codigo);
                if (matrizControlesExistente == null)
                {
                    ctx.MatrizControles.Add(matrizControles);
                }
                else
                {
                    ctx.Entry(matrizControlesExistente).CurrentValues.SetValues(matrizControles);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Matriz con código " + matrizControles.Codigo + " actualizada correctamente.";
        }

        private string GuardarArchivoLocal(string nombreArchivo, byte[] bytes)
        {
            string path = Path.Combine(ConfigurationManager.AppSettings["RutaEvidencias"], nombreArchivo);
            File.WriteAllBytes(path, bytes);
            return path;
        }
    }

}

