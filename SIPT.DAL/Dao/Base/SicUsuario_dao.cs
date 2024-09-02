using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class SicUsuario_dao
    {
        public abstract SicUsuario Login(string username, string password, string aplicacion, string equipo);
        //public abstract void ListarUsuariosPorApp(string username, string password, string aplicacion, string equipo);

        public abstract List<SicUsuario> ListarUsuariosAppRol(string aplicacion, string usuariorol);

    }
}
