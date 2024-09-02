using System;
using System.Data;
using IBM.Data.DB2;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;
using DBAccess;
using SIPT.APPL.Logs;
using DBAccess.Util;
using System.Collections.Generic;
using SIPT.BL.Models.Consultas;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class PtuUbicaciones_db2 : PtuUbicaciones_dao
    {
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuUbicaciones_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }
        public override List<PtuUbicaciones> ListarPorFiltro(PtuUbicaciones pPtuUbicaciones)
        {
            List<PtuUbicaciones> oPtuUbicacionesList=null;
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;                
                arrParam[0] = new DB2Parameter("@VCHUBIPRE", DB2Type.VarChar);
                arrParam[0].Value = pPtuUbicaciones.vchubipre;
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPREDIO_LISTARPORFILTRO", arrParam);

                oPtuUbicacionesList = ConvertidorUtil.DeReaderAColeccion<PtuUbicaciones, List<PtuUbicaciones>>(dataReader);
                
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUPREDIO_LISTARPORFILTRO");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuUbicacionesList);
            }
            return oPtuUbicacionesList;
        }

        public override List<PtuRequerimiento_Editables> ListarEditables(int intsolicitudplantilla)
        {
            List<PtuRequerimiento_Editables> oPtuRequerimiento_EditablesList = null;
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;
                arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
                arrParam[0].Value = intsolicitudplantilla;
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_LISTAREDITABLES", arrParam);

                oPtuRequerimiento_EditablesList = ConvertidorUtil.DeReaderAColeccion<PtuRequerimiento_Editables, List<PtuRequerimiento_Editables>>(dataReader);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_LISTAREDITABLES");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuRequerimiento_EditablesList);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_LISTAREDITABLES : "+ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
            return oPtuRequerimiento_EditablesList;
        }

        public override List<PtuPlantillareqvalores> ListarValores(int intsolicitudplantilla)
        {
            List<PtuPlantillareqvalores> oPtuPlantillareqvaloresList = null;
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;
                arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
                arrParam[0].Value = intsolicitudplantilla;
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_LISTARVALORES", arrParam);

                oPtuPlantillareqvaloresList = ConvertidorUtil.DeReaderAColeccion<PtuPlantillareqvalores, List<PtuPlantillareqvalores>>(dataReader);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_LISTARVALORES");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuPlantillareqvaloresList);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQDETALLE_LISTARVALORES : " + ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
            return oPtuPlantillareqvaloresList;
        }

        public override void EjecutarScript(string query)
        {
            try
            {
                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.Text, query);
                Log.Info(this.logMensajes.codigoMensaje.ToString(), query);                                

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), query + " : " + ex.Message);                
                throw ex;
            }
        }

    }
}