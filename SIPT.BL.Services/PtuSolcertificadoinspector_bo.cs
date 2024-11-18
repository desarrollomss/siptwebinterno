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
	public class PtuSolcertificadoinspector_bo
	{
		private PtuSolcertificadoinspector_dao oPtuSolcertificadoinspector_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolcertificadoinspector_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuSolcertificadoinspectorDTO Insertar(PtuSolcertificadoinspectorDTO pPtuSolcertificadoinspectorDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolcertificadoinspector_dao = ObjectFactory.Instanciar<PtuSolcertificadoinspector_dao>(new PtuSolcertificadoinspector(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolcertificadoinspector oPtuSolcertificadoinspector = mapeo.Map<PtuSolcertificadoinspectorDTO, PtuSolcertificadoinspector>(pPtuSolcertificadoinspectorDTO);

				dbconex.IniciarTransaccion();
				pPtuSolcertificadoinspectorDTO.intcodsolicitudinspector = oPtuSolcertificadoinspector_dao.Insertar(oPtuSolcertificadoinspector);
				dbconex.RegistrarTransaccion();

				return pPtuSolcertificadoinspectorDTO;
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

		public void Actualizar(PtuSolcertificadoinspectorDTO pPtuSolcertificadoinspectorDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolcertificadoinspector_dao = ObjectFactory.Instanciar<PtuSolcertificadoinspector_dao>(new PtuSolcertificadoinspector(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolcertificadoinspector oPtuSolcertificadoinspector = mapeo.Map<PtuSolcertificadoinspectorDTO, PtuSolcertificadoinspector>(pPtuSolcertificadoinspectorDTO);

				dbconex.IniciarTransaccion();
				oPtuSolcertificadoinspector_dao.Actualizar(oPtuSolcertificadoinspector);
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

		public void Eliminar(int? intcodsolicitudinspector)
		{
			dbconex = new Db();
			try
			{
				oPtuSolcertificadoinspector_dao = ObjectFactory.Instanciar<PtuSolcertificadoinspector_dao>(new PtuSolcertificadoinspector(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolcertificadoinspector_dao.Eliminar(intcodsolicitudinspector);
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

		public List<PtuSolcertificadoinspectorDTO> Listar()
		{
			List<PtuSolcertificadoinspector> oPtuSolcertificadoinspectorList;
			List<PtuSolcertificadoinspectorDTO> oPtuSolcertificadoinspectorDTOList = new List<PtuSolcertificadoinspectorDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolcertificadoinspector_dao = ObjectFactory.Instanciar<PtuSolcertificadoinspector_dao>(new PtuSolcertificadoinspector(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolcertificadoinspectorList = oPtuSolcertificadoinspector_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuSolcertificadoinspector oPtuSolcertificadoinspector in oPtuSolcertificadoinspectorList)
				{
					var oPtuSolcertificadoinspectorDTO = mapeo.Map<PtuSolcertificadoinspector, PtuSolcertificadoinspectorDTO>(oPtuSolcertificadoinspector);
					oPtuSolcertificadoinspectorDTOList.Add(oPtuSolcertificadoinspectorDTO);
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
			return oPtuSolcertificadoinspectorDTOList;
		}

		public PtuSolcertificadoinspectorDTO ListarKey(int? intcodsolicitudinspector)
		{
			PtuSolcertificadoinspectorDTO oPtuSolcertificadoinspectorDTO;
			dbconex = new Db();
			try
			{
				oPtuSolcertificadoinspector_dao = ObjectFactory.Instanciar<PtuSolcertificadoinspector_dao>(new PtuSolcertificadoinspector(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuSolcertificadoinspector oPtuSolcertificadoinspector = oPtuSolcertificadoinspector_dao.ListarKey(intcodsolicitudinspector);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuSolcertificadoinspectorDTO = mapeo.Map<PtuSolcertificadoinspector, PtuSolcertificadoinspectorDTO>(oPtuSolcertificadoinspector);
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
			return oPtuSolcertificadoinspectorDTO;
		}

		public List<PtuSolcertificadoinspectorDTO> ListarKeys(
								int? intcodsolicitudinspector,
								int? intcodsolicitud)
		{
			List<PtuSolcertificadoinspector> oPtuSolcertificadoinspectorList;
			List<PtuSolcertificadoinspectorDTO> oPtuSolcertificadoinspectorDTOList = new List<PtuSolcertificadoinspectorDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolcertificadoinspector_dao = ObjectFactory.Instanciar<PtuSolcertificadoinspector_dao>(new PtuSolcertificadoinspector(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolcertificadoinspectorList = oPtuSolcertificadoinspector_dao.ListarKeys(
								intcodsolicitudinspector,
								intcodsolicitud);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuSolcertificadoinspector oPtuSolcertificadoinspector in oPtuSolcertificadoinspectorList)
				{
					var oPtuSolcertificadoinspectorDTO = mapeo.Map<PtuSolcertificadoinspector, PtuSolcertificadoinspectorDTO>(oPtuSolcertificadoinspector);
					oPtuSolcertificadoinspectorDTOList.Add(oPtuSolcertificadoinspectorDTO);
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
			return oPtuSolcertificadoinspectorDTOList;
		}


	}
}
