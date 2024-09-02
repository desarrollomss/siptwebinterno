using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Services;
using System.Web.Http.Cors;
using System.Web.Http;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.Api.Controllers
{
    public class OrdenAtencionController : ApiController
    {
        private LogMensajes logMensajes;
        private TestOrdenAtencionDTO testOrdenAtencionDTO;
        private PtuSolicitudDTO ptuSolicitudDTO;
        private List<StdDocumento_InsertaResultado> ListStdDocumento_InsertaResultado;
        private List<PtuLicenciaDTO> ptuLicenciaDTOList;

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response Registrar([FromBody] Request request) 
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);            
            ptuSolicitudDTO = APPL.FrondEnd.Request.Deserializar<PtuSolicitudDTO>(request);            
            try
            {
                TestOrdenAtencion_bo oTestOrdenAtencion_bo = new TestOrdenAtencion_bo(ref logMensajes);
                testOrdenAtencionDTO = oTestOrdenAtencion_bo.RegistrarOrden(ptuSolicitudDTO.intcodsolicitud, ptuSolicitudDTO.vchtidcodigosol,
                                            ptuSolicitudDTO.vchnrodocumentosol, ptuSolicitudDTO.intcodigosolicitante, ptuSolicitudDTO.intcodigoprocedimiento,
                                            request.vchaudprograma, request.vchaudequipo, request.vchaudcodusuario);
                                
                return Response.Ok(testOrdenAtencionDTO);
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
        public Response Consultar([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            ptuSolicitudDTO = APPL.FrondEnd.Request.Deserializar<PtuSolicitudDTO>(request);

            try
            {
                TestOrdenAtencion_bo oTestOrdenAtencion_bo = new TestOrdenAtencion_bo(ref logMensajes);
                TestOrdenAtencionDTO oTestOrdenAtencionDTO = oTestOrdenAtencion_bo.ConsultarOrdenPorSolicitud(ptuSolicitudDTO);
                
                return Response.Ok(oTestOrdenAtencionDTO);
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
        public Response ConsultarLicencia([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            ptuSolicitudDTO = APPL.FrondEnd.Request.Deserializar<PtuSolicitudDTO>(request);

            try
            {
                PtuLicencia_bo ptuLicencia_bo = new PtuLicencia_bo(ref logMensajes);
                TestOrdenAtencion_bo testOrdenAtencion_bo = new TestOrdenAtencion_bo(ref logMensajes);

                ptuLicenciaDTOList = ptuLicencia_bo.ListarKeys(0, ptuSolicitudDTO.intcodsolicitud);

                if (ptuLicenciaDTOList == null || ptuLicenciaDTOList.Count == 0)
                {
                    return Response.Ok(null);
                }
                ptuLicenciaDTOList[0].intreporteid = testOrdenAtencion_bo.ObtenerIdReporteLicencia(ptuLicenciaDTOList[0].intcodlicencia);
                
                return Response.Ok(ptuLicenciaDTOList[0]);
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
    }
}