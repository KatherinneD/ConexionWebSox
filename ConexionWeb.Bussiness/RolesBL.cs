using Microsoft.AspNet.Identity;
using ConexionWeb.DataAcess;
using ConexionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ConexionWeb.Bussiness
{
    public class RolesBL
    {
        private ConexionSOXDBContext ctx = new ConexionSOXDBContext();
        public IQueryable<Roles> ObtenerRoles()
        {
            var query = ctx.Roles;
            return query;
        }

        public Roles ObtenerRol(string idRol)
        {
            return ctx.Roles.SingleOrDefault(c => c.IdRol == idRol);
        }

        public string CrearActualizarRoles(Roles Roles)
        {
            try
            {
                
                var RolesExistente = ctx.Roles.SingleOrDefault(c => c.IdRol == Roles.IdRol);
                if (RolesExistente == null)
                {
                    ctx.Roles.Add(Roles);
                }
                else
                {
                    ctx.Entry(RolesExistente).CurrentValues.SetValues(Roles);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Rol con ID " + Roles.IdRol + " actualizado correctamente.";
        }
    }
}
