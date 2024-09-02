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
	public class PtuPlantillareq_bo
	{
		private PtuPlantillareq_dao oPtuPlantillareq_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuPlantillareq_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuPlantillareqDTO Insertar(PtuPlantillareqDTO pPtuPlantillareqDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuPlantillareq oPtuPlantillareq = mapeo.Map<PtuPlantillareqDTO, PtuPlantillareq>(pPtuPlantillareqDTO);

				dbconex.IniciarTransaccion();
				pPtuPlantillareqDTO.intcodplantilla = oPtuPlantillareq_dao.Insertar(oPtuPlantillareq);
				dbconex.RegistrarTransaccion();

				return pPtuPlantillareqDTO;
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
		}

		public void Actualizar(PtuPlantillareqDTO pPtuPlantillareqDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuPlantillareq oPtuPlantillareq = mapeo.Map<PtuPlantillareqDTO, PtuPlantillareq>(pPtuPlantillareqDTO);

				dbconex.IniciarTransaccion();
				oPtuPlantillareq_dao.Actualizar(oPtuPlantillareq);
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
		}

		public void Eliminar(int? intcodplantilla)
		{
			dbconex = new Db();
			try
			{
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuPlantillareq_dao.Eliminar(intcodplantilla);
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
		}

		public List<PtuPlantillareqDTO> Listar()
		{
			List<PtuPlantillareq> oPtuPlantillareqList;
			List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();
			dbconex = new Db();
			try
			{
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuPlantillareqList = oPtuPlantillareq_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuPlantillareq oPtuPlantillareq in oPtuPlantillareqList)
				{
					var oPtuPlantillareqDTO = mapeo.Map<PtuPlantillareq, PtuPlantillareqDTO>(oPtuPlantillareq);
					oPtuPlantillareqDTOList.Add(oPtuPlantillareqDTO);
				}
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
			return oPtuPlantillareqDTOList;
		}

		public PtuPlantillareqDTO ListarKey(int? intcodplantilla)
		{
			PtuPlantillareqDTO oPtuPlantillareqDTO;
			dbconex = new Db();
			try
			{
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuPlantillareq oPtuPlantillareq = oPtuPlantillareq_dao.ListarKey(intcodplantilla);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuPlantillareqDTO = mapeo.Map<PtuPlantillareq, PtuPlantillareqDTO>(oPtuPlantillareq);
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
			return oPtuPlantillareqDTO;
		}

		public List<PtuPlantillareqDTO> ListarKeys(
								int? intcodplantilla)
		{
			List<PtuPlantillareq> oPtuPlantillareqList;
			List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();
			dbconex = new Db();
			try
			{
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuPlantillareqList = oPtuPlantillareq_dao.ListarKeys(
								intcodplantilla);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuPlantillareq oPtuPlantillareq in oPtuPlantillareqList)
				{
					var oPtuPlantillareqDTO = mapeo.Map<PtuPlantillareq, PtuPlantillareqDTO>(oPtuPlantillareq);
					oPtuPlantillareqDTOList.Add(oPtuPlantillareqDTO);
				}
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
			return oPtuPlantillareqDTOList;
		}

		public List<PtuPlantillareqDTO> ListarPlantillas(int? intcodplantilla, int? intcodigoprocedimiento, int? intcodsolicitud)
		{
			List<PtuPlantillareq> oPtuPlantillareqList;
			List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();
			dbconex = new Db();
			try
			{
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuPlantillareqList = oPtuPlantillareq_dao.ListarPlantillas(intcodplantilla, intcodigoprocedimiento, intcodsolicitud);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuPlantillareq oPtuPlantillareq in oPtuPlantillareqList)
				{
					var oPtuPlantillareqDTO = mapeo.Map<PtuPlantillareq, PtuPlantillareqDTO>(oPtuPlantillareq);
					oPtuPlantillareqDTOList.Add(oPtuPlantillareqDTO);
				}
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
			return oPtuPlantillareqDTOList;
		}


	}
}
