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
	public class PtuSolreqdetalle_bo
	{
		private PtuSolreqdetalle_dao oPtuSolreqdetalle_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolreqdetalle_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuSolreqdetalleDTO Insertar(PtuSolreqdetalleDTO pPtuSolreqdetalleDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolreqdetalle oPtuSolreqdetalle = mapeo.Map<PtuSolreqdetalleDTO, PtuSolreqdetalle>(pPtuSolreqdetalleDTO);

				dbconex.IniciarTransaccion();
				pPtuSolreqdetalleDTO.intcodsolreqdetalle = oPtuSolreqdetalle_dao.Insertar(oPtuSolreqdetalle);
				dbconex.RegistrarTransaccion();

				return pPtuSolreqdetalleDTO;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Actualizar(PtuSolreqdetalleDTO pPtuSolreqdetalleDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolreqdetalle oPtuSolreqdetalle = mapeo.Map<PtuSolreqdetalleDTO, PtuSolreqdetalle>(pPtuSolreqdetalleDTO);

				dbconex.IniciarTransaccion();
				oPtuSolreqdetalle_dao.Actualizar(oPtuSolreqdetalle);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Eliminar(int? intcodsolreqdetalle)
		{
			dbconex = new Db();
			try
			{
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolreqdetalle_dao.Eliminar(intcodsolreqdetalle);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public List<PtuSolreqdetalleDTO> Listar()
		{
			List<PtuSolreqdetalle> oPtuSolreqdetalleList;
			List<PtuSolreqdetalleDTO> oPtuSolreqdetalleDTOList = new List<PtuSolreqdetalleDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolreqdetalleList = oPtuSolreqdetalle_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuSolreqdetalle oPtuSolreqdetalle in oPtuSolreqdetalleList)
				{
					var oPtuSolreqdetalleDTO = mapeo.Map<PtuSolreqdetalle, PtuSolreqdetalleDTO>(oPtuSolreqdetalle);
					oPtuSolreqdetalleDTOList.Add(oPtuSolreqdetalleDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolreqdetalleDTOList;
		}

		public PtuSolreqdetalleDTO ListarKey(int? intcodsolreqdetalle)
		{
			PtuSolreqdetalleDTO oPtuSolreqdetalleDTO;
			dbconex = new Db();
			try
			{
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuSolreqdetalle oPtuSolreqdetalle = oPtuSolreqdetalle_dao.ListarKey(intcodsolreqdetalle);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuSolreqdetalleDTO = mapeo.Map<PtuSolreqdetalle, PtuSolreqdetalleDTO>(oPtuSolreqdetalle);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolreqdetalleDTO;
		}

		public List<PtuSolreqdetalleDTO> ListarKeys(
								int? intcodsolreqdetalle,
								int? intcodsolreqgrupo)
		{
			List<PtuSolreqdetalle> oPtuSolreqdetalleList;
			List<PtuSolreqdetalleDTO> oPtuSolreqdetalleDTOList = new List<PtuSolreqdetalleDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolreqdetalleList = oPtuSolreqdetalle_dao.ListarKeys(
								intcodsolreqdetalle,
								intcodsolreqgrupo);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuSolreqdetalle oPtuSolreqdetalle in oPtuSolreqdetalleList)
				{
					var oPtuSolreqdetalleDTO = mapeo.Map<PtuSolreqdetalle, PtuSolreqdetalleDTO>(oPtuSolreqdetalle);
					oPtuSolreqdetalleDTOList.Add(oPtuSolreqdetalleDTO);
				}
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolreqdetalleDTOList;
		}


	}
}
