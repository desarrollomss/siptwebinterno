using DBAccess;
using DBAccess.Util;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class DjuPredio_db2: DjuPredio_dao
    {
        private DjuPredio oDjuPredio;
        private LogMensajes logMensajes;
        private Db dbconex;

        public DjuPredio_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override DjuPredio ListarPorId(int? intprecodigo)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;
                
                arrParam[0] = new DB2Parameter("@INTPRECODIGO", DB2Type.Integer);
                arrParam[0].Value = intprecodigo;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.DJUPREDIO_LISTARKEY", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.DJUPREDIO_LISTARKEY");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                oDjuPredio = ConvertidorUtil.DeReaderAEntidad<DjuPredio>(dataReader);

                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oDjuPredio);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), "SIPT.DJUPREDIO_LISTARKEY");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

                throw ex;
            }
            return oDjuPredio;
        }
    }
}
