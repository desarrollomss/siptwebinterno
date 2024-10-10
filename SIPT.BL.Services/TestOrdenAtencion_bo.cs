using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.DTO.Mapper;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;

namespace SIPT.BL.Services
{
    public class TestOrdenAtencion_bo
    {
        private TestOrdenAtencion_dao testOrdenAtencion_dao;
        private TestOrdenAtencion testOrdenAtencion;
        private TestOrdenAtencionDTO oTestOrdenAtencionDTO;

        private PtuLicencia ptuLicencia;
        private PtuLicencia_dao ptuLicencia_dao;

        private PtuSolLicencia_dao ptuSolLicencia_dao;
        private PtuSolicitud_dao ptuSolicitud_dao;
        private PtuProcedimientostupa_dao ptuProcedimientostupa_dao;
        private PtuProcedimientostupa ptuProcedimientostupa;
        private PtuSolLicencia ptuSolLicencia;

        private AutLicencia_dao autLicencia_dao;
        private AutLicencia_Inserta autLicencia_Inserta;
        private AutLicencia_Resultado autLicencia_Resultado;

        private PtuSolicitud ptuSolicitud;
        private LogMensajes logMensajes;
        private Db dbconex;

        public TestOrdenAtencion_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public TestOrdenAtencionDTO RegistrarOrden(int? intcodsolicitud, string vchtidcodigo, 
                string vchoradocumento, int? intadmcodigo, int? intcodigoprocedimiento, 
                string vchaplicacion, string vchaudequipo, string vchusuario)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                //string vchtidcodigo = "01";
                //string vchoradocumento = "41437906"; 
                string vchoranombre = "Registro de Orden de Atencion por el SIPT";
                //int intadmcodigo = 0;
                //decimal decoratotpagar = 166.4m;
                //Int16 smltricodigo = 1008; 

                ptuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                ptuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);
                testOrdenAtencion_dao = ObjectFactory.Instanciar<TestOrdenAtencion_dao>(new TestOrdenAtencion(), this.logMensajes);
                ptuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);

                ptuSolLicencia = new PtuSolLicencia();
                ptuSolLicencia.intcodsolicitud = intcodsolicitud;
                ptuSolLicencia.smlestsollicencia = 26;
                ptuSolLicencia_dao.Actualizar(ptuSolLicencia);

                ptuProcedimientostupa = ptuProcedimientostupa_dao.ListarKey(intcodigoprocedimiento);

                int numOrdenAtencion = testOrdenAtencion_dao.RegistrarOrden(vchtidcodigo, vchoradocumento, vchoranombre, intadmcodigo,
                    ptuProcedimientostupa.decpagoapertura, Convert.ToInt16(ptuProcedimientostupa.vchcodderechoapertura), vchaudequipo, vchaplicacion, vchusuario);

                oTestOrdenAtencionDTO = ConsultarOrdenPorApi(numOrdenAtencion);
                oTestOrdenAtencionDTO.intcodsolicitud = intcodsolicitud;


                ptuSolicitud = new PtuSolicitud();
                ptuSolicitud.intcodsolicitud = intcodsolicitud;
                ptuSolicitud.vchnumordenatencion = oTestOrdenAtencionDTO.intordennumero.ToString();
                ptuSolicitud.deccosto = oTestOrdenAtencionDTO.decordentotalpagar;
                ptuSolicitud_dao.Actualizar(ptuSolicitud);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oTestOrdenAtencionDTO;
        }

        public TestOrdenAtencionDTO ConsultarOrdenPorApi(int intoranumero)
        {
            testOrdenAtencion_dao = ObjectFactory.Instanciar<TestOrdenAtencion_dao>(new TestOrdenAtencion(), this.logMensajes);
            testOrdenAtencion = testOrdenAtencion_dao.ConsultarOrden(intoranumero);
            Mapeos mapeo = new Mapeos();
            oTestOrdenAtencionDTO = mapeo.Map<TestOrdenAtencion, TestOrdenAtencionDTO>(testOrdenAtencion);
           
            return oTestOrdenAtencionDTO;
        }

        public int ObtenerIdReporteLicencia(int? intintcodlicencia)
        {
            int codigoReporte = 0;            
            
            testOrdenAtencion_dao = ObjectFactory.Instanciar<TestOrdenAtencion_dao>(new TestOrdenAtencion(), this.logMensajes);

            codigoReporte = testOrdenAtencion_dao.ObtenerIdReporteLicencia(intintcodlicencia);
           
            return codigoReporte;
        }


        public TestOrdenAtencionDTO ConsultarOrdenPorSolicitud(PtuSolicitudDTO ptuSolicitudDTO)
        {
            bool generarSolicitud = false;
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                ptuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                ptuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                testOrdenAtencion_dao = ObjectFactory.Instanciar<TestOrdenAtencion_dao>(new TestOrdenAtencion(), this.logMensajes);

                if (ptuSolicitudDTO.intcodsolicitud != 0)
                {
                    ptuSolicitud = ptuSolicitud_dao.ListarPorId(ptuSolicitudDTO.intcodsolicitud);
                    ptuSolLicencia = ptuSolLicencia_dao.ListarPorId(ptuSolicitudDTO.intcodsolicitud);
                    testOrdenAtencion = testOrdenAtencion_dao.ConsultarOrden(Convert.ToInt32(ptuSolicitud.vchnumordenatencion));

                    Mapeos mapeo = new Mapeos();
                    oTestOrdenAtencionDTO = mapeo.Map<TestOrdenAtencion, TestOrdenAtencionDTO>(testOrdenAtencion);
                    oTestOrdenAtencionDTO.intcodsolicitud = ptuSolicitudDTO.intcodsolicitud;

                    if (testOrdenAtencion!=null && testOrdenAtencion.vchestadodescripcion == "PAGADO" && ptuSolLicencia.smlestsollicencia == 26)
                    {
                        generarSolicitud = true;                        
                    }                    
                }
                
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }


            if (generarSolicitud)
            {
                dbconex = new Db();
                try
                {
                    dbconex.IniciarTransaccion();

                    autLicencia_dao = ObjectFactory.Instanciar<AutLicencia_dao>(new AutLicencia(), this.logMensajes, dbconex);

                    autLicencia_Inserta = new AutLicencia_Inserta();
                    autLicencia_Inserta.p_chrsolanio = ptuSolicitud.chranio;
                    autLicencia_Inserta.p_vchsolnumero = ptuSolicitud.vchnumero;
                    autLicencia_Inserta.p_datlicfeccreacion = DateTime.Now;
                    autLicencia_Inserta.p_vchaudusucreacion = "0154"; //ptuSolicitudDTO.vchaudusucreacion;
                    autLicencia_Resultado = autLicencia_dao.Insertar(autLicencia_Inserta)[0];

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

                    ptuLicencia_dao = ObjectFactory.Instanciar<PtuLicencia_dao>(new PtuLicencia(), this.logMensajes, dbconex);
                    ptuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);

                    ptuLicencia = new PtuLicencia();
                    ptuLicencia.chlicanio = autLicencia_Resultado.p_chrlicanio;
                    ptuLicencia.vchlicnumero = autLicencia_Resultado.p_vchlicnumero;
                    ptuLicencia.datvigenciaini = DateTime.Now;
                    ptuLicencia.datvigenciafin = null;
                    ptuLicencia.tmsregistrolicencia = null;
                    ptuLicencia.smlvigencia = 1;
                    ptuLicencia.vchobservacion = "";
                    ptuLicencia.intaforo =null;
                    ptuLicencia.intdoccodigo = ptuSolicitud.intdoccodigoexpediente;
                    ptuLicencia.datfechaprogramacion = DateTime.Now.AddDays(2);
                    ptuLicencia.vchhoraprogramacion = DateTime.Now.AddDays(2).Hour.ToString();
                    ptuLicencia.vchliccategoria = null;
                    ptuLicencia.smlameritaprogramacion = null;

                    ptuLicencia.vchzonacod = null;
                    ptuLicencia.vchestrcodigo = null;
                    ptuLicencia.vchsolgerencia = null;
                    ptuLicencia.vchsolsubgerencia = null;
                    ptuLicencia.intcodsolicitud = ptuSolicitudDTO.intcodsolicitud; 
                    ptuLicencia.vchaudusucreacion = ptuSolicitudDTO.vchaudusucreacion;
                    ptuLicencia.tmsaudfeccreacion = DateTime.Now; 
                    ptuLicencia.vchaudusumodif = null;
                    ptuLicencia.tmsaudfecmodif = null;
                    ptuLicencia.vchaudequipo = ptuSolicitudDTO.vchaudequipo;
                    ptuLicencia.vchaudprograma = ptuSolicitudDTO.vchaudprograma;

                    ptuSolLicencia = new PtuSolLicencia();
                    ptuSolLicencia.intcodsolicitud = ptuSolicitudDTO.intcodsolicitud;
                    ptuSolLicencia.smlestsollicencia = 42;
                    ptuSolLicencia_dao.Actualizar(ptuSolLicencia);


                    ptuLicencia_dao.Insertar(ptuLicencia);

                    dbconex.RegistrarTransaccion();
                }
                finally
                {
                    dbconex.CerrarConexion();
                }
            }

            return oTestOrdenAtencionDTO;
        }

    }
}
