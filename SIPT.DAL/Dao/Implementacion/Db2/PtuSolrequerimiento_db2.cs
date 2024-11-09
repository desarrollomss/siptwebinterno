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
	public class PtuSolrequerimiento_db2: PtuSolrequerimiento_dao
	{
		private List<PtuSolrequerimiento> oPtuSolrequerimientoList;
		private PtuSolrequerimiento oPtuSolrequerimiento;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolrequerimiento_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuSolrequerimiento pPtuSolrequerimiento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[12];
			
			arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
			arrParam[0].Direction = ParameterDirection.Output;
			arrParam[1] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
			arrParam[1].Value = pPtuSolrequerimiento.intcodplantilla;
			arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
			arrParam[2].Value = pPtuSolrequerimiento.intcodsolicitud;
			arrParam[3] = new DB2Parameter("@VCHOBSEVALUACION", DB2Type.VarChar);
			arrParam[3].Value = pPtuSolrequerimiento.vchobsevaluacion;
			arrParam[4] = new DB2Parameter("@SMLEVALUACION", DB2Type.SmallInt);
			arrParam[4].Value = pPtuSolrequerimiento.smlevaluacion;
			arrParam[5] = new DB2Parameter("@VCHDOCREQUERIMIENTO", DB2Type.VarChar);
			arrParam[5].Value = pPtuSolrequerimiento.vchdocrequerimiento;
			arrParam[6] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
			arrParam[6].Value = this.logMensajes.Usuario;
			arrParam[7] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
			arrParam[7].Value = DateTime.Now;
			arrParam[8] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
			arrParam[8].Value = DBNull.Value;
			arrParam[9] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
			arrParam[9].Value = DBNull.Value;
			arrParam[10] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
			arrParam[10].Value = this.logMensajes.Equipo;
			arrParam[11] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
			arrParam[11].Value = this.logMensajes.Programa;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_INSERTAR", this.logMensajes, arrParam);

			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuSolrequerimiento pPtuSolrequerimiento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[14];
			
			arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
			arrParam[0].Value = pPtuSolrequerimiento.intsolicitudplantilla;
			arrParam[1] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
			arrParam[1].Value = pPtuSolrequerimiento.intcodplantilla;
			arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
			arrParam[2].Value = pPtuSolrequerimiento.intcodsolicitud;
			arrParam[3] = new DB2Parameter("@VCHOBSEVALUACION", DB2Type.VarChar);
			arrParam[3].Value = pPtuSolrequerimiento.vchobsevaluacion;
			arrParam[4] = new DB2Parameter("@SMLEVALUACION", DB2Type.SmallInt);
			arrParam[4].Value = pPtuSolrequerimiento.smlevaluacion;
			arrParam[5] = new DB2Parameter("@VCHDOCREQUERIMIENTO", DB2Type.VarChar);
			arrParam[5].Value = pPtuSolrequerimiento.vchdocrequerimiento;
			arrParam[6] = new DB2Parameter("@TMSFECHADOCUMENTO", DB2Type.Timestamp);
			arrParam[6].Value = pPtuSolrequerimiento.tmsfechadocumento;
			arrParam[7] = new DB2Parameter("@SMLESTADODOCUMENTO", DB2Type.SmallInt);
			arrParam[7].Value = pPtuSolrequerimiento.smlestadodocumento;
			arrParam[8] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
			arrParam[8].Value = DBNull.Value;
			arrParam[9] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
			arrParam[9].Value = DBNull.Value;
			arrParam[10] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
			arrParam[10].Value = this.logMensajes.Usuario;
			arrParam[11] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
			arrParam[11].Value = DateTime.Now;
			arrParam[12] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
			arrParam[12].Value = this.logMensajes.Equipo;
			arrParam[13] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
			arrParam[13].Value = this.logMensajes.Programa;

			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_ACTUALIZAR", this.logMensajes, arrParam);
		}

		public override void Eliminar(int? intsolicitudplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			
			arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
			arrParam[0].Value = intsolicitudplantilla;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_ELIMINAR", this.logMensajes, arrParam);
		}

		public override List<PtuSolrequerimiento> Listar()
		{
			oPtuSolrequerimientoList = new List<PtuSolrequerimiento>();
			return DB2Comando.Listar<PtuSolrequerimiento>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTAR", this.logMensajes);
		}

		public override PtuSolrequerimiento ListarKey(int? intsolicitudplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			
			arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
			arrParam[0].Value = intsolicitudplantilla;
			return DB2Comando.Obtener<PtuSolrequerimiento>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTARKEY", this.logMensajes, arrParam);				
		}

		public override List<PtuSolrequerimiento> ListarKeys(
								int? intsolicitudplantilla,
								int? intcodplantilla,
								int? intcodsolicitud,
								Int16? smlevaluacion,
								Int16? smlestadodocumento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[5];
			
			arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
			arrParam[0].Value = intsolicitudplantilla;
			arrParam[1] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
			arrParam[1].Value = intcodplantilla;
			arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
			arrParam[2].Value = intcodsolicitud;
			arrParam[3] = new DB2Parameter("@SMLEVALUACION", DB2Type.SmallInt);
			arrParam[3].Value = smlevaluacion;
			arrParam[4] = new DB2Parameter("@SMLESTADODOCUMENTO", DB2Type.SmallInt);
			arrParam[4].Value = smlestadodocumento;

			return DB2Comando.Listar<PtuSolrequerimiento>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTARKEYS", this.logMensajes, arrParam);				
		}

		public override List<PtuSolrequerimiento> ListarAcredita(int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			
			arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
			arrParam[0].Value = intcodsolicitud;

			return DB2Comando.Listar<PtuSolrequerimiento>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTAR_ACREDITA", this.logMensajes, arrParam);				
		}

	}
}
