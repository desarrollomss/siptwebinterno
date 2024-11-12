using System;
using System.Data;
using IBM.Data.DB2;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;
using DBAccess;
using SIPT.APPL.Logs;
using DBAccess.Util;
using System.Collections.Generic;
using SIPT.BL.Models.Consultas;
using SIPT.DAL.Dao.Factory;
using System.Data.Common;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class PtuUbicaciones_db2 : PtuUbicaciones_dao
    {
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuUbicaciones_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }
        public override List<PtuUbicaciones> ListarPorFiltro(PtuUbicaciones pPtuUbicaciones)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
                           
            arrParam[0] = new DB2Parameter("@VCHUBIPRE", DB2Type.VarChar);
            arrParam[0].Value = pPtuUbicaciones.vchubipre;
            return DB2Comando.Listar<PtuUbicaciones>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUPREDIO_LISTARPORFILTRO", this.logMensajes, arrParam);
        }

        public override List<PtuRequerimiento_Editables> ListarEditables(int intsolicitudplantilla)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
           
            arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
            arrParam[0].Value = intsolicitudplantilla;
            return DB2Comando.Listar<PtuRequerimiento_Editables>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_LISTAREDITABLES", this.logMensajes, arrParam);
        }

        public override List<PtuPlantillareqvalores> ListarValores(int intsolicitudplantilla)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
           
            arrParam[0] = new DB2Parameter("@INTSOLICITUDPLANTILLA", DB2Type.Integer);
            arrParam[0].Value = intsolicitudplantilla;
            return DB2Comando.Listar<PtuPlantillareqvalores>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQDETALLE_LISTARVALORES", this.logMensajes, arrParam);

        }

        public override void EjecutarScript(string query)
        {
            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.Text, query, this.logMensajes);
               
        }
                
        public override DataTable EjecutarScriptDataTable(string query)
        {
            DataSet oDS = DB2Comando.DataSet((DB2Transaction)this.dbconex.Transaccion(), CommandType.Text, query, this.logMensajes);
            
            return oDS.Tables[0];
            //return DB2Comando.Reader((DB2Transaction)this.dbconex.Transaccion(), CommandType.Text, query, this.logMensajes);

        }

    }
}