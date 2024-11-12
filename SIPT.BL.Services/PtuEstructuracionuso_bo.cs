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
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Services
{
	public class PtuEstructuracionuso_bo
	{
		private PtuEstructuracion_dao oPtuEstructuracion_dao;
		private PtuEstructuracioncolumna_dao oPtuEstructuracioncolumna_dao;
		private PtuUbicaciones_dao oPtuUbicaciones_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuEstructuracionuso_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public List<PtuEstructuracionDTO> ListarEstructurasActivas()
		{
			List<PtuEstructuracion> oPtuEstructuracionList;
			List<PtuEstructuracionDTO> oPtuEstructuracionDTOList;
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();

				oPtuEstructuracion_dao = ObjectFactory.Instanciar<PtuEstructuracion_dao>(new PtuEstructuracion(), this.logMensajes, dbconex);
				oPtuEstructuracionList = oPtuEstructuracion_dao.ListarKeys(-1, 1);

				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuEstructuracionDTOList = mapeo.MapList<PtuEstructuracion, PtuEstructuracionDTO>(oPtuEstructuracionList);
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuEstructuracionDTOList;
		}

		public DataTable ListarEstructuraPorUso(int? intcodestructuracion, string vchcoduso, string vchnombreuso)
		{
			List<PtuEstructuracioncolumna> oPtuEstructuracioncolumnaList;
			DataTable tabla = new DataTable("MiTabla");
			dbconex = new Db();
			try
			{
				dbconex.IniciarTransaccion();

				oPtuEstructuracioncolumna_dao = ObjectFactory.Instanciar<PtuEstructuracioncolumna_dao>(new PtuEstructuracioncolumna(), this.logMensajes, dbconex);
				oPtuUbicaciones_dao = ObjectFactory.Instanciar<PtuUbicaciones_dao>(new PtuUbicaciones(), this.logMensajes, dbconex);

				oPtuEstructuracioncolumnaList = oPtuEstructuracioncolumna_dao.ListarKeys(-1, intcodestructuracion);

				StringBuilder oSQuery = new StringBuilder();
				oSQuery.Append("SELECT "); oSQuery.AppendLine();
				//oSQuery.Append("EST.INTCODESTRUCTURACIONUSO,"); oSQuery.AppendLine();
				//oSQuery.Append("EST.INTCODESTRUCTURACION,"); oSQuery.AppendLine();
				//oSQuery.Append("EST.INTCODUSO,"); oSQuery.AppendLine();
				oSQuery.Append("USO.VCHCODUSO AS CODIGO,"); oSQuery.AppendLine();
				oSQuery.Append("USO.VCHNOMBREUSO AS USO"); oSQuery.AppendLine();
				foreach (PtuEstructuracioncolumna oPtuEstructuracioncolumna in oPtuEstructuracioncolumnaList)
                {					
					oSQuery.Append(",EST."+ oPtuEstructuracioncolumna.vchcolumna+ " AS \""+ oPtuEstructuracioncolumna.vchcolumnazonificacion+ "\" "); oSQuery.AppendLine();
				}					
				oSQuery.Append("FROM SIPT.PTUESTRUCTURACIONUSO EST"); oSQuery.AppendLine();
				oSQuery.Append("INNER JOIN SIPT.PTUUSO USO ON EST.INTCODUSO = USO.INTCODUSO AND USO.CHRTIPO = 'U' ");
				oSQuery.Append("AND USO.VCHCODUSO LIKE '%"+ vchcoduso + "%' AND USO.VCHNOMBREUSO LIKE '%"+ vchnombreuso + "%'"); oSQuery.AppendLine();
				oSQuery.Append("WHERE EST.INTCODESTRUCTURACION = 1"); oSQuery.AppendLine();
				oSQuery.Append("ORDER BY EST.INTCODESTRUCTURACIONUSO ASC"); oSQuery.AppendLine();
				oSQuery.Append("FETCH FIRST 500 ROW ONLY WITH UR");

				tabla = oPtuUbicaciones_dao.EjecutarScriptDataTable(oSQuery.ToString());

				dbconex.RegistrarTransaccion();
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return tabla;

		}


	}
}
