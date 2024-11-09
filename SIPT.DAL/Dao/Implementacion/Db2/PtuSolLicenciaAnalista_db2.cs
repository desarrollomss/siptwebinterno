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
    public class PtuSolLicenciaAnalista_db2 : PtuSolLicenciaAnalista_dao
    {
        private List<PtuSolLicenciaAnalista> oPtuSolLicenciaAnalistaList;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolLicenciaAnalista_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override int Insertar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[8];

            arrParam[0] = new DB2Parameter("@INTCODSOLICITUDANALISTA", DB2Type.Integer);
            arrParam[0].Direction = ParameterDirection.Output;
            arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
            arrParam[1].Value = pPtuSolLicenciaAnalista.intusuanalista;
            arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[2].Value = pPtuSolLicenciaAnalista.intcodsolicitud;
            arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
            arrParam[3].Value = pPtuSolLicenciaAnalista.smlestado; // ? 1 : 0;
            arrParam[4] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
            arrParam[4].Value = this.logMensajes.Usuario;
            arrParam[5] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
            arrParam[5].Value = DateTime.Now;
            arrParam[6] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
            arrParam[6].Value = this.logMensajes.Equipo;
            arrParam[7] = new DB2Parameter("@VACHAUDPROGRAMA", DB2Type.VarChar);
            arrParam[7].Value = this.logMensajes.Programa;
            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAANALISTA_INSERTAR", this.logMensajes, arrParam);
           
            return Convert.ToInt32(arrParam[0].Value);
        }

        public override void Actualizar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[6];
          
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUDANALISTA", DB2Type.Integer);
            arrParam[0].Value = pPtuSolLicenciaAnalista.intcodsolicitudanalista;
            arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
            arrParam[1].Value = pPtuSolLicenciaAnalista.intusuanalista;
            arrParam[2] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[2].Value = pPtuSolLicenciaAnalista.intcodsolicitud;
            arrParam[3] = new DB2Parameter("@SMLESTADO", DB2Type.SmallInt);
            arrParam[3].Value = pPtuSolLicenciaAnalista.smlestado; // ? 1 : 0;
            arrParam[4] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
            arrParam[4].Value = this.logMensajes.Usuario;
            arrParam[5] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
            arrParam[5].Value = DateTime.Now;

            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAANALISTA_ACTUALIZAR", this.logMensajes, arrParam);
        }

        public override void Eliminar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];

            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolLicenciaAnalista.intcodsolicitud;

            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PtuSolLicenciaAnalista_ELIMINAR", this.logMensajes, arrParam);
        }

        public override List<PtuSolLicenciaAnalista> Listar()
        {
            return DB2Comando.Listar<PtuSolLicenciaAnalista>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PtuSolLicenciaAnalista_LISTAR", this.logMensajes);
        }

        public override PtuSolLicenciaAnalista ListarPorId(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[2];
           
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolLicenciaAnalista.intcodsolicitud;

            return DB2Comando.Obtener<PtuSolLicenciaAnalista>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PtuSolLicenciaAnalista_LISTARKEY", this.logMensajes, arrParam);
        }

    }
}