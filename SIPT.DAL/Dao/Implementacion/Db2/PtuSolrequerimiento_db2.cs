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
			try
			{
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
				arrParam[6].Value = pPtuSolrequerimiento.vchaudusucreacion;
				arrParam[7] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[7].Value = pPtuSolrequerimiento.tmsaudfeccreacion;
				arrParam[8] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[8].Value = pPtuSolrequerimiento.vchaudusumodif;
				arrParam[9] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[9].Value = pPtuSolrequerimiento.tmsaudfecmodif;
				arrParam[10] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[10].Value = pPtuSolrequerimiento.vchaudequipo;
				arrParam[11] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[11].Value = pPtuSolrequerimiento.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_INSERTAR", arrParam);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_INSERTAR : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuSolrequerimiento pPtuSolrequerimiento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[14];
			try
			{
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
				arrParam[8].Value = pPtuSolrequerimiento.vchaudusucreacion;
				arrParam[9] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[9].Value = pPtuSolrequerimiento.tmsaudfeccreacion;
				arrParam[10] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[10].Value = pPtuSolrequerimiento.vchaudusumodif;
				arrParam[11] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[11].Value = pPtuSolrequerimiento.tmsaudfecmodif;
				arrParam[12] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[12].Value = pPtuSolrequerimiento.vchaudequipo;
				arrParam[13] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[13].Value = pPtuSolrequerimiento.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_ACTUALIZAR", arrParam);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_ACTUALIZAR : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
		}

		public override void Eliminar(int? intsolicitudplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = intsolicitudplantilla;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_ELIMINAR", arrParam);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_ELIMINAR : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
		}

		public override List<PtuSolrequerimiento> Listar()
		{
			try
			{
				oPtuSolrequerimientoList = new List<PtuSolrequerimiento>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTAR");
				oPtuSolrequerimientoList = ConvertidorUtil.DeReaderAColeccion<PtuSolrequerimiento, List<PtuSolrequerimiento>>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimientoList);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTAR : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimientoList);
				throw ex;
			}
			return oPtuSolrequerimientoList;
		}

		public override PtuSolrequerimiento ListarKey(int? intsolicitudplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = intsolicitudplantilla;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTARKEY", arrParam);
				oPtuSolrequerimiento = ConvertidorUtil.DeReaderAEntidad<PtuSolrequerimiento>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimiento);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTARKEY : " + ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimiento);
				throw ex;
			}
			return oPtuSolrequerimiento;
		}

		public override List<PtuSolrequerimiento> ListarKeys(
								int? intsolicitudplantilla,
								int? intcodplantilla,
								int? intcodsolicitud,
								Int16? smlevaluacion,
								Int16? smlestadodocumento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[5];
			try
			{
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
				oPtuSolrequerimientoList = new List<PtuSolrequerimiento>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTARKEYS", arrParam);
				oPtuSolrequerimientoList = ConvertidorUtil.DeReaderAColeccion<PtuSolrequerimiento, List<PtuSolrequerimiento>>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimientoList);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTARKEYS : " + ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimientoList);
				throw ex;
			}
			return oPtuSolrequerimientoList;
		}

		public override List<PtuSolrequerimiento> ListarAcredita(int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[0].Value = intcodsolicitud;
				oPtuSolrequerimientoList = new List<PtuSolrequerimiento>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_LISTAR_ACREDITA", arrParam);
				oPtuSolrequerimientoList = ConvertidorUtil.DeReaderAColeccion<PtuSolrequerimiento, List<PtuSolrequerimiento>>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTAR_ACREDITA");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimientoList);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_LISTAR_ACREDITA : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), oPtuSolrequerimientoList);
				throw ex;
			}
			return oPtuSolrequerimientoList;
		}

	}
}
