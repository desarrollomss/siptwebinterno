using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;

namespace SIPT.BL.Services
{
    public class PtuConsultas_bo
    {
        #region Ubicaciones
        private List<PtuUbicaciones> oPtuUbicacionesList;
        private PtuUbicaciones_dao oPtuUbicaciones_dao;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuConsultas_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public List<PtuUbicaciones> Ubicaciones_ListarPorFiltro(PtuUbicaciones pPtuUbicaciones)
        {
            dbconex = new Db();
            try
            {
                string vchubipretmp = "";
                string[] parametros = pPtuUbicaciones.vchubipre.Split(Convert.ToChar(" "));
                foreach (string valor in parametros)
                {
                    vchubipretmp = vchubipretmp + valor + "%";
                }
                pPtuUbicaciones.vchubipre = "%" + vchubipretmp;


                oPtuUbicaciones_dao = ObjectFactory.Instanciar<PtuUbicaciones_dao>(new PtuUbicaciones(), this.logMensajes, dbconex);
                dbconex.IniciarTransaccion();

                oPtuUbicacionesList = oPtuUbicaciones_dao.ListarPorFiltro(pPtuUbicaciones);

                dbconex.RegistrarTransaccion();
            }
            catch (Exception ex)
            {
                dbconex.AnularTransaccion();
                throw ex;
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuUbicacionesList;
        }
        #endregion

    }
}