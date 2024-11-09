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
    public class PtuSolLicenciaUso_db2: PtuSolLicenciaUso_dao
    {
        private List<PtuSolLicenciaUso> oPtuSolLicenciaUsoList;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolLicenciaUso_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override void Insertar(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[10];
           
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;
            arrParam[1] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
            arrParam[1].Value = pPtuSolLicenciaUso.intcoduso;
            arrParam[2] = new DB2Parameter("@SMLUSOPRINCIPAL", DB2Type.SmallInt);
            arrParam[2].Value = pPtuSolLicenciaUso.smlusoprincipal; // ? 1 : 0;
            arrParam[3] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
            arrParam[3].Value = this.logMensajes.Usuario;
            arrParam[4] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
            arrParam[4].Value = DateTime.Now;
            arrParam[5] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
            arrParam[5].Value = DBNull.Value;
            arrParam[6] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
            arrParam[6].Value = DBNull.Value;
            arrParam[7] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
            arrParam[7].Value = this.logMensajes.Equipo;
            arrParam[8] = new DB2Parameter("@VACHAUDPROGRAMA", DB2Type.VarChar);
            arrParam[8].Value = this.logMensajes.Programa;
            arrParam[9] = new DB2Parameter("@VCHCODUSO", DB2Type.VarChar);
            arrParam[9].Value = pPtuSolLicenciaUso.vchcoduso;

            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_INSERTAR", this.logMensajes, arrParam);
        }

        public override void Actualizar(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[10];
                       
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;
            arrParam[1] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
            arrParam[1].Value = pPtuSolLicenciaUso.intcoduso;
            arrParam[2] = new DB2Parameter("@SMLUSOPRINCIPAL", DB2Type.SmallInt);
            arrParam[2].Value = pPtuSolLicenciaUso.smlusoprincipal;
            arrParam[3] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
            arrParam[3].Value = DBNull.Value;
            arrParam[4] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
            arrParam[4].Value = DBNull.Value;
            arrParam[5] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
            arrParam[5].Value = this.logMensajes.Usuario;
            arrParam[6] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
            arrParam[6].Value = DateTime.Now;
            arrParam[7] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
            arrParam[7].Value = this.logMensajes.Equipo;
            arrParam[8] = new DB2Parameter("@VACHAUDPROGRAMA", DB2Type.VarChar);
            arrParam[8].Value = this.logMensajes.Programa;
            arrParam[9] = new DB2Parameter("@VCHCODUSO", DB2Type.VarChar);
            arrParam[9].Value = pPtuSolLicenciaUso.vchcoduso;

            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_ACTUALIZAR", this.logMensajes, arrParam);
        }
       
        public override void Eliminar(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
                       
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;

            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_ELIMINAR", this.logMensajes, arrParam);
        }

        public override List<PtuSolLicenciaUso> Listar()
        {
            oPtuSolLicenciaUsoList = new List<PtuSolLicenciaUso>();
            return DB2Comando.Listar<PtuSolLicenciaUso>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_LISTAR", this.logMensajes);
        }

        public override PtuSolLicenciaUso ListarPorId(PtuSolLicenciaUso pPtuSolLicenciaUso)
        {
            DB2Parameter[] arrParam = new DB2Parameter[2];
                
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolLicenciaUso.intcodsolicitud;
            arrParam[1] = new DB2Parameter("@INTCODUSO", DB2Type.Integer);
            arrParam[1].Value = pPtuSolLicenciaUso.intcoduso;

            return DB2Comando.Obtener<PtuSolLicenciaUso>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_LISTARKEY", this.logMensajes, arrParam);

        }

        public override List<PtuSolLicenciaUso> ListarPorSolicitud(int? intcodsolicitud)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];            

            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = intcodsolicitud;

            return DB2Comando.Listar<PtuSolLicenciaUso>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIAUSO_LISTARPORSOLICITUD", this.logMensajes, arrParam);

        }

    }
}