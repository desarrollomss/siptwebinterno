using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Services
{
    public class StdDocumento_bo
    {
        private LogMensajes logMensajes;
        private Db dbconex;
        private List<StdDocumento_InsertaResultado> stdDocumento_InsertaResultado;
        private StdDocumento_InsertaDocWebSipt stdDocumento_InsertaDocWebSipt;
        private StdDocumento_dao stdDocumento_dao;
        private PtuProcedimientostupa_dao ptuProcedimientostupa_dao;
        private PtuProcedimientostupa ptuProcedimientostupa;
        private PtuSolicitud_dao ptuSolicitud_dao;
        private PtuSolicitud ptuSolicitud;
        private PtuSolLicencia_dao ptuSolLicencia_dao;
        private PtuSolLicencia ptuSolLicencia;

        public StdDocumento_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public StdDocumento_InsertaResultado Insertar(PtuSolicitudDTO ptuSolicitudDTO)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                
                ptuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                ptuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                ptuProcedimientostupa_dao = ObjectFactory.Instanciar<PtuProcedimientostupa_dao>(new PtuProcedimientostupa(), this.logMensajes, dbconex);

                ptuSolicitud = ptuSolicitud_dao.ListarPorId(ptuSolicitudDTO.intcodsolicitud);
                ptuSolLicencia = ptuSolLicencia_dao.ListarPorId(ptuSolicitudDTO.intcodsolicitud);
                ptuProcedimientostupa = ptuProcedimientostupa_dao.ListarKey(ptuSolicitud.intcodigoprocedimiento);

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

                stdDocumento_dao = ObjectFactory.Instanciar<StdDocumento_dao>(new StdDocumento(), this.logMensajes, dbconex);
                ptuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                ptuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);

                stdDocumento_InsertaDocWebSipt = new StdDocumento_InsertaDocWebSipt();
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
                stdDocumento_InsertaDocWebSipt.vchaudequipocreacion = ptuSolicitudDTO.vchaudequipo;
                stdDocumento_InsertaDocWebSipt.pvchuniorgremcodigo = ptuProcedimientostupa.vchoficodigo;
                stdDocumento_InsertaDocWebSipt.pvchuniorgreccodigo = ptuProcedimientostupa.vchoficodigo;

                stdDocumento_InsertaResultado = stdDocumento_dao.Insertar(stdDocumento_InsertaDocWebSipt);

                //ptuSolicitud = new PtuSolicitud();
                //ptuSolicitud.intcodsolicitud = ptuSolicitudDTO.intcodsolicitud;
                //ptuSolicitud.vchnumexpediente = stdDocumento_InsertaResultado[0].vchdocnumcompleto;
                //ptuSolicitud.datregexpediente = DateTime.Now;
                //ptuSolicitud.vchaudusumodif = ptuSolicitudDTO.vchaudusumodif;
                //ptuSolicitud_dao.Actualizar(ptuSolicitud);

                //ptuSolLicencia = new PtuSolLicencia();
                //ptuSolLicencia.intcodsolicitud = ptuSolicitudDTO.intcodsolicitud;
                //ptuSolLicencia.vchaudusumodif = ptuSolicitudDTO.vchaudusumodif;
                //ptuSolLicencia.smlestsollicencia = 26;
                //ptuSolLicencia_dao.Actualizar(ptuSolLicencia);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return stdDocumento_InsertaResultado[0];

        }
    }
}
