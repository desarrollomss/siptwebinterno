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
    public class PtuSolicitud_bo
    {
        private PtuSolicitud_dao oPtuSolicitud_dao;
        private PtuSolLicencia_dao oPtuSolLicencia_dao;
        private PtuSolLicenciaUso_dao oPtuSolLicenciaUso_dao;
        private DjuPredio_dao oDjuPredio_dao;
        private PtuUso_dao oPtuUso_dao;
        private ConAdministrado_dao oConAdministrado_dao;
        private PtuTabla_dao oPtuTabla_dao;

        private PtuLicencia_dao oPtuLicencia_dao;

        private DjuPredio oDjuPredio;
        private PtuSolicitud oPtuSolicitud;
        private PtuSolLicencia oPtuSolLicencia;
        private PtuSolLicenciaUso oPtuSolLicenciaUso;
        private ConAdministrado oConAdministrado;
        private PtuTabla oPtuTabla;

        private List<PtuSolLicenciaUso> oPtuSolLicenciaUsoList;
        private List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitanteList;

        private List<PtuSolicitud> oPtuSolicitudList;

        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolicitud_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }
        public int Insertar(PtuSolicitudDTO pPtuSolicitudDTO)
        {
            dbconex = new Db();
            int valor;
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                oPtuSolLicenciaUso_dao = ObjectFactory.Instanciar<PtuSolLicenciaUso_dao>(new PtuSolLicenciaUso(), this.logMensajes, dbconex);
                
                Mapeos mapeo = new Mapeos();
                PtuSolicitud otuSolicitud = mapeo.Map<PtuSolicitudDTO, PtuSolicitud>(pPtuSolicitudDTO);
                PtuSolLicencia oPtuSolLicencia = mapeo.Map<PtuSolicitudDTO, PtuSolLicencia>(pPtuSolicitudDTO);

                valor = oPtuSolicitud_dao.Insertar(otuSolicitud);

                otuSolicitud.intcodsolicitud = valor;
                oPtuSolLicencia.intcodsolicitud = valor;

                oPtuSolLicencia_dao.Insertar(oPtuSolLicencia);
                foreach (PtuUsoDTO oPtuUsoDTO in pPtuSolicitudDTO.PtuUsosDTO)
                {
                    oPtuUsoDTO.intcodsolicitud = otuSolicitud.intcodsolicitud;
                    PtuSolLicenciaUso oPtuSolLicenciaUso = mapeo.Map<PtuUsoDTO, PtuSolLicenciaUso>(oPtuUsoDTO);
                    oPtuSolLicenciaUso_dao.Insertar(oPtuSolLicenciaUso);
                }
                dbconex.RegistrarTransaccion();
                return valor;
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
        }

        public PtuSolicitudDTO Actualizar(PtuSolicitudDTO pPtuSolicitudDTO)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                oPtuSolLicenciaUso_dao = ObjectFactory.Instanciar<PtuSolLicenciaUso_dao>(new PtuSolLicenciaUso(), this.logMensajes, dbconex);

                Mapeos mapeo = new Mapeos();
                PtuSolicitud oPtuSolicitud = mapeo.Map<PtuSolicitudDTO, PtuSolicitud>(pPtuSolicitudDTO);
                PtuSolLicencia oPtuSolLicencia = mapeo.Map<PtuSolicitudDTO, PtuSolLicencia>(pPtuSolicitudDTO);                

                oPtuSolicitud =  oPtuSolicitud_dao.Actualizar(oPtuSolicitud);
                oPtuSolLicencia_dao.Actualizar(oPtuSolLicencia);

                oPtuSolLicenciaUso = new PtuSolLicenciaUso();
                oPtuSolLicenciaUso.intcodsolicitud  = oPtuSolicitud.intcodsolicitud;

                if(pPtuSolicitudDTO.PtuUsosDTO !=null && pPtuSolicitudDTO.PtuUsosDTO.Count > 0)
                {
                    oPtuSolLicenciaUso_dao.Eliminar(oPtuSolLicenciaUso);

                    foreach (PtuUsoDTO oPtuUsoDTO in pPtuSolicitudDTO.PtuUsosDTO)
                    {
                        PtuSolLicenciaUso oPtuSolLicenciaUso = mapeo.Map<PtuUsoDTO, PtuSolLicenciaUso>(oPtuUsoDTO);

                        oPtuSolLicenciaUso.intcodsolicitud = oPtuSolicitud.intcodsolicitud;
                        oPtuSolLicenciaUso_dao.Insertar(oPtuSolLicenciaUso);
                    }
                }                

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
            return pPtuSolicitudDTO;
        }

        public void Eliminar(PtuSolicitud pPtuSolicitud)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                
                oPtuSolicitud_dao.Eliminar(pPtuSolicitud);
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
        }

        public PtuSolicitudDTO ListarPorId(int? intcodsolicitud)
        {
            PtuSolicitudDTO ptuSolicitudDTO;
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                oPtuSolLicencia_dao = ObjectFactory.Instanciar<PtuSolLicencia_dao>(new PtuSolLicencia(), this.logMensajes, dbconex);
                oPtuSolLicenciaUso_dao = ObjectFactory.Instanciar<PtuSolLicenciaUso_dao>(new PtuSolLicenciaUso(), this.logMensajes, dbconex);
                oDjuPredio_dao = ObjectFactory.Instanciar<DjuPredio_dao>(new DjuPredio(), this.logMensajes, dbconex);
                oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                //oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                oConAdministrado_dao = ObjectFactory.Instanciar<ConAdministrado_dao>(new ConAdministrado(), this.logMensajes, dbconex);
                oPtuTabla_dao = ObjectFactory.Instanciar<PtuTabla_dao>(new PtuTabla(), this.logMensajes, dbconex);

                oPtuSolicitud = oPtuSolicitud_dao.ListarPorId(intcodsolicitud);
                oPtuSolLicencia = oPtuSolLicencia_dao.ListarPorId(intcodsolicitud);
                oDjuPredio = oDjuPredio_dao.ListarPorId(oPtuSolLicencia.intcodigopredio);
                oConAdministrado = oConAdministrado_dao.ListarplataformaPorId(oPtuSolicitud.intadmpropietario);
                oPtuTabla = oPtuTabla_dao.ListarKey(oPtuSolLicencia.smlcondicionsolicitante);
                Mapeos mapeo = new Mapeos();
                ptuSolicitudDTO = mapeo.Map<PtuSolicitud, PtuSolLicencia, PtuSolicitudDTO>(oPtuSolicitud, oPtuSolLicencia);
                ptuSolicitudDTO.vchubicacionpredio = oDjuPredio.vchpredireccion;
                ptuSolicitudDTO.vchadmcompleto = oConAdministrado.vchadmcompleto;
                ptuSolicitudDTO.vchcondicionsolicitante = oPtuTabla.vchdescripcion;
                oPtuSolLicenciaUsoList = oPtuSolLicenciaUso_dao.ListarPorSolicitud(intcodsolicitud);

                PtuUso oPtuUso;
                List<PtuUsoDTO> oPtuUsosDTO = new List<PtuUsoDTO>();

                foreach (PtuSolLicenciaUso ptuSolLicenciaUso in oPtuSolLicenciaUsoList)
                {
                    oPtuUso = oPtuUso_dao.ListarPorId(ptuSolLicenciaUso.intcoduso);
                    var PtuUsoDTO = mapeo.Map<PtuSolLicenciaUso, PtuUso, PtuUsoDTO>(ptuSolLicenciaUso, oPtuUso);
                    PtuUsoDTO.vchnombreusocompleto = PtuUsoDTO.vchcoduso + " - " + PtuUsoDTO.vchnombreuso;

                    oPtuUsosDTO.Add(PtuUsoDTO);
                }
                ptuSolicitudDTO.PtuUsosDTO = oPtuUsosDTO;

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
            return ptuSolicitudDTO;
        }      

        public List<PtuSolicitud_PorAnalistaPorSolicitante> ListarPorAnalistaPorSolicitante(int? intcodigosolicitante, int? intusuanalista)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);
                
                oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_dao.ListarPorAnalistaPorSolicitante(intcodigosolicitante, intusuanalista);

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
            return oPtuSolicitud_PorAnalistaPorSolicitanteList;
        }

        public List<PtuSolicitud_PorAnalistaPorSolicitante> ListarPendientes(PtuSolicitud pPtuSolicitud, int? intusuanalista)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);

                oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_dao.ListarPendientes(pPtuSolicitud, intusuanalista);

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
            return oPtuSolicitud_PorAnalistaPorSolicitanteList;
        }

        public List<PtuSolicitud_PorAnalistaPorSolicitante> ListarCalificar(PtuSolicitud pPtuSolicitud, int? intusuanalista)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);

                oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_dao.ListarCalificar(pPtuSolicitud, intusuanalista);
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuSolicitud_PorAnalistaPorSolicitanteList;
        }

        public List<PtuSolicitud_PorAnalistaPorSolicitante> ListarAcreditar(PtuSolicitud pPtuSolicitud, int? intusuanalista)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuSolicitud_dao = ObjectFactory.Instanciar<PtuSolicitud_dao>(new PtuSolicitud(), this.logMensajes, dbconex);

                oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_dao.ListarAcreditar(pPtuSolicitud, intusuanalista);

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
            return oPtuSolicitud_PorAnalistaPorSolicitanteList;
        }

        public List<PtuLicenciaDTO> ListarKeys(
                                int? intcodlicencia,
                                int? intcodsolicitud)
        {
            List<PtuLicencia> oPtuLicenciaList;
            List<PtuLicenciaDTO> oPtuLicenciaDTOList = new List<PtuLicenciaDTO>();
            dbconex = new Db();
            try
            {
                oPtuLicencia_dao = ObjectFactory.Instanciar<PtuLicencia_dao>(new PtuLicencia(), this.logMensajes, dbconex);

                dbconex.IniciarTransaccion();
                oPtuLicenciaList = oPtuLicencia_dao.ListarKeys(
                                intcodlicencia,
                                intcodsolicitud);
                dbconex.RegistrarTransaccion();
                Mapeos mapeo = new Mapeos();

                foreach (PtuLicencia oPtuLicencia in oPtuLicenciaList)
                {
                    var oPtuLicenciaDTO = mapeo.Map<PtuLicencia, PtuLicenciaDTO>(oPtuLicencia);
                    oPtuLicenciaDTOList.Add(oPtuLicenciaDTO);
                }
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
            return oPtuLicenciaDTOList;
        }


    }
}