using System;
using System.Data;
using IBM.Data.DB2;
using DBAccess;
using DBAccess.Util;
using System.Collections.Generic;
using SIPT.APPL.Logs;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using SIPT.DAL.Dao.Factory;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
	public class PtuRequerimientostupa_db2: PtuRequerimientostupa_dao
	{
		private List<PtuRequerimientostupa> oPtuRequerimientostupaList;
		private PtuRequerimientostupa oPtuRequerimientostupa;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuRequerimientostupa_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuRequerimientostupa pPtuRequerimientostupa)
		{
			DB2Parameter[] arrParam = new DB2Parameter[9];
			arrParam[0] = new DB2Parameter("@INTCODREQUERIMIENTOTUPA", DB2Type.Integer);
			arrParam[0].Direction = ParameterDirection.Output;
			arrParam[1] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
			arrParam[1].Value = pPtuRequerimientostupa.intcodplantilla;
			arrParam[2] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
			arrParam[2].Value = pPtuRequerimientostupa.intcodigoprocedimiento;
			arrParam[3] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
			arrParam[3].Value = pPtuRequerimientostupa.vchaudusucreacion;
			arrParam[4] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
			arrParam[4].Value = pPtuRequerimientostupa.tmsaudfeccreacion;
			arrParam[5] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
			arrParam[5].Value = pPtuRequerimientostupa.vchaudusumodif;
			arrParam[6] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
			arrParam[6].Value = pPtuRequerimientostupa.tmsaudfecmodif;
			arrParam[7] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
			arrParam[7].Value = pPtuRequerimientostupa.vchaudequipo;
			arrParam[8] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
			arrParam[8].Value = pPtuRequerimientostupa.vchaudprograma;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUREQUERIMIENTOSTUPA_INSERTAR", this.logMensajes, arrParam);
		
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuRequerimientostupa pPtuRequerimientostupa)
		{
			DB2Parameter[] arrParam = new DB2Parameter[9];

			arrParam[0] = new DB2Parameter("@INTCODREQUERIMIENTOTUPA", DB2Type.Integer);
			arrParam[0].Value = pPtuRequerimientostupa.intcodrequerimientotupa;
			arrParam[1] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
			arrParam[1].Value = pPtuRequerimientostupa.intcodplantilla;
			arrParam[2] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
			arrParam[2].Value = pPtuRequerimientostupa.intcodigoprocedimiento;
			arrParam[3] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
			arrParam[3].Value = pPtuRequerimientostupa.vchaudusucreacion;
			arrParam[4] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
			arrParam[4].Value = pPtuRequerimientostupa.tmsaudfeccreacion;
			arrParam[5] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
			arrParam[5].Value = pPtuRequerimientostupa.vchaudusumodif;
			arrParam[6] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
			arrParam[6].Value = pPtuRequerimientostupa.tmsaudfecmodif;
			arrParam[7] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
			arrParam[7].Value = pPtuRequerimientostupa.vchaudequipo;
			arrParam[8] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
			arrParam[8].Value = pPtuRequerimientostupa.vchaudprograma;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUREQUERIMIENTOSTUPA_ACTUALIZAR", this.logMensajes, arrParam);			
		}

		public override void Eliminar(int? intcodrequerimientotupa)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			
			arrParam[0] = new DB2Parameter("@INTCODREQUERIMIENTOTUPA", DB2Type.Integer);
			arrParam[0].Value = intcodrequerimientotupa;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUREQUERIMIENTOSTUPA_ELIMINAR", this.logMensajes, arrParam);		
		}

		public override List<PtuRequerimientostupa> Listar()
		{
			oPtuRequerimientostupaList = new List<PtuRequerimientostupa>();
			return DB2Comando.Listar<PtuRequerimientostupa>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUREQUERIMIENTOSTUPA_LISTAR", this.logMensajes);
		}

		public override PtuRequerimientostupa ListarKey(int? intcodrequerimientotupa)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			
			arrParam[0] = new DB2Parameter("@INTCODREQUERIMIENTOTUPA", DB2Type.Integer);
			arrParam[0].Value = intcodrequerimientotupa;
			return DB2Comando.Obtener<PtuRequerimientostupa>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUREQUERIMIENTOSTUPA_LISTARKEY", this.logMensajes, arrParam);			
		}

		public override List<PtuRequerimientostupa> ListarKeys(
								int? intcodrequerimientotupa,
								int? intcodplantilla,
								int? intcodigoprocedimiento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[3];
			
			arrParam[0] = new DB2Parameter("@INTCODREQUERIMIENTOTUPA", DB2Type.Integer);
			arrParam[0].Value = intcodrequerimientotupa;
			arrParam[1] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
			arrParam[1].Value = intcodplantilla;
			arrParam[2] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
			arrParam[2].Value = intcodigoprocedimiento;			

			return DB2Comando.Listar<PtuRequerimientostupa>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUREQUERIMIENTOSTUPA_LISTARKEYS", this.logMensajes, arrParam);				
		}

	}
}
