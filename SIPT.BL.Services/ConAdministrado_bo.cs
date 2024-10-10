using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;
namespace SIPT.BL.Services
{
    public class ConAdministrado_bo
    {
        private ConAdministrado_dao oConAdministrado_dao;        
        private List<ConAdministrado> oConAdministradoList;
        private ConAdministrado oConAdministrado;
        private LogMensajes logMensajes;
        private Db dbconex;

        public ConAdministrado_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public List<ConAdministrado> ListarPorFiltro(ConAdministrado pConAdministrado)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                string vchadmcompletotmp = "";
                string[] parametros = pConAdministrado.vchadmcompleto.Split(Convert.ToChar(" "));
                foreach (string valor in parametros)
                {
                    vchadmcompletotmp = vchadmcompletotmp + valor + "%";
                }
                pConAdministrado.vchadmcompleto = "%" + vchadmcompletotmp;

                oConAdministrado_dao = ObjectFactory.Instanciar<ConAdministrado_dao>(new ConAdministrado(), this.logMensajes, dbconex);
                oConAdministradoList = oConAdministrado_dao.ListarPorFiltro(pConAdministrado);
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oConAdministradoList;
        }

        public ConAdministrado ListarplataformaPorId(int? intadmcodigo)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oConAdministrado_dao = ObjectFactory.Instanciar<ConAdministrado_dao>(new ConAdministrado(), this.logMensajes, dbconex);
                
                oConAdministrado = oConAdministrado_dao.ListarplataformaPorId(intadmcodigo);
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oConAdministrado;
        }
    }
}