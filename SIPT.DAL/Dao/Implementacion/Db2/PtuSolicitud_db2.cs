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

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class PtuSolicitud_db2: PtuSolicitud_dao
    {

        private List<PtuSolicitud> oPtuSolicitudList;
        private List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitante;
        private PtuSolicitud oPtuSolicitud;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolicitud_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;            
        }
        public override int Insertar(PtuSolicitud pPtuSolicitud)
        {
            DB2Parameter[] arrParam = new DB2Parameter[36];

            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Direction = ParameterDirection.Output;
            arrParam[1] = new DB2Parameter("@VCHAREAOFICINA", DB2Type.VarChar);
            arrParam[1].Value = pPtuSolicitud.vchareaoficina;
            arrParam[2] = new DB2Parameter("@CHRANIO", DB2Type.Char);
            arrParam[2].Value = pPtuSolicitud.chranio;
            arrParam[3] = new DB2Parameter("@VCHNUMERO", DB2Type.Char);
            arrParam[3].Value = pPtuSolicitud.vchnumero;
            arrParam[4] = new DB2Parameter("@SMLTIPOSOLICITUD", DB2Type.SmallInt);
            arrParam[4].Value = pPtuSolicitud.smltiposolicitud;
            arrParam[5] = new DB2Parameter("@SMLCONDICIONSOLICITUD", DB2Type.SmallInt);
            arrParam[5].Value = pPtuSolicitud.smlcondicionsolicitud;
            arrParam[6] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
            arrParam[6].Value = pPtuSolicitud.intcodigoprocedimiento;
            arrParam[7] = new DB2Parameter("@INTADMPROPIETARIO", DB2Type.Integer);
            arrParam[7].Value = pPtuSolicitud.intadmpropietario;
            arrParam[8] = new DB2Parameter("@VCHNUMORDENATENCION", DB2Type.VarChar);
            arrParam[8].Value = pPtuSolicitud.vchnumordenatencion;
            arrParam[9] = new DB2Parameter("@VCHNUMRUC", DB2Type.Char);
            arrParam[9].Value = pPtuSolicitud.vchnumruc;
            arrParam[10] = new DB2Parameter("@VCHNOMBRECOMERCIO", DB2Type.VarChar);
            arrParam[10].Value = pPtuSolicitud.vchnombrecomercio;
            arrParam[11] = new DB2Parameter("@INTCODREPRESENTANTELEGAL", DB2Type.Integer);
            arrParam[11].Value = pPtuSolicitud.intcodrepresentantelegal;
            arrParam[12] = new DB2Parameter("@VCHNOMREPRESENTANTELEGAL", DB2Type.VarChar);
            arrParam[12].Value = pPtuSolicitud.vchnomrepresentantelegal;
            arrParam[13] = new DB2Parameter("@VCHDOCUMENTOREPRELEGAL", DB2Type.VarChar);
            arrParam[13].Value = pPtuSolicitud.vchdocumentoreprelegal;
            arrParam[14] = new DB2Parameter("@VCHNROPARTIDASUNARPRLEGAL", DB2Type.VarChar);
            arrParam[14].Value = pPtuSolicitud.vchnropartidasunarprlegal;
            arrParam[15] = new DB2Parameter("@INTDOCCODIGOEXPEDIENTE", DB2Type.Integer);
            arrParam[15].Value = pPtuSolicitud.intdoccodigoexpediente;
            arrParam[16] = new DB2Parameter("@VCHNUMEXPEDIENTE", DB2Type.VarChar);
            arrParam[16].Value = pPtuSolicitud.vchnumexpediente;
            arrParam[17] = new DB2Parameter("@DATREGEXPEDIENTE", DB2Type.Date);
            arrParam[17].Value = pPtuSolicitud.datregexpediente;
            arrParam[18] = new DB2Parameter("@DATREGSOLICITUD", DB2Type.Date);
            arrParam[18].Value = pPtuSolicitud.datregsolicitud;
            arrParam[19] = new DB2Parameter("@DECCOSTO", DB2Type.Decimal);
            arrParam[19].Value = pPtuSolicitud.deccosto;
            arrParam[20] = new DB2Parameter("@VCHNUMERORECIBO", DB2Type.VarChar);
            arrParam[20].Value = pPtuSolicitud.vchnumerorecibo;
            arrParam[21] = new DB2Parameter("@INTCODIGOSOLICITANTE", DB2Type.Integer);
            arrParam[21].Value = pPtuSolicitud.intcodigosolicitante;
            arrParam[22] = new DB2Parameter("@VCHNOMBRESOLICITANTE", DB2Type.VarChar);
            arrParam[22].Value = pPtuSolicitud.vchnombresolicitante;
            arrParam[23] = new DB2Parameter("@VCHTIDCODIGOSOL", DB2Type.VarChar);
            arrParam[23].Value = pPtuSolicitud.vchtidcodigosol;
            arrParam[24] = new DB2Parameter("@VCHNRODOCUMENTOSOL", DB2Type.VarChar);
            arrParam[24].Value = pPtuSolicitud.vchnrodocumentosol;
            arrParam[25] = new DB2Parameter("@VCHNRORUCSOL", DB2Type.VarChar);
            arrParam[25].Value = pPtuSolicitud.vchnrorucsol;
            arrParam[26] = new DB2Parameter("@VCHNROTELEFONOSOL", DB2Type.VarChar);
            arrParam[26].Value = pPtuSolicitud.vchnrotelefonosol;
            arrParam[27] = new DB2Parameter("@VCHEMAILSOL", DB2Type.VarChar);
            arrParam[27].Value = pPtuSolicitud.vchemailsol;
            arrParam[28] = new DB2Parameter("@VCHDIRECCIONSOL", DB2Type.VarChar);
            arrParam[28].Value = pPtuSolicitud.vchdireccionsol;
            arrParam[29] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
            arrParam[29].Value = pPtuSolicitud.vchobservacion;
            arrParam[30] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
            arrParam[30].Value = pPtuSolicitud.vchaudusucreacion;
            arrParam[31] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
            arrParam[31].Value = pPtuSolicitud.tmsaudfeccreacion;
            arrParam[32] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
            arrParam[32].Value = pPtuSolicitud.vchaudusumodif;
            arrParam[33] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
            arrParam[33].Value = pPtuSolicitud.tmsaudfecmodif;
            arrParam[34] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
            arrParam[34].Value = pPtuSolicitud.vchaudequipo;
            arrParam[35] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
            arrParam[35].Value = pPtuSolicitud.vchaudprograma;
            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_INSERTAR", this.logMensajes, arrParam);

            return Convert.ToInt32(arrParam[0].Value);
        }

        public override PtuSolicitud Actualizar(PtuSolicitud pPtuSolicitud)
        {
            DB2Parameter[] arrParam = new DB2Parameter[36];            
          
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolicitud.intcodsolicitud;
            arrParam[1] = new DB2Parameter("@VCHAREAOFICINA", DB2Type.VarChar);
            arrParam[1].Value = pPtuSolicitud.vchareaoficina;
            arrParam[2] = new DB2Parameter("@CHRANIO", DB2Type.Char);
            arrParam[2].Value = pPtuSolicitud.chranio;
            arrParam[3] = new DB2Parameter("@VCHNUMERO", DB2Type.Char);
            arrParam[3].Value = pPtuSolicitud.vchnumero;
            arrParam[4] = new DB2Parameter("@SMLTIPOSOLICITUD", DB2Type.SmallInt);
            arrParam[4].Value = pPtuSolicitud.smltiposolicitud;
            arrParam[5] = new DB2Parameter("@SMLCONDICIONSOLICITUD", DB2Type.SmallInt);
            arrParam[5].Value = pPtuSolicitud.smlcondicionsolicitud;
            arrParam[6] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
            arrParam[6].Value = pPtuSolicitud.intcodigoprocedimiento;
            arrParam[7] = new DB2Parameter("@INTADMPROPIETARIO", DB2Type.Integer);
            arrParam[7].Value = pPtuSolicitud.intadmpropietario;
            arrParam[8] = new DB2Parameter("@VCHNUMORDENATENCION", DB2Type.VarChar);
            arrParam[8].Value = pPtuSolicitud.vchnumordenatencion;
            arrParam[9] = new DB2Parameter("@VCHNUMRUC", DB2Type.Char);
            arrParam[9].Value = pPtuSolicitud.vchnumruc;
            arrParam[10] = new DB2Parameter("@VCHNOMBRECOMERCIO", DB2Type.VarChar);
            arrParam[10].Value = pPtuSolicitud.vchnombrecomercio;
            arrParam[11] = new DB2Parameter("@INTCODREPRESENTANTELEGAL", DB2Type.Integer);
            arrParam[11].Value = pPtuSolicitud.intcodrepresentantelegal;
            arrParam[12] = new DB2Parameter("@VCHNOMREPRESENTANTELEGAL", DB2Type.VarChar);
            arrParam[12].Value = pPtuSolicitud.vchnomrepresentantelegal;
            arrParam[13] = new DB2Parameter("@VCHDOCUMENTOREPRELEGAL", DB2Type.VarChar);
            arrParam[13].Value = pPtuSolicitud.vchdocumentoreprelegal;
            arrParam[14] = new DB2Parameter("@VCHNROPARTIDASUNARPRLEGAL", DB2Type.VarChar);
            arrParam[14].Value = pPtuSolicitud.vchnropartidasunarprlegal;
            arrParam[15] = new DB2Parameter("@INTDOCCODIGOEXPEDIENTE", DB2Type.Integer);
            arrParam[15].Value = pPtuSolicitud.intdoccodigoexpediente;
            arrParam[16] = new DB2Parameter("@VCHNUMEXPEDIENTE", DB2Type.VarChar);
            arrParam[16].Value = pPtuSolicitud.vchnumexpediente;
            arrParam[17] = new DB2Parameter("@DATREGEXPEDIENTE", DB2Type.Date);
            arrParam[17].Value = pPtuSolicitud.datregexpediente;
            arrParam[18] = new DB2Parameter("@DATREGSOLICITUD", DB2Type.Date);
            arrParam[18].Value = pPtuSolicitud.datregsolicitud;
            arrParam[19] = new DB2Parameter("@DECCOSTO", DB2Type.Decimal);
            arrParam[19].Value = pPtuSolicitud.deccosto;
            arrParam[20] = new DB2Parameter("@VCHNUMERORECIBO", DB2Type.VarChar);
            arrParam[20].Value = pPtuSolicitud.vchnumerorecibo;
            arrParam[21] = new DB2Parameter("@INTCODIGOSOLICITANTE", DB2Type.Integer);
            arrParam[21].Value = pPtuSolicitud.intcodigosolicitante;
            arrParam[22] = new DB2Parameter("@VCHNOMBRESOLICITANTE", DB2Type.VarChar);
            arrParam[22].Value = pPtuSolicitud.vchnombresolicitante;
            arrParam[23] = new DB2Parameter("@VCHTIDCODIGOSOL", DB2Type.VarChar);
            arrParam[23].Value = pPtuSolicitud.vchtidcodigosol;
            arrParam[24] = new DB2Parameter("@VCHNRODOCUMENTOSOL", DB2Type.VarChar);
            arrParam[24].Value = pPtuSolicitud.vchnrodocumentosol;
            arrParam[25] = new DB2Parameter("@VCHNRORUCSOL", DB2Type.VarChar);
            arrParam[25].Value = pPtuSolicitud.vchnrorucsol;
            arrParam[26] = new DB2Parameter("@VCHNROTELEFONOSOL", DB2Type.VarChar);
            arrParam[26].Value = pPtuSolicitud.vchnrotelefonosol;
            arrParam[27] = new DB2Parameter("@VCHEMAILSOL", DB2Type.VarChar);
            arrParam[27].Value = pPtuSolicitud.vchemailsol;
            arrParam[28] = new DB2Parameter("@VCHDIRECCIONSOL", DB2Type.VarChar);
            arrParam[28].Value = pPtuSolicitud.vchdireccionsol;
            arrParam[29] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
            arrParam[29].Value = pPtuSolicitud.vchobservacion;
            arrParam[30] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
            arrParam[30].Value = pPtuSolicitud.vchaudusucreacion;
            arrParam[31] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
            arrParam[31].Value = pPtuSolicitud.tmsaudfeccreacion;
            arrParam[32] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
            arrParam[32].Value = pPtuSolicitud.vchaudusumodif;
            arrParam[33] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
            arrParam[33].Value = pPtuSolicitud.tmsaudfecmodif;
            arrParam[34] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
            arrParam[34].Value = pPtuSolicitud.vchaudequipo;
            arrParam[35] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
            arrParam[35].Value = pPtuSolicitud.vchaudprograma;

            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_ACTUALIZAR", this.logMensajes, arrParam);
           
            return pPtuSolicitud;
        }


        public override void Eliminar(PtuSolicitud pPtuSolicitud)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];            
            
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = pPtuSolicitud.intcodsolicitud;

            DB2Comando.Ejecutar((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_ELIMINAR", this.logMensajes, arrParam);           
        }

        public override List<PtuSolicitud> Listar()
        {
            oPtuSolicitudList = new List<PtuSolicitud>();
            return DB2Comando.Listar<PtuSolicitud>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_LISTAR", this.logMensajes);            
        }

        public override PtuSolicitud ListarPorId(int? intcodsolicitud)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            
            arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
            arrParam[0].Value = intcodsolicitud;

            return DB2Comando.Obtener<PtuSolicitud>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_LISTARKEY", this.logMensajes, arrParam);
        }

        public override List<PtuSolicitud_PorAnalistaPorSolicitante> ListarPorAnalistaPorSolicitante(int? intcodigosolicitante, int? intusuanalista)
        {
            DB2Parameter[] arrParam = new DB2Parameter[2];
            
            arrParam[0] = new DB2Parameter("@INTCODIGOSOLICITANTE", DB2Type.Integer);
            arrParam[0].Value = intcodigosolicitante;
            arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
            arrParam[1].Value = intusuanalista;

            return DB2Comando.Listar<PtuSolicitud_PorAnalistaPorSolicitante>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_LISTARPORANALISTAPORSOLICITANTE", this.logMensajes, arrParam);            
        }


        public override List<PtuSolicitud_PorAnalistaPorSolicitante> ListarPendientes(PtuSolicitud pPtuSolicitud, int? intusuanalista)
        {
            oPtuSolicitudList = new List<PtuSolicitud>();

            DB2Parameter[] arrParam = new DB2Parameter[2];

            arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
            arrParam[1].Value = intusuanalista;

            return DB2Comando.Listar<PtuSolicitud_PorAnalistaPorSolicitante>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_LISTAR_PENDIENTES", this.logMensajes, arrParam);            
        }


        public override List<PtuSolicitud_PorAnalistaPorSolicitante> ListarCalificar(PtuSolicitud pPtuSolicitud, int? intusuanalista)
        {            
            DB2Parameter[] arrParam = new DB2Parameter[2];

            arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
            arrParam[1].Value = intusuanalista;
                        
            return DB2Comando.Listar<PtuSolicitud_PorAnalistaPorSolicitante>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_LISTAR_CALIFICA", this.logMensajes, arrParam);
        }

        public override List<PtuSolicitud_PorAnalistaPorSolicitante> ListarAcreditar(PtuSolicitud pPtuSolicitud, int? intusuanalista)
        {
            oPtuSolicitudList = new List<PtuSolicitud>();

            DB2Parameter[] arrParam = new DB2Parameter[2];

            arrParam[1] = new DB2Parameter("@INTUSUANALISTA", DB2Type.Integer);
            arrParam[1].Value = intusuanalista;

            return DB2Comando.Listar<PtuSolicitud_PorAnalistaPorSolicitante>((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLICITUD_LISTAR_ACREDITAR", this.logMensajes, arrParam);           
        }


    }
}