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
	public class PtuDiligencia_bo
	{
		private PtuDiligencia_dao oPtuDiligencia_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuDiligencia_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuDiligenciaDTO Insertar(PtuDiligenciaDTO pPtuDiligenciaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuDiligencia_dao = ObjectFactory.Instanciar<PtuDiligencia_dao>(new PtuDiligencia(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuDiligencia oPtuDiligencia = mapeo.Map<PtuDiligenciaDTO, PtuDiligencia>(pPtuDiligenciaDTO);

				dbconex.IniciarTransaccion();
				pPtuDiligenciaDTO.intcoddiligencia = oPtuDiligencia_dao.Insertar(oPtuDiligencia);
				dbconex.RegistrarTransaccion();

				return pPtuDiligenciaDTO;
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

		public void Actualizar(PtuDiligenciaDTO pPtuDiligenciaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuDiligencia_dao = ObjectFactory.Instanciar<PtuDiligencia_dao>(new PtuDiligencia(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuDiligencia oPtuDiligencia = mapeo.Map<PtuDiligenciaDTO, PtuDiligencia>(pPtuDiligenciaDTO);

				dbconex.IniciarTransaccion();
				oPtuDiligencia_dao.Actualizar(oPtuDiligencia);
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

		public void Eliminar(int? intcoddiligencia)
		{
			dbconex = new Db();
			try
			{
				oPtuDiligencia_dao = ObjectFactory.Instanciar<PtuDiligencia_dao>(new PtuDiligencia(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuDiligencia_dao.Eliminar(intcoddiligencia);
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

		public List<PtuDiligenciaDTO> Listar()
		{
			List<PtuDiligencia> oPtuDiligenciaList;
			List<PtuDiligenciaDTO> oPtuDiligenciaDTOList = new List<PtuDiligenciaDTO>();
			dbconex = new Db();
			try
			{
				oPtuDiligencia_dao = ObjectFactory.Instanciar<PtuDiligencia_dao>(new PtuDiligencia(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuDiligenciaList = oPtuDiligencia_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuDiligencia oPtuDiligencia in oPtuDiligenciaList)
				{
					var oPtuDiligenciaDTO = mapeo.Map<PtuDiligencia, PtuDiligenciaDTO>(oPtuDiligencia);
					oPtuDiligenciaDTOList.Add(oPtuDiligenciaDTO);
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
			return oPtuDiligenciaDTOList;
		}

		public PtuDiligenciaDTO ListarKey(int? intcoddiligencia)
		{
			PtuDiligenciaDTO oPtuDiligenciaDTO;
			dbconex = new Db();
			try
			{
				oPtuDiligencia_dao = ObjectFactory.Instanciar<PtuDiligencia_dao>(new PtuDiligencia(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuDiligencia oPtuDiligencia = oPtuDiligencia_dao.ListarKey(intcoddiligencia);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuDiligenciaDTO = mapeo.Map<PtuDiligencia, PtuDiligenciaDTO>(oPtuDiligencia);
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
			return oPtuDiligenciaDTO;
		}

		public List<PtuDiligencia> ListarKeys(
								int? intcoddiligencia,
								int? intcodsolicitud)
		{
			List<PtuDiligencia> oPtuDiligenciaList;
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();

				oPtuDiligencia_dao = ObjectFactory.Instanciar<PtuDiligencia_dao>(new PtuDiligencia(), this.logMensajes, dbconex);
				oPtuDiligenciaList = oPtuDiligencia_dao.ListarKeys(
								intcoddiligencia,
								intcodsolicitud);

				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuDiligenciaList;
		}


	}
}
