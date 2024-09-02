using System;
using System.Data;
using IBM.Data.DB2;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;
using DBAccess;
using SIPT.APPL.Logs;
using DBAccess.Util;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class PtuSolLicencia_db2: PtuSolLicencia_dao
    {
        private List<PtuSolLicencia> oPtuSolLicenciaList;
        private PtuSolLicencia oPtuSolLicencia;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolLicencia_db2(ref LogMensajes logMensajes, ref Db dbconex)
        {
            this.logMensajes = logMensajes;
            this.dbconex = dbconex;
        }

        public override void Insertar(PtuSolLicencia pPtuSollicencia)
        {
            DB2Parameter[] arrParam = new DB2Parameter[38];

            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSollicencia.intcodsolicitud;
                arrParam[1] = new DB2Parameter("@DECAREAOCUPAR", DB2Type.Decimal);
                arrParam[1].Value = pPtuSollicencia.decareaocupar;
                arrParam[2] = new DB2Parameter("@SMLCONDICIONSOLICITANTE", DB2Type.SmallInt);
                arrParam[2].Value = pPtuSollicencia.smlcondicionsolicitante;
                arrParam[3] = new DB2Parameter("@INTCODIGOPREDIO", DB2Type.Integer);
                arrParam[3].Value = pPtuSollicencia.intcodigopredio;
                arrParam[4] = new DB2Parameter("@INTNUMPREDIO", DB2Type.Integer);
                arrParam[4].Value = pPtuSollicencia.intnumpredio;
                arrParam[5] = new DB2Parameter("@CHRCODLOTECATASTRAL", DB2Type.Char);
                arrParam[5].Value = pPtuSollicencia.chrcodlotecatastral;
                arrParam[6] = new DB2Parameter("@VCHDIRECCIONPREDIO", DB2Type.VarChar);
                arrParam[6].Value = pPtuSollicencia.vchdireccionpredio;
                arrParam[7] = new DB2Parameter("@VCHLOCALIDAD", DB2Type.VarChar);
                arrParam[7].Value = pPtuSollicencia.vchlocalidad;
                arrParam[8] = new DB2Parameter("@VCHDISCODIGO", DB2Type.VarChar);
                arrParam[8].Value = pPtuSollicencia.vchdiscodigo;
                arrParam[9] = new DB2Parameter("@VCHNOMDISTRITO", DB2Type.VarChar);
                arrParam[9].Value = pPtuSollicencia.vchnomdistrito;
                arrParam[10] = new DB2Parameter("@VCHNOMPROVINCIA", DB2Type.VarChar);
                arrParam[10].Value = pPtuSollicencia.vchnomprovincia;
                arrParam[11] = new DB2Parameter("@VCHDEPARTAMENTO", DB2Type.VarChar);
                arrParam[11].Value = pPtuSollicencia.vchdepartamento;
                arrParam[12] = new DB2Parameter("@DATVIGENCIAINI", DB2Type.Date);
                arrParam[12].Value = pPtuSollicencia.datvigenciaini;
                arrParam[13] = new DB2Parameter("@DATVIGENCIAFIN", DB2Type.Date);
                arrParam[13].Value = pPtuSollicencia.datvigenciafin;
                arrParam[14] = new DB2Parameter("@INTNUMTRABAJADORES", DB2Type.Integer);
                arrParam[14].Value = pPtuSollicencia.intnumtrabajadores;
                arrParam[15] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
                arrParam[15].Value = pPtuSollicencia.vchobservacion;
                arrParam[16] = new DB2Parameter("@VCHNUMCOLEGIO", DB2Type.VarChar);
                arrParam[16].Value = pPtuSollicencia.vchnumcolegio;
                arrParam[17] = new DB2Parameter("@SMLREQUIEREINSPEC", DB2Type.SmallInt);
                arrParam[17].Value = pPtuSollicencia.smlrequiereinspec;
                arrParam[18] = new DB2Parameter("@INTNUMESTACIONAMIENTOS", DB2Type.Integer);
                arrParam[18].Value = pPtuSollicencia.intnumestacionamientos;
                arrParam[19] = new DB2Parameter("@VCHTIPOEMPRESA", DB2Type.VarChar);
                arrParam[19].Value = pPtuSollicencia.vchtipoempresa;
                arrParam[20] = new DB2Parameter("@VCHZONIFICACION", DB2Type.VarChar);
                arrParam[20].Value = pPtuSollicencia.vchzonificacion;
                arrParam[21] = new DB2Parameter("@VCHCONCLUSION", DB2Type.VarChar);
                arrParam[21].Value = pPtuSollicencia.vchconclusion;
                arrParam[22] = new DB2Parameter("@VCHNUMLICENCIACONSTR", DB2Type.VarChar);
                arrParam[22].Value = pPtuSollicencia.vchnumlicenciaconstr;
                arrParam[23] = new DB2Parameter("@VCHNUMDECLFABRICA", DB2Type.VarChar);
                arrParam[23].Value = pPtuSollicencia.vchnumdeclfabrica;
                arrParam[24] = new DB2Parameter("@VCHCESENUMEROLIC", DB2Type.VarChar);
                arrParam[24].Value = pPtuSollicencia.vchcesenumerolic;
                arrParam[25] = new DB2Parameter("@CHRCESEANIOLIC", DB2Type.VarChar);
                arrParam[25].Value = pPtuSollicencia.chrceseaniolic;
                arrParam[26] = new DB2Parameter("@VCHCESEEXPENUMERO", DB2Type.VarChar);
                arrParam[26].Value = pPtuSollicencia.vchceseexpenumero;
                arrParam[27] = new DB2Parameter("@DATCESEEXPEFECHA", DB2Type.Date);
                arrParam[27].Value = pPtuSollicencia.datceseexpefecha;
                arrParam[28] = new DB2Parameter("@SMLCESECODMOTIVO", DB2Type.SmallInt);
                arrParam[28].Value = pPtuSollicencia.smlcesecodmotivo;                
                arrParam[29] = new DB2Parameter("@SMLESTSOLLICENCIA", DB2Type.SmallInt);
                arrParam[29].Value = pPtuSollicencia.smlestsollicencia;
                arrParam[30] = new DB2Parameter("@SMLRESULTADO", DB2Type.SmallInt);
                arrParam[30].Value = pPtuSollicencia.smlresultado;
                arrParam[31] = new DB2Parameter("@SMLESTLICENCIA", DB2Type.SmallInt);
                arrParam[31].Value = pPtuSollicencia.smlestlicencia;                
                arrParam[32] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[32].Value = pPtuSollicencia.vchaudusucreacion;
                arrParam[33] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
                arrParam[33].Value = pPtuSollicencia.tmsaudfeccreacion;
                arrParam[34] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[34].Value = pPtuSollicencia.vchaudusumodif;
                arrParam[35] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[35].Value = pPtuSollicencia.tmsaudfecmodif;
                arrParam[36] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[36].Value = pPtuSollicencia.vchaudequipo;
                arrParam[37] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[37].Value = pPtuSollicencia.vchaudprograma;
                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_INSERTAR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_INSERTAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_INSERTAR : " + ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
        }

        public override void Actualizar(PtuSolLicencia pPtuSollicencia)
        {
            DB2Parameter[] arrParam = new DB2Parameter[38];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSollicencia.intcodsolicitud;
                arrParam[1] = new DB2Parameter("@DECAREAOCUPAR", DB2Type.Decimal);
                arrParam[1].Value = pPtuSollicencia.decareaocupar;
                arrParam[2] = new DB2Parameter("@SMLCONDICIONSOLICITANTE", DB2Type.SmallInt);
                arrParam[2].Value = pPtuSollicencia.smlcondicionsolicitante;
                arrParam[3] = new DB2Parameter("@INTCODIGOPREDIO", DB2Type.Integer);
                arrParam[3].Value = pPtuSollicencia.intcodigopredio;
                arrParam[4] = new DB2Parameter("@INTNUMPREDIO", DB2Type.Integer);
                arrParam[4].Value = pPtuSollicencia.intnumpredio;
                arrParam[5] = new DB2Parameter("@CHRCODLOTECATASTRAL", DB2Type.Char);
                arrParam[5].Value = pPtuSollicencia.chrcodlotecatastral;
                arrParam[6] = new DB2Parameter("@VCHDIRECCIONPREDIO", DB2Type.VarChar);
                arrParam[6].Value = pPtuSollicencia.vchdireccionpredio;
                arrParam[7] = new DB2Parameter("@VCHLOCALIDAD", DB2Type.VarChar);
                arrParam[7].Value = pPtuSollicencia.vchlocalidad;
                arrParam[8] = new DB2Parameter("@VCHDISCODIGO", DB2Type.VarChar);
                arrParam[8].Value = pPtuSollicencia.vchdiscodigo;
                arrParam[9] = new DB2Parameter("@VCHNOMDISTRITO", DB2Type.VarChar);
                arrParam[9].Value = pPtuSollicencia.vchnomdistrito;
                arrParam[10] = new DB2Parameter("@VCHNOMPROVINCIA", DB2Type.VarChar);
                arrParam[10].Value = pPtuSollicencia.vchnomprovincia;
                arrParam[11] = new DB2Parameter("@VCHDEPARTAMENTO", DB2Type.VarChar);
                arrParam[11].Value = pPtuSollicencia.vchdepartamento;
                arrParam[12] = new DB2Parameter("@DATVIGENCIAINI", DB2Type.Date);
                arrParam[12].Value = pPtuSollicencia.datvigenciaini;
                arrParam[13] = new DB2Parameter("@DATVIGENCIAFIN", DB2Type.Date);
                arrParam[13].Value = pPtuSollicencia.datvigenciafin;
                arrParam[14] = new DB2Parameter("@INTNUMTRABAJADORES", DB2Type.Integer);
                arrParam[14].Value = pPtuSollicencia.intnumtrabajadores;
                arrParam[15] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
                arrParam[15].Value = pPtuSollicencia.vchobservacion;
                arrParam[16] = new DB2Parameter("@VCHNUMCOLEGIO", DB2Type.VarChar);
                arrParam[16].Value = pPtuSollicencia.vchnumcolegio;
                arrParam[17] = new DB2Parameter("@SMLREQUIEREINSPEC", DB2Type.SmallInt);
                arrParam[17].Value = pPtuSollicencia.smlrequiereinspec;
                arrParam[18] = new DB2Parameter("@INTNUMESTACIONAMIENTOS", DB2Type.Integer);
                arrParam[18].Value = pPtuSollicencia.intnumestacionamientos;
                arrParam[19] = new DB2Parameter("@VCHTIPOEMPRESA", DB2Type.VarChar);
                arrParam[19].Value = pPtuSollicencia.vchtipoempresa;
                arrParam[20] = new DB2Parameter("@VCHZONIFICACION", DB2Type.VarChar);
                arrParam[20].Value = pPtuSollicencia.vchzonificacion;
                arrParam[21] = new DB2Parameter("@VCHCONCLUSION", DB2Type.VarChar);
                arrParam[21].Value = pPtuSollicencia.vchconclusion;
                arrParam[22] = new DB2Parameter("@VCHNUMLICENCIACONSTR", DB2Type.VarChar);
                arrParam[22].Value = pPtuSollicencia.vchnumlicenciaconstr;
                arrParam[23] = new DB2Parameter("@VCHNUMDECLFABRICA", DB2Type.VarChar);
                arrParam[23].Value = pPtuSollicencia.vchnumdeclfabrica;
                arrParam[24] = new DB2Parameter("@VCHCESENUMEROLIC", DB2Type.VarChar);
                arrParam[24].Value = pPtuSollicencia.vchcesenumerolic;
                arrParam[25] = new DB2Parameter("@CHRCESEANIOLIC", DB2Type.VarChar);
                arrParam[25].Value = pPtuSollicencia.chrceseaniolic;
                arrParam[26] = new DB2Parameter("@VCHCESEEXPENUMERO", DB2Type.VarChar);
                arrParam[26].Value = pPtuSollicencia.vchceseexpenumero;
                arrParam[27] = new DB2Parameter("@DATCESEEXPEFECHA", DB2Type.Date);
                arrParam[27].Value = pPtuSollicencia.datceseexpefecha;
                arrParam[28] = new DB2Parameter("@SMLCESECODMOTIVO", DB2Type.SmallInt);
                arrParam[28].Value = pPtuSollicencia.smlcesecodmotivo;
                arrParam[29] = new DB2Parameter("@SMLESTSOLLICENCIA", DB2Type.SmallInt);
                arrParam[29].Value = pPtuSollicencia.smlestsollicencia;
                arrParam[30] = new DB2Parameter("@SMLRESULTADO", DB2Type.SmallInt);
                arrParam[30].Value = pPtuSollicencia.smlresultado;
                arrParam[31] = new DB2Parameter("@SMLESTLICENCIA", DB2Type.SmallInt);
                arrParam[31].Value = pPtuSollicencia.smlestlicencia;
                arrParam[32] = new DB2Parameter("@VCHAUDUSUCREACION", DB2Type.VarChar);
                arrParam[32].Value = pPtuSollicencia.vchaudusucreacion;
                arrParam[33] = new DB2Parameter("@TMSAUDFECCREACION", DB2Type.Timestamp);
                arrParam[33].Value = pPtuSollicencia.tmsaudfeccreacion;
                arrParam[34] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[34].Value = pPtuSollicencia.vchaudusumodif;
                arrParam[35] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[35].Value = pPtuSollicencia.tmsaudfecmodif;
                arrParam[36] = new DB2Parameter("@VCHAUDEQUIPO", DB2Type.VarChar);
                arrParam[36].Value = pPtuSollicencia.vchaudequipo;
                arrParam[37] = new DB2Parameter("@VCHAUDPROGRAMA", DB2Type.VarChar);
                arrParam[37].Value = pPtuSollicencia.vchaudprograma;


                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_ACTUALIZAR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_ACTUALIZAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);

            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_ACTUALIZAR : "+ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);

                throw ex;
            }
        }

        public override void Eliminar(PtuSolLicencia pPtuSolLicencia)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicencia.intcodsolicitud;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_ELIMINAR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_ELIMINAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_ELIMINAR : "+ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
        }

        public override List<PtuSolLicencia> Listar()
        {
            try
            {
                DB2DataReader dataReader;
                oPtuSolLicenciaList = new List<PtuSolLicencia>();
                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_LISTAR");
                oPtuSolLicenciaList = ConvertidorUtil.DeReaderAColeccion<PtuSolLicencia, List<PtuSolLicencia>>(dataReader);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_LISTAR");                
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolLicenciaList);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_LISTAR : "+ ex.Message);
                throw ex;
            }
            return oPtuSolLicenciaList;
        }

        public override PtuSolLicencia ListarPorId(int? intcodsolicitud)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                DB2DataReader dataReader;
                
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = intcodsolicitud;

                dataReader = DB2helper.ExecuteReader((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_LISTARKEY", arrParam);
                oPtuSolLicencia = ConvertidorUtil.DeReaderAEntidad<PtuSolLicencia>(dataReader);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_LISTARKEY");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), oPtuSolLicencia);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_LISTARKEY : "+ex.Message);                
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
            return oPtuSolLicencia;
        }

        public override void Desistir(PtuSolLicencia pPtuSolLicencia)
        {
            DB2Parameter[] arrParam = new DB2Parameter[4];
            try
            {                
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicencia.intcodsolicitud;
                arrParam[1] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[1].Value = pPtuSolLicencia.vchaudusumodif;
                arrParam[2] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[2].Value = pPtuSolLicencia.tmsaudfecmodif;
                arrParam[3] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
                arrParam[3].Value = pPtuSolLicencia.vchobservacion;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_DESISTIR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_DESISTIR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_DESISTIR : "+ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
        }

        public override void Calificar(PtuSolLicencia pPtuSolLicencia, int pintcodigoprocedimiento)
        {
            DB2Parameter[] arrParam = new DB2Parameter[7];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicencia.intcodsolicitud;

                arrParam[1] = new DB2Parameter("@INTCODIGOPROCEDIMIENTO", DB2Type.Integer);
                arrParam[1].Value = pintcodigoprocedimiento;

                arrParam[2] = new DB2Parameter("@SMLESTSOLLICENCIA", DB2Type.Integer);
                arrParam[2].Value = pPtuSolLicencia.smlestsollicencia;

                arrParam[3] = new DB2Parameter("@SMLRESULTADO", DB2Type.Integer);
                arrParam[3].Value = pPtuSolLicencia.smlresultado;

                arrParam[4] = new DB2Parameter("@VCHOBSERVACION", DB2Type.VarChar);
                arrParam[4].Value = pPtuSolLicencia.vchobservacion;

                arrParam[5] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[5].Value = pPtuSolLicencia.vchaudusumodif;

                arrParam[6] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[6].Value = pPtuSolLicencia.tmsaudfecmodif;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_CALIFICAR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_CALIFICAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_CALIFICAR : "+ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
        }

        public override void ProcesarPlantillas(PtuSolLicencia pPtuSolLicencia)
        {
            DB2Parameter[] arrParam = new DB2Parameter[1];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicencia.intcodsolicitud;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLREQUERIMIENTO_GENERARDATA", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_GENERARDATA");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLREQUERIMIENTO_GENERARDATA : "+ex.Message);                
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
        }

        public override void Acreditar(PtuSolLicencia pPtuSolLicencia)
        {
            DB2Parameter[] arrParam = new DB2Parameter[4];
            try
            {
                arrParam[0] = new DB2Parameter("@INTCODSOLICITUD", DB2Type.Integer);
                arrParam[0].Value = pPtuSolLicencia.intcodsolicitud;
                arrParam[1] = new DB2Parameter("@SMLESTSOLLICENCIA", DB2Type.Integer);
                arrParam[1].Value = pPtuSolLicencia.smlestsollicencia;
                arrParam[2] = new DB2Parameter("@VCHAUDUSUMODIF", DB2Type.VarChar);
                arrParam[2].Value = pPtuSolLicencia.vchaudusumodif;
                arrParam[3] = new DB2Parameter("@TMSAUDFECMODIF", DB2Type.Timestamp);
                arrParam[3].Value = pPtuSolLicencia.tmsaudfecmodif;

                DB2helper.ExecuteNonQuery((DB2Transaction)this.dbconex.Transaccion(), CommandType.StoredProcedure, "SIPT.PTUSOLLICENCIA_ACREDITAR", arrParam);

                Log.Info(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_ACREDITAR");
                Log.Debug(this.logMensajes.codigoMensaje.ToString(), arrParam);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), "SIPT.PTUSOLLICENCIA_ACREDITAR : " + ex.Message);
                Log.Error(this.logMensajes.codigoMensaje.ToString(), arrParam);
                throw ex;
            }
        }



    }
}