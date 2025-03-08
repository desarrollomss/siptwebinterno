using SIPT.APPL.Logs;
using System;

namespace SIPT.APPL.FrondEnd
{
    public class Response
    {
        public CodigoResultado resultado { get; set; }
        public string mensaje { get; set; }
        public string titulo { get; set; }
        public object objeto { get; set; }

        public static Response Ok(LogMensajes logMensaje)
        {
            Response res = new Response();
            res.resultado = CodigoResultado.success;
            res.titulo = "Exito !";
            res.mensaje = "";
            res.objeto = null;

            logMensaje.FinSolicitud();

            return res;
        }
        public static Response OkGuardar(LogMensajes logMensaje, string entidad = "")
        {
            Response res = new Response();
            res.resultado = CodigoResultado.success;
            res.titulo = "Exito !";
            res.mensaje = "Se Registró correctamente "+ entidad;
            res.objeto = null;

            logMensaje.FinSolicitud();

            return res;
        }
        public static Response OkBorrar(LogMensajes logMensaje, string entidad = "")
        {
            Response res = new Response();
            res.resultado = CodigoResultado.success;
            res.titulo = "Exito !";
            res.mensaje = "Se Borró correctamente " + entidad;
            res.objeto = null;

            logMensaje.FinSolicitud();

            return res;
        }

        /*public static Response Ok(object objeto, LogMensajes logMensaje)
        {
            Response res = new Response();
            res.resultado = CodigoResultado.success;
            res.titulo = "Exito!";
            res.mensaje = "";
            res.objeto = objeto;

            logMensaje.FinSolicitud();

            return res;
        }*/

        public static Response Error(Exception ex, LogMensajes logMensaje)
        {
            Response res = new Response();
            res.resultado = CodigoResultado.error;

            Type tipo = ex.GetType();
            res.titulo = "Error interno del Servidor!";
            string codigoError = "0";

            switch (tipo.Name)
            {
                // Generico (SystemException) 
                case "IndexOutOfRangeException":
                    codigoError = "601";
                    res.mensaje = "(" + codigoError + ") Indice está fuera de los límites de la colección.";
                    break;
                case "NullReferenceException":
                    codigoError = "602";
                    res.mensaje = "(" + codigoError + ") El valor al que se quiere acceder es Nulo.";
                    break;
                case "OutOfMemoryException":
                    codigoError = "603";
                    res.mensaje = "(" + codigoError + ") No hay memoria suficiente.";
                    break;

                // Aritmetico 
                case "DivideByZeroException":
                    codigoError = "701";
                    res.mensaje = "(" + codigoError + ") Error en division por cero.";
                    break;
                case "OverflowException":
                    codigoError = "702";
                    res.mensaje = "(" + codigoError + ") Desbordamiento en la conversión de tipo de datos.";
                    break;
                case "NotFiniteNumberException":
                    codigoError = "703";
                    res.mensaje = "(" + codigoError + ") El valor es infinito o no Numerico.";
                    break;

                // De Argumento 
                case "ArgumentNullException":
                    codigoError = "704";
                    res.mensaje = "(" + codigoError + ") Un argumento obligatorio del método es Nulo.";
                    break;
                case "ArgumentOutOfRangeException":
                    codigoError = "705";
                    res.mensaje = "(" + codigoError + ") El valor de un argumento está fuera del intervalo de valores permitido.";
                    break;

                // IOException
                case "EndOfStreamException":
                    codigoError = "801";
                    res.mensaje = "(" + codigoError + ") El número de bytes a superado la secuencia y no se puede leer más allá del final de la secuencia.";
                    break;
                case "FileNotFoundException":
                    codigoError = "802";
                    res.mensaje = "(" + codigoError + ") Error al intentar acceder a un archivo que no existe en el disco.";
                    break;
                case "DirectoryNotFoundException":
                    codigoError = "803";
                    res.mensaje = "(" + codigoError + ") No se encuentra el directorio.";
                    break;

                // DB2
                case "DB2Exception":
                    codigoError = "901";
                    res.titulo = "Error interno de la Base de Datos!";
                    res.mensaje = "(" + codigoError + ") " + ex.Message;
                    break;

                // TimeoutException
                case "TimeoutException":
                    codigoError = "1001";
                    res.titulo = "Tiempo de espera excedido!";
                    res.mensaje = "(" + codigoError + ") " +ex.InnerException == null ? ex.Message: ex.InnerException.Message;
                    break;

                default:
                    codigoError = "2001";
                    res.titulo = "Error!";
                    res.mensaje = "(" + codigoError + ") " + ex.Message;
                    break;
            }
            
            res.objeto = null;

            Log.Error(logMensaje.codigoMensaje.ToString(), res.mensaje+": "+ ex.StackTrace);

            logMensaje.MensajeError = res.mensaje;
            logMensaje.Intcodmensaje = int.Parse(codigoError);
            logMensaje.FinSolicitud(res);
            
            return res;
        }

