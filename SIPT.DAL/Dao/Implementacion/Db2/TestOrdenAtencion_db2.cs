using System;
using RestSharp;
using SIPT.APPL.Logs;
using SIPT.DAL.Dao.Base;
using SIPT.BL.Models.Entity;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class TestOrdenAtencion_db2 : TestOrdenAtencion_dao
    {
        private LogMensajes logMensajes;

        public TestOrdenAtencion_db2(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

       
        public override int RegistrarOrden(string vchtidcodigo, string vchoradocumento, string vchoranombre, int? intadmcodigo, 
            decimal? decoratotpagar, Int16 smltricodigo, string vchaudequipo, string vchaudprograma, string vchusuario)
        {
            string vchOfiCodigo = ConfigurationManager.AppSettings["ORDATEoficodigo"];
            string vchCodEntidad = ConfigurationManager.AppSettings["ORDATEcodentidad"];
            string vchCodSistema = ConfigurationManager.AppSettings["ORDATEcodsistema"];
            string vchKey = ConfigurationManager.AppSettings["ORDATEkey"];

            string urlApi = ConfigurationManager.AppSettings["ORDATEapi"];// "http://172.16.2.28:8081/pidemss/servicios/";
            string endpoint = "ordate/reg?entidad=" + vchCodEntidad + "&sistema=" + vchCodSistema + "&key=" + vchKey;
            int numOrdAtencion = 0;
            try
            {
                var ordenAtendion = new {
                    pvchoficodigo = vchOfiCodigo,
                    pvchtidcodigo = vchtidcodigo,
                    pvchoradocumento = vchoradocumento,
                    pvchoranombre = vchoranombre,
                    pvchoradireccion = "",
                    pintadmcodigo = intadmcodigo,
                    pdecoratotpagar = decoratotpagar.ToString(),
                    listaItems = new[] { new {
                            porden = 0,
                            psmltricodigo = smltricodigo.ToString(),
                            pdecorapreunitario = decoratotpagar.ToString(),
                            pintoracantidad = 1,
                            pdecoratotpagar = decoratotpagar.ToString()
                        } },
                    pvchaudequipo = vchaudequipo,
                    pvchaudprograma = vchaudprograma,
                    pvchusuario = "8680"
                };

                JavaScriptSerializer jss = new JavaScriptSerializer();
                string data = jss.Serialize(ordenAtendion);

                var contenido = EjecutarPost(urlApi + endpoint, data);
                
                Response oResponse = JsonConvert.DeserializeObject<Response>(contenido);
                if (oResponse.codigo != "0")
                {
                    Log.Error(this.logMensajes.codigoMensaje.ToString(), oResponse.mensaje);
                }
                else
                {
                    numOrdAtencion = oResponse.contenido[0].intoranumero;
                }
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
            }

            return numOrdAtencion;
        }

        public override TestOrdenAtencion ConsultarOrden(int intoranumero)
        {
            TestOrdenAtencion oTestOrdenAtencion = new TestOrdenAtencion();
            string vchCodEntidad = ConfigurationManager.AppSettings["ORDATEcodentidad"];
            string vchCodSistema = ConfigurationManager.AppSettings["ORDATEcodsistema"];
            string vchKey = ConfigurationManager.AppSettings["ORDATEkey"];

            string urlApi = ConfigurationManager.AppSettings["ORDATEapi"];
            string endpoint = "ordate/con?PINTORANUMERO="+ intoranumero + "&entidad=" + vchCodEntidad + "&sistema=" + vchCodSistema + "&key=" + vchKey;                                    
            try
            {
                var contenido = EjecutarGet(urlApi, endpoint);
                Response oResponse = JsonConvert.DeserializeObject<Response>(contenido);
                if (oResponse.codigo != "0")
                {
                    Log.Error(this.logMensajes.codigoMensaje.ToString(), oResponse.mensaje);
                }
                else
                {
                    oTestOrdenAtencion.intordennumero = oResponse.contenido[0].intoranumero;
                    oTestOrdenAtencion.vchestadodescripcion = oResponse.contenido[0].vcheoadescri;
                    oTestOrdenAtencion.datfechacreacion = oResponse.contenido[0].tmsaudfeccreacion;
                    oTestOrdenAtencion.decordentotalpagar = oResponse.contenido[0].decoratotpagar;
                }
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
            }

            return oTestOrdenAtencion;
        }

        public override int ObtenerIdReporteLicencia(int? intintcodlicencia)
        {
            int codigoReporte = 0;
            string nombrerpt = ConfigurationManager.AppSettings["GENREPnombrerpt"];
            string nombreId = ConfigurationManager.AppSettings["GENREPnombreId"];

            string urlApi = ConfigurationManager.AppSettings["GENREPapi"];
            string endpoint = ConfigurationManager.AppSettings["GENREPenpoint"]; ;
            endpoint = endpoint + "?" + nombreId + "=" + intintcodlicencia.ToString() + "&opc=" + nombrerpt;
            try
            {
                var contenido = EjecutarGet(urlApi, endpoint);
                codigoReporte = Convert.ToInt32(contenido);
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
            }

            return codigoReporte;
        }



        private string EjecutarPost(string urlApiEndpoint, string json)
        {
            var request = (HttpWebRequest)WebRequest.Create(urlApiEndpoint);            
            request.Method = "POST";
            request.ContentType = "application/json";
            //request.Accept = "application/json";

            string responseBody = "";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }
            return responseBody;
        }

        private string EjecutarGet(string urlApiEndpoint, string filtro)
        {
            var url = $"" + urlApiEndpoint + filtro;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            //request.Accept = "application/json"; 
            string responseBody = "";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }
            return responseBody;
        }

    }


    
    public class Contenido
    {
        public int intoranumero { get; set; }
        public string vcheoadescri { get; set; }
        public DateTime tmsaudfeccreacion { get; set; }
        public decimal decoratotpagar { get; set; }
    }

    public class Response
    {
        public string codigo { get; set; }
        public string mensaje { get; set; }
        public Contenido[] contenido {get; set;}
    }

}
