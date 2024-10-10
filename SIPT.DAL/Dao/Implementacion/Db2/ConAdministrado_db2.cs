using System;
using System.Data;
using IBM.Data.DB2;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;
using DBAccess;
using SIPT.APPL.Logs;
using DBAccess.Util;
using System.Collections.Generic;
using SIPT.DAL.Dao.Factory;

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
            DB2Parameter[] arrParam = new DB2Parameter[1];
            arrParam[0] = new DB2Parameter("@VCHADMCOMPLETO", DB2Type.VarChar);
            arrParam[0].Value = pConAdministrado.vchadmcompleto;

            oConAdministradoList = new List<ConAdministrado>();
            return DB2Comando.Listar<ConAdministrado>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.CONADMINISTRADO_LISTARPORFILTRO", this.logMensajes, arrParam);
        }

        public override ConAdministrado ListarplataformaPorId(int? intadmcodigo)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            arrParam[0] = new DB2Parameter("@INTADMCODIGO", DB2Type.Integer);
            arrParam[0].Value = intadmcodigo;

            return DB2Comando.Obtener<ConAdministrado>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.CONADMINISTRADO_LISTARPLATAFORMAPORID", this.logMensajes, arrParam);
        }

    }
}