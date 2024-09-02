using DBAccess;
using DBAccess.Util;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Consultas;
using SIPT.DAL.Dao.Base;
using System;
using System.Collections.Generic;
using System.Data;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class AutSolicitud_db2 : AutSolicitud_dao
    {
        private List<AutSolicitud_Resultado> autSolicitud_Resultado;
        private LogMensajes logMensajes;
        private Db dbconex;

        public AutSolicitud_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override List<AutSolicitud_Resultado> Insertar(AutSolicitud_Inserta autSolicitud_Inserta)
        {
            DB2Parameter[] arrParam = new DB2Parameter[10];
            try
            {
                DB2DataReader dataReader;

                arrParam[0] = new DB2Parameter("P_SMLTIPAUTCODIGO", DB2Type.SmallInt);
                arrParam[0].Value = autSolicitud_Inserta.p_smltipautcodigo;
                arrParam[1] = new DB2Parameter("P_INTPRECODIGO", DB2Type.Integer);
                arrParam[1].Value = autSolicitud_Inserta.p_intprecodigo;
                arrParam[2] = new DB2Parameter("P_INTADMCODIGO", DB2Type.Integer);
                arrParam[2].Value = autSolicitud_Inserta.p_intadmcodigo;
                arrParam[3] = new DB2Parameter("P_DECSLICAREOCUP", DB2Type.Decimal);
                arrParam[3].Value = autSolicitud_Inserta.p_decslicareocup;
                arrParam[4] = new DB2Parameter("P_SMLCODTABLA", DB2Type.SmallInt);
                arrParam[4].Value = autSolicitud_Inserta.p_smlcodtabla;
                arrParam[5] = new DB2Parameter("P_INTDOCCODIGO", DB2Type.Integer);
                arrParam[5].Value = autSolicitud_Inserta.p_intdoccodigo;
                arrParam[6] = new DB2Parameter("P_INTCODSOLICITUD", DB2Type.Integer);
                arrParam[6].Value = autSolicitud_Inserta.p_intcodsolicitud;
                arrParam[7] = new DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[7].Value = autSolicitud_Inserta.p_vchaudusucreacion;
                arrParam[8] = new DB2Parameter("P_VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[8].Value = autSolicitud_Inserta.p_vchaudequipo;
                arrParam[9] = new DB2Parameter("P_VCHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[9].Value = autSolicitud_Inserta.p_vchaudprograma;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "DBSAC.AUTSOLICITUD_CABECERA_INSERTAR", arrParam);
                autSolicitud_Resultado = ConvertidorUtil.DeReaderAColeccion<AutSolicitud_Resultado, List<AutSolicitud_Resultado>>(dataReader);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "DBSAC.AUTSOLICITUD_CABECERA_INSERTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), autSolicitud_Resultado);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "DBSAC.AUTSOLICITUD_CABECERA_INSERTAR : " + ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
            return autSolicitud_Resultado;
        }

    }
}
