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

namespace SIPT.DAL.Dao.Implementacion.Db2
{
	public class PtuLicencia_db2: PtuLicencia_dao
	{
		private List<PtuLicencia> oPtuLicenciaList;
		private PtuLicencia oPtuLicencia;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuLicencia_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuLicencia pPtuLicencia)
		{
			DB2Parameter[] arrParam = new DB2Parameter[25];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODLICENCIA", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@CHLICANIO", DB2Type.Char);
				arrParam[1].Value = pPtuLicencia.chlicanio;
				arrParam[2] = new DB2Parameter("@VCHLICNUMERO", DB2Type.VarChar);
				arrParam[2].Value = pPtuLicencia.vchlicnumero;
				arrParam[3] = new DB2Parameter("@DATVIGENCIAINI", DB2Type.Date);
				arrParam[3].Value = pPtuLicencia.datvigenciaini;
				arrParam[4] = new DB2Parameter("@DATVIGENCIAFIN", DB2Type.Date);
				arrParam[4].Value = pPtuLicencia.datvigenciafin;
				arrParam[5] = new DB2Parameter("@TMSREGISTROLICENCIA", DB2Type.Timestamp);
				arrParam[5].Value = pPtuLicencia.tmsregistrolicencia;
				arrParam[6] = new DB2Parameter("@SMLVIGENCIA", DB2Type.SmallInt);
				arrParam[6].Value = pPtuLicencia.smlvigencia;
				arrParam[7] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
				arrParam[7].Value = pPtuLicencia.vchobservacion;
				arrParam[8] = new DB2Parameter("@INTAFORO", DB2Type.Integer);
				arrParam[8].Value = pPtuLicencia.intaforo;
				arrParam[9] = new DB2Parameter("@INTDOCCODIGO", DB2Type.Integer);
				arrParam[9].Value = pPtuLicencia.intdoccodigo;
				arrParam[10] = new DB2Parameter("@DATFECHAPROGRAMACION", DB2Type.Date);
				arrParam[10].Value = pPtuLicencia.datfechaprogramacion;
				arrParam[11] = new DB2Parameter("@VCHHORAPROGRAMACION", DB2Type.VarChar);
				arrParam[11].Value = pPtuLicencia.vchhoraprogramacion;
				arrParam[12] = new DB2Parameter("@VCHLICCATEGORIA", DB2Type.VarChar);
				arrParam[12].Value = pPtuLicencia.vchliccategoria;
				arrParam[13] = new DB2Parameter("@SMLAMERITAPROGRAMACION", DB2Type.SmallInt);
				arrParam[13].Value = pPtuLicencia.smlameritaprogramacion;
				arrParam[14] = new DB2Parameter("@VCHZONACOD", DB2Type.VarChar);
				arrParam[14].Value = pPtuLicencia.vchzonacod;
				arrParam[15] = new DB2Parameter("@VCHESTRCODIGO", DB2Type.VarChar);
				arrParam[15].Value = pPtuLicencia.vchestrcodigo;
				arrParam[16] = new DB2Parameter("@VCHSOLGERENCIA", DB2Type.VarChar);
				arrParam[16].Value = pPtuLicencia.vchsolgerencia;
				arrParam[17] = new DB2Parameter("@VCHSOLSUBGERENCIA", DB2Type.VarChar);
				arrParam[17].Value = pPtuLicencia.vchsolsubgerencia;
				arrParam[18] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[18].Value = pPtuLicencia.intcodsolicitud;
				arrParam[19] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[19].Value = pPtuLicencia.vchaudusucreacion;
				arrParam[20] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[20].Value = pPtuLicencia.tmsaudfeccreacion;
				arrParam[21] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[21].Value = pPtuLicencia.vchaudusumodif;
				arrParam[22] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[22].Value = pPtuLicencia.tmsaudfecmodif;
				arrParam[23] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[23].Value = pPtuLicencia.vchaudequipo;
				arrParam[24] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[24].Value = pPtuLicencia.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTULICENCIA_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTULICENCIA_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override List<PtuLicencia> ListarKeys(
								int? intcodlicencia,
								int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODLICENCIA", DB2Type.Integer);
				arrParam[0].Value = intcodlicencia;
				arrParam[1] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[1].Value = intcodsolicitud;
				oPtuLicenciaList = new List<PtuLicencia>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTULICENCIA_LISTARKEYS", arrParam);
				oPtuLicenciaList = ConvertidorUtil.DeReaderAColeccion<PtuLicencia, List<PtuLicencia>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTULICENCIA_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuLicenciaList);
			}
			return oPtuLicenciaList;
		}


	}
}
