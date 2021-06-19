using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionWeb.Bussiness
{
    public class ServidoresBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<Servidores> ObtenerServidores()
        {
            var query = ctx.Servidores;
            return query;
        }

        public Servidores ObtenerServidor(string nombre)
        {
            return ctx.Servidores.SingleOrDefault(c => c.Nombre == nombre);
        }

        public string CrearActualizarServidor(Servidores servidor)
        {
            try
            {
                var ServidorExistente = ctx.Servidores.SingleOrDefault(c => c.Nombre == servidor.Nombre);
                if (ServidorExistente == null)
                {
                    ctx.Servidores.Add(servidor);
                }
                else
                {
                    ctx.Entry(ServidorExistente).CurrentValues.SetValues(servidor);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Servidor con código " + servidor.Nombre + " actualizado correctamente.";
        }
    }
}
