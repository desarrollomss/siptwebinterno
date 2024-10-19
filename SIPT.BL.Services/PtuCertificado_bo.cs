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
	public class PtuCertificado_bo
	{
		private PtuCertificado_dao oPtuCertificado_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuCertificado_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuCertificadoDTO Insertar(PtuCertificadoDTO pPtuCertificadoDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuCertificado_dao = ObjectFactory.Instanciar<PtuCertificado_dao>(new PtuCertificado(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuCertificado oPtuCertificado = mapeo.Map<PtuCertificadoDTO, PtuCertificado>(pPtuCertificadoDTO);

				dbconex.IniciarTransaccion();
				pPtuCertificadoDTO.intcodcertificado = oPtuCertificado_dao.Insertar(oPtuCertificado);
				dbconex.RegistrarTransaccion();

				return pPtuCertificadoDTO;
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

		public void Actualizar(PtuCertificadoDTO pPtuCertificadoDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuCertificado_dao = ObjectFactory.Instanciar<PtuCertificado_dao>(new PtuCertificado(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuCertificado oPtuCertificado = mapeo.Map<PtuCertificadoDTO, PtuCertificado>(pPtuCertificadoDTO);

				dbconex.IniciarTransaccion();
				oPtuCertificado_dao.Actualizar(oPtuCertificado);
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

		public void Eliminar(int? intcodcertificado)
		{
			dbconex = new Db();
			try
			{
				oPtuCertificado_dao = ObjectFactory.Instanciar<PtuCertificado_dao>(new PtuCertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuCertificado_dao.Eliminar(intcodcertificado);
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

		public List<PtuCertificadoDTO> Listar()
		{
			List<PtuCertificado> oPtuCertificadoList;
			List<PtuCertificadoDTO> oPtuCertificadoDTOList = new List<PtuCertificadoDTO>();
			dbconex = new Db();
			try
			{
				oPtuCertificado_dao = ObjectFactory.Instanciar<PtuCertificado_dao>(new PtuCertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuCertificadoList = oPtuCertificado_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuCertificado oPtuCertificado in oPtuCertificadoList)
				{
					var oPtuCertificadoDTO = mapeo.Map<PtuCertificado, PtuCertificadoDTO>(oPtuCertificado);
					oPtuCertificadoDTOList.Add(oPtuCertificadoDTO);
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
			return oPtuCertificadoDTOList;
		}

		public PtuCertificadoDTO ListarKey(int? intcodcertificado)
		{
			PtuCertificadoDTO oPtuCertificadoDTO;
			dbconex = new Db();
			try
			{
				oPtuCertificado_dao = ObjectFactory.Instanciar<PtuCertificado_dao>(new PtuCertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuCertificado oPtuCertificado = oPtuCertificado_dao.ListarKey(intcodcertificado);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuCertificadoDTO = mapeo.Map<PtuCertificado, PtuCertificadoDTO>(oPtuCertificado);
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
			return oPtuCertificadoDTO;
		}

		public List<PtuCertificadoDTO> ListarKeys(
								int? intcodcertificado,
								int? intcodsolicitud)
		{
			List<PtuCertificado> oPtuCertificadoList;
			List<PtuCertificadoDTO> oPtuCertificadoDTOList = new List<PtuCertificadoDTO>();
			dbconex = new Db();
			try
			{
				oPtuCertificado_dao = ObjectFactory.Instanciar<PtuCertificado_dao>(new PtuCertificado(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuCertificadoList = oPtuCertificado_dao.ListarKeys(
								intcodcertificado,
								intcodsolicitud);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuCertificado oPtuCertificado in oPtuCertificadoList)
				{
					var oPtuCertificadoDTO = mapeo.Map<PtuCertificado, PtuCertificadoDTO>(oPtuCertificado);
					oPtuCertificadoDTOList.Add(oPtuCertificadoDTO);
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
			return oPtuCertificadoDTOList;
		}


	}
}
