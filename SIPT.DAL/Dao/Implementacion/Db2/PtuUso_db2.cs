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
    public class PtuUso_db2 : PtuUso_dao
    {
        private List<PtuUso> oPtuUsoList;
        private PtuUso oPtuUso;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuUso_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override void Insertar(PtuUso pPtuUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[21];
            try
            {                
                arrParam[0] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
                arrParam[0].Value = pPtuUso.intcoduso;
                arrParam[1] = new DB2Parameter("@VCHCODUSO", DB2Type.VarChar);
                arrParam[1].Value = pPtuUso.vchcoduso;
                arrParam[2] = new DB2Parameter("@VCHNOMBREUSO", DB2Type.VarChar);
                arrParam[2].Value = pPtuUso.vchnombreuso;
                arrParam[3] = new DB2Parameter("@CHRTIPO", DB2Type.Char);
                arrParam[3].Value = pPtuUso.chrtipo;
                arrParam[4] = new DB2Parameter("@SMLNIVEL", DB2Type.SmallInt);
                arrParam[4].Value = pPtuUso.smlnivel;
                arrParam[5] = new DB2Parameter("@INTCODUSOPADRE", DB2Type.Integer);
                arrParam[5].Value = pPtuUso.intcodusopadre;
                arrParam[6] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
                arrParam[6].Value = pPtuUso.smlestado;
                arrParam[7] = new DB2Parameter("@VCHCODGRUPO", DB2Type.VarChar);
                arrParam[7].Value = pPtuUso.vchcodgrupo;
                arrParam[8] = new DB2Parameter("@VCHNOMBREGRUPO", DB2Type.VarChar);
                arrParam[8].Value = pPtuUso.vchnombregrupo;
                arrParam[9] = new DB2Parameter("@VCHCODCATEGORIA1", DB2Type.VarChar);
                arrParam[9].Value = pPtuUso.vchcodcategoria1;
                arrParam[10] = new DB2Parameter("@VCHNOMBRECATEGORIA1", DB2Type.VarChar);
                arrParam[10].Value = pPtuUso.vchnombrecategoria1;
                arrParam[11] = new DB2Parameter("@VCHCODCATEGORIA2", DB2Type.VarChar);
                arrParam[11].Value = pPtuUso.vchcodcategoria2;
                arrParam[12] = new DB2Parameter("@VCHNOMBRECATEGORIA2", DB2Type.VarChar);
                arrParam[12].Value = pPtuUso.vchnombrecategoria2;
                arrParam[13] = new DB2Parameter("@VCHCODCATEGORIA3", DB2Type.VarChar);
                arrParam[13].Value = pPtuUso.vchcodcategoria3;
                arrParam[14] = new DB2Parameter("@VCHNOMBRECATEGORIA3", DB2Type.VarChar);
                arrParam[14].Value = pPtuUso.vchnombrecategoria3;
                arrParam[15] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[15].Value = pPtuUso.vchaudusucreacion;
                arrParam[16] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
                arrParam[16].Value = pPtuUso.tmsaudfeccreacion;
                arrParam[17] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[17].Value = pPtuUso.vchaudusumodif;
                arrParam[18] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[0].Value = pPtuUso.tmsaudfecmodif;
                arrParam[19] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[19].Value = pPtuUso.vchaudequipo;
                arrParam[20] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[20].Value = pPtuUso.vchaudprograma;
                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUUSO_INSERTAR", arrParam);
                
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_INSERTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_INSERTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                throw ex;
            }
        }

        public override void Actualizar(PtuUso pPtuUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[21];
            try
            {                
                arrParam[0] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
                arrParam[0].Value = pPtuUso.intcoduso;
                arrParam[1] = new DB2Parameter("@VCHCODUSO", DB2Type.VarChar);
                arrParam[1].Value = pPtuUso.vchcoduso;
                arrParam[2] = new DB2Parameter("@VCHNOMBREUSO", DB2Type.VarChar);
                arrParam[2].Value = pPtuUso.vchnombreuso;
                arrParam[3] = new DB2Parameter("@CHRTIPO", DB2Type.Char);
                arrParam[3].Value = pPtuUso.chrtipo;
                arrParam[4] = new DB2Parameter("@SMLNIVEL", DB2Type.SmallInt);
                arrParam[4].Value = pPtuUso.smlnivel;
                arrParam[5] = new DB2Parameter("@INTCODUSOPADRE", DB2Type.Integer);
                arrParam[5].Value = pPtuUso.intcodusopadre;
                arrParam[6] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
                arrParam[6].Value = pPtuUso.smlestado;
                arrParam[7] = new DB2Parameter("@VCHCODGRUPO", DB2Type.VarChar);
                arrParam[7].Value = pPtuUso.vchcodgrupo;
                arrParam[8] = new DB2Parameter("@VCHNOMBREGRUPO", DB2Type.VarChar);
                arrParam[8].Value = pPtuUso.vchnombregrupo;
                arrParam[9] = new DB2Parameter("@VCHCODCATEGORIA1", DB2Type.VarChar);
                arrParam[9].Value = pPtuUso.vchcodcategoria1;
                arrParam[10] = new DB2Parameter("@VCHNOMBRECATEGORIA1", DB2Type.VarChar);
                arrParam[10].Value = pPtuUso.vchnombrecategoria1;
                arrParam[11] = new DB2Parameter("@VCHCODCATEGORIA2", DB2Type.VarChar);
                arrParam[11].Value = pPtuUso.vchcodcategoria2;
                arrParam[12] = new DB2Parameter("@VCHNOMBRECATEGORIA2", DB2Type.VarChar);
                arrParam[12].Value = pPtuUso.vchnombrecategoria2;
                arrParam[13] = new DB2Parameter("@VCHCODCATEGORIA3", DB2Type.VarChar);
                arrParam[13].Value = pPtuUso.vchcodcategoria3;
                arrParam[14] = new DB2Parameter("@VCHNOMBRECATEGORIA3", DB2Type.VarChar);
                arrParam[14].Value = pPtuUso.vchnombrecategoria3;
                arrParam[15] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[15].Value = pPtuUso.vchaudusucreacion;
                arrParam[16] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
                arrParam[16].Value = pPtuUso.tmsaudfeccreacion;
                arrParam[17] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[17].Value = pPtuUso.vchaudusumodif;
                arrParam[18] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[0].Value = pPtuUso.tmsaudfecmodif;
                arrParam[19] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[19].Value = pPtuUso.vchaudequipo;
                arrParam[20] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[20].Value = pPtuUso.vchaudprograma;
                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUUSO_ACTUALIZAR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_ACTUALIZAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_ACTUALIZAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                throw ex;
            }
        }


        public override void Eliminar(PtuUso pPtuUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {                
                arrParam[0] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
                arrParam[0].Value = pPtuUso.intcoduso;
                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUUSO_ELIMINAR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_ELIMINAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_ELIMINAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                throw ex;
            }
        }

        public override List<PtuUso> Listar()
        {
            try
            {
                DB2DataReader dataReader;
                oPtuUsoList = new List<PtuUso>();
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUUSO_LISTAR");

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_LISTAR");
                
                oPtuUsoList = ConvertidorUtil.DeReaderAColeccion<PtuUso, List<PtuUso>>(dataReader);

                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuUsoList);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_LISTAR");

                throw ex;
            }
            return oPtuUsoList;
        }

        public override PtuUso ListarPorId(int? intcoduso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;
                
                arrParam[0] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
                arrParam[0].Value = intcoduso;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUUSO_LISTARKEY", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_LISTARKEY");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                oPtuUso = ConvertidorUtil.DeReaderAEntidad<PtuUso>(dataReader);

                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuUso);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_LISTARKEY");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                throw ex;
            }
            return oPtuUso;
        }



        public override List<PtuUso> ListarPorFiltro(PtuUso pPtuUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;
                
                arrParam[0] = new DB2Parameter("@VCHNOMBREUSO", DB2Type.VarChar);
                arrParam[0].Value = pPtuUso.vchnombreuso;

                //oPtuUsoList = new List<PtuUso>();
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUUSO_LISTARPORFILTRO", arrParam);
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_LISTARPORFILTRO");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                oPtuUsoList = ConvertidorUtil.DeReaderAColeccion<PtuUso, List<PtuUso>>(dataReader);

                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuUsoList);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUUSO_LISTARPORFILTRO");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                throw ex;
            }
            return oPtuUsoList;
        }

    }
}