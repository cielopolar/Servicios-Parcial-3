using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppsParcial3.Models;
using static AppsParcial3.Models.LibLogin;

namespace AppsParcial3.Clases
{
    public class clsLogin
    {
        private bdNatilleraEntities dbSuper = new bdNatilleraEntities();
        public Login login { get; set; }
        private LoginRespuesta logRpta;
        private bool ValidarUsuario()
        {
            try
            {
                Administrador admin = dbSuper.Administradors.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (admin == null)
                {
                    logRpta = new LoginRespuesta();
                    logRpta.Mensaje = "Usuario no existe";
                    return false;
                }
                login.Clave = admin.Clave   ;
                return true;
            }
            catch (Exception ex)
            {
                logRpta = new LoginRespuesta();
                logRpta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario())
            {
                //string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbSuper.Set<Administrador>()
                       where U.Usuario == login.Usuario &&
                             U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Usuario,
                           Autenticado = true,
                           Token = token,
                           Mensaje = "Usuario autenticado",
                       };
            }
            else
            {
                return null;
            }
        }
    }
}