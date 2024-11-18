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
	public class PtuSolcertificadoinspector_db2: PtuSolcertificadoinspector_dao
	{
		private List<PtuSolcertificadoinspector> oPtuSolcertificadoinspectorList;
		private PtuSolcertificadoinspector oPtuSolcertificadoinspector;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolcertificadoinspector_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuSolcertificadoinspector pPtuSolcertificadoinspector)
		{
			DB2Parameter[] arrParam = new DB2Parameter[10];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUDINSPECTOR", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@INTUSUINSPECTOR", DB2Type.Integer);
				arrParam[1].Value = pPtuSolcertificadoinspector.intusuinspector;
				arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[2].Value = pPtuSolcertificadoinspector.intcodsolicitud;
				arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
				arrParam[3].Value = pPtuSolcertificadoinspector.smlestado;
				arrParam[4] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[4].Value = pPtuSolcertificadoinspector.vchaudusucreacion;
				arrParam[5] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[5].Value = pPtuSolcertificadoinspector.tmsaudfeccreacion;
				arrParam[6] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[6].Value = pPtuSolcertificadoinspector.vchaudusumodif;
				arrParam[7] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[7].Value = pPtuSolcertificadoinspector.tmsaudfecmodif;
				arrParam[8] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[8].Value = pPtuSolcertificadoinspector.vchaudequipo;
				arrParam[9] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[9].Value = pPtuSolcertificadoinspector.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADOINSPECTOR_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADOINSPECTOR_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuSolcertificadoinspector pPtuSolcertificadoinspector)
		{
			DB2Parameter[] arrParam = new DB2Parameter[10];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUDINSPECTOR", DB2Type.Integer);
				arrParam[0].Value = pPtuSolcertificadoinspector.intcodsolicitudinspector;
				arrParam[1] = new DB2Parameter("@INTUSUINSPECTOR", DB2Type.Integer);
				arrParam[1].Value = pPtuSolcertificadoinspector.intusuinspector;
				arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[2].Value = pPtuSolcertificadoinspector.intcodsolicitud;
				arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
				arrParam[3].Value = pPtuSolcertificadoinspector.smlestado;
				arrParam[4] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[4].Value = pPtuSolcertificadoinspector.vchaudusucreacion;
				arrParam[5] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[5].Value = pPtuSolcertificadoinspector.tmsaudfeccreacion;
				arrParam[6] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[6].Value = pPtuSolcertificadoinspector.vchaudusumodif;
				arrParam[7] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[7].Value = pPtuSolcertificadoinspector.tmsaudfecmodif;
				arrParam[8] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[8].Value = pPtuSolcertificadoinspector.vchaudequipo;
				arrParam[9] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[9].Value = pPtuSolcertificadoinspector.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADOINSPECTOR_ACTUALIZAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADOINSPECTOR_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override void Eliminar(int? intcodsolicitudinspector)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUDINSPECTOR", DB2Type.Integer);
				arrParam[0].Value = intcodsolicitudinspector;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADOINSPECTOR_ELIMINAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADOINSPECTOR_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override List<PtuSolcertificadoinspector> Listar()
		{
			try
			{
				oPtuSolcertificadoinspectorList = new List<PtuSolcertificadoinspector>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADOINSPECTOR_LISTAR");
				oPtuSolcertificadoinspectorList = ConvertidorUtil.DeReaderAColeccion<PtuSolcertificadoinspector, List<PtuSolcertificadoinspector>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADOINSPECTOR_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolcertificadoinspectorList);
			}
			return oPtuSolcertificadoinspectorList;
		}

		public override PtuSolcertificadoinspector ListarKey(int? intcodsolicitudinspector)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUDINSPECTOR", DB2Type.Integer);
				arrParam[0].Value = intcodsolicitudinspector;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADOINSPECTOR_LISTARKEY", arrParam);
				oPtuSolcertificadoinspector = ConvertidorUtil.DeReaderAEntidad<PtuSolcertificadoinspector>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADOINSPECTOR_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolcertificadoinspector);
			}
			return oPtuSolcertificadoinspector;
		}

		public override List<PtuSolcertificadoinspector> ListarKeys(
								int? intcodsolicitudinspector,
								int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUDINSPECTOR", DB2Type.Integer);
				arrParam[0].Value = intcodsolicitudinspector;
				arrParam[1] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[1].Value = intcodsolicitud;
				oPtuSolcertificadoinspectorList = new List<PtuSolcertificadoinspector>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADOINSPECTOR_LISTARKEYS", arrParam);
				oPtuSolcertificadoinspectorList = ConvertidorUtil.DeReaderAColeccion<PtuSolcertificadoinspector, List<PtuSolcertificadoinspector>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADOINSPECTOR_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolcertificadoinspectorList);
			}
			return oPtuSolcertificadoinspectorList;
		}


	}
}
