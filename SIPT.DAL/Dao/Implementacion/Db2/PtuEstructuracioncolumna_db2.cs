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
	public class PtuEstructuracioncolumna_db2: PtuEstructuracioncolumna_dao
	{
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuEstructuracioncolumna_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override int Insertar(PtuEstructuracioncolumna pPtuEstructuracioncolumna)
		{
			DB2Parameter[] arrParam = new DB2Parameter[11];
			
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCOLUMNA", DB2Type.Integer);
			arrParam[0].Direction = ParameterDirection.Output;
			arrParam[1] = new DB2Parameter("@VCHCOLUMNA", DB2Type.VarChar);
			arrParam[1].Value = pPtuEstructuracioncolumna.vchcolumna;
			arrParam[2] = new DB2Parameter("@VCHCOLUMNAZONIFICACION", DB2Type.VarChar);
			arrParam[2].Value = pPtuEstructuracioncolumna.vchcolumnazonificacion;
			arrParam[3] = new DB2Parameter("@VCHCOLUMNADESCRIPCION", DB2Type.VarChar);
			arrParam[3].Value = pPtuEstructuracioncolumna.vchcolumnadescripcion;
			arrParam[4] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[4].Value = pPtuEstructuracioncolumna.intcodestructuracion;
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
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCOLUMNA_INSERTAR", this.logMensajes, arrParam);
			
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override PtuEstructuracioncolumna Actualizar(PtuEstructuracioncolumna pPtuEstructuracioncolumna)
		{
			DB2Parameter[] arrParam = new DB2Parameter[11];
			
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCOLUMNA", DB2Type.Integer);
			arrParam[0].Value = pPtuEstructuracioncolumna.intcodestructuracioncolumna;
			arrParam[1] = new DB2Parameter("@VCHCOLUMNA", DB2Type.VarChar);
			arrParam[1].Value = pPtuEstructuracioncolumna.vchcolumna;
			arrParam[2] = new DB2Parameter("@VCHCOLUMNAZONIFICACION", DB2Type.VarChar);
			arrParam[2].Value = pPtuEstructuracioncolumna.vchcolumnazonificacion;
			arrParam[3] = new DB2Parameter("@VCHCOLUMNADESCRIPCION", DB2Type.VarChar);
			arrParam[3].Value = pPtuEstructuracioncolumna.vchcolumnadescripcion;
			arrParam[4] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[4].Value = pPtuEstructuracioncolumna.intcodestructuracion;
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
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCOLUMNA_ACTUALIZAR", this.logMensajes, arrParam);
			
			return pPtuEstructuracioncolumna;
		}

		public override void Eliminar(int? intcodestructuracioncolumna)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCOLUMNA", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracioncolumna;
			DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCOLUMNA_ELIMINAR", this.logMensajes, arrParam);
			
		}

		public override List<PtuEstructuracioncolumna> Listar()
		{
			return DB2Comando.Listar<PtuEstructuracioncolumna>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCOLUMNA_LISTAR", this.logMensajes);
		}

		public override PtuEstructuracioncolumna ListarKey(int? intcodestructuracioncolumna)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCOLUMNA", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracioncolumna;
			return DB2Comando.Obtener<PtuEstructuracioncolumna>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCOLUMNA_LISTARKEY", this.logMensajes, arrParam);
		}

		public override List<PtuEstructuracioncolumna> ListarKeys(
								int? intcodestructuracioncolumna,
								int? intcodestructuracion)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			arrParam[0] = new DB2Parameter("@INTCODESTRUCTURACIONCOLUMNA", DB2Type.Integer);
			arrParam[0].Value = intcodestructuracioncolumna;
			arrParam[1] = new DB2Parameter("@INTCODESTRUCTURACION", DB2Type.Integer);
			arrParam[1].Value = intcodestructuracion;
			return DB2Comando.Listar<PtuEstructuracioncolumna>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUESTRUCTURACIONCOLUMNA_LISTARKEYS", this.logMensajes, arrParam);
		}


	}
}
