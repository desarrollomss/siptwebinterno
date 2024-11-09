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
using SIPT.DAL.Dao.Factory;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
	public class PtuSolcertificado_db2: PtuSolcertificado_dao
	{
		private List<PtuSolcertificado> oPtuSolcertificadoList;
		private List<PtuSolcertificado_PorInspector> oPtuSolcertificado_PorInspectorList;
		private PtuSolcertificado oPtuSolcertificado;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolcertificado_db2(ref LogMensajes logMensajes, ref Db dbconex)
		{
			this.logMensajes = logMensajes;
			this.dbconex = dbconex;
		}

		public override Int32 Insertar(PtuSolcertificado pPtuSolcertificado)
		{
			DB2Parameter[] arrParam = new DB2Parameter[19];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[0].Direction = ParameterDirection.Output;
				arrParam[1] = new DB2Parameter("@VCHNOMCOMERCIALSOLCERT", DB2Type.VarChar);
				arrParam[1].Value = pPtuSolcertificado.vchnomcomercialsolcert;
				arrParam[2] = new DB2Parameter("@VCHDIRECCSOLICITANTECERT", DB2Type.VarChar);
				arrParam[2].Value = pPtuSolcertificado.vchdireccsolicitantecert;
				arrParam[3] = new DB2Parameter("@DATFECHAPROGRAMACION", DB2Type.Date);
				arrParam[3].Value = pPtuSolcertificado.datfechaprogramacion;
				arrParam[4] = new DB2Parameter("@DATFECHAVENCIMIENTO", DB2Type.Date);
				arrParam[4].Value = pPtuSolcertificado.datfechavencimiento;
				arrParam[5] = new DB2Parameter("@SMLESTSOLCERTIFICADO", DB2Type.SmallInt);
				arrParam[5].Value = pPtuSolcertificado.smlestsolcertificado;
				arrParam[6] = new DB2Parameter("@SMLRESULTADOCERTIFICACION", DB2Type.SmallInt);
				arrParam[6].Value = pPtuSolcertificado.smlresultadocertificacion;
				arrParam[7] = new DB2Parameter("@VCHZONIFICACION", DB2Type.VarChar);
				arrParam[7].Value = pPtuSolcertificado.vchzonificacion;
				arrParam[8] = new DB2Parameter("@VCHESTRUCTURACION", DB2Type.VarChar);
				arrParam[8].Value = pPtuSolcertificado.vchestructuracion;
				arrParam[9] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
				arrParam[9].Value = pPtuSolcertificado.vchobservacion;
				arrParam[10] = new DB2Parameter("@INTCODSOLICITUDLICENCIA", DB2Type.Integer);
				arrParam[10].Value = pPtuSolcertificado.intcodsolicitudlicencia;
				arrParam[11] = new DB2Parameter("@VCHREPORTERESOLUCION", DB2Type.VarChar);
				arrParam[11].Value = pPtuSolcertificado.vchreporteresolucion;
				arrParam[12] = new DB2Parameter("@INTCODLICENCIA", DB2Type.Integer);
				arrParam[12].Value = pPtuSolcertificado.intcodlicencia;
				arrParam[13] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[13].Value = this.logMensajes.Usuario;
				arrParam[14] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[14].Value = DateTime.Now;
				arrParam[15] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[15].Value = DBNull.Value;
				arrParam[16] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[16].Value = DBNull.Value;
				arrParam[17] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[17].Value = this.logMensajes.Equipo;
				arrParam[18] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[18].Value = this.logMensajes.Programa;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADO_INSERTAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADO_INSERTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
			return Convert.ToInt32(arrParam[0].Value);
		}

		public override void Actualizar(PtuSolcertificado pPtuSolcertificado)
		{
			DB2Parameter[] arrParam = new DB2Parameter[19];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[0].Value = pPtuSolcertificado.intcodsolicitud;
				arrParam[1] = new DB2Parameter("@VCHNOMCOMERCIALSOLCERT", DB2Type.VarChar);
				arrParam[1].Value = pPtuSolcertificado.vchnomcomercialsolcert;
				arrParam[2] = new DB2Parameter("@VCHDIRECCSOLICITANTECERT", DB2Type.VarChar);
				arrParam[2].Value = pPtuSolcertificado.vchdireccsolicitantecert;
				arrParam[3] = new DB2Parameter("@DATFECHAPROGRAMACION", DB2Type.Date);
				arrParam[3].Value = pPtuSolcertificado.datfechaprogramacion;
				arrParam[4] = new DB2Parameter("@DATFECHAVENCIMIENTO", DB2Type.Date);
				arrParam[4].Value = pPtuSolcertificado.datfechavencimiento;
				arrParam[5] = new DB2Parameter("@SMLESTSOLCERTIFICADO", DB2Type.SmallInt);
				arrParam[5].Value = pPtuSolcertificado.smlestsolcertificado;
				arrParam[6] = new DB2Parameter("@SMLRESULTADOCERTIFICACION", DB2Type.SmallInt);
				arrParam[6].Value = pPtuSolcertificado.smlresultadocertificacion;
				arrParam[7] = new DB2Parameter("@VCHZONIFICACION", DB2Type.VarChar);
				arrParam[7].Value = pPtuSolcertificado.vchzonificacion;
				arrParam[8] = new DB2Parameter("@VCHESTRUCTURACION", DB2Type.VarChar);
				arrParam[8].Value = pPtuSolcertificado.vchestructuracion;
				arrParam[9] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
				arrParam[9].Value = pPtuSolcertificado.vchobservacion;
				arrParam[10] = new DB2Parameter("@INTCODSOLICITUDLICENCIA", DB2Type.Integer);
				arrParam[10].Value = pPtuSolcertificado.intcodsolicitudlicencia;
				arrParam[11] = new DB2Parameter("@VCHREPORTERESOLUCION", DB2Type.VarChar);
				arrParam[11].Value = pPtuSolcertificado.vchreporteresolucion;
				arrParam[12] = new DB2Parameter("@INTCODLICENCIA", DB2Type.Integer);
				arrParam[12].Value = pPtuSolcertificado.intcodlicencia;
				arrParam[13] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
				arrParam[13].Value = DBNull.Value;
				arrParam[14] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
				arrParam[14].Value = DBNull.Value;
				arrParam[15] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
				arrParam[15].Value = this.logMensajes.Usuario;
				arrParam[16] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
				arrParam[16].Value = DateTime.Now;
				arrParam[17] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
				arrParam[17].Value = this.logMensajes.Equipo;
				arrParam[18] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
				arrParam[18].Value = this.logMensajes.Programa;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADO_ACTUALIZAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADO_ACTUALIZAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override void Eliminar(int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[0].Value = intcodsolicitud;
				DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADO_ELIMINAR", arrParam);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADO_ELIMINAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
			}
		}

		public override List<PtuSolcertificado> Listar()
		{
			try
			{
				oPtuSolcertificadoList = new List<PtuSolcertificado>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADO_LISTAR");
				oPtuSolcertificadoList = ConvertidorUtil.DeReaderAColeccion<PtuSolcertificado, List<PtuSolcertificado>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADO_LISTAR");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolcertificadoList);
			}
			return oPtuSolcertificadoList;
		}

		public override PtuSolcertificado ListarKey(int? intcodsolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[1];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[0].Value = intcodsolicitud;
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADO_LISTARKEY", arrParam);
				oPtuSolcertificado = ConvertidorUtil.DeReaderAEntidad<PtuSolcertificado>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADO_LISTARKEY");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolcertificado);
			}
			return oPtuSolcertificado;
		}

		public override List<PtuSolcertificado> ListarKeys(
								int? intcodsolicitud,
								int? intcodlicencia)
		{
			DB2Parameter[] arrParam = new DB2Parameter[2];
			try
			{
				arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
				arrParam[0].Value = intcodsolicitud;
				arrParam[1] = new DB2Parameter("@INTCODLICENCIA", DB2Type.Integer);
				arrParam[1].Value = intcodlicencia;
				oPtuSolcertificadoList = new List<PtuSolcertificado>();
				DB2DataReader dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADO_LISTARKEYS", arrParam);
				oPtuSolcertificadoList = ConvertidorUtil.DeReaderAColeccion<PtuSolcertificado, List<PtuSolcertificado>>(dataReader);
			}
			catch (Exception ex)
			{
				Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
				throw ex;
			}
			finally
			{
				Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLCERTIFICADO_LISTARKEYS");
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
				Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolcertificadoList);
			}
			return oPtuSolcertificadoList;
		}


		public override List<PtuSolcertificado_PorInspector> Buscar(
						PtuSolcertificado pPtuSolcertificado,
						PtuSolicitud pPtuSolicitud)
		{
			DB2Parameter[] arrParam = new DB2Parameter[8];
			
			arrParam[0] = new DB2Parameter("@CHRANIO", DB2Type.Char );
			arrParam[0].Value = pPtuSolicitud.chranio;
			arrParam[1] = new DB2Parameter("@VCHNUMERO", DB2Type.VarChar );
			arrParam[1].Value = pPtuSolicitud.vchnumero;
			arrParam[2] = new DB2Parameter("@SMLESTSOLCERTIFICADO", DB2Type.SmallInt );
			arrParam[2].Value = pPtuSolcertificado.smlestsolcertificado;
			arrParam[3] = new DB2Parameter("@SMLRESULTADOCERTIFICACION", DB2Type.SmallInt);
			arrParam[3].Value = pPtuSolcertificado.smlresultadocertificacion;
			arrParam[4] = new DB2Parameter("@VCHNUMEXPEDIENTE", DB2Type.VarChar);
			arrParam[4].Value = pPtuSolicitud.vchnumexpediente;
			arrParam[5] = new DB2Parameter("@INTCODIGOSOLICITANTE", DB2Type.Integer);
			arrParam[5].Value = pPtuSolicitud.intcodigosolicitante;
			arrParam[6] = new DB2Parameter("@VCHNOMBRESOLICITANTE", DB2Type.VarChar);
			arrParam[6].Value = pPtuSolicitud.vchnombresolicitante;
			arrParam[7] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
			arrParam[7].Value = pPtuSolicitud.intcodigosolicitante;


			return DB2Comando.Listar<PtuSolcertificado_PorInspector>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLCERTIFICADO_BUSCAR", this.logMensajes, arrParam);
				
		}


	}
}
