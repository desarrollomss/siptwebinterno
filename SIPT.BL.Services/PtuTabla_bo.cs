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
	public class PtuTabla_bo
	{
		private PtuTabla_dao oPtuTabla_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuTabla_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuTablaDTO Insertar(PtuTablaDTO pPtuTablaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuTabla oPtuTabla = mapeo.Map<PtuTablaDTO, PtuTabla>(pPtuTablaDTO);

				dbconex.IniciarTransaccion();
				pPtuTablaDTO.smlcodtabla = oPtuTabla_dao.Insertar(oPtuTabla);
				dbconex.RegistrarTransaccion();

				return pPtuTablaDTO;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Actualizar(PtuTablaDTO pPtuTablaDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuTabla oPtuTabla = mapeo.Map<PtuTablaDTO, PtuTabla>(pPtuTablaDTO);

				dbconex.IniciarTransaccion();
				oPtuTabla_dao.Actualizar(oPtuTabla);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Eliminar(int? smlcodtabla)
		{
			dbconex = new Db();
			try
			{
				oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuTabla_dao.Eliminar(smlcodtabla);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public List<PtuTablaDTO> Listar()
		{
			List<PtuTabla> oPtuTablaList;
			List<PtuTablaDTO> oPtuTablaDTOList = new List<PtuTablaDTO>();
			dbconex = new Db();
			try
			{
				oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuTablaList = oPtuTabla_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuTabla oPtuTabla in oPtuTablaList)
				{
					var oPtuTablaDTO = mapeo.Map<PtuTabla, PtuTablaDTO>(oPtuTabla);
					oPtuTablaDTOList.Add(oPtuTablaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuTablaDTOList;
		}

		public PtuTablaDTO ListarKey(int? smlcodtabla)
		{
			PtuTablaDTO oPtuTablaDTO;
			dbconex = new Db();
			try
			{
				oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuTabla oPtuTabla = oPtuTabla_dao.ListarKey(smlcodtabla);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuTablaDTO = mapeo.Map<PtuTabla, PtuTablaDTO>(oPtuTabla);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuTablaDTO;
		}

		public List<PtuTablaDTO> ListarKeys(
								Int16? smlcodtabla,
								Int16? smlestado)
		{
			List<PtuTabla> oPtuTablaList;
			List<PtuTablaDTO> oPtuTablaDTOList = new List<PtuTablaDTO>();
			dbconex = new Db();
			try
			{
				oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuTablaList = oPtuTabla_dao.ListarKeys(
								smlcodtabla,
								smlestado);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuTabla oPtuTabla in oPtuTablaList)
				{
					var oPtuTablaDTO = mapeo.Map<PtuTabla, PtuTablaDTO>(oPtuTabla);
					oPtuTablaDTOList.Add(oPtuTablaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuTablaDTOList;
		}

		public List<PtuTablaDTO> ListarTiposTramite(
								Int16? smlcodtabla,
								Int16? smlestado)
		{
			List<PtuTabla> oPtuTablaList;
			List<PtuTablaDTO> oPtuTablaDTOList = new List<PtuTablaDTO>();
			dbconex = new Db();
			try
			{
				oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuTablaList = oPtuTabla_dao.ListarKeys(
								smlcodtabla,
								smlestado);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				var vPtuTablaList = oPtuTablaList.FindAll(o => o.vchcampo == "SMLTIPOSOLICITUD");

				foreach (PtuTabla oPtuTabla in vPtuTablaList)
				{
					var oPtuTablaDTO = mapeo.Map<PtuTabla, PtuTablaDTO>(oPtuTabla);
					oPtuTablaDTOList.Add(oPtuTablaDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuTablaDTOList;

		}


	}
}
