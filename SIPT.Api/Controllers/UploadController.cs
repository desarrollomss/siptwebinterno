using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Configuration;
using System;
using SIPT.BL.Services;
using SIPT.BL.DTO.DTO;
using System.IO;
using SIPT.BL.Models.Entity;

namespace SIPT.Api.Controllers
{

    public class UploadController : ApiController
    {
		private LogMensajes logMensajes;		

		[HttpPost]
		[EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
        public Response CargarRequerimiento()
        {
			Request request = new Request();
			request.vchaudprograma = HttpContext.Current.Request.Form["vchaplicacion"].ToString();
			request.vchopcion = HttpContext.Current.Request.Form["vchopcion"].ToString();
			request.vchconnombre = HttpContext.Current.Request.Form["vchconnombre"].ToString();
			request.vchaudcodusuario = HttpContext.Current.Request.Form["vchcodusuario"].ToString();
			request.vchaudequipo = HttpContext.Current.Request.Form["vchequipo"].ToString();

			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			var httpRequest = HttpContext.Current.Request;

			string directorio = ConfigurationManager.AppSettings["RutaPlantillas"];
			int intsolicitudplantilla = Convert.ToInt32(HttpContext.Current.Request.Form["id"].ToString());


			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = oPtuSolrequerimiento_bo.ListarKey(intsolicitudplantilla);

				oPtuSolrequerimientoDTO.tmsfechadocumento = DateTime.Now;
				oPtuSolrequerimientoDTO.smlestadodocumento = 41;

				if (httpRequest.Files.Count > 0)
				{
					byte[] archivo;
					var docfiles = new List<string>();
					using (Stream inputStream = httpRequest.InputStream)
					{
						using (MemoryStream memoryStream = new MemoryStream())
						{
							inputStream.CopyTo(memoryStream);
							archivo = memoryStream.ToArray();
						}
						BytesAArchivo(archivo, directorio + oPtuSolrequerimientoDTO.vchdocrequerimiento);
					}

					/*foreach (string file in httpRequest.Files)
					{
						var postedFile = httpRequest.Files[file];						

						var filePath = HttpContext.Current.Server.MapPath(directorio + oPtuSolrequerimientoDTO.vchdocrequerimiento);
						postedFile.SaveAs(filePath);
						docfiles.Add(filePath);
					}*/
					//result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
				}
				oPtuSolrequerimiento_bo.Actualizar(oPtuSolrequerimientoDTO);

				List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList1 = oPtuSolrequerimiento_bo.ListarKeys(0, 0, oPtuSolrequerimientoDTO.intcodsolicitud, Convert.ToInt16(0), Convert.ToInt16(41));
				List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList2 = oPtuSolrequerimiento_bo.ListarKeys(0, 0, oPtuSolrequerimientoDTO.intcodsolicitud, Convert.ToInt16(0), Convert.ToInt16(0));
				if(oPtuSolrequerimientoDTOList1.Count == oPtuSolrequerimientoDTOList2.Count)
                {
					PtuSolLicencia_bo oPtuSolLicencia_bo = new PtuSolLicencia_bo(ref logMensajes);
					PtuSolLicencia oPtuSolLicencia = new PtuSolLicencia();
					oPtuSolLicencia.intcodsolicitud = oPtuSolrequerimientoDTO.intcodsolicitud;
					oPtuSolLicencia.smlestsollicencia = 37;
					oPtuSolLicencia_bo.Actualizar(oPtuSolLicencia);
				}

				return Response.Ok(null);

			}
			catch (Exception ex)
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

		private void BytesAArchivo(byte[] bytes, string Path)
		{
			long K;
			if (bytes == null)
				return;
			try
			{
				K = bytes.Length - 1;
				using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write))
				{
					fs.Write(bytes, 0, (int)K);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

	}
}