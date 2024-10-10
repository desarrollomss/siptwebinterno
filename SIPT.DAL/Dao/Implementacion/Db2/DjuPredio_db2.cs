using DBAccess;
using DBAccess.Util;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
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
          
            arrParam[0] = new DB2Parameter("@INTPRECODIGO", DB2Type.Integer);
            arrParam[0].Value = intprecodigo;

            return DB2Comando.Obtener<DjuPredio>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.DJUPREDIO_LISTARKEY", this.logMensajes, arrParam);
        }
    }
}
