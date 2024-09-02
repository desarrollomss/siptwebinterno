using System;
using System.Data;
using IBM.Data.DB2;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;
using DBAccess;
using SIPT.APPL.Logs;
using DBAccess.Util;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class PtuSolLicenciaAnalista_db2 : PtuSolLicenciaAnalista_dao
    {
        private List<PtuSolLicenciaAnalista> oPtuSolLicenciaAnalistaList;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolLicenciaAnalista_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override int Insertar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[8];
            try
            {

                arrParam[0] = new DB2Parameter("@INTCODSOLICITUDANALISTA", DB2Type.Integer);
                arrParam[0].Direction = ParameterDirection.Output;
                arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
                arrParam[1].Value = pPtuSolLicenciaAnalista.intusuanalista;
                arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[2].Value = pPtuSolLicenciaAnalista.intcodsolicitud;
                arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
                arrParam[3].Value = pPtuSolLicenciaAnalista.smlestado; // ? 1 : 0;
                arrParam[4] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[4].Value = pPtuSolLicenciaAnalista.vchaudusucreacion;
                arrParam[5] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
                arrParam[5].Value = pPtuSolLicenciaAnalista.tmsaudfeccreacion;
                arrParam[6] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[6].Value = pPtuSolLicenciaAnalista.vchaudequipo;
                arrParam[7] = new DB2Parameter("@VACHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[7].Value = pPtuSolLicenciaAnalista.vchaudprograma;
                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAANALISTA_INSERTAR", arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAANALISTA_INSERTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            return Convert.ToInt32(arrParam[0].Value);
        }

        public override void Actualizar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[6];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUDANALISTA", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicenciaAnalista.intcodsolicitudanalista;
                arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
                arrParam[1].Value = pPtuSolLicenciaAnalista.intusuanalista;
                arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[2].Value = pPtuSolLicenciaAnalista.intcodsolicitud;
                arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
                arrParam[3].Value = pPtuSolLicenciaAnalista.smlestado; // ? 1 : 0;
                arrParam[4] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[4].Value = pPtuSolLicenciaAnalista.vchaudusumodif;
                arrParam[5] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[5].Value = pPtuSolLicenciaAnalista.tmsaudfecmodif;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAANALISTA_ACTUALIZAR", arrParam);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAANALISTA_ACTUALIZAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
        }

        public override void Eliminar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicenciaAnalista.intcodsolicitud;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PtuSolLicenciaAnalista_ELIMINAR", arrParam);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PtuSolLicenciaAnalista_ELIMINAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
        }

        public override List<PtuSolLicenciaAnalista> Listar()
        {
            try
            {
                DB2DataReader dataReader;
                oPtuSolLicenciaAnalistaList = new List<PtuSolLicenciaAnalista>();
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PtuSolLicenciaAnalista_LISTAR");

                oPtuSolLicenciaAnalistaList = ConvertidorUtil.DeReaderAColeccion<PtuSolLicenciaAnalista, List<PtuSolLicenciaAnalista>>(dataReader);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PtuSolLicenciaAnalista_LISTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolLicenciaAnalistaList);
            }
            return oPtuSolLicenciaAnalistaList;
        }

        public override PtuSolLicenciaAnalista ListarPorId(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[2];
            try
            {
                DB2DataReader dataReader;
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicenciaAnalista.intcodsolicitud;


                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PtuSolLicenciaAnalista_LISTARKEY", arrParam);

                pPtuSolLicenciaAnalista = ConvertidorUtil.DeReaderAEntidad<PtuSolLicenciaAnalista>(dataReader);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PtuSolLicenciaAnalista_LISTARKEY");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), pPtuSolLicenciaAnalista);
            }
            return pPtuSolLicenciaAnalista;
        }

    }
}