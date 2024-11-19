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
	public class PtuSolcertificado_bo
	{
		private PtuSolcertificado_dao oPtuSolcertificado_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolcertificado_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuSolcertificadoDTO Insertar(PtuSolcertificadoDTO pPtuSolcertificadoDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolcertificado_dao = ObjectFactory.Instanciar<PtuSolcertificado_dao>(new PtuSolcertificado(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolcertificado oPtuSolcertificado = mapeo.Map<PtuSolcertificadoDTO, PtuSolcertificado>(pPtuSolcertificadoDTO);

				dbconex.IniciarTransaccion();
				pPtuSolcertificadoDTO.intcodsolicitud = oPtuSolcertificado_dao.Insertar(oPtuSolcertificado);
				dbconex.RegistrarTransaccion();

				return pPtuSolcertificadoDTO;
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

		public void Actualizar(PtuSolcertificadoDTO pPtuSolcertificadoDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolcertificado_dao = ObjectFactory.Instanciar<PtuSolcertificado_dao>(new PtuSolcertificado(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolcertificado oPtuSolcertificado = mapeo.Map<PtuSolcertificadoDTO, PtuSolcertificado>(pPtuSolcertificadoDTO);

				dbconex.IniciarTransaccion();
				oPtuSolcertificado_dao.Actualizar(oPtuSolcertificado);
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

		public void Eliminar(int? intcodsolicitud)
		{
			dbconex = new Db();
			try
			{
				oPtuSolcertificado_dao = ObjectFactory.Instanciar<PtuSolcertificado_dao>(new PtuSolcertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolcertificado_dao.Eliminar(intcodsolicitud);
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

		public List<PtuSolcertificadoDTO> Listar()
		{
			List<PtuSolcertificado> oPtuSolcertificadoList;
			List<PtuSolcertificadoDTO> oPtuSolcertificadoDTOList = new List<PtuSolcertificadoDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolcertificado_dao = ObjectFactory.Instanciar<PtuSolcertificado_dao>(new PtuSolcertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolcertificadoList = oPtuSolcertificado_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuSolcertificado oPtuSolcertificado in oPtuSolcertificadoList)
				{
					var oPtuSolcertificadoDTO = mapeo.Map<PtuSolcertificado, PtuSolcertificadoDTO>(oPtuSolcertificado);
					oPtuSolcertificadoDTOList.Add(oPtuSolcertificadoDTO);
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
			return oPtuSolcertificadoDTOList;
		}

		public PtuSolcertificadoDTO ListarKey(int? intcodsolicitud)
		{
			PtuSolcertificadoDTO oPtuSolcertificadoDTO;
			dbconex = new Db();
			try
			{
				oPtuSolcertificado_dao = ObjectFactory.Instanciar<PtuSolcertificado_dao>(new PtuSolcertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuSolcertificado oPtuSolcertificado = oPtuSolcertificado_dao.ListarKey(intcodsolicitud);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuSolcertificadoDTO = mapeo.Map<PtuSolcertificado, PtuSolcertificadoDTO>(oPtuSolcertificado);
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
			return oPtuSolcertificadoDTO;
		}

		public List<PtuSolcertificadoDTO> ListarKeys(
								int? intcodsolicitud,
								int? intcodlicencia)
		{
			List<PtuSolcertificado> oPtuSolcertificadoList;
			List<PtuSolcertificadoDTO> oPtuSolcertificadoDTOList = new List<PtuSolcertificadoDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolcertificado_dao = ObjectFactory.Instanciar<PtuSolcertificado_dao>(new PtuSolcertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolcertificadoList = oPtuSolcertificado_dao.ListarKeys(
								intcodsolicitud,
								intcodlicencia);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuSolcertificado oPtuSolcertificado in oPtuSolcertificadoList)
				{
					var oPtuSolcertificadoDTO = mapeo.Map<PtuSolcertificado, PtuSolcertificadoDTO>(oPtuSolcertificado);
					oPtuSolcertificadoDTOList.Add(oPtuSolcertificadoDTO);
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
			return oPtuSolcertificadoDTOList;
		}

		public List<PtuSolcertificado_PorInspector> Buscar(
										PtuSolcertificado pPtuSolcertificado,
										PtuSolicitud pPtuSolicitud)
		{
			List<PtuSolcertificado_PorInspector> oPtuSolcertificado_PorInspectorList= null;
			dbconex = new Db();
			try
			{
				oPtuSolcertificado_dao = ObjectFactory.Instanciar<PtuSolcertificado_dao>(new PtuSolcertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolcertificado_PorInspectorList = oPtuSolcertificado_dao.Buscar(pPtuSolcertificado,pPtuSolicitud);
				dbconex.RegistrarTransaccion();

			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolcertificado_PorInspectorList;
		}


	}
}
