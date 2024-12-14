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

        public override List<PtuUbicaciones> ListarPorFiltro(PtuUbicaciones pPtuUbicaciones, Int32 esNumero)
        {
            DB2Parameter[] arrParam = new DB2Parameter[2];

            arrParam[0] = new DB2Parameter("@VCHUBIPRE", DB2Type.VarChar);
            arrParam[0].Value = pPtuUbicaciones.vchubipre;
            arrParam[1] = new DB2Parameter("@SMLESNUMERO", DB2Type.SmallInt);
            arrParam[1].Value = esNumero;

            return DB2Comando.Listar<PtuUbicaciones>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.DJUPREDIO_LISTARPORFILTRO", this.logMensajes, arrParam);
        }

    }
}
