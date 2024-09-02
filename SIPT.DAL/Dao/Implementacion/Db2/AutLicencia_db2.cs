﻿using DBAccess;
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
    public class AutLicencia_db2: AutLicencia_dao
    {
        private List<AutLicencia_Resultado> autLiciencia_Resutado;
        private LogMensajes logMensajes;
        private Db dbconex;

        public AutLicencia_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override List<AutLicencia_Resultado> Insertar(AutLicencia_Inserta autLiciencia_Inserta)
        {
            DB2Parameter[] arrParam = new DB2Parameter[4];
            try
            {
                DB2DataReader dataReader;

                arrParam[0] = new DB2Parameter("P_CHRSOLANIO", DB2Type.Char);
                arrParam[0].Value = autLiciencia_Inserta.p_chrsolanio;
                arrParam[1] = new DB2Parameter("P_VCHSOLNUMERO", DB2Type.VarChar);
                arrParam[1].Value = autLiciencia_Inserta.p_vchsolnumero;
                arrParam[2] = new DB2Parameter("P_DATLICFECCREACION", DB2Type.Date);
                arrParam[2].Value = autLiciencia_Inserta.p_datlicfeccreacion;
                arrParam[3] = new DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[3].Value = autLiciencia_Inserta.p_vchaudusucreacion;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "DBSAC.AUTLICENCIA_CABECERA_INSERTAR", arrParam);
                autLiciencia_Resutado = ConvertidorUtil.DeReaderAColeccion<AutLicencia_Resultado, List<AutLicencia_Resultado>>(dataReader);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "DBSAC.AUTLICENCIA_CABECERA_INSERTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), autLiciencia_Resutado);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "DBSAC.AUTLICENCIA_CABECERA_INSERTAR : " + ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
            return autLiciencia_Resutado;
        }
    }
}