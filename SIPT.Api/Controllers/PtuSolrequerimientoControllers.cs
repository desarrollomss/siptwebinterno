using Microsoft.Office.Interop.Word;
using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Services;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SIPT.Api.Controllers
{
    public class PtuSolrequerimientoController : ApiController
	{
		private LogMensajes logMensajes;

		[HttpPost]
		[EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
		public Response Insertar([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = APPL.FrondEnd.Request.Deserializar<PtuSolrequerimientoDTO>(request);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				oPtuSolrequerimientoDTO = oPtuSolrequerimiento_bo.Insertar(oPtuSolrequerimientoDTO);
				return Response.Ok(oPtuSolrequerimientoDTO);
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

			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = APPL.FrondEnd.Request.Deserializar<PtuSolrequerimientoDTO>(request);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				oPtuSolrequerimiento_bo.Actualizar(oPtuSolrequerimientoDTO);
				return Response.Ok(oPtuSolrequerimientoDTO);
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

			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = APPL.FrondEnd.Request.Deserializar<PtuSolrequerimientoDTO>(request);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				oPtuSolrequerimiento_bo.Eliminar(oPtuSolrequerimientoDTO.intsolicitudplantilla);
				return Response.Ok(oPtuSolrequerimientoDTO);
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
		public Response Listar([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = oPtuSolrequerimiento_bo.Listar();
				return Response.Ok(oPtuSolrequerimientoDTOList);
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
		public Response ListarKey([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = APPL.FrondEnd.Request.Deserializar<PtuSolrequerimientoDTO>(request);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				oPtuSolrequerimientoDTO = oPtuSolrequerimiento_bo.ListarKey(oPtuSolrequerimientoDTO.intsolicitudplantilla);
				return Response.Ok(oPtuSolrequerimientoDTO);
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
		public Response ListarKeys([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = APPL.FrondEnd.Request.Deserializar<PtuSolrequerimientoDTO>(request);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = oPtuSolrequerimiento_bo.ListarKeys(
								oPtuSolrequerimientoDTO.intsolicitudplantilla,
								oPtuSolrequerimientoDTO.intcodplantilla,
								oPtuSolrequerimientoDTO.intcodsolicitud,
								oPtuSolrequerimientoDTO.smlevaluacion,
								oPtuSolrequerimientoDTO.smlestadodocumento);
				return Response.Ok(oPtuSolrequerimientoDTOList);
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
		public Response ListarRequerimientosPorSolicitud([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = APPL.FrondEnd.Request.Deserializar<PtuSolrequerimientoDTO>(request);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = new List<PtuSolrequerimientoDTO>();
				if (oPtuSolrequerimientoDTO.intcodsolicitud != 0)
				{
					oPtuSolrequerimientoDTOList = oPtuSolrequerimiento_bo.ListarRequerimientosPorSolicitud(oPtuSolrequerimientoDTO.intcodsolicitud);
				}
				return Response.Ok(oPtuSolrequerimientoDTOList);
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
		public Response ListarSolReqGrupo([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = APPL.FrondEnd.Request.Deserializar<PtuSolrequerimientoDTO>(request);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				object oModelo = oPtuSolrequerimiento_bo.ListarSolReqGrupo(oPtuSolrequerimientoDTO.intsolicitudplantilla);				
				return Response.Ok(oModelo);
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
		public Response GuardarRequerimiento([FromBody] Request request)
		{
			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
			var objetos = APPL.FrondEnd.Request.DeserializarDictionary(request.objeto.ToString());

			string directorio = ConfigurationManager.AppSettings["RutaPlantillas"]; //"Requerimientos/"; // 
			int intsolicitudplantilla = Convert.ToInt32(objetos["intsolicitudplantilla"].ToString());

			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
			try
			{
				PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = oPtuSolrequerimiento_bo.GuardarRequerimiento(objetos);
				string documento = oPtuSolrequerimientoDTO.intcodsolicitud.ToString() + "." + oPtuSolrequerimientoDTO.vchdocplantilla;
				oPtuSolrequerimientoDTO.vchdocrequerimiento = documento;
				oPtuSolrequerimientoDTO.tmsfechadocumento = DateTime.Now;
				oPtuSolrequerimientoDTO.smlestadodocumento = 40;

				if (!System.IO.Directory.Exists(directorio))
                {
					throw new Exception("No existe el directorio");
				}

                /*try
				{
					using (FileStream fs = File.Create(Path.Combine(directorio, "AccessTemp.txt"), 1, FileOptions.DeleteOnClose))
					{
						fs.Close();
					}
				}
				catch (Exception ex)
				{
					throw new Exception("No se tiene permiso de escritura en el directorio");
				}*/

                try
                {
					BytesAArchivo(oPtuSolrequerimientoDTO.blbdocplantilla, directorio + documento);
				}
				catch(Exception ex)
                {
					logMensajes.error = ex;
					Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, "BytesAArchivo : " + ex.Message);
					throw ex;
				}

				//Document document = new Document();
				try
				{
					// generar PDF		
					Microsoft.Office.Interop.Word.Document myWordDoc = null;			
					Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
					object missing = System.Reflection.Missing.Value;
					object readOnly = false;
					myWordDoc = wordApp.Documents.Open(@"" + directorio + documento, ref missing, ref readOnly,
														ref missing, ref missing, ref missing,
														ref missing, ref missing, ref missing,
														ref missing, ref missing, ref missing,
														 true, ref missing, ref missing, ref missing);

					myWordDoc.Activate();

					List<PtuPlantillareqvalores> valores = oPtuSolrequerimiento_bo.ListarValores(intsolicitudplantilla);
					foreach (PtuPlantillareqvalores valor in valores)
					{
						string dato = valor.vchvalor is null ? "" : valor.vchvalor;
						if (valor.vchtipovalor == "TextoS")
						{
							dato = dato.Replace("<I>", "- ");
							dato = dato.Replace("<S>", "\n");
							//document.Replace(valor.vchetiqueta, dato, false, true);
							FindAndReplace(wordApp, valor.vchetiqueta, dato);							
						}
						else if (valor.vchtipovalor == "CheckBoxBinario")
						{
							string nuevoValor = valor.vchetiqueta.Substring(0, valor.vchetiqueta.Length - 1);
							nuevoValor = nuevoValor + "!";
							if (dato == "X")
							{
								//document.Replace(valor.vchetiqueta, dato, false, true);
								//document.Replace(nuevoValor, "", false, true);
								FindAndReplace(wordApp, valor.vchetiqueta, dato);
								FindAndReplace(wordApp, nuevoValor, "");								
							}
							else
							{
								//document.Replace(valor.vchetiqueta, "", false, true);
								//document.Replace(nuevoValor, "X", false, true);
								FindAndReplace(wordApp, valor.vchetiqueta, "");
								FindAndReplace(wordApp, nuevoValor, "X");								
							}
						}
						else
						{
							//document.Replace(valor.vchetiqueta, dato, false, true);
							FindAndReplace(wordApp, valor.vchetiqueta, dato);							
						}
					}
					string filename = directorio + documento;
					filename = filename.Replace("docx", "pdf");
					myWordDoc.ExportAsFixedFormat(@"" + filename, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
					object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
					((_Document)myWordDoc).Close(ref saveChanges, ref missing, ref missing);

					((_Application)wordApp).Quit(ref missing, ref missing, ref missing);

					wordApp = null;
					myWordDoc = null;

					//wordApp.ActiveDocument.SaveAs2(@"" + directorio + documento);
					//myWordDoc.Close();

					/*document.LoadFromFile(@"" + directorio + documento);
					List<PtuPlantillareqvalores> valores = oPtuSolrequerimiento_bo.ListarValores(intsolicitudplantilla);
					foreach (PtuPlantillareqvalores valor in valores)
					{
						string dato = valor.vchvalor is null ? "" : valor.vchvalor;
						if (valor.vchtipovalor == "TextoS")
						{
							dato = dato.Replace("<I>", "- ");
							dato = dato.Replace("<S>", "\n");
							document.Replace(valor.vchetiqueta, dato, false, true);
						}
						else if (valor.vchtipovalor == "CheckBoxBinario")
						{
							string nuevoValor = valor.vchetiqueta.Substring(0, valor.vchetiqueta.Length-1);
							nuevoValor = nuevoValor + "!";
							if(dato == "X")
							{
								document.Replace(valor.vchetiqueta, dato, false, true);
								document.Replace(nuevoValor, "", false, true);
							}
							else
							{
								document.Replace(valor.vchetiqueta, "", false, true);
								document.Replace(nuevoValor, "X", false, true);
							}
						}
						else
						{
							document.Replace(valor.vchetiqueta, dato, false, true);
						}

					}*/

				}
				catch (Exception ex)
				{
					logMensajes.error = ex;
					Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, "LoadFromFile : " + ex.Message);
					throw ex;
				}				

				try
				{
					//document.SaveToFile(@"" + directorio + documento, FileFormat.Docx);

					documento = documento.Replace("docx", "pdf");
					//document.SaveToFile(@"" + directorio + documento, FileFormat.PDF);
				}
				catch (Exception ex)
				{
					logMensajes.error = ex;
					Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, "SaveToFile : " + ex.Message);
					throw ex;
				}

				/*
				string filename = directorio + documento;
				Microsoft.Office.Interop.Word.Document myWordDoc = null;

				try
				{
					// generar PDF					
					Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
					object missing = Missing.Value;
					object readOnly = false;					
					myWordDoc = wordApp.Documents.Open(filename, ref missing, ref readOnly,
														ref missing, ref missing, ref missing,
														ref missing, ref missing, ref missing,
														ref missing, ref missing, ref missing,
														 ref missing, ref missing, ref missing, ref missing);

					
				}
				catch (Exception ex)
				{
					logMensajes.error = ex;
					Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, "Interop.Word : " + ex.Message);
					throw ex;
				}

				try
				{
					// guardar PDF en ruta
					filename = filename.Replace("docx", "pdf");
					myWordDoc.ExportAsFixedFormat(@"" + filename, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
					myWordDoc.Close();
				}
                catch (Exception ex)
                {
					logMensajes.error = ex;
					Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, "ExportAsFixedFormat : " + ex.Message);
					throw ex;
				}*/

				oPtuSolrequerimientoDTO.vchdocrequerimiento = documento; //.Replace("docx", "pdf");
				oPtuSolrequerimiento_bo.Actualizar(oPtuSolrequerimientoDTO);

				return Response.Ok(null);
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


		private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
		{
			//options
			object matchCase = false;
			object matchWholeWord = true;
			object matchWildCards = false;
			object matchSoundsLike = false;
			object matchAllWordForms = false;
			object forward = true;
			object format = false;
			object matchKashida = false;
			object matchDiacritics = false;
			object matchAlefHamza = false;
			object matchControl = false;
			object read_only = false;
			object visible = true;
			object replace = 2;
			object wrap = 1;
			//execute find and replace
			doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
				ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
				ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
		}



		[HttpGet]
		[EnableCors(origins: Constantes.CorsOrigins, headers: Constantes.CorsHeaders, methods: Constantes.CorsMethods)]
		public HttpResponseMessage GetObtenerPDF(int intsolicitudplantilla)
		{
			Request request = new Request();
			request.vchaudprograma = "";
			request.vchopcion = "";
			request.vchconnombre = "";
			request.vchaudcodusuario = "";
			request.vchaudequipo = "";

			logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
			PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);

			try
			{
				PtuSolrequerimientoDTO oPtuSolrequerimientoDTO = oPtuSolrequerimiento_bo.ListarKey(intsolicitudplantilla);

				string directorio = ConfigurationManager.AppSettings["RutaPlantillas"];
				string reqBook = directorio + oPtuSolrequerimientoDTO.vchdocrequerimiento;
				string bookName = oPtuSolrequerimientoDTO.vchdocrequerimiento;
				
				var dataBytes = File.ReadAllBytes(reqBook);				
				var dataStream = new MemoryStream(dataBytes);

				HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
				httpResponseMessage.Content = new StreamContent(dataStream);
				httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
				httpResponseMessage.Content.Headers.ContentDisposition.FileName = bookName;
				httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

				return httpResponseMessage;

			}
			catch (System.Exception ex)
			{
				logMensajes.error = ex;
				return null;
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
					fs.Close();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

	}
}
