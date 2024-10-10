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
	public class PtuProcedimientostupa_bo
	{
		private PtuProcedimientostupa_dao oPtuProcedimientostupa_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuProcedimientostupa_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuProcedimientostupaDTO Insertar(PtuProcedimientostupaDTO pPtuProcedimientostupaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuProcedimientostupa oPtuProcedimientostupa = mapeo.Map<PtuProcedimientostupaDTO, PtuProcedimientostupa>(pPtuProcedimientostupaDTO);

				dbconex.IniciarTransaccion();
				pPtuProcedimientostupaDTO.intcodigoprocedimiento = oPtuProcedimientostupa_dao.Insertar(oPtuProcedimientostupa);
				dbconex.RegistrarTransaccion();

				return pPtuProcedimientostupaDTO;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Actualizar(PtuProcedimientostupaDTO pPtuProcedimientostupaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuProcedimientostupa oPtuProcedimientostupa = mapeo.Map<PtuProcedimientostupaDTO, PtuProcedimientostupa>(pPtuProcedimientostupaDTO);

				dbconex.IniciarTransaccion();
				oPtuProcedimientostupa_dao.Actualizar(oPtuProcedimientostupa);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Eliminar(int? intcodigoprocedimiento)
		{
			dbconex = new Db();
			try
			{
				oPtuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuProcedimientostupa_dao.Eliminar(intcodigoprocedimiento);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public List<PtuProcedimientostupaDTO> Listar()
		{
			List<PtuProcedimientostupa> oPtuProcedimientostupaList;
			List<PtuProcedimientostupaDTO> oPtuProcedimientostupaDTOList = new List<PtuProcedimientostupaDTO>();
			dbconex = new Db();
			try
			{
				oPtuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuProcedimientostupaList = oPtuProcedimientostupa_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuProcedimientostupa oPtuProcedimientostupa in oPtuProcedimientostupaList)
				{
					var oPtuProcedimientostupaDTO = mapeo.Map<PtuProcedimientostupa, PtuProcedimientostupaDTO>(oPtuProcedimientostupa);
					oPtuProcedimientostupaDTOList.Add(oPtuProcedimientostupaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuProcedimientostupaDTOList;
		}

		public PtuProcedimientostupaDTO ListarKey(int? intcodigoprocedimiento)
		{
			PtuProcedimientostupaDTO oPtuProcedimientostupaDTO;
			dbconex = new Db();
			try
			{
				oPtuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuProcedimientostupa oPtuProcedimientostupa = oPtuProcedimientostupa_dao.ListarKey(intcodigoprocedimiento);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuProcedimientostupaDTO = mapeo.Map<PtuProcedimientostupa, PtuProcedimientostupaDTO>(oPtuProcedimientostupa);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuProcedimientostupaDTO;
		}

		public List<PtuProcedimientostupaDTO> ListarKeys(
								int? intcodigoprocedimiento)
		{
			List<PtuProcedimientostupa> oPtuProcedimientostupaList;
			List<PtuProcedimientostupaDTO> oPtuProcedimientostupaDTOList = new List<PtuProcedimientostupaDTO>();
			dbconex = new Db();
			try
			{
				oPtuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuProcedimientostupaList = oPtuProcedimientostupa_dao.ListarKeys(
								intcodigoprocedimiento);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuProcedimientostupa oPtuProcedimientostupa in oPtuProcedimientostupaList)
				{
					var oPtuProcedimientostupaDTO = mapeo.Map<PtuProcedimientostupa, PtuProcedimientostupaDTO>(oPtuProcedimientostupa);
					oPtuProcedimientostupaDTOList.Add(oPtuProcedimientostupaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuProcedimientostupaDTOList;
		}


	}
}
