using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Services
{
    public enum TipoContacto
    {
        TelefonoFijo = 1,
        TelefonoMovil = 2,
        Fax = 3,
        Email = 4
    }

    public class ConContacto_bo
    {
        private ConContacto_dao oConContacto_dao;
        private ConContacto oConContacto;
        private LogMensajes logMensajes;
        private Db dbconex;

        public ConContacto_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }


        public ConContacto ListarPlataformaPorId(int intadmcodigo, TipoContacto tipoContacto)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oConContacto_dao = ObjectFactory.Instanciar<ConContacto_dao>(new ConContacto(), this.logMensajes, dbconex);                
                oConContacto = oConContacto_dao.ListarPlataformaPorId(intadmcodigo, "0"+ ((int)TipoContacto.Email).ToString());
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oConContacto;
        }
    }
}
