using System;
using DBAccess;
using System.Collections.Generic;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.DTO.Mapper;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;

namespace SIPT.BL.Services
{
	public class PtuLicencia_bo
	{
		private PtuLicencia_dao oPtuLicencia_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuLicencia_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuLicenciaDTO Insertar(PtuLicenciaDTO pPtuLicenciaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuLicencia_dao = ObjectFactory.Instanciar<PtuLicencia_dao>(new PtuLicencia(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuLicencia oPtuLicencia = mapeo.Map<PtuLicenciaDTO, PtuLicencia>(pPtuLicenciaDTO);

				dbconex.IniciarTransaccion();
				pPtuLicenciaDTO.intcodlicencia = oPtuLicencia_dao.Insertar(oPtuLicencia);
				dbconex.RegistrarTransaccion();

				return pPtuLicenciaDTO;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public List<PtuLicenciaDTO> ListarKeys(
								int? intcodlicencia,
								int? intcodsolicitud)
		{
			List<PtuLicencia> oPtuLicenciaList;
			List<PtuLicenciaDTO> oPtuLicenciaDTOList = new List<PtuLicenciaDTO>();
			dbconex = new Db();
			try
			{
				oPtuLicencia_dao = ObjectFactory.Instanciar<PtuLicencia_dao>(new PtuLicencia(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuLicenciaList = oPtuLicencia_dao.ListarKeys(
								intcodlicencia,
								intcodsolicitud);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuLicencia oPtuLicencia in oPtuLicenciaList)
				{
					var oPtuLicenciaDTO = mapeo.Map<PtuLicencia, PtuLicenciaDTO>(oPtuLicencia);
					oPtuLicenciaDTOList.Add(oPtuLicenciaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuLicenciaDTOList;
		}


	}
}
