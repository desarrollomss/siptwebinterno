using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SIPT.Api.Controllers
{
    public class PtuUsoController : ApiController
    {
        private LogMensajes logMensajes;

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response Insertar([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuUso oPtuUso = APPL.FrondEnd.Request.Deserializar<PtuUso>(request);
            try
            {
                PtuUso_bo oPtuUso_bo = new PtuUso_bo(ref logMensajes);
                oPtuUso_bo.Insertar(oPtuUso);
                return Response.Ok(oPtuUso);
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
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuUso oPtuUso = APPL.FrondEnd.Request.Deserializar<PtuUso>(request);
            try
            {
                PtuUso_bo oPtuUso_bo = new PtuUso_bo(ref logMensajes);
                oPtuUso_bo.Actualizar(oPtuUso);
                return Response.Ok(oPtuUso);
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

        [HttpDelete]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response Eliminar([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            PtuUso oPtuUso = APPL.FrondEnd.Request.Deserializar<PtuUso>(request);
            try
            {
                PtuUso_bo oPtuUso_bo = new PtuUso_bo(ref logMensajes);
                oPtuUso_bo.Eliminar(oPtuUso);
                return Response.Ok(oPtuUso);
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

            PtuUso oPtuUso = APPL.FrondEnd.Request.Deserializar<PtuUso>(request);
            try
            {
                PtuUso_bo oPtuUso_bo = new PtuUso_bo(ref logMensajes);
                oPtuUso = oPtuUso_bo.ListarPorId(oPtuUso.intcoduso);
                return Response.Ok(oPtuUso);
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
        public Response ListarPorFiltro([FromBody] Request request)
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                PtuUso oPtuUso = new PtuUso();  // SolicitudFrond.Deserializar<PtuUso>(pSolicitudFrond.objeto);
                PtuUso_bo oPtuUso_bo = new PtuUso_bo(ref logMensajes);
                oPtuUso.vchnombreuso = "";
                List<PtuUsoDTO> oPtuUsoDTOList = oPtuUso_bo.ListarPorFiltro(oPtuUso);
                return Response.Ok(oPtuUsoDTOList);
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
