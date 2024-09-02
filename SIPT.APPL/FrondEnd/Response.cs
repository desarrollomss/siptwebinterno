using System;

namespace SIPT.APPL.FrondEnd
{
    public class Response
    {
        public CodigoResultado resultado { get; set; }
        public string mensaje { get; set; }
        public object objeto { get; set; }

        public static Response Ok(object _objeto)
        {
            Response res = new Response();
            res.resultado = CodigoResultado.c200_OK;
            res.mensaje = "OK";
            res.objeto = _objeto;
            return res;
        }
        public static Response Error(string mensaje, string mensajeEx)
        {
            Response res = new Response();
            string mensajeTexto = mensaje;
            string mensajeExcep = mensajeEx; 
            res.resultado = CodigoResultado.c400_SolicitudIncorrecta;
            res.mensaje = $"{mensajeTexto}{Environment.NewLine}{mensajeExcep}";
            res.objeto = null;
            return res;
        }
        public static Response Error(Exception ex)
        {
            Response res = new Response();
            res.resultado = CodigoResultado.c400_SolicitudIncorrecta;
            res.mensaje = ex.Message;
            res.objeto = null;
            return res;
        }

    }

    public enum CodigoResultado
    {
        c200_OK = 200,
        c201_Creado = 201,
        c202_Aceptado = 202,
        c204_SinContenido = 204,
        c400_SolicitudIncorrecta = 400,
        c404_NoEncontrado = 404
    }
}