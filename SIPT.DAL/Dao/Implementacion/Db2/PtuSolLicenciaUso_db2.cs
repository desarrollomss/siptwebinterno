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
    public class PtuSolLicenciaUso_db2: PtuSolLicenciaUso_dao
    {
        private List<PtuSolLicenciaUso> oPtuSolLicenciaUsoList;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolLicenciaUso_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override void Insertar(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[10];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;
                arrParam[1] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
                arrParam[1].Value = pPtuSolLicenciaUso.intcoduso;
                arrParam[2] = new DB2Parameter("@SMLUSOPRINCIPAL", DB2Type.SmallInt);
                arrParam[2].Value = pPtuSolLicenciaUso.smlusoprincipal; // ? 1 : 0;
                arrParam[3] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[3].Value = pPtuSolLicenciaUso.vchaudusucreacion;
                arrParam[4] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
                arrParam[4].Value = pPtuSolLicenciaUso.tmsaudfeccreacion;
                arrParam[5] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[5].Value = pPtuSolLicenciaUso.vchaudusumodif;
                arrParam[6] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[6].Value = pPtuSolLicenciaUso.tmsaudfecmodif;
                arrParam[7] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[7].Value = pPtuSolLicenciaUso.vchaudequipo;
                arrParam[8] = new DB2Parameter("@VACHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[8].Value = pPtuSolLicenciaUso.vchaudprograma;
                arrParam[9] = new DB2Parameter("@VCHCODUSO", DB2Type.VarChar);
                arrParam[9].Value = pPtuSolLicenciaUso.vchcoduso;


                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_INSERTAR", arrParam);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);                
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAUSO_INSERTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
        }

        public override void Actualizar(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[10];
            try
            {                
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;
                arrParam[1] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
                arrParam[1].Value = pPtuSolLicenciaUso.intcoduso;
                arrParam[2] = new DB2Parameter("@SMLUSOPRINCIPAL", DB2Type.SmallInt);
                arrParam[2].Value = pPtuSolLicenciaUso.smlusoprincipal;
                arrParam[3] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[3].Value = pPtuSolLicenciaUso.vchaudusucreacion;
                arrParam[4] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
                arrParam[4].Value = pPtuSolLicenciaUso.tmsaudfeccreacion;
                arrParam[5] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[5].Value = pPtuSolLicenciaUso.vchaudusumodif;
                arrParam[6] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[6].Value = pPtuSolLicenciaUso.tmsaudfecmodif;
                arrParam[7] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[7].Value = pPtuSolLicenciaUso.vchaudequipo;
                arrParam[8] = new DB2Parameter("@VACHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[8].Value = pPtuSolLicenciaUso.vchaudprograma;
                arrParam[9] = new DB2Parameter("@VCHCODUSO", DB2Type.VarChar);
                arrParam[9].Value = pPtuSolLicenciaUso.vchcoduso;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_ACTUALIZAR", arrParam);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAUSO_ACTUALIZAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
        }
       
        public override void Eliminar(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {                
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_ELIMINAR", arrParam);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAUSO_ELIMINAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
        }

        public override List<PtuSolLicenciaUso> Listar()
        {
            try
            {
                DB2DataReader dataReader;
                oPtuSolLicenciaUsoList = new List<PtuSolLicenciaUso>();
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_LISTAR");

                oPtuSolLicenciaUsoList = ConvertidorUtil.DeReaderAColeccion<PtuSolLicenciaUso, List<PtuSolLicenciaUso>>(dataReader);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAUSO_LISTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolLicenciaUsoList);
            }
            return oPtuSolLicenciaUsoList;
        }

        public override PtuSolLicenciaUso ListarPorId(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[2];
            try
            {
                DB2DataReader dataReader;                
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;
                arrParam[1] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
                arrParam[1].Value = pPtuSolLicenciaUso.intcoduso;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_LISTARKEY", arrParam);

                pPtuSolLicenciaUso = ConvertidorUtil.DeReaderAEntidad<PtuSolLicenciaUso>(dataReader);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAUSO_LISTARKEY");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), pPtuSolLicenciaUso);
            }
            return pPtuSolLicenciaUso;
        }

        public override List<PtuSolLicenciaUso> ListarPorSolicitud(int? intcodsolicitud)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;
                oPtuSolLicenciaUsoList = new List<PtuSolLicenciaUso>();

                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = intcodsolicitud;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_LISTARPORSOLICITUD", arrParam);

                oPtuSolLicenciaUsoList = ConvertidorUtil.DeReaderAColeccion<PtuSolLicenciaUso, List<PtuSolLicenciaUso>>(dataReader);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIAUSO_LISTARPORSOLICITUD");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolLicenciaUsoList);
            }
            return oPtuSolLicenciaUsoList;
        }

    }
}