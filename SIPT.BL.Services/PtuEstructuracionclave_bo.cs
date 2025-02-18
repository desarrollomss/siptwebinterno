using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.DTO.Mapper;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIPT.BL.Services
{
	public class PtuEstructuracionclave_bo
	{
		private PtuEstructuracionclave_dao oPtuEstructuracionclave_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuEstructuracionclave_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public int Insertar(PtuEstructuracionclaveDTO pPtuEstructuracionclaveDTO)
		{
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();
				oPtuEstructuracionclave_dao = ObjectFactory.Instanciar<PtuEstructuracionclave_dao>(new PtuEstructuracionclave(), this.logMensajes, dbconex);

				Mapeos mapeo = new Mapeos();
				PtuEstructuracionclave oPtuEstructuracionclave = mapeo.Map<PtuEstructuracionclaveDTO, PtuEstructuracionclave>(pPtuEstructuracionclaveDTO);

				oPtuEstructuracionclave_dao.Insertar(oPtuEstructuracionclave);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return 1;
		}

		public int Actualizar(PtuEstructuracionclaveDTO pPtuEstructuracionclaveDTO)
		{
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();
				oPtuEstructuracionclave_dao = ObjectFactory.Instanciar<PtuEstructuracionclave_dao>(new PtuEstructuracionclave(), this.logMensajes, dbconex);

				Mapeos mapeo = new Mapeos();
				PtuEstructuracionclave oPtuEstructuracionclave = mapeo.Map<PtuEstructuracionclaveDTO, PtuEstructuracionclave>(pPtuEstructuracionclaveDTO);

				oPtuEstructuracionclave_dao.Actualizar(oPtuEstructuracionclave);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return 1;
		}

		public int Eliminar(int? intcodestructuracionclave)
		{
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();
				oPtuEstructuracionclave_dao = ObjectFactory.Instanciar<PtuEstructuracionclave_dao>(new PtuEstructuracionclave(), this.logMensajes, dbconex);
				oPtuEstructuracionclave_dao.Eliminar(intcodestructuracionclave);
				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return 1;
		}

		public List<PtuEstructuracionclaveDTO> Listar()
		{
			List<PtuEstructuracionclave> oPtuEstructuracionclaveList;
			List<PtuEstructuracionclaveDTO> oPtuEstructuracionclaveDTOList;
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();
				oPtuEstructuracionclave_dao = ObjectFactory.Instanciar<PtuEstructuracionclave_dao>(new PtuEstructuracionclave(), this.logMensajes, dbconex);
				oPtuEstructuracionclaveList = oPtuEstructuracionclave_dao.Listar();
				dbconex.RegistrarTransaccion();
				
				Mapeos mapeo = new Mapeos();
				oPtuEstructuracionclaveDTOList = mapeo.MapList<PtuEstructuracionclave, PtuEstructuracionclaveDTO>(oPtuEstructuracionclaveList);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuEstructuracionclaveDTOList;
		}

		public PtuEstructuracionclaveDTO ListarKey(int? intcodestructuracionclave)
		{
			PtuEstructuracionclave oPtuEstructuracionclave;
			PtuEstructuracionclaveDTO oPtuEstructuracionclaveDTO;
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();
			
				oPtuEstructuracionclave_dao = ObjectFactory.Instanciar<PtuEstructuracionclave_dao>(new PtuEstructuracionclave(), this.logMensajes, dbconex);
				oPtuEstructuracionclave = oPtuEstructuracionclave_dao.ListarKey(intcodestructuracionclave);
			
				dbconex.RegistrarTransaccion();
			
				Mapeos mapeo = new Mapeos();
				oPtuEstructuracionclaveDTO = mapeo.Map<PtuEstructuracionclave, PtuEstructuracionclaveDTO>(oPtuEstructuracionclave);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuEstructuracionclaveDTO;
		}

		public List<PtuEstructuracionclaveDTO> ListarKeys(
								int? intcodestructuracionclave,
								int? intcodestructuracion)
		{
			List<PtuEstructuracionclave> oPtuEstructuracionclaveList;
			List<PtuEstructuracionclaveDTO> oPtuEstructuracionclaveDTOList;
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();
			
				oPtuEstructuracionclave_dao = ObjectFactory.Instanciar<PtuEstructuracionclave_dao>(new PtuEstructuracionclave(), this.logMensajes, dbconex);
				oPtuEstructuracionclaveList = oPtuEstructuracionclave_dao.ListarKeys(intcodestructuracionclave,intcodestructuracion);
			
				dbconex.RegistrarTransaccion();
			
				Mapeos mapeo = new Mapeos();
				oPtuEstructuracionclaveDTOList = mapeo.MapList<PtuEstructuracionclave, PtuEstructuracionclaveDTO>(oPtuEstructuracionclaveList);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuEstructuracionclaveDTOList;
		}


	}
}
