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
	public class PtuPlantillareq_db2: PtuPlantillareq_dao
	{
		private List<PtuPlantillareq> oPtuPlantillareqList;
		private PtuPlantillareq oPtuPlantillareq;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuPlantillareq_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuPlantillareq pPtuPlantillareq)
		{
			DB2Parameter[] arrParam = new DB2Parameter[14];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@VCHNOMBREPLANTILLA", DB2Type.VarChar);
				arrParam[1].Value = pPtuPlantillareq.vchnombreplantilla;
				arrParam[2] = new DB2Parameter("@VCHDOCPLANTILLA", DB2Type.VarChar);
				arrParam[2].Value = pPtuPlantillareq.vchdocplantilla;
				arrParam[3] = new DB2Parameter("@BLBDOCPLANTILLA", DB2Type.Blob);
				arrParam[3].Value = pPtuPlantillareq.blbdocplantilla;
				arrParam[4] = new DB2Parameter("@SMLTIPODOCUMENTOREQ", DB2Type.SmallInt);
				arrParam[4].Value = pPtuPlantillareq.smltipodocumentoreq;
				arrParam[5] = new DB2Parameter("@VCHNOTAREQ", DB2Type.VarChar);
				arrParam[5].Value = pPtuPlantillareq.vchnotareq;
				arrParam[6] = new DB2Parameter("@VCHPROCEDIMIENTOALM", DB2Type.VarChar);
				arrParam[6].Value = pPtuPlantillareq.vchprocedimientoalm;
				arrParam[7] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
				arrParam[7].Value = pPtuPlantillareq.smlestado;
				arrParam[8] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[8].Value = pPtuPlantillareq.vchaudusucreacion;
				arrParam[9] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[9].Value = pPtuPlantillareq.tmsaudfeccreacion;
				arrParam[10] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[10].Value = pPtuPlantillareq.vchaudusumodif;
				arrParam[11] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[11].Value = pPtuPlantillareq.tmsaudfecmodif;
				arrParam[12] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[12].Value = pPtuPlantillareq.vchaudequipo;
				arrParam[13] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[13].Value = pPtuPlantillareq.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPLANTILLAREQ_INSERTAR", arrParam);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_INSERTAR : "+ ex.Message);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuPlantillareq pPtuPlantillareq)
		{
			DB2Parameter[] arrParam = new DB2Parameter[14];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = pPtuPlantillareq.intcodplantilla;
				arrParam[1] = new DB2Parameter("@VCHNOMBREPLANTILLA", DB2Type.VarChar);
				arrParam[1].Value = pPtuPlantillareq.vchnombreplantilla;
				arrParam[2] = new DB2Parameter("@VCHDOCPLANTILLA", DB2Type.VarChar);
				arrParam[2].Value = pPtuPlantillareq.vchdocplantilla;
				arrParam[3] = new DB2Parameter("@BLBDOCPLANTILLA", DB2Type.Blob);
				arrParam[3].Value = pPtuPlantillareq.blbdocplantilla;
				arrParam[4] = new DB2Parameter("@SMLTIPODOCUMENTOREQ", DB2Type.SmallInt);
				arrParam[4].Value = pPtuPlantillareq.smltipodocumentoreq;
				arrParam[5] = new DB2Parameter("@VCHNOTAREQ", DB2Type.VarChar);
				arrParam[5].Value = pPtuPlantillareq.vchnotareq;
				arrParam[6] = new DB2Parameter("@VCHPROCEDIMIENTOALM", DB2Type.VarChar);
				arrParam[6].Value = pPtuPlantillareq.vchprocedimientoalm;
				arrParam[7] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
				arrParam[7].Value = pPtuPlantillareq.smlestado;
				arrParam[8] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[8].Value = pPtuPlantillareq.vchaudusucreacion;
				arrParam[9] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[9].Value = pPtuPlantillareq.tmsaudfeccreacion;
				arrParam[10] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[10].Value = pPtuPlantillareq.vchaudusumodif;
				arrParam[11] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[11].Value = pPtuPlantillareq.tmsaudfecmodif;
				arrParam[12] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[12].Value = pPtuPlantillareq.vchaudequipo;
				arrParam[13] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[13].Value = pPtuPlantillareq.vchaudprograma;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPLANTILLAREQ_ACTUALIZAR", arrParam);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_ACTUALIZAR : "+ ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
		}

		public override void Eliminar(int? intcodplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = intcodplantilla;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPLANTILLAREQ_ELIMINAR", arrParam);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_ELIMINAR : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
		}

		public override List<PtuPlantillareq> Listar()
		{
			try
			{
				oPtuPlantillareqList = new List<PtuPlantillareq>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPLANTILLAREQ_LISTAR");
				oPtuPlantillareqList = ConvertidorUtil.DeReaderAColeccion<PtuPlantillareq, List<PtuPlantillareq>>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuPlantillareqList);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_LISTAR : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), oPtuPlantillareqList);
				throw ex;
			}
			return oPtuPlantillareqList;
		}

		public override PtuPlantillareq ListarKey(int? intcodplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			oPtuPlantillareq = new PtuPlantillareq();
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = intcodplantilla;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPLANTILLAREQ_LISTARKEY", arrParam);
				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						oPtuPlantillareq.intcodplantilla = Convert.ToInt32(dataReader["INTCODPLANTILLA"]);
						oPtuPlantillareq.vchnombreplantilla = Convert.ToString(dataReader["VCHNOMBREPLANTILLA"]);
						oPtuPlantillareq.vchdocplantilla = Convert.ToString(dataReader["VCHDOCPLANTILLA"]);
						oPtuPlantillareq.blbdocplantilla = (byte[])dataReader["BLBDOCPLANTILLA"];
						oPtuPlantillareq.smltipodocumentoreq = Convert.ToInt16(dataReader["SMLTIPODOCUMENTOREQ"]);
						oPtuPlantillareq.vchnotareq = Convert.ToString(dataReader["VCHNOTAREQ"]);
						oPtuPlantillareq.smlestado = Convert.ToInt16(dataReader["SMLESTADO"]);
					}
				}
				//oPtuPlantillareq = ConvertidorUtil.DeReaderAEntidad<PtuPlantillareq>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuPlantillareq);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_LISTARKEY : "+ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
			return oPtuPlantillareq;
		}

		public override List<PtuPlantillareq> ListarKeys(
								int? intcodplantilla)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = intcodplantilla;
				oPtuPlantillareqList = new List<PtuPlantillareq>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPLANTILLAREQ_LISTARKEYS", arrParam);
				oPtuPlantillareqList = ConvertidorUtil.DeReaderAColeccion<PtuPlantillareq, List<PtuPlantillareq>>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuPlantillareqList);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_LISTARKEYS : " + ex.Message);
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
			return oPtuPlantillareqList;
		}

		public override List<PtuPlantillareq> ListarPlantillas(
								int? intcodplantilla,
								int? intcodigoprocedimiento, 
								int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[3];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODPLANTILLA", DB2Type.Integer);
				arrParam[0].Value = intcodplantilla;
				arrParam[1] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
				arrParam[1].Value = intcodigoprocedimiento;
				arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[2].Value = intcodsolicitud;

				oPtuPlantillareqList = new List<PtuPlantillareq>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPLANTILLAREQ_PROCTUPA", arrParam);
				oPtuPlantillareqList = ConvertidorUtil.DeReaderAColeccion<PtuPlantillareq, List<PtuPlantillareq>>(dataReader);

				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_PROCTUPA");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuPlantillareqList);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPLANTILLAREQ_PROCTUPA : "+ex.Message);				
				Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
				throw ex;
			}
			return oPtuPlantillareqList;
		}



	}
}
