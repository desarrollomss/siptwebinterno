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
	public class PtuSolreqgrupo_db2: PtuSolreqgrupo_dao
	{
		private List<PtuSolreqgrupo> oPtuSolreqgrupoList;
		private PtuSolreqgrupo oPtuSolreqgrupo;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolreqgrupo_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuSolreqgrupo pPtuSolreqgrupo)
		{
			DB2Parameter[] arrParam = new DB2Parameter[17];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@VCHCODGRUPO", DB2Type.VarChar);
				arrParam[1].Value = pPtuSolreqgrupo.vchcodgrupo;
				arrParam[2] = new DB2Parameter("@VCHNOMBREGRUPO", DB2Type.VarChar);
				arrParam[2].Value = pPtuSolreqgrupo.vchnombregrupo;
				arrParam[3] = new DB2Parameter("@CHREDITABLE", DB2Type.Char);
				arrParam[3].Value = pPtuSolreqgrupo.chreditable;
				arrParam[4] = new DB2Parameter("@SMLTIPOGRUPO", DB2Type.SmallInt);
				arrParam[4].Value = pPtuSolreqgrupo.smltipogrupo;
				arrParam[5] = new DB2Parameter("@SMLMOSTRARTITULO", DB2Type.SmallInt);
				arrParam[5].Value = pPtuSolreqgrupo.smlmostrartitulo;
				arrParam[6] = new DB2Parameter("@SMLNIVEL", DB2Type.SmallInt);
				arrParam[6].Value = pPtuSolreqgrupo.smlnivel;
				arrParam[7] = new DB2Parameter("@SMLULTIMONIVEL", DB2Type.SmallInt);
				arrParam[7].Value = pPtuSolreqgrupo.smlultimonivel;
				arrParam[8] = new DB2Parameter("@INTCODIGOFUNCION", DB2Type.Integer);
				arrParam[8].Value = pPtuSolreqgrupo.intcodigofuncion;
				arrParam[9] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
				arrParam[9].Value = pPtuSolreqgrupo.intsolicitudplantilla;
				arrParam[10] = new DB2Parameter("@INTCODSOLREQGRPPADRE", DB2Type.Integer);
				arrParam[10].Value = pPtuSolreqgrupo.intcodsolreqgrppadre;
				arrParam[11] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[11].Value = pPtuSolreqgrupo.vchaudusucreacion;
				arrParam[12] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[12].Value = pPtuSolreqgrupo.tmsaudfeccreacion;
				arrParam[13] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[13].Value = pPtuSolreqgrupo.vchaudusumodif;
				arrParam[14] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[14].Value = pPtuSolreqgrupo.tmsaudfecmodif;
				arrParam[15] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[15].Value = pPtuSolreqgrupo.vchaudequipo;
				arrParam[16] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[16].Value = pPtuSolreqgrupo.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQGRUPO_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQGRUPO_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuSolreqgrupo pPtuSolreqgrupo)
		{
			DB2Parameter[] arrParam = new DB2Parameter[17];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[0].Value = pPtuSolreqgrupo.intcodsolreqgrupo;
				arrParam[1] = new DB2Parameter("@VCHCODGRUPO", DB2Type.VarChar);
				arrParam[1].Value = pPtuSolreqgrupo.vchcodgrupo;
				arrParam[2] = new DB2Parameter("@VCHNOMBREGRUPO", DB2Type.VarChar);
				arrParam[2].Value = pPtuSolreqgrupo.vchnombregrupo;
				arrParam[3] = new DB2Parameter("@CHREDITABLE", DB2Type.Char);
				arrParam[3].Value = pPtuSolreqgrupo.chreditable;
				arrParam[4] = new DB2Parameter("@SMLTIPOGRUPO", DB2Type.SmallInt);
				arrParam[4].Value = pPtuSolreqgrupo.smltipogrupo;
				arrParam[5] = new DB2Parameter("@SMLMOSTRARTITULO", DB2Type.SmallInt);
				arrParam[5].Value = pPtuSolreqgrupo.smlmostrartitulo;
				arrParam[6] = new DB2Parameter("@SMLNIVEL", DB2Type.SmallInt);
				arrParam[6].Value = pPtuSolreqgrupo.smlnivel;
				arrParam[7] = new DB2Parameter("@SMLULTIMONIVEL", DB2Type.SmallInt);
				arrParam[7].Value = pPtuSolreqgrupo.smlultimonivel;
				arrParam[8] = new DB2Parameter("@INTCODIGOFUNCION", DB2Type.Integer);
				arrParam[8].Value = pPtuSolreqgrupo.intcodigofuncion;
				arrParam[9] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
				arrParam[9].Value = pPtuSolreqgrupo.intsolicitudplantilla;
				arrParam[10] = new DB2Parameter("@INTCODSOLREQGRPPADRE", DB2Type.Integer);
				arrParam[10].Value = pPtuSolreqgrupo.intcodsolreqgrppadre;
				arrParam[11] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[11].Value = pPtuSolreqgrupo.vchaudusucreacion;
				arrParam[12] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[12].Value = pPtuSolreqgrupo.tmsaudfeccreacion;
				arrParam[13] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[13].Value = pPtuSolreqgrupo.vchaudusumodif;
				arrParam[14] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[14].Value = pPtuSolreqgrupo.tmsaudfecmodif;
				arrParam[15] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[15].Value = pPtuSolreqgrupo.vchaudequipo;
				arrParam[16] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[16].Value = pPtuSolreqgrupo.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQGRUPO_ACTUALIZAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQGRUPO_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override void Eliminar(int? intcodsolreqgrupo)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[0].Value = intcodsolreqgrupo;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQGRUPO_ELIMINAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQGRUPO_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override List<PtuSolreqgrupo> Listar()
		{
			try
			{
				oPtuSolreqgrupoList = new List<PtuSolreqgrupo>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQGRUPO_LISTAR");
				oPtuSolreqgrupoList = ConvertidorUtil.DeReaderAColeccion<PtuSolreqgrupo, List<PtuSolreqgrupo>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQGRUPO_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolreqgrupoList);
			}
			return oPtuSolreqgrupoList;
		}

		public override PtuSolreqgrupo ListarKey(int? intcodsolreqgrupo)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[0].Value = intcodsolreqgrupo;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQGRUPO_LISTARKEY", arrParam);
				oPtuSolreqgrupo = ConvertidorUtil.DeReaderAEntidad<PtuSolreqgrupo>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQGRUPO_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolreqgrupo);
			}
			return oPtuSolreqgrupo;
		}

		public override List<PtuSolreqgrupo> ListarKeys(
								int? intcodsolreqgrupo,
								int? intsolicitudplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLREQGRUPO", DB2Type.Integer);
				arrParam[0].Value = intcodsolreqgrupo;
				arrParam[1] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
				arrParam[1].Value = intsolicitudplantilla;
				oPtuSolreqgrupoList = new List<PtuSolreqgrupo>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQGRUPO_LISTARKEYS", arrParam);
				oPtuSolreqgrupoList = ConvertidorUtil.DeReaderAColeccion<PtuSolreqgrupo, List<PtuSolreqgrupo>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQGRUPO_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolreqgrupoList);
			}
			return oPtuSolreqgrupoList;
		}

		public override List<PtuSolreqgrupo> ListarSegunFuncion(int? intsolicitudplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = intsolicitudplantilla;
				oPtuSolreqgrupoList = new List<PtuSolreqgrupo>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQGRUPO_LISTARSEGUNFUNCION", arrParam);
				oPtuSolreqgrupoList = ConvertidorUtil.DeReaderAColeccion<PtuSolreqgrupo, List<PtuSolreqgrupo>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQGRUPO_LISTARSEGUNFUNCION");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolreqgrupoList);
			}
			return oPtuSolreqgrupoList;
		}


	}
}