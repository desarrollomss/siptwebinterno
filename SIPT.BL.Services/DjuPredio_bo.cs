using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;

namespace SIPT.BL.Services
{
    public class DjuPredio_bo
    {
		private List<PtuUbicaciones> oPtuUbicacionesList;
		private DjuPredio_dao oDjuPredio_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public DjuPredio_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

        public List<PtuUbicaciones> Ubicaciones_ListarPorFiltro(PtuUbicaciones pPtuUbicaciones)
        {
            dbconex = new Db();
            try
            {
                string vchubipretmp = "";
                int codigo;
                Int32 esNumero = 0;
                if (int.TryParse(pPtuUbicaciones.vchubipre.Trim(), out codigo))
                {
                    esNumero = 1;
                }
                string[] parametros = pPtuUbicaciones.vchubipre.Split(Convert.ToChar(" "));
                foreach (string valor in parametros)
                {
                    vchubipretmp = vchubipretmp + valor + "%";
                }
                pPtuUbicaciones.vchubipre = "%" + vchubipretmp;

                dbconex.IniciarTransaccion();
                oDjuPredio_dao = ObjectFactory.Instanciar<DjuPredio_dao>(new DjuPredio(), this.logMensajes, dbconex);

                oPtuUbicacionesList = oDjuPredio_dao.ListarPorFiltro(pPtuUbicaciones, esNumero);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuUbicacionesList;
        }

    }
}
