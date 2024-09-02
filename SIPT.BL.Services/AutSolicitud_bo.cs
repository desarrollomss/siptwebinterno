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
    public class AutSolicitud_bo
    {
        private LogMensajes logMensajes;
        private Db dbconex;

        
        private PtuSolicitud ptuSolicitud;
        private PtuSolicitud_dao ptuSolicitud_dao;

        private PtuSolLicencia ptuSolLicencia;
        private PtuSolLicencia_dao ptuSolLicencia_dao;

        private AutSolicitud_dao autSolicitud_dao;
        private AutSolicitud_Inserta autSolicitud_Inserta;
        private AutSolicitud_Resultado autSolicitud_Resultado;
        public AutSolicitud_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public AutSolicitud_Resultado Insertar(PtuSolicitudDTO ptuSolicitudDTO)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                ptuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                ptuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                autSolicitud_dao = ObjectFactory.Instanciar<AutSolicitud_dao>(new AutSolicitud(), this.logMensajes, dbconex);

                ptuSolicitud = ptuSolicitud_dao.ListarPorId(ptuSolicitudDTO.intcodsolicitud);
                ptuSolLicencia = ptuSolLicencia_dao.ListarPorId(ptuSolicitudDTO.intcodsolicitud);

                autSolicitud_Inserta = new AutSolicitud_Inserta();
                autSolicitud_Inserta.p_smltipautcodigo = 1;
                autSolicitud_Inserta.p_intprecodigo = ptuSolLicencia.intcodigopredio;
                autSolicitud_Inserta.p_intadmcodigo = ptuSolicitud.intcodigosolicitante;
                autSolicitud_Inserta.p_decslicareocup = ptuSolLicencia.decareaocupar;
                autSolicitud_Inserta.p_smlcodtabla = ptuSolLicencia.smlcondicionsolicitante;
                autSolicitud_Inserta.p_intdoccodigo = ptuSolicitudDTO.intdoccodigoexpediente;
                autSolicitud_Inserta.p_intcodsolicitud = ptuSolicitudDTO.intcodsolicitud;
                autSolicitud_Inserta.p_vchaudusucreacion = ptuSolicitudDTO.vchaudusucreacion;
                autSolicitud_Inserta.p_vchaudequipo = ptuSolicitudDTO.vchaudequipo;
                autSolicitud_Inserta.p_vchaudprograma = ptuSolicitudDTO.vchaudprograma;

                autSolicitud_Resultado = autSolicitud_dao.Insertar(autSolicitud_Inserta)[0];

                dbconex.RegistrarTransaccion();
            }
            catch (Exception ex)
            {
                dbconex.AnularTransaccion();
                throw ex;
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return autSolicitud_Resultado;
        }
    }
}
