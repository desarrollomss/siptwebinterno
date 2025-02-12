using DBAccess;
using DBAccess.Util;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Consultas;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;
using System.Data;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class StdDocumento_db2 : StdDocumento_dao
    {
        private List<StdDocumento_InsertaResultado> stdDocumento_InsertaResultado;        
        private LogMensajes logMensajes;
        private Db dbconex;

        public StdDocumento_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override List<StdDocumento_InsertaResultado> Insertar(StdDocumento_InsertaDocWebSipt stdDocumento_InsertaDocWebSipt)
        {
            DB2Parameter[] arrParam = new DB2Parameter[15];
            
            arrParam[0] = new DB2Parameter("@INTADMCODIGO", DB2Type.Integer);
            arrParam[0].Value = stdDocumento_InsertaDocWebSipt.intadmcodigo;
            arrParam[1] = new DB2Parameter("@INTTIPDOCCODIGO", DB2Type.Integer);
            arrParam[1].Value = stdDocumento_InsertaDocWebSipt.inttipdoccodigo;
            arrParam[2] = new DB2Parameter("@INTTIPPROCODIGO", DB2Type.Integer);
            arrParam[2].Value = stdDocumento_InsertaDocWebSipt.inttipprocodigo;
            arrParam[3] = new DB2Parameter("@VCHOFICODIGO", DB2Type.VarChar);
            arrParam[3].Value = stdDocumento_InsertaDocWebSipt.vchoficodigo;
            arrParam[4] = new DB2Parameter("@INTTUPCODIGO", DB2Type.Integer);
            arrParam[4].Value = stdDocumento_InsertaDocWebSipt.inttupcodigo;
            arrParam[5] = new DB2Parameter("@INTPROCODIGO", DB2Type.Integer);
            arrParam[5].Value = stdDocumento_InsertaDocWebSipt.intprocodigo;
            arrParam[6] = new DB2Parameter("@INTASUCODIGO", DB2Type.Integer);
            arrParam[6].Value = stdDocumento_InsertaDocWebSipt.intasucodigo;
            arrParam[7] = new DB2Parameter("@VCHDOCASUNTO", DB2Type.VarChar);
            arrParam[7].Value = stdDocumento_InsertaDocWebSipt.vchdocasunto;
            arrParam[8] = new DB2Parameter("@INTDOCFOLIO", DB2Type.Integer);
            arrParam[8].Value = stdDocumento_InsertaDocWebSipt.intdocfolio;
            arrParam[9] = new DB2Parameter("@INTPRECODIGO", DB2Type.Integer);
            arrParam[9].Value = stdDocumento_InsertaDocWebSipt.intprecodigo;
            arrParam[10] = new DB2Parameter("@VCHDOCOBSERVACION", DB2Type.VarChar);
            arrParam[10].Value = stdDocumento_InsertaDocWebSipt.vchdocobservacion;
            arrParam[11] = new DB2Parameter("@INTRECNUMBER", DB2Type.Integer);
            arrParam[11].Value = stdDocumento_InsertaDocWebSipt.intrecnumber;
            arrParam[12] = new DB2Parameter("@VCHAUDEQUIPOCREACION", DB2Type.VarChar);
            arrParam[12].Value = this.logMensajes.Equipo;
            arrParam[13] = new DB2Parameter("@PVCHUNIORGREMCODIGO", DB2Type.VarChar);
            arrParam[13].Value = stdDocumento_InsertaDocWebSipt.pvchuniorgremcodigo;
            arrParam[14] = new DB2Parameter("@PVCHUNIORGRECCODIGO", DB2Type.VarChar);
            arrParam[14].Value = stdDocumento_InsertaDocWebSipt.pvchuniorgreccodigo;

            return DB2Comando.Listar<StdDocumento_InsertaResultado>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.SISDOC_INSERTA_DOCWEBSIPT", this.logMensajes, arrParam);
                
        }

    }
}
