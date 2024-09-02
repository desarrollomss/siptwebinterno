using DBAccess;
using DBAccess.Util;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using System;
using System.Data;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class ConContacto_db2: ConContacto_dao
    {
        private ConContacto oConContacto;
        private LogMensajes logMensajes;
        private Db dbconex;

        public ConContacto_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override ConContacto ListarPlataformaPorId(int intadmcodigo, string vchtipodato)
        {
            DB2Parameter[] arrParam = new DB2Parameter[2];
            try
            {
                DB2DataReader dataReader;

                arrParam[0] = new DB2Parameter("@INTADMCODIGO", DB2Type.Integer);
                arrParam[0].Value = intadmcodigo;
                arrParam[1] = new DB2Parameter("@VCHTICCODIGO", DB2Type.VarChar);
                arrParam[1].Value = vchtipodato;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.CONCONTACTO_LISTARPLATAFORMAPORID", arrParam);
                oConContacto = ConvertidorUtil.DeReaderAEntidad<ConContacto>(dataReader);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.CONCONTACTO_LISTARPLATAFORMAPORID");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oConContacto);
            }
            return oConContacto;
        }
    }
}
