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
	public class PtuRequerimientostupa_bo
	{
		private PtuRequerimientostupa_dao oPtuRequerimientostupa_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuRequerimientostupa_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuRequerimientostupaDTO Insertar(PtuRequerimientostupaDTO pPtuRequerimientostupaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuRequerimientostupa_dao = ObjectFactory.Instanciar<PtuRequerimientostupa_dao>(new PtuRequerimientostupa(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuRequerimientostupa oPtuRequerimientostupa = mapeo.Map<PtuRequerimientostupaDTO, PtuRequerimientostupa>(pPtuRequerimientostupaDTO);

				dbconex.IniciarTransaccion();
				pPtuRequerimientostupaDTO.intcodrequerimientotupa = oPtuRequerimientostupa_dao.Insertar(oPtuRequerimientostupa);
				dbconex.RegistrarTransaccion();

				return pPtuRequerimientostupaDTO;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Actualizar(PtuRequerimientostupaDTO pPtuRequerimientostupaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuRequerimientostupa_dao = ObjectFactory.Instanciar<PtuRequerimientostupa_dao>(new PtuRequerimientostupa(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuRequerimientostupa oPtuRequerimientostupa = mapeo.Map<PtuRequerimientostupaDTO, PtuRequerimientostupa>(pPtuRequerimientostupaDTO);

				dbconex.IniciarTransaccion();
				oPtuRequerimientostupa_dao.Actualizar(oPtuRequerimientostupa);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Eliminar(int? intcodrequerimientotupa)
		{
			dbconex = new Db();
			try
			{
				oPtuRequerimientostupa_dao = ObjectFactory.Instanciar<PtuRequerimientostupa_dao>(new PtuRequerimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuRequerimientostupa_dao.Eliminar(intcodrequerimientotupa);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public List<PtuRequerimientostupaDTO> Listar()
		{
			List<PtuRequerimientostupa> oPtuRequerimientostupaList;
			List<PtuRequerimientostupaDTO> oPtuRequerimientostupaDTOList = new List<PtuRequerimientostupaDTO>();
			dbconex = new Db();
			try
			{
				oPtuRequerimientostupa_dao = ObjectFactory.Instanciar<PtuRequerimientostupa_dao>(new PtuRequerimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuRequerimientostupaList = oPtuRequerimientostupa_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuRequerimientostupa oPtuRequerimientostupa in oPtuRequerimientostupaList)
				{
					var oPtuRequerimientostupaDTO = mapeo.Map<PtuRequerimientostupa, PtuRequerimientostupaDTO>(oPtuRequerimientostupa);
					oPtuRequerimientostupaDTOList.Add(oPtuRequerimientostupaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuRequerimientostupaDTOList;
		}

		public PtuRequerimientostupaDTO ListarKey(int? intcodrequerimientotupa)
		{
			PtuRequerimientostupaDTO oPtuRequerimientostupaDTO;
			dbconex = new Db();
			try
			{
				oPtuRequerimientostupa_dao = ObjectFactory.Instanciar<PtuRequerimientostupa_dao>(new PtuRequerimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuRequerimientostupa oPtuRequerimientostupa = oPtuRequerimientostupa_dao.ListarKey(intcodrequerimientotupa);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuRequerimientostupaDTO = mapeo.Map<PtuRequerimientostupa, PtuRequerimientostupaDTO>(oPtuRequerimientostupa);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuRequerimientostupaDTO;
		}

		public List<PtuRequerimientostupaDTO> ListarKeys(
								int? intcodrequerimientotupa,
								int? intcodplantilla,
								int? intcodigoprocedimiento)
		{
			List<PtuRequerimientostupa> oPtuRequerimientostupaList;
			List<PtuRequerimientostupaDTO> oPtuRequerimientostupaDTOList = new List<PtuRequerimientostupaDTO>();
			dbconex = new Db();
			try
			{
				oPtuRequerimientostupa_dao = ObjectFactory.Instanciar<PtuRequerimientostupa_dao>(new PtuRequerimientostupa(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuRequerimientostupaList = oPtuRequerimientostupa_dao.ListarKeys(
								intcodrequerimientotupa,
								intcodplantilla,
								intcodigoprocedimiento);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuRequerimientostupa oPtuRequerimientostupa in oPtuRequerimientostupaList)
				{
					var oPtuRequerimientostupaDTO = mapeo.Map<PtuRequerimientostupa, PtuRequerimientostupaDTO>(oPtuRequerimientostupa);
					oPtuRequerimientostupaDTOList.Add(oPtuRequerimientostupaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuRequerimientostupaDTOList;
		}



	}
}
