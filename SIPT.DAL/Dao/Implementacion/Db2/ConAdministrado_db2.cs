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
    public class ConAdministrado_db2 : ConAdministrado_dao
    {

        private List<ConAdministrado> oConAdministradoList;
        private ConAdministrado oConAdministrado;
        private LogMensajes logMensajes;
        private Db dbconex;

        public ConAdministrado_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override List<ConAdministrado> ListarPorFiltro(ConAdministrado pConAdministrado)
        {
            try
            {
                DB2DataReader dataReader;

                DB2Parameter[] arrParam = new DB2Parameter[1];
                arrParam[0] = new DB2Parameter("@VCHADMCOMPLETO", DB2Type.VarChar);
                arrParam[0].Value = pConAdministrado.vchadmcompleto;

                oConAdministradoList = new List<ConAdministrado>();
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.CONADMINISTRADO_LISTARPORFILTRO", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.CONADMINISTRADO_LISTARPORFILTRO");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                oConAdministradoList = ConvertidorUtil.DeReaderAColeccion<ConAdministrado, List<ConAdministrado>>(dataReader);

                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oConAdministradoList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oConAdministradoList;
        }

        public override ConAdministrado ListarplataformaPorId(int? intadmcodigo)
        {
            try
            {
                DB2DataReader dataReader;

                DB2Parameter[] arrParam = new DB2Parameter[1];
                arrParam[0] = new DB2Parameter("@INTADMCODIGO", DB2Type.Integer);
                arrParam[0].Value = intadmcodigo;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.CONADMINISTRADO_LISTARPLATAFORMAPORID", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.CONADMINISTRADO_LISTARPLATAFORMAPORID");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                oConAdministrado = ConvertidorUtil.DeReaderAEntidad<ConAdministrado>(dataReader);                

                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oConAdministrado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oConAdministrado;
        }

    }
}