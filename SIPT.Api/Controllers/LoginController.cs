using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SIPT.Api.Controllers
{


    public class LoginController : ApiController
    {
        private LogMensajes logMensajes;
        private UsuarioDTO usuarioDTO;

        [HttpPost]
        [EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response Logear([FromBody] Request request) //public IHttpActionResult PostSicUser(SicUsuario sicUsuario) 
        {
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            usuarioDTO = APPL.FrondEnd.Request.Deserializar<UsuarioDTO>(request);

            try
            {
                Usuario_bo oUsuario_bo = new Usuario_bo(ref logMensajes);
                UsuarioDTO oUsuarioDTO = oUsuario_bo.Logear(usuarioDTO, request.vchaudprograma, request.vchaudequipo);
                return Response.Ok(oUsuarioDTO);
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
