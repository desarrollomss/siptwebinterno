using System;

namespace SIPT.APPL.FrondEnd
{
    public class Response
    {
        public CodigoResultado resultado { get; set; }
        public string mensaje { get; set; }
        public string descripcion { get; set; }
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
            Type tipo = ex.GetType();
            string mensajeTexto = "Se produjo un error interno del Servidor";
            string mensajeExcep = "";
            switch (tipo.Name)
            {
                // Generico (SystemException) 
                case "IndexOutOfRangeException":
                    mensajeExcep = "Indice está fuera de los límites de la colección.";
                    break;
                case "NullReferenceException":
                    mensajeExcep = "El valor al que se quiere acceder es Nulo.";
                    break;
                case "OutOfMemoryException":
                    mensajeExcep = "No hay memoria suficiente.";
                    break;

                // Aritmetico 
                case "DivideByZeroException":
                    mensajeExcep = "Error en division por cero.";
                    break;
                case "OverflowException":
                    mensajeExcep = "Desbordamiento en la conversión de tipo de datos.";
                    break;
                case "NotFiniteNumberException":
                    mensajeExcep = "El valor es infinito o no Numerico.";
                    break;

                // De Argumento 
                case "ArgumentNullException":
                    mensajeExcep = "Uno argumento obligatorio del método es Nulo.";
                    break;
                case "ArgumentOutOfRangeException":
                    mensajeExcep = "El valor de un argumento está fuera del intervalo de valores permitido.";
                    break;

                // IOException
                case "EndOfStreamException":
                    mensajeExcep = "El número de bytes a superado la secuencia y no se puede leer más allá del final de la secuencia.";
                    break;
                case "FileNotFoundException":
                    mensajeExcep = "Error al intentar acceder a un archivo que no existe en el disco.";
                    break;
                case "DirectoryNotFoundException":
                    mensajeExcep = "No se encuentra el directorio.";
                    break;

                default:
                    mensajeExcep = ex.Message;
                    break;
            }
            res.mensaje = mensajeTexto;
            res.descripcion = mensajeExcep;
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