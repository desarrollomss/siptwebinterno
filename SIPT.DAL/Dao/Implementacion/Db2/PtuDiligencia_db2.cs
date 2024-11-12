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
	public class PtuDiligencia_db2 : PtuDiligencia_dao
	{
		private List<PtuDiligencia> oPtuDiligenciaList;
		private PtuDiligencia oPtuDiligencia;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuDiligencia_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuDiligencia pPtuDiligencia)
		{
			DB2Parameter[] arrParam = new DB2Parameter[21];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODDILIGENCIA", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@DATFECHADILIGENCIA", DB2Type.Date);
				arrParam[1].Value = pPtuDiligencia.datfechadiligencia;
				arrParam[2] = new DB2Parameter("@SMLHORADILIGENCIA", DB2Type.SmallInt);
				arrParam[2].Value = pPtuDiligencia.smlhoradiligencia;
				arrParam[3] = new DB2Parameter("@VCHFILEACTADILIGENCIA", DB2Type.VarChar);
				arrParam[3].Value = pPtuDiligencia.vchfileactadiligencia;
				arrParam[4] = new DB2Parameter("@INTCODDOCACTADILIGENCIA", DB2Type.Integer);
				arrParam[4].Value = pPtuDiligencia.intcoddocactadiligencia;
				arrParam[5] = new DB2Parameter("@VCHFILEINFORMECUMPLIMIENTO", DB2Type.VarChar);
				arrParam[5].Value = pPtuDiligencia.vchfileinformecumplimiento;
				arrParam[6] = new DB2Parameter("@INTCODDOCINFCUMPLIMIENTO", DB2Type.Integer);
				arrParam[6].Value = pPtuDiligencia.intcoddocinfcumplimiento;
				arrParam[7] = new DB2Parameter("@VCHFILEPANELFOTOGRAFICO", DB2Type.VarChar);
				arrParam[7].Value = pPtuDiligencia.vchfilepanelfotografico;
				arrParam[8] = new DB2Parameter("@INTCODDOCPANELFOTOGRAFICO", DB2Type.Integer);
				arrParam[8].Value = pPtuDiligencia.intcoddocpanelfotografico;
				arrParam[9] = new DB2Parameter("@VCHOBSINSPECTOR", DB2Type.VarChar);
				arrParam[9].Value = pPtuDiligencia.vchobsinspector;
				arrParam[10] = new DB2Parameter("@VCHOBSSOLICITANTE", DB2Type.VarChar);
				arrParam[10].Value = pPtuDiligencia.vchobssolicitante;
				arrParam[11] = new DB2Parameter("@SMLESTDILIGENCIA", DB2Type.SmallInt);
				arrParam[11].Value = pPtuDiligencia.smlestdiligencia;
				arrParam[12] = new DB2Parameter("@DATFECHAMAXSUBSANACION", DB2Type.Date);
				arrParam[12].Value = pPtuDiligencia.datfechamaxsubsanacion;
				arrParam[13] = new DB2Parameter("@DATFECHAREPROGRAMACION", DB2Type.Date);
				arrParam[13].Value = pPtuDiligencia.datfechareprogramacion;
				arrParam[14] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[14].Value = pPtuDiligencia.intcodsolicitud;
				arrParam[15] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[15].Value = pPtuDiligencia.vchaudusucreacion;
				arrParam[16] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[16].Value = pPtuDiligencia.tmsaudfeccreacion;
				arrParam[17] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[17].Value = pPtuDiligencia.vchaudusumodif;
				arrParam[18] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[18].Value = pPtuDiligencia.tmsaudfecmodif;
				arrParam[19] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[19].Value = pPtuDiligencia.vchaudequipo;
				arrParam[20] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[20].Value = pPtuDiligencia.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUDILIGENCIA_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUDILIGENCIA_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuDiligencia pPtuDiligencia)
		{
			DB2Parameter[] arrParam = new DB2Parameter[21];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODDILIGENCIA", DB2Type.Integer);
				arrParam[0].Value = pPtuDiligencia.intcoddiligencia;
				arrParam[1] = new DB2Parameter("@DATFECHADILIGENCIA", DB2Type.Date);
				arrParam[1].Value = pPtuDiligencia.datfechadiligencia;
				arrParam[2] = new DB2Parameter("@SMLHORADILIGENCIA", DB2Type.SmallInt);
				arrParam[2].Value = pPtuDiligencia.smlhoradiligencia;
				arrParam[3] = new DB2Parameter("@VCHFILEACTADILIGENCIA", DB2Type.VarChar);
				arrParam[3].Value = pPtuDiligencia.vchfileactadiligencia;
				arrParam[4] = new DB2Parameter("@INTCODDOCACTADILIGENCIA", DB2Type.Integer);
				arrParam[4].Value = pPtuDiligencia.intcoddocactadiligencia;
				arrParam[5] = new DB2Parameter("@VCHFILEINFORMECUMPLIMIENTO", DB2Type.VarChar);
				arrParam[5].Value = pPtuDiligencia.vchfileinformecumplimiento;
				arrParam[6] = new DB2Parameter("@INTCODDOCINFCUMPLIMIENTO", DB2Type.Integer);
				arrParam[6].Value = pPtuDiligencia.intcoddocinfcumplimiento;
				arrParam[7] = new DB2Parameter("@VCHFILEPANELFOTOGRAFICO", DB2Type.VarChar);
				arrParam[7].Value = pPtuDiligencia.vchfilepanelfotografico;
				arrParam[8] = new DB2Parameter("@INTCODDOCPANELFOTOGRAFICO", DB2Type.Integer);
				arrParam[8].Value = pPtuDiligencia.intcoddocpanelfotografico;
				arrParam[9] = new DB2Parameter("@VCHOBSINSPECTOR", DB2Type.VarChar);
				arrParam[9].Value = pPtuDiligencia.vchobsinspector;
				arrParam[10] = new DB2Parameter("@VCHOBSSOLICITANTE", DB2Type.VarChar);
				arrParam[10].Value = pPtuDiligencia.vchobssolicitante;
				arrParam[11] = new DB2Parameter("@SMLESTDILIGENCIA", DB2Type.SmallInt);
				arrParam[11].Value = pPtuDiligencia.smlestdiligencia;
				arrParam[12] = new DB2Parameter("@DATFECHAMAXSUBSANACION", DB2Type.Date);
				arrParam[12].Value = pPtuDiligencia.datfechamaxsubsanacion;
				arrParam[13] = new DB2Parameter("@DATFECHAREPROGRAMACION", DB2Type.Date);
				arrParam[13].Value = pPtuDiligencia.datfechareprogramacion;
				arrParam[14] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[14].Value = pPtuDiligencia.intcodsolicitud;
				arrParam[15] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[15].Value = pPtuDiligencia.vchaudusucreacion;
				arrParam[16] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[16].Value = pPtuDiligencia.tmsaudfeccreacion;
				arrParam[17] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[17].Value = pPtuDiligencia.vchaudusumodif;
				arrParam[18] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[18].Value = pPtuDiligencia.tmsaudfecmodif;
				arrParam[19] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[19].Value = pPtuDiligencia.vchaudequipo;
				arrParam[20] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[20].Value = pPtuDiligencia.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUDILIGENCIA_ACTUALIZAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUDILIGENCIA_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override void Eliminar(int? intcoddiligencia)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODDILIGENCIA", DB2Type.Integer);
				arrParam[0].Value = intcoddiligencia;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUDILIGENCIA_ELIMINAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUDILIGENCIA_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override List<PtuDiligencia> Listar()
		{
			try
			{
				oPtuDiligenciaList = new List<PtuDiligencia>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUDILIGENCIA_LISTAR");
				oPtuDiligenciaList = ConvertidorUtil.DeReaderAColeccion<PtuDiligencia, List<PtuDiligencia>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUDILIGENCIA_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuDiligenciaList);
			}
			return oPtuDiligenciaList;
		}

		public override PtuDiligencia ListarKey(int? intcoddiligencia)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODDILIGENCIA", DB2Type.Integer);
				arrParam[0].Value = intcoddiligencia;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUDILIGENCIA_LISTARKEY", arrParam);
				oPtuDiligencia = ConvertidorUtil.DeReaderAEntidad<PtuDiligencia>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUDILIGENCIA_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuDiligencia);
			}
			return oPtuDiligencia;
		}

		public override List<PtuDiligencia> ListarKeys(
								int? intcoddiligencia,
								int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODDILIGENCIA", DB2Type.Integer);
				arrParam[0].Value = intcoddiligencia;
				arrParam[1] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[1].Value = intcodsolicitud;
				oPtuDiligenciaList = new List<PtuDiligencia>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUDILIGENCIA_LISTARKEYS", arrParam);
				oPtuDiligenciaList = ConvertidorUtil.DeReaderAColeccion<PtuDiligencia, List<PtuDiligencia>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUDILIGENCIA_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuDiligenciaList);
			}
			return oPtuDiligenciaList;
		}


	}
}
