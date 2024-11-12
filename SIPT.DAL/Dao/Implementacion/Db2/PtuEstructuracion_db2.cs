using DBAccess;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
	public class PtuEstructuracion_db2: PtuEstructuracion_dao
	{
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuEstructuracion_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override int Insertar(PtuEstructuracion pPtuEstructuracion)
		{
			DB2Parameter[] arrParam = new DB2Parameter[11];
			
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[0].Direction = ParameterDirection.Output;
			arrParam[1] = new DB2Parameter("@VCHABREVESTRUCTURACION", DB2Type.VarChar);
			arrParam[1].Value = pPtuEstructuracion.vchabrevestructuracion;
			arrParam[2] = new DB2Parameter("@VCHNOMESTRUCTURACION", DB2Type.VarChar);
			arrParam[2].Value = pPtuEstructuracion.vchnomestructuracion;
			arrParam[3] = new DB2Parameter("@VCHNOTASCOMPLEMENTARIAS", DB2Type.VarChar);
			arrParam[3].Value = pPtuEstructuracion.vchnotascomplementarias;
			arrParam[4] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
			arrParam[4].Value = pPtuEstructuracion.smlestado;
			arrParam[5] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
			arrParam[5].Value = this.logMensajes.Usuario;
			arrParam[6] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
			arrParam[6].Value = DateTime.Now;
			arrParam[7] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
			arrParam[7].Value = DBNull.Value;
			arrParam[8] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
			arrParam[8].Value = DBNull.Value;
			arrParam[9] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
			arrParam[9].Value = this.logMensajes.Equipo;
			arrParam[10] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
			arrParam[10].Value = this.logMensajes.Programa;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACION_INSERTAR", this.logMensajes, arrParam);
			
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override PtuEstructuracion Actualizar(PtuEstructuracion pPtuEstructuracion)
		{
			DB2Parameter[] arrParam = new DB2Parameter[11];
			
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[0].Value = pPtuEstructuracion.intcodestructuracion;
			arrParam[1] = new DB2Parameter("@VCHABREVESTRUCTURACION", DB2Type.VarChar);
			arrParam[1].Value = pPtuEstructuracion.vchabrevestructuracion;
			arrParam[2] = new DB2Parameter("@VCHNOMESTRUCTURACION", DB2Type.VarChar);
			arrParam[2].Value = pPtuEstructuracion.vchnomestructuracion;
			arrParam[3] = new DB2Parameter("@VCHNOTASCOMPLEMENTARIAS", DB2Type.VarChar);
			arrParam[3].Value = pPtuEstructuracion.vchnotascomplementarias;
			arrParam[4] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
			arrParam[4].Value = pPtuEstructuracion.smlestado;
			arrParam[5] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
			arrParam[5].Value = DBNull.Value;
			arrParam[6] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
			arrParam[6].Value = DBNull.Value;
			arrParam[7] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
			arrParam[7].Value = this.logMensajes.Usuario;
			arrParam[8] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
			arrParam[8].Value = DateTime.Now;
			arrParam[9] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
			arrParam[9].Value = this.logMensajes.Equipo;
			arrParam[10] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
			arrParam[10].Value = this.logMensajes.Programa;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACION_ACTUALIZAR", this.logMensajes, arrParam);
			
			return pPtuEstructuracion;
		}

		public override void Eliminar(int? intcodestructuracion)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracion;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACION_ELIMINAR", this.logMensajes, arrParam);
			
		}

		public override List<PtuEstructuracion> Listar()
		{
			return DB2Comando.Listar<PtuEstructuracion>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACION_LISTAR", this.logMensajes);
		}

		public override PtuEstructuracion ListarKey(int? intcodestructuracion)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracion;
			return DB2Comando.Obtener<PtuEstructuracion>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACION_LISTARKEY", this.logMensajes, arrParam);
		}

		public override List<PtuEstructuracion> ListarKeys(int? intcodestructuracion, Int16? smlestado)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracion;
			arrParam[1] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
			arrParam[1].Value = smlestado;

			return DB2Comando.Listar<PtuEstructuracion>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACION_LISTARKEYS", this.logMensajes, arrParam);
		}


	}
}
