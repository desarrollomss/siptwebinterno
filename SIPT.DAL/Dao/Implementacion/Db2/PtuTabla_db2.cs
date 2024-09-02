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
	public class PtuTabla_db2: PtuTabla_dao
	{
		private List<PtuTabla> oPtuTablaList;
		private PtuTabla oPtuTabla;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuTabla_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int16 Insertar(PtuTabla pPtuTabla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[14];
			try
			{
				arrParam[0] = new DB2Parameter("@SMLCODTABLA", DB2Type.SmallInt);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@SMLORDEN", DB2Type.SmallInt);
				arrParam[1].Value = pPtuTabla.smlorden;
				arrParam[2] = new DB2Parameter("@VCHDESCRIPCION", DB2Type.VarChar);
				arrParam[2].Value = pPtuTabla.vchdescripcion;
				arrParam[3] = new DB2Parameter("@VCHDESCRIPCIONALTERNA", DB2Type.VarChar);
				arrParam[3].Value = pPtuTabla.vchdescripcionalterna;
				arrParam[4] = new DB2Parameter("@VCHENLACE", DB2Type.VarChar);
				arrParam[4].Value = pPtuTabla.vchenlace;
				arrParam[5] = new DB2Parameter("@VCHTABLA", DB2Type.VarChar);
				arrParam[5].Value = pPtuTabla.vchtabla;
				arrParam[6] = new DB2Parameter("@VCHCAMPO", DB2Type.VarChar);
				arrParam[6].Value = pPtuTabla.vchcampo;
				arrParam[7] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
				arrParam[7].Value = pPtuTabla.smlestado;
				arrParam[8] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[8].Value = pPtuTabla.vchaudusucreacion;
				arrParam[9] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[9].Value = pPtuTabla.tmsaudfeccreacion;
				arrParam[10] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[10].Value = pPtuTabla.vchaudusumodif;
				arrParam[11] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[11].Value = pPtuTabla.tmsaudfecmodif;
				arrParam[12] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[12].Value = pPtuTabla.vchaudequipo;
				arrParam[13] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[13].Value = pPtuTabla.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUTABLA_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUTABLA_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt16(arrParam[0].Value);
		}

		public override void Actualizar(PtuTabla pPtuTabla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[14];
			try
			{
				arrParam[0] = new DB2Parameter("@SMLCODTABLA", DB2Type.SmallInt);
				arrParam[0].Value = pPtuTabla.smlcodtabla;
				arrParam[1] = new DB2Parameter("@SMLORDEN", DB2Type.SmallInt);
				arrParam[1].Value = pPtuTabla.smlorden;
				arrParam[2] = new DB2Parameter("@VCHDESCRIPCION", DB2Type.VarChar);
				arrParam[2].Value = pPtuTabla.vchdescripcion;
				arrParam[3] = new DB2Parameter("@VCHDESCRIPCIONALTERNA", DB2Type.VarChar);
				arrParam[3].Value = pPtuTabla.vchdescripcionalterna;
				arrParam[4] = new DB2Parameter("@VCHENLACE", DB2Type.VarChar);
				arrParam[4].Value = pPtuTabla.vchenlace;
				arrParam[5] = new DB2Parameter("@VCHTABLA", DB2Type.VarChar);
				arrParam[5].Value = pPtuTabla.vchtabla;
				arrParam[6] = new DB2Parameter("@VCHCAMPO", DB2Type.VarChar);
				arrParam[6].Value = pPtuTabla.vchcampo;
				arrParam[7] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
				arrParam[7].Value = pPtuTabla.smlestado;
				arrParam[8] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[8].Value = pPtuTabla.vchaudusucreacion;
				arrParam[9] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[9].Value = pPtuTabla.tmsaudfeccreacion;
				arrParam[10] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[10].Value = pPtuTabla.vchaudusumodif;
				arrParam[11] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[11].Value = pPtuTabla.tmsaudfecmodif;
				arrParam[12] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[12].Value = pPtuTabla.vchaudequipo;
				arrParam[13] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[13].Value = pPtuTabla.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUTABLA_ACTUALIZAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUTABLA_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override void Eliminar(int? smlcodtabla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@SMLCODTABLA", DB2Type.SmallInt);
				arrParam[0].Value = smlcodtabla;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUTABLA_ELIMINAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUTABLA_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override List<PtuTabla> Listar()
		{
			try
			{
				oPtuTablaList = new List<PtuTabla>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUTABLA_LISTAR");
				oPtuTablaList = ConvertidorUtil.DeReaderAColeccion<PtuTabla, List<PtuTabla>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUTABLA_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuTablaList);
			}
			return oPtuTablaList;
		}

		public override PtuTabla ListarKey(int? smlcodtabla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@SMLCODTABLA", DB2Type.SmallInt);
				arrParam[0].Value = smlcodtabla;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUTABLA_LISTARKEY", arrParam);
				oPtuTabla = ConvertidorUtil.DeReaderAEntidad<PtuTabla>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUTABLA_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuTabla);
			}
			return oPtuTabla;
		}

		public override List<PtuTabla> ListarKeys(
								Int16? smlcodtabla,
								Int16? smlestado)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@SMLCODTABLA", DB2Type.SmallInt);
				arrParam[0].Value = smlcodtabla;
				arrParam[1] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
				arrParam[1].Value = smlestado;
				oPtuTablaList = new List<PtuTabla>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUTABLA_LISTARKEYS", arrParam);
				oPtuTablaList = ConvertidorUtil.DeReaderAColeccion<PtuTabla, List<PtuTabla>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUTABLA_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuTablaList);
			}
			return oPtuTablaList;
		}


	}
}