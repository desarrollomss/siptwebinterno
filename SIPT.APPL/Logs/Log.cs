using log4net;
using System.Web.Script.Serialization;

namespace SIPT.APPL.Logs
{
    public class Log
    {
        private static readonly Log _instance = new Log();
        protected ILog monitoringLogger; // = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected static ILog debugLogger;
        private static JavaScriptSerializer jss;// = new JavaScriptSerializer();


        private Log()
        {
            //var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            //XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            //monitoringLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //var logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
            jss = new JavaScriptSerializer();
        }

        /*
        public static void Debug(string message)
        {
            if (LogMensajes.codigoMensaje is null)
            {
                debugLogger.Debug(message);
            }
            else
            {
                debugLogger.Debug(LogMensajes.codigoMensaje.ToString() + " - " + message);
            }
        }
        */
        public static void Debug(string codigoTransaccion, string message)
        {
            debugLogger.Debug(codigoTransaccion + " - " + message);
        }

        public static void Debug(string codigoTransaccion, object objeto)
        {
            debugLogger.Debug(codigoTransaccion + " - " + jss.Serialize(objeto));
        }

        public static void Debug(string message, System.Exception exception)
        {
            debugLogger.Debug(message, exception);
        }

        /*
        public static void Info(string message)
        {
            if (LogMensajes.codigoMensaje is null)
            {
                //monitoringLogger.Info(message);
                _instance.monitoringLogger.Info(message);
            }
            else
            {
                //monitoringLogger.Info(LogMensajes.codigoMensaje.ToString() + " - " + message);
                _instance.monitoringLogger.Info(LogMensajes.codigoMensaje.ToString() + " - " + message);
            }
        }

        public static void Info(object objeto)
        {
            if (LogMensajes.codigoMensaje is null)
            {
                //monitoringLogger.Info(jss.Serialize(objeto));
                _instance.monitoringLogger.Info(jss.Serialize(objeto));
            }
            else
            {
                //monitoringLogger.Info(LogMensajes.codigoMensaje.ToString() + " - " + jss.Serialize(objeto));
                _instance.monitoringLogger.Info(LogMensajes.codigoMensaje.ToString() + " - " + jss.Serialize(objeto));
            }
        }*/

        public static void Info(string codigoTransaccion, string message)
        {
            //monitoringLogger.Info(codigoTransaccion + " - " + message);
            _instance.monitoringLogger.Info(codigoTransaccion + " - " + message);
        }

        public static void Info(string codigoTransaccion, object objeto)
        {
            //monitoringLogger.Info(codigoTransaccion + " - " + jss.Serialize(objeto));
            _instance.monitoringLogger.Info(codigoTransaccion + " - " + jss.Serialize(objeto));
        }

        public static void Info(string message, System.Exception exception)
        {
            //monitoringLogger.Info(message, exception);
            _instance.monitoringLogger.Info(message, exception);
        }

        /*
        public static void Warn(string message)
        {
            if (LogMensajes.codigoMensaje is null)
            {
                //monitoringLogger.Warn(message);
                _instance.monitoringLogger.Warn(message);
            }
            else
            {
                //monitoringLogger.Warn(LogMensajes.codigoMensaje.ToString() + " - " + message);
                _instance.monitoringLogger.Warn(LogMensajes.codigoMensaje.ToString() + " - " + message);
            }
        }
        */
        public static void Warn(string codigoTransaccion, string message)
        {
            //monitoringLogger.Warn(codigoTransaccion + " - " + message);
            _instance.monitoringLogger.Warn(codigoTransaccion + " - " + message);
        }

        public static void Warn(string codigoTransaccion, object objeto)
        {
            //monitoringLogger.Warn(codigoTransaccion + " - " + jss.Serialize(objeto));
            _instance.monitoringLogger.Warn(codigoTransaccion + " - " + jss.Serialize(objeto));
        }

        public static void Warn(string message, System.Exception exception)
        {
            //monitoringLogger.Warn(message, exception);
            _instance.monitoringLogger.Warn(message, exception);
        }

        /*
        public static void Error(string message)
        {
            if (LogMensajes.codigoMensaje is null)
            {
                //monitoringLogger.Error(message);
                _instance.monitoringLogger.Error(message);
            }
            else
            {
                //monitoringLogger.Error(LogMensajes.codigoMensaje.ToString() + " - " + message);
                _instance.monitoringLogger.Error(LogMensajes.codigoMensaje.ToString() + " - " + message);
            }
        }
        */

        /*public static void Error(string codigoTransaccion, string clase, string metodo, string message)
        {
            _instance.monitoringLogger.Error(codigoTransaccion + " - " + "No se pudo " + metodo + " en " + clase + ": " + message);
        }*/

        public static void Error(string codigoTransaccion, System.Exception exception)
        {
            _instance.monitoringLogger.Error(codigoTransaccion + " - " + exception.Message+": "+ exception.StackTrace);
        }

        public static void Error(string codigoTransaccion, string message)
        {
            _instance.monitoringLogger.Error(codigoTransaccion + " - " + message);
        }

        public static void Error(string codigoTransaccion, object json)
        {
            //monitoringLogger.Error(codigoTransaccion + " - " + jss.Serialize(objeto));
            _instance.monitoringLogger.Error(codigoTransaccion + " - " + jss.Serialize(json));
        }


        /*
        public static void Fatal(string message)
        {
            if (LogMensajes.codigoMensaje is null)
            {
                //monitoringLogger.Fatal(message);
                _instance.monitoringLogger.Fatal(message);
            }
            else
            {
                //monitoringLogger.Fatal(LogMensajes.codigoMensaje.ToString() + " - " + message);
                _instance.monitoringLogger.Fatal(LogMensajes.codigoMensaje.ToString() + " - " + message);
            }
        }
        */
        public static void Fatal(string codigoTransaccion, string message)
        {
            //monitoringLogger.Fatal(codigoTransaccion + " - " + message);
            _instance.monitoringLogger.Fatal(codigoTransaccion + " - " + message);
        }

        public static void Fatal(string codigoTransaccion, object objeto)
        {
            //monitoringLogger.Fatal(codigoTransaccion + " - " + jss.Serialize(objeto));
            _instance.monitoringLogger.Fatal(codigoTransaccion + " - " + jss.Serialize(objeto));
        }

        public static void Fatal(string message, System.Exception exception)
        {
            //monitoringLogger.Fatal(message, exception);
            _instance.monitoringLogger.Fatal(message, exception);
        }
    }
}