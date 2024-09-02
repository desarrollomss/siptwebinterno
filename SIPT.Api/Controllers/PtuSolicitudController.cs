using Newtonsoft.Json;
using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SIPT.Api.Controllers
{
    public class PtuSolicitudController : ApiController
    {
        private LogMensajes logMensajes;

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response Insertar([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuSolicitudDTO optuSolicitudDTO = APPL.FrondEnd.Request.Deserializar<PtuSolicitudDTO>(request);  //string json = JsonConvert.SerializeObject(pSolicitudFrond);
            PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
            AutSolicitud_bo oAutSolicitud_bo = new AutSolicitud_bo(ref logMensajes);
            try
            {
                //StdDocumento_bo StdDocumento_bo = new StdDocumento_bo(ref logMensajes);
                //StdDocumento_InsertaResultado stdDocumento_InsertaResultado = StdDocumento_bo.Insertar(optuSolicitudDTO);

                //optuSolicitudDTO.intdoccodigoexpediente = stdDocumento_InsertaResultado.intdoccodigo;
                //optuSolicitudDTO.vchnumexpediente = stdDocumento_InsertaResultado.vchdocnumcompleto;
                //optuSolicitudDTO.datregexpediente = DateTime.Now;
                optuSolicitudDTO.intcodsolicitud = oPtuSolicitud_bo.Insertar(optuSolicitudDTO);

                //AutSolicitud_Resultado autSolicitud_Resultado = oAutSolicitud_bo.Insertar(optuSolicitudDTO);

                //PtuSolicitudDTO optuSolicitudDTO2 = new PtuSolicitudDTO();
                //optuSolicitudDTO2.intcodsolicitud = optuSolicitudDTO.intcodsolicitud;
                //optuSolicitudDTO2.chranio = autSolicitud_Resultado.p_chrsolanio;
                //optuSolicitudDTO2.vchnumero = autSolicitud_Resultado.p_vchsolnumero;
                //oPtuSolicitud_bo.Actualizar(optuSolicitudDTO);

                return Response.Ok(optuSolicitudDTO);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                return Response.Error(ex);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }

        [HttpPut]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response Actualizar([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuSolicitudDTO optuSolicitudDTO = APPL.FrondEnd.Request.Deserializar<PtuSolicitudDTO>(request);            
            PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
            try
            {
                optuSolicitudDTO = oPtuSolicitud_bo.Actualizar(optuSolicitudDTO);
                return Response.Ok(optuSolicitudDTO);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                return Response.Error(ex);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }


        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response ListarPorId([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuSolicitudDTO oPtuSolicitudDTO = APPL.FrondEnd.Request.Deserializar<PtuSolicitudDTO>(request);
            try
            {
                PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
                oPtuSolicitudDTO = oPtuSolicitud_bo.ListarPorId(oPtuSolicitudDTO.intcodsolicitud);
                return Response.Ok(oPtuSolicitudDTO);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                return Response.Error(ex);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response ListarxSolicitantexAnalista([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuSolicitud_PorAnalistaPorSolicitante vObjeto = APPL.FrondEnd.Request.Deserializar<PtuSolicitud_PorAnalistaPorSolicitante>(request);            
            try
            {
                PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
                List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_bo.ListarPorAnalistaPorSolicitante(vObjeto.intcodigosolicitante, vObjeto.intusuanalista);
                return Response.Ok(oPtuSolicitud_PorAnalistaPorSolicitanteList);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                return Response.Error(ex);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response Desistir([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuSolLicencia oPtuSolLicencia = APPL.FrondEnd.Request.Deserializar<PtuSolLicencia>(request);
            PtuSolLicencia_bo oPtuSolLicencia_bo = new PtuSolLicencia_bo(ref logMensajes);
            try
            {   
                oPtuSolLicencia_bo.Desistir(oPtuSolLicencia);
                return Response.Ok(oPtuSolLicencia);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                return Response.Error(ex);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }



    }
}