        public void MensajeSwal(System.Web.UI.ClientScriptManager clientScript)
        {
            string script = "window.onload = function() { swal('" + this.titulo + "', '" + this.mensaje + "', '" + this.resultado.ToString() + "'); };";
            clientScript.RegisterStartupScript(this.GetType(), "swal", script, true);
        }

        public void ConfirmacionSwal(System.Web.UI.ClientScriptManager clientScript, TipoConfirmacion tipoConfirmacion, string entidad, string nombreBoton)
        {
            string texto = "Esta seguro de" + (tipoConfirmacion == TipoConfirmacion.GUARDAR ? " Guardar " : " Borrar ") + entidad + " !";
            string script = "window.onload = function() { swal({" +
                    "title: 'Esta seguro ?',"+
                    "text: '" + texto + "'," +
                    "type: 'warning'," +
                    "showCancelButton: true," +
                    "confirmButtonColor: '#"+ (tipoConfirmacion == TipoConfirmacion.GUARDAR ? "63DD85" : "DD6B55") + "',"+
                    "confirmButtonText: 'Si, " + (tipoConfirmacion == TipoConfirmacion.GUARDAR ? "Guardar" : "Borrar") + " !'," +
                    "closeOnConfirm: false" +
                "}, function()" +
                "{ document.getElementById('ContentPlaceHolder1_"+ nombreBoton  + "').click(); }" +
                //"swal('borrado!', 'Your imaginary file has been deleted.', 'success');"+
                "); };";
            clientScript.RegisterStartupScript(this.GetType(), "swal", script, true);
        }

        public void ConfirmacionSwalProcedimiento(System.Web.UI.ClientScriptManager clientScript, TipoConfirmacion tipoConfirmacion, string entidad, string nombreBoton)
        {
            string texto = "Esta seguro de" + (tipoConfirmacion == TipoConfirmacion.GUARDAR ? " Guardar " : " Borrar ") + entidad + " !";
            string script = "window.onload = function() { if(validarSelect()){ swal({" +
                    "title: 'Esta seguro ?'," +
                    "text: '" + texto + "'," +
                    "type: 'warning'," +
                    "showCancelButton: true," +
                    "confirmButtonColor: '#" + (tipoConfirmacion == TipoConfirmacion.GUARDAR ? "63DD85" : "DD6B55") + "'," +
                    "confirmButtonText: 'Si, " + (tipoConfirmacion == TipoConfirmacion.GUARDAR ? "Guardar" : "Borrar") + " !'," +
                    "closeOnConfirm: false" +
                "}, function()" +
                "{ document.getElementById('ContentPlaceHolder1_" + nombreBoton + "').click(); }" +
                //"swal('borrado!', 'Your imaginary file has been deleted.', 'success');"+
                "); } };";
            clientScript.RegisterStartupScript(this.GetType(), "swal", script, true);
        }
    }

    public enum CodigoResultado
    {
        success = 200,
        warning = 300,
        error = 400
    }

    public enum TipoConfirmacion
    {
        GUARDAR = 1,
        BORRAR = 2
    }
}