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
	public class PtuSolreqdetalle_db2: PtuSolreqdetalle_dao
	{
		private List<PtuSolreqdetalle> oPtuSolreqdetalleList;
		private PtuSolreqdetalle oPtuSolreqdetalle;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolreqdetalle_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuSolreqdetalle pPtuSolreqdetalle)
		{
			DB2Parameter[] arrParam = new DB2Parameter[15];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQDETALLE", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@VCHETIQUETA", DB2Type.VarChar);
				arrParam[1].Value = pPtuSolreqdetalle.vchetiqueta;
				arrParam[2] = new DB2Parameter("@VCHDESCRIPCION", DB2Type.VarChar);
				arrParam[2].Value = pPtuSolreqdetalle.vchdescripcion;
				arrParam[3] = new DB2Parameter("@VCHNOTA", DB2Type.VarChar);
				arrParam[3].Value = pPtuSolreqdetalle.vchnota;
				arrParam[4] = new DB2Parameter("@CHREDITABLE", DB2Type.Char);
				arrParam[4].Value = pPtuSolreqdetalle.chreditable;
				arrParam[5] = new DB2Parameter("@CHROBLIGATORIO", DB2Type.Char);
				arrParam[5].Value = pPtuSolreqdetalle.chrobligatorio;
				arrParam[6] = new DB2Parameter("@VCHTIPOVALOR", DB2Type.VarChar);
				arrParam[6].Value = pPtuSolreqdetalle.vchtipovalor;
				arrParam[7] = new DB2Parameter("@VCHVALOR", DB2Type.VarChar);
				arrParam[7].Value = pPtuSolreqdetalle.vchvalor;
				arrParam[8] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[8].Value = pPtuSolreqdetalle.intcodsolreqgrupo;
				arrParam[9] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[9].Value = pPtuSolreqdetalle.vchaudusucreacion;
				arrParam[10] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[10].Value = pPtuSolreqdetalle.tmsaudfeccreacion;
				arrParam[11] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[11].Value = pPtuSolreqdetalle.vchaudusumodif;
				arrParam[12] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[12].Value = pPtuSolreqdetalle.tmsaudfecmodif;
				arrParam[13] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[13].Value = pPtuSolreqdetalle.vchaudequipo;
				arrParam[14] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[14].Value = pPtuSolreqdetalle.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuSolreqdetalle pPtuSolreqdetalle)
		{
			DB2Parameter[] arrParam = new DB2Parameter[15];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQDETALLE", DB2Type.Integer);
				arrParam[0].Value = pPtuSolreqdetalle.intcodsolreqdetalle;
				arrParam[1] = new DB2Parameter("@VCHETIQUETA", DB2Type.VarChar);
				arrParam[1].Value = pPtuSolreqdetalle.vchetiqueta;
				arrParam[2] = new DB2Parameter("@VCHDESCRIPCION", DB2Type.VarChar);
				arrParam[2].Value = pPtuSolreqdetalle.vchdescripcion;
				arrParam[3] = new DB2Parameter("@VCHNOTA", DB2Type.VarChar);
				arrParam[3].Value = pPtuSolreqdetalle.vchnota;
				arrParam[4] = new DB2Parameter("@CHREDITABLE", DB2Type.Char);
				arrParam[4].Value = pPtuSolreqdetalle.chreditable;
				arrParam[5] = new DB2Parameter("@CHROBLIGATORIO", DB2Type.Char);
				arrParam[5].Value = pPtuSolreqdetalle.chrobligatorio;
				arrParam[6] = new DB2Parameter("@VCHTIPOVALOR", DB2Type.VarChar);
				arrParam[6].Value = pPtuSolreqdetalle.vchtipovalor;
				arrParam[7] = new DB2Parameter("@VCHVALOR", DB2Type.VarChar);
				arrParam[7].Value = pPtuSolreqdetalle.vchvalor;
				arrParam[8] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[8].Value = pPtuSolreqdetalle.intcodsolreqgrupo;
				arrParam[9] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[9].Value = pPtuSolreqdetalle.vchaudusucreacion;
				arrParam[10] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[10].Value = pPtuSolreqdetalle.tmsaudfeccreacion;
				arrParam[11] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[11].Value = pPtuSolreqdetalle.vchaudusumodif;
				arrParam[12] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[12].Value = pPtuSolreqdetalle.tmsaudfecmodif;
				arrParam[13] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[13].Value = pPtuSolreqdetalle.vchaudequipo;
				arrParam[14] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[14].Value = pPtuSolreqdetalle.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_ACTUALIZAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override void Eliminar(int? intcodsolreqdetalle)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQDETALLE", DB2Type.Integer);
				arrParam[0].Value = intcodsolreqdetalle;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_ELIMINAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override List<PtuSolreqdetalle> Listar()
		{
			try
			{
				oPtuSolreqdetalleList = new List<PtuSolreqdetalle>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_LISTAR");
				oPtuSolreqdetalleList = ConvertidorUtil.DeReaderAColeccion<PtuSolreqdetalle, List<PtuSolreqdetalle>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolreqdetalleList);
			}
			return oPtuSolreqdetalleList;
		}

		public override PtuSolreqdetalle ListarKey(int? intcodsolreqdetalle)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQDETALLE", DB2Type.Integer);
				arrParam[0].Value = intcodsolreqdetalle;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_LISTARKEY", arrParam);
				oPtuSolreqdetalle = ConvertidorUtil.DeReaderAEntidad<PtuSolreqdetalle>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolreqdetalle);
			}
			return oPtuSolreqdetalle;
		}

		public override List<PtuSolreqdetalle> ListarKeys(
								int? intcodsolreqdetalle,
								int? intcodsolreqgrupo)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQDETALLE", DB2Type.Integer);
				arrParam[0].Value = intcodsolreqdetalle;
				arrParam[1] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[1].Value = intcodsolreqgrupo;
				oPtuSolreqdetalleList = new List<PtuSolreqdetalle>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_LISTARKEYS", arrParam);
				oPtuSolreqdetalleList = ConvertidorUtil.DeReaderAColeccion<PtuSolreqdetalle, List<PtuSolreqdetalle>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolreqdetalleList);
			}
			return oPtuSolreqdetalleList;
		}


	}
}
