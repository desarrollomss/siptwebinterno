﻿using RestSharp;
using SIPT.APPL.FrondEnd;
using System;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SIPT.APPL.Logs
{
    public class LogMensajes : IDisposable
    {
        public  Guid? codigoMensaje;
        private  string programa;
        private  string opcion;
        private  string control;
        private  string usuario;
        private  string equipo;
        private  string nodo;
        private  DateTime inicio;
        private  DateTime termino;
        private  double tiempo;

        private int intcodmensaje;
        private string vchmensaje;
        
        public string MensajeError = "";
        
        public LogMensajes(Request request)
        {   
            opcion = request.vchopcion;
            control = request.vchconnombre;

            usuario = request.vchaudcodusuario;
            programa = request.vchaudprograma;
            equipo = request.vchaudequipo;

            codigoMensaje = Guid.NewGuid();
            inicio = DateTime.Now;
            nodo = ConfigurationManager.AppSettings["Nodo"];
            Log.Info(codigoMensaje.ToString(), "Inicio de Opción: " + opcion + "." + control);
        }

        public LogMensajes(Request request, string vchconnombre)
        {
            opcion = request.vchopcion;
            control = vchconnombre;

            usuario = request.vchaudcodusuario;
            programa = request.vchaudprograma;
            equipo = request.vchaudequipo;

            codigoMensaje = Guid.NewGuid();
            inicio = DateTime.Now;
            nodo = ConfigurationManager.AppSettings["Nodo"];
            Log.Info(codigoMensaje.ToString(), "Inicio de Opción: " + opcion + "." + control);
        }

        public int Intcodmensaje
        {
            set { this.intcodmensaje = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
        }

        public string Equipo
        {
            get { return this.equipo; }
        }

        public string Programa
        {
            get { return this.programa; }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public Response FinSolicitud(Response response = null)
        {
            termino = DateTime.Now;
            TimeSpan tsTiempo = termino - inicio;
            tiempo = tsTiempo.TotalSeconds;

            string conApiLog = ConfigurationManager.AppSettings["ConApiLog"];
            nodo = ConfigurationManager.AppSettings["Nodo"];

            if (conApiLog == "S")
            {
                string urlApiLog = ConfigurationManager.AppSettings["UrlApiLog"];

                //var client0 = new RestClient(urlApiLog);
                //var request0 = new RestRequest("SisLogmensajes");
                //var response0 = client0.ExecuteGet(request0);
                //var data = JsonSerializer.Deserialize<JsonNode>(response0.Content);
                if(MensajeError != "")
                {
                    //this.intcodmensaje = 1;
                    this.vchmensaje = MensajeError;
                }
                else
                {
                    this.intcodmensaje = 0;
                    this.vchmensaje = "TRANSACCION REALIZADA CORRECTAMENTE";
                }

                var client = new RestClient(urlApiLog);
                var request = new RestRequest("SisLogmensajes");
                SisLogmensajes sisLogmensajes = new SisLogmensajes();

                //string jsonPost = "{" +
                //    "\"vchcodlogmensajes\" : \"" + codigoMensaje.ToString() + "\", " +
                //    "\"datfecha\" : \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\", " +
                //    "\"tmsfecha\" : \"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-05:00\", " +
                //    "\"vchaplicacion\" : \"" + programa + "\", " +
                //    "\"vchopcion\" : \"" + opcion + "\", " +
                //    "\"vchconnombre\" : \"" + control + "\", " +
                //    "\"dectiempo\" : " + tiempo.ToString() + ", " +
                //    "\"vchcodmensaje\" : \"" + this.intcodmensaje.ToString() + "\", " +
                //    "\"vchmensaje\" : \"" + this.vchmensaje + "\", " +
                //    "\"vchcodusuario\" : \"" + usuario + "\", " +
                //    "\"vchequipo\" : \"" + equipo + "\", " +
                //    "\"vchnodo\" : \"" + nodo + "\"" +
                //    "}";

                //request.AddJsonBody(jsonPost);

                request.AddBody(
                    new
                    {
                        vchcodlogmensajes = codigoMensaje,
                        datfecha = DateTime.Now.ToString("yyyy-MM-dd"),
                        tmsfecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-05:00",
                        vchaplicacion = this.programa,
                        vchopcion = opcion,
                        vchconnombre = control,
                        dectiempo = tiempo,
                        vchcodmensaje = this.intcodmensaje,
                        vchmensaje = this.vchmensaje,
                        vchcodusuario = usuario,
                        vchequipo = equipo,
                        vchnodo = nodo
                    });

                var vresponse = client.ExecutePost(request);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                if(response is null)
                {
                    response = new Response();
                }
                JsonNode product = null;
                try
                {
                    product = JsonSerializer.Deserialize<JsonNode>(vresponse.Content, options);

                    if (product.ToString().Substring(0, 1) == "0")
                    {
                        response.resultado = CodigoResultado.error;
                        response.titulo = "Error en servicio externo: SisLogmensajes!";
                        response.mensaje = "(2003) " + product.ToString();

                        Log.Error(codigoMensaje.ToString(), response.titulo+": "+ response.mensaje);
                    }
                }
                catch (Exception ex)
                {
                    response.resultado = CodigoResultado.error;
                    response.titulo = "Error de conexión a servicio!";
                    response.mensaje = "(2002) Error al intentar comunicarse con el servicio: SisLogmensajes: " + ex.Message;

                    //Log.Error(codigoMensaje.ToString(), response.mensaje + ": " + jsonPost + ". PILA: " + ex.StackTrace);
                    Log.Error(codigoMensaje.ToString(), response.mensaje + ". PILA: " + ex.StackTrace);
                }

                
            }            

            Log.Info(codigoMensaje.ToString(), "Termino de Opción");

            this.Dispose();

            return response;

        }
    }
}