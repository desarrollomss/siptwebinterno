using System;
using System.Data;
using IBM.Data.DB2;
using DBAccess;
using DBAccess.Util;
using System.Collections.Generic;
using SIPT.APPL.Logs;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
	public class PtuProcedimientostupa_db2: PtuProcedimientostupa_dao
	{
		private List<PtuProcedimientostupa> oPtuProcedimientostupaList;
		private PtuProcedimientostupa oPtuProcedimientostupa;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuProcedimientostupa_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuProcedimientostupa pPtuProcedimientostupa)
		{
			DB2Parameter[] arrParam = new DB2Parameter[27];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@VCHAREAOFICINA", DB2Type.VarChar);
				arrParam[1].Value = pPtuProcedimientostupa.vchareaoficina;
				arrParam[2] = new DB2Parameter("@VCHCONCEPTO", DB2Type.VarChar);
				arrParam[2].Value = pPtuProcedimientostupa.vchconcepto;
				arrParam[3] = new DB2Parameter("@SMLTIPOSOLICITUD", DB2Type.SmallInt);
				arrParam[3].Value = pPtuProcedimientostupa.smltiposolicitud;
				arrParam[4] = new DB2Parameter("@SMLNIVEL", DB2Type.SmallInt);
				arrParam[4].Value = pPtuProcedimientostupa.smlnivel;
				arrParam[5] = new DB2Parameter("@DECPAGOAPERTURA", DB2Type.Decimal);
				arrParam[5].Value = pPtuProcedimientostupa.decpagoapertura;
				arrParam[6] = new DB2Parameter("@DECPAGORENOVACION", DB2Type.Decimal);
				arrParam[6].Value = pPtuProcedimientostupa.decpagorenovacion;
				arrParam[7] = new DB2Parameter("@DECPAGOVENCIMIENTO", DB2Type.Decimal);
				arrParam[7].Value = pPtuProcedimientostupa.decpagovencimiento;
				arrParam[8] = new DB2Parameter("@VCHCODDERECHOAPERTURA", DB2Type.VarChar);
				arrParam[8].Value = pPtuProcedimientostupa.vchcodderechoapertura;
				arrParam[9] = new DB2Parameter("@VCHCODDERECHORENOVACION", DB2Type.VarChar);
				arrParam[9].Value = pPtuProcedimientostupa.vchcodderechorenovacion;
				arrParam[10] = new DB2Parameter("@VCHCODDERECHOVENCIMIENTO", DB2Type.VarChar);
				arrParam[10].Value = pPtuProcedimientostupa.vchcodderechovencimiento;
				arrParam[11] = new DB2Parameter("@INTTUPCODIGO", DB2Type.Integer);
				arrParam[11].Value = pPtuProcedimientostupa.inttupcodigo;
				arrParam[12] = new DB2Parameter("@VCHOFICODIGO", DB2Type.VarChar);
				arrParam[12].Value = pPtuProcedimientostupa.vchoficodigo;
				arrParam[13] = new DB2Parameter("@INTPROCODIGO", DB2Type.Integer);
				arrParam[13].Value = pPtuProcedimientostupa.intprocodigo;
				arrParam[14] = new DB2Parameter("@SMLCALIFICACIONAUTOMATICA", DB2Type.SmallInt);
				arrParam[14].Value = pPtuProcedimientostupa.smlcalificacionautomatica;
				arrParam[15] = new DB2Parameter("@SMLEVALPREVIAPOSITIVA", DB2Type.SmallInt);
				arrParam[15].Value = pPtuProcedimientostupa.smlevalpreviapositiva;
				arrParam[16] = new DB2Parameter("@SMLEVALPREVIANEGATIVA", DB2Type.SmallInt);
				arrParam[16].Value = pPtuProcedimientostupa.smlevalprevianegativa;
				arrParam[17] = new DB2Parameter("@SMLDIASPLAZO", DB2Type.SmallInt);
				arrParam[17].Value = pPtuProcedimientostupa.smldiasplazo;
				arrParam[18] = new DB2Parameter("@VCHINSTANCIASRECONSIDERACION", DB2Type.VarChar);
				arrParam[18].Value = pPtuProcedimientostupa.vchinstanciasreconsideracion;
				arrParam[19] = new DB2Parameter("@VCHINSTANCIASAPELACION", DB2Type.VarChar);
				arrParam[19].Value = pPtuProcedimientostupa.vchinstanciasapelacion;
				arrParam[20] = new DB2Parameter("@SMLPROCTUPAACTIVO", DB2Type.SmallInt);
				arrParam[20].Value = pPtuProcedimientostupa.smlproctupaactivo;
				arrParam[21] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[21].Value = pPtuProcedimientostupa.vchaudusucreacion;
				arrParam[22] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[22].Value = pPtuProcedimientostupa.tmsaudfeccreacion;
				arrParam[23] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[23].Value = pPtuProcedimientostupa.vchaudusumodif;
				arrParam[24] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[24].Value = pPtuProcedimientostupa.tmsaudfecmodif;
				arrParam[25] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[25].Value = pPtuProcedimientostupa.vchaudequipo;
				arrParam[26] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[26].Value = pPtuProcedimientostupa.vchaudprograma;

				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPROCEDIMIENTOSTUPA_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPROCEDIMIENTOSTUPA_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuProcedimientostupa pPtuProcedimientostupa)
		{
			DB2Parameter[] arrParam = new DB2Parameter[27];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@VCHAREAOFICINA", DB2Type.VarChar);
				arrParam[1].Value = pPtuProcedimientostupa.vchareaoficina;
				arrParam[2] = new DB2Parameter("@VCHCONCEPTO", DB2Type.VarChar);
				arrParam[2].Value = pPtuProcedimientostupa.vchconcepto;
				arrParam[3] = new DB2Parameter("@SMLTIPOSOLICITUD", DB2Type.SmallInt);
				arrParam[3].Value = pPtuProcedimientostupa.smltiposolicitud;
				arrParam[4] = new DB2Parameter("@SMLNIVEL", DB2Type.SmallInt);
				arrParam[4].Value = pPtuProcedimientostupa.smlnivel;
				arrParam[5] = new DB2Parameter("@DECPAGOAPERTURA", DB2Type.Decimal);
				arrParam[5].Value = pPtuProcedimientostupa.decpagoapertura;
				arrParam[6] = new DB2Parameter("@DECPAGORENOVACION", DB2Type.Decimal);
				arrParam[6].Value = pPtuProcedimientostupa.decpagorenovacion;
				arrParam[7] = new DB2Parameter("@DECPAGOVENCIMIENTO", DB2Type.Decimal);
				arrParam[7].Value = pPtuProcedimientostupa.decpagovencimiento;
				arrParam[8] = new DB2Parameter("@VCHCODDERECHOAPERTURA", DB2Type.VarChar);
				arrParam[8].Value = pPtuProcedimientostupa.vchcodderechoapertura;
				arrParam[9] = new DB2Parameter("@VCHCODDERECHORENOVACION", DB2Type.VarChar);
				arrParam[9].Value = pPtuProcedimientostupa.vchcodderechorenovacion;
				arrParam[10] = new DB2Parameter("@VCHCODDERECHOVENCIMIENTO", DB2Type.VarChar);
				arrParam[10].Value = pPtuProcedimientostupa.vchcodderechovencimiento;
				arrParam[11] = new DB2Parameter("@INTTUPCODIGO", DB2Type.Integer);
				arrParam[11].Value = pPtuProcedimientostupa.inttupcodigo;
				arrParam[12] = new DB2Parameter("@VCHOFICODIGO", DB2Type.VarChar);
				arrParam[12].Value = pPtuProcedimientostupa.vchoficodigo;
				arrParam[13] = new DB2Parameter("@INTPROCODIGO", DB2Type.Integer);
				arrParam[13].Value = pPtuProcedimientostupa.intprocodigo;
				arrParam[14] = new DB2Parameter("@SMLCALIFICACIONAUTOMATICA", DB2Type.SmallInt);
				arrParam[14].Value = pPtuProcedimientostupa.smlcalificacionautomatica;
				arrParam[15] = new DB2Parameter("@SMLEVALPREVIAPOSITIVA", DB2Type.SmallInt);
				arrParam[15].Value = pPtuProcedimientostupa.smlevalpreviapositiva;
				arrParam[16] = new DB2Parameter("@SMLEVALPREVIANEGATIVA", DB2Type.SmallInt);
				arrParam[16].Value = pPtuProcedimientostupa.smlevalprevianegativa;
				arrParam[17] = new DB2Parameter("@SMLDIASPLAZO", DB2Type.SmallInt);
				arrParam[17].Value = pPtuProcedimientostupa.smldiasplazo;
				arrParam[18] = new DB2Parameter("@VCHINSTANCIASRECONSIDERACION", DB2Type.VarChar);
				arrParam[18].Value = pPtuProcedimientostupa.vchinstanciasreconsideracion;
				arrParam[19] = new DB2Parameter("@VCHINSTANCIASAPELACION", DB2Type.VarChar);
				arrParam[19].Value = pPtuProcedimientostupa.vchinstanciasapelacion;
				arrParam[20] = new DB2Parameter("@SMLPROCTUPAACTIVO", DB2Type.SmallInt);
				arrParam[20].Value = pPtuProcedimientostupa.smlproctupaactivo;
				arrParam[21] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[21].Value = pPtuProcedimientostupa.vchaudusucreacion;
				arrParam[22] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[22].Value = pPtuProcedimientostupa.tmsaudfeccreacion;
				arrParam[23] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[23].Value = pPtuProcedimientostupa.vchaudusumodif;
				arrParam[24] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[24].Value = pPtuProcedimientostupa.tmsaudfecmodif;
				arrParam[25] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[25].Value = pPtuProcedimientostupa.vchaudequipo;
				arrParam[26] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[26].Value = pPtuProcedimientostupa.vchaudprograma;

				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPROCEDIMIENTOSTUPA_ACTUALIZAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPROCEDIMIENTOSTUPA_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override void Eliminar(int? intcodigoprocedimiento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
				arrParam[0].Value = intcodigoprocedimiento;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPROCEDIMIENTOSTUPA_ELIMINAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPROCEDIMIENTOSTUPA_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override List<PtuProcedimientostupa> Listar()
		{
			try
			{
				oPtuProcedimientostupaList = new List<PtuProcedimientostupa>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPROCEDIMIENTOSTUPA_LISTAR");
				oPtuProcedimientostupaList = ConvertidorUtil.DeReaderAColeccion<PtuProcedimientostupa, List<PtuProcedimientostupa>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPROCEDIMIENTOSTUPA_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuProcedimientostupaList);
			}
			return oPtuProcedimientostupaList;
		}

		public override PtuProcedimientostupa ListarKey(int? intcodigoprocedimiento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
				arrParam[0].Value = intcodigoprocedimiento;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPROCEDIMIENTOSTUPA_LISTARKEY", arrParam);
				oPtuProcedimientostupa = ConvertidorUtil.DeReaderAEntidad<PtuProcedimientostupa>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPROCEDIMIENTOSTUPA_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuProcedimientostupa);
			}
			return oPtuProcedimientostupa;
		}

		public override List<PtuProcedimientostupa> ListarKeys(
								int? intcodigoprocedimiento)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
				arrParam[0].Value = intcodigoprocedimiento;
				oPtuProcedimientostupaList = new List<PtuProcedimientostupa>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPROCEDIMIENTOSTUPA_LISTARKEYS", arrParam);
				oPtuProcedimientostupaList = ConvertidorUtil.DeReaderAColeccion<PtuProcedimientostupa, List<PtuProcedimientostupa>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPROCEDIMIENTOSTUPA_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuProcedimientostupaList);
			}
			return oPtuProcedimientostupaList;
		}


	}
}
