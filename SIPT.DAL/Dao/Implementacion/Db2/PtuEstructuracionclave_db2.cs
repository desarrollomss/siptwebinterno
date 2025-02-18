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
	public class PtuEstructuracionclave_db2: PtuEstructuracionclave_dao
	{
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuEstructuracionclave_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override  Int32 Insertar(PtuEstructuracionclave pPtuEstructuracionclave)
		{
			DB2Parameter[] arrParam = new DB2Parameter[11];
			
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCLAVE", DB2Type.Integer);
			arrParam[0].Direction = ParameterDirection.Output;
			arrParam[1] = new DB2Parameter("@VCHABREVESTRUCTURACIONCLAVE", DB2Type.VarChar);
			arrParam[1].Value = pPtuEstructuracionclave.vchabrevestructuracionclave;
			arrParam[2] = new DB2Parameter("@VCHDESCESTRUCTURACIONCLAVE", DB2Type.VarChar);
			arrParam[2].Value = pPtuEstructuracionclave.vchdescestructuracionclave;
			arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
			arrParam[3].Value = pPtuEstructuracionclave.smlestado;
			arrParam[4] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[4].Value = pPtuEstructuracionclave.intcodestructuracion;
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
		    DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCLAVE_INSERTAR", this.logMensajes, arrParam);
			
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override Int32 Actualizar(PtuEstructuracionclave pPtuEstructuracionclave)
		{
			DB2Parameter[] arrParam = new DB2Parameter[11];
			
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCLAVE", DB2Type.Integer);
			arrParam[0].Value = pPtuEstructuracionclave.intcodestructuracionclave;
			arrParam[1] = new DB2Parameter("@VCHABREVESTRUCTURACIONCLAVE", DB2Type.VarChar);
			arrParam[1].Value = pPtuEstructuracionclave.vchabrevestructuracionclave;
			arrParam[2] = new DB2Parameter("@VCHDESCESTRUCTURACIONCLAVE", DB2Type.VarChar);
			arrParam[2].Value = pPtuEstructuracionclave.vchdescestructuracionclave;
			arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
			arrParam[3].Value = pPtuEstructuracionclave.smlestado;
			arrParam[4] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[4].Value = pPtuEstructuracionclave.intcodestructuracion;
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
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCLAVE_ACTUALIZAR", this.logMensajes, arrParam);
			
			return 1;
		}

		public override Int32 Eliminar(int? intcodestructuracionclave)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCLAVE", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracionclave;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCLAVE_ELIMINAR", this.logMensajes, arrParam);
			
			return 1;
		}

		public override List<PtuEstructuracionclave> Listar()
		{
			return DB2Comando.Listar<PtuEstructuracionclave>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCLAVE_LISTAR", this.logMensajes);
		}

		public override PtuEstructuracionclave ListarKey(int? intcodestructuracionclave)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCLAVE", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracionclave;
			return DB2Comando.Obtener<PtuEstructuracionclave>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCLAVE_LISTARKEY", this.logMensajes, arrParam);
		}

		public override List<PtuEstructuracionclave> ListarKeys(
								int? intcodestructuracionclave,
								int? intcodestructuracion)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCLAVE", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracionclave;
			arrParam[1] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[1].Value = intcodestructuracion;
			return DB2Comando.Listar<PtuEstructuracionclave>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCLAVE_LISTARKEYS", this.logMensajes, arrParam);
		}


	}
}
