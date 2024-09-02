using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;

namespace SIPT.Api.Controllers
{
	public class PtuTablaController : ApiController
	{
		private LogMensajes logMensajes;

		[HttpPost]
		[EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
		public Response Insertar([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuTablaDTO oPtuTablaDTO = APPL.FrondEnd.Request.Deserializar<PtuTablaDTO>(request);
			PtuTabla_bo oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);
			try
			{
				oPtuTablaDTO = oPtuTabla_bo.Insertar(oPtuTablaDTO);
				return Response.Ok(oPtuTablaDTO);
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

			PtuTablaDTO oPtuTablaDTO = APPL.FrondEnd.Request.Deserializar<PtuTablaDTO>(request);
			PtuTabla_bo oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);
			try
			{
				oPtuTabla_bo.Actualizar(oPtuTablaDTO);
				return Response.Ok(oPtuTablaDTO);
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

			PtuTablaDTO oPtuTablaDTO = APPL.FrondEnd.Request.Deserializar<PtuTablaDTO>(request);
			PtuTabla_bo oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);
			try
			{
				oPtuTabla_bo.Eliminar(oPtuTablaDTO.smlcodtabla);
				return Response.Ok(oPtuTablaDTO);
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

		[HttpPatch]
		[EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
		public Response Listar([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuTabla_bo oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);
			try
			{
				List<PtuTablaDTO> oPtuTablaDTOList = oPtuTabla_bo.Listar();
				return Response.Ok(oPtuTablaDTOList);
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

		[HttpPatch]
		[EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
		public Response ListarKey([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuTablaDTO oPtuTablaDTO = APPL.FrondEnd.Request.Deserializar<PtuTablaDTO>(request);
			PtuTabla_bo oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);
			try
			{
				oPtuTablaDTO = oPtuTabla_bo.ListarKey(oPtuTablaDTO.smlcodtabla);
				return Response.Ok(oPtuTablaDTO);
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
		public Response ListarTiposTramite([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuTablaDTO oPtuTablaDTO = APPL.FrondEnd.Request.Deserializar<PtuTablaDTO>(request);
			PtuTabla_bo oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);
			try
			{
				List<PtuTablaDTO> oPtuTablaDTOList = oPtuTabla_bo.ListarTiposTramite(
								oPtuTablaDTO.smlcodtabla,
								oPtuTablaDTO.smlestado);
				return Response.Ok(oPtuTablaDTOList);
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
