using DBAccess;
using DBAccess.Util;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
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

            arrParam[0] = new DB2Parameter("@INTADMCODIGO", DB2Type.Integer);
            arrParam[0].Value = intadmcodigo;
            arrParam[1] = new DB2Parameter("@VCHTICCODIGO", DB2Type.VarChar);
            arrParam[1].Value = vchtipodato;

            return DB2Comando.Obtener<ConContacto>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.CONCONTACTO_LISTARPLATAFORMAPORID", this.logMensajes, arrParam);            
        }
    }
}
