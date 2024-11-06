using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using SIPT.BL.DTO.DTO;
using System;
using System.Collections.Generic;
using SIPT.BL.Models.Consultas;

namespace SIPT.BL.Services
{
    public class PtuSolLicencia_bo
    {
        private PtuSolicitud_dao oPtuSolicitud_dao;
        private PtuSolLicencia_dao oPtuSolLicencia_dao;
        private List<PtuSolLicencia> oPtuSolLicenciaList;
        private PtuSolLicencia oPtuSolLicencia;
        private PtuSolrequerimiento_dao oPtuSolrequerimiento_dao;
        private StdDocumento_dao stdDocumento_dao;
        private AutSolicitud_dao autSolicitud_dao;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolLicencia_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public  void Insertar(PtuSolLicencia pPtuSolLicencia) 
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                

                oPtuSolLicencia_dao.Insertar(pPtuSolLicencia);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public void Actualizar(PtuSolLicencia pPtuSolLicencia) 
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);                

                oPtuSolLicencia_dao.Actualizar(pPtuSolLicencia);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public void Eliminar(PtuSolLicencia pPtuSolLicencia)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);

                oPtuSolLicencia_dao.Eliminar(pPtuSolLicencia);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public List<PtuSolLicencia> Listar()
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                
                oPtuSolLicenciaList = oPtuSolLicencia_dao.Listar();

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuSolLicenciaList;
        }

        public PtuSolLicencia ListarPorId(int? intcodsolicitud)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                
                oPtuSolLicencia = oPtuSolLicencia_dao.ListarPorId(intcodsolicitud);
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuSolLicencia;
        }

        public void Desistir(PtuSolLicencia pPtuSolLicencia)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                
                oPtuSolLicencia_dao.Desistir(pPtuSolLicencia);
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public void Calificar(PtuSolLicencia pPtuSolLicencia, int pintcodigoprocedimiento, string usuarioRol)
        {
            PtuSolicitud ptuSolicitud = null;
            PtuSolLicencia ptuSolLicencia = null;
            PtuProcedimientostupa ptuProcedimientostupa = null;
            AutSolicitud_Resultado autSolicitud_Resultado;
            List<StdDocumento_InsertaResultado> stdDocumento_InsertaResultado;

            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                PtuSolicitud_dao ptuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                PtuSolLicencia_dao ptuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                PtuProcedimientostupa_dao ptuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);

                ptuSolicitud = ptuSolicitud_dao.ListarPorId(pPtuSolLicencia.intcodsolicitud);
                ptuSolLicencia = ptuSolLicencia_dao.ListarPorId(pPtuSolLicencia.intcodsolicitud);
                ptuProcedimientostupa = ptuProcedimientostupa_dao.ListarKey(1);

                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);

                oPtuSolLicencia_dao.Calificar(pPtuSolLicencia, pintcodigoprocedimiento);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }


            if (usuarioRol.Equals("COORDINADOR SIPT"))
            {
                /********* Registro de Expediente en SISDOC *****************/
                dbconex = new Db();
                try
                {
                    dbconex.IniciarTransaccion();
                    stdDocumento_dao = ObjectFactory.Instanciar<StdDocumento_dao>(new StdDocumento(), this.logMensajes, dbconex);

                    StdDocumento_InsertaDocWebSipt stdDocumento_InsertaDocWebSipt = new StdDocumento_InsertaDocWebSipt();
                    stdDocumento_InsertaDocWebSipt.intadmcodigo = ptuSolicitud.intcodigosolicitante;
                    stdDocumento_InsertaDocWebSipt.inttipdoccodigo = 1;
                    stdDocumento_InsertaDocWebSipt.inttipprocodigo = 1;
                    stdDocumento_InsertaDocWebSipt.vchoficodigo = ptuProcedimientostupa.vchoficodigo;
                    stdDocumento_InsertaDocWebSipt.inttupcodigo = ptuProcedimientostupa.inttupcodigo;
                    stdDocumento_InsertaDocWebSipt.intprocodigo = ptuProcedimientostupa.intprocodigo;
                    //stdDocumento_InsertaDocWebSipt.intasucodigo = ptuSolicitudDTO
                    //stdDocumento_InsertaDocWebSipt.vchdocasunto = ptuSolicitudDTO
                    stdDocumento_InsertaDocWebSipt.intdocfolio = 1;
                    stdDocumento_InsertaDocWebSipt.intprecodigo = ptuSolLicencia.intcodigopredio;
                    stdDocumento_InsertaDocWebSipt.vchdocobservacion = "";
                    stdDocumento_InsertaDocWebSipt.intrecnumber = Convert.ToInt32(ptuSolicitud.vchnumordenatencion);
                    stdDocumento_InsertaDocWebSipt.vchaudequipocreacion = pPtuSolLicencia.vchaudequipo;
                    stdDocumento_InsertaDocWebSipt.pvchuniorgremcodigo = ptuProcedimientostupa.vchoficodigo;
                    stdDocumento_InsertaDocWebSipt.pvchuniorgreccodigo = ptuProcedimientostupa.vchoficodigo;

                    stdDocumento_InsertaResultado = stdDocumento_dao.Insertar(stdDocumento_InsertaDocWebSipt);
                    dbconex.RegistrarTransaccion();
                }
                finally
                {
                    dbconex.CerrarConexion();
                }

                /********* Registro de Solicitud en DBSAC *****************/
                dbconex = new Db();
                try
                {
                    dbconex.IniciarTransaccion();
                    autSolicitud_dao = ObjectFactory.Instanciar<AutSolicitud_dao>(new AutSolicitud(), this.logMensajes, dbconex);

                    AutSolicitud_Inserta autSolicitud_Inserta = new AutSolicitud_Inserta();
                    autSolicitud_Inserta.p_smltipautcodigo = 1;
                    autSolicitud_Inserta.p_intprecodigo = ptuSolLicencia.intcodigopredio;
                    autSolicitud_Inserta.p_intadmcodigo = ptuSolicitud.intcodigosolicitante;
                    autSolicitud_Inserta.p_decslicareocup = ptuSolLicencia.decareaocupar;
                    autSolicitud_Inserta.p_smlcodtabla = ptuSolLicencia.smlcondicionsolicitante;
                    autSolicitud_Inserta.p_intdoccodigo = stdDocumento_InsertaResultado[0].intdoccodigo;
                    autSolicitud_Inserta.p_intcodsolicitud = pPtuSolLicencia.intcodsolicitud;
                    autSolicitud_Inserta.p_vchaudusucreacion = pPtuSolLicencia.vchaudusumodif;
                    autSolicitud_Inserta.p_vchaudequipo = pPtuSolLicencia.vchaudequipo;
                    autSolicitud_Inserta.p_vchaudprograma = pPtuSolLicencia.vchaudprograma;

                    autSolicitud_Resultado = autSolicitud_dao.Insertar(autSolicitud_Inserta)[0];

                    dbconex.RegistrarTransaccion();
                }
                finally
                {
                    dbconex.CerrarConexion();
                }



                dbconex = new Db();
                try
                {
                    dbconex.IniciarTransaccion();
                    oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                    

                    if (autSolicitud_Resultado.sql_codigo == 0)
                    {
                        PtuSolicitud optuSolicitud = new PtuSolicitud();
                        optuSolicitud.intcodsolicitud = pPtuSolLicencia.intcodsolicitud;
                        optuSolicitud.vchaudusumodif = pPtuSolLicencia.vchaudusumodif;
                        optuSolicitud.vchaudequipo = pPtuSolLicencia.vchaudequipo;
                        optuSolicitud.vchaudprograma = pPtuSolLicencia.vchaudprograma;
                        optuSolicitud.chranio = autSolicitud_Resultado.p_chrsolanio;
                        optuSolicitud.vchnumero = autSolicitud_Resultado.p_vchsolnumero;
                        optuSolicitud.vchnumexpediente = stdDocumento_InsertaResultado[0].vchdocnumcompleto;
                        optuSolicitud.intdoccodigoexpediente = stdDocumento_InsertaResultado[0].intdoccodigo;
                        optuSolicitud.datregexpediente = DateTime.Now;
                        oPtuSolicitud_dao.Actualizar(optuSolicitud);
                    }

                    dbconex.RegistrarTransaccion();
                }
                finally
                {
                    dbconex.CerrarConexion();
                }
            }

        }

        public void ProcesarPlantillas(PtuSolLicencia pPtuSolLicencia)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);

                oPtuSolLicencia_dao.ProcesarPlantillas(pPtuSolLicencia);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }


        public void Acreditar(PtuSolLicencia pPtuSolLicencia, int pintcodprocedimiento, List<PtuSolrequerimiento> pPtuSolrequerimientoList)
        {
            dbconex = new Db();

            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);

                oPtuSolLicencia_dao.Acreditar(pPtuSolLicencia, pintcodprocedimiento);

                foreach (PtuSolrequerimiento oPtuSolrequerimiento in pPtuSolrequerimientoList)
                {
                    oPtuSolrequerimiento_dao.Actualizar(oPtuSolrequerimiento);
                }
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }



    }
}