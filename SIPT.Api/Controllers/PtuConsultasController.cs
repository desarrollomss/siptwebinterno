using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SIPT.Api.Controllers
{
    public class PtuUbicacionesController : ApiController
    {
        private LogMensajes logMensajes;
        private string nomClase = "Ubicaciones";

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response ListarUbicaciones([FromBody] Request request)
        {
            string nomMetodo = "ListarUbicaciones";
            logMensajes = new LogMensajes(request, this.ToString(), nomMetodo);

            PtuUbicaciones oPtuUbicaciones = APPL.FrondEnd.Request.Deserializar<PtuUbicaciones>(request);            
            try
            {
                PtuConsultas_bo oPtuConsultas_bo = new PtuConsultas_bo(ref logMensajes);
                List<PtuUbicaciones> oPtuUbicacionesList = oPtuConsultas_bo.Ubicaciones_ListarPorFiltro(oPtuUbicaciones);
                return Response.Ok(oPtuUbicacionesList);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), nomClase, nomMetodo, ex.Message);
                return Response.Error(ex);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }

    }

    public class ConAdministradoController : ApiController
    {
        private LogMensajes logMensajes;
        private string nomClase = "Administrado";

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response ListarAdministrados([FromBody] Request request)
        {
            string nomMetodo = "ListarAdministrados";
            logMensajes = new LogMensajes(request, this.ToString(), nomMetodo);

            ConAdministrado oConAdministrado = APPL.FrondEnd.Request.Deserializar<ConAdministrado>(request);
            try
            {
                ConAdministrado_bo oConAdministrado_bo = new ConAdministrado_bo(ref logMensajes);
                List<ConAdministrado> oConAdministradoList = oConAdministrado_bo.ListarPorFiltro(oConAdministrado);
                return Response.Ok(oConAdministradoList);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), nomClase, nomMetodo, ex.Message);
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
            string nomMetodo = "ListarPorId";
            logMensajes = new LogMensajes(request, this.ToString(), nomMetodo);

            ConAdministrado oConAdministrado = APPL.FrondEnd.Request.Deserializar<ConAdministrado>(request);
            try
            {
                ConAdministrado_bo oConAdministrado_bo = new ConAdministrado_bo(ref logMensajes);
                oConAdministrado = oConAdministrado_bo.ListarplataformaPorId(oConAdministrado.intadmcodigo);
                return Response.Ok(oConAdministrado);
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), nomClase, nomMetodo, ex.Message);
                return Response.Error(ex);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }
    }  

}

