using DBAccess;
using DBAccess.Util;
using IBM.Data.DB2;
using SIPT.APPL.Logs;
using System.Collections.Generic;
using System.Data;

namespace SIPT.DAL.Dao.Factory
{
    public class DB2Comando
    {
        public static List<T> Listar<T>(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes, params DB2Parameter[] commandParameters)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);
            Log.Debug(logMensajes.codigoMensaje.ToString(), commandParameters);

            DB2DataReader dataReader;
            dataReader = DB2helper.ExecuteReader(transaction, commandType, commandText, commandParameters);
            List<T> lista = ConvertidorUtil.DeReaderAColeccion<T, List<T>>(dataReader);

            Log.Debug(logMensajes.codigoMensaje.ToString(), lista);
            return lista;
        }

        public static List<T> Listar<T>(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);

            DB2DataReader dataReader;
            dataReader = DB2helper.ExecuteReader(transaction, commandType, commandText);
            List<T> lista = ConvertidorUtil.DeReaderAColeccion<T, List<T>>(dataReader);

            Log.Debug(logMensajes.codigoMensaje.ToString(), lista);
            return lista;
        }

        public static T Obtener<T>(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes, params DB2Parameter[] commandParameters)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);
            Log.Debug(logMensajes.codigoMensaje.ToString(), commandParameters);

            DB2DataReader dataReader;
            dataReader = DB2helper.ExecuteReader(transaction, commandType, commandText, commandParameters);
            T entidad = ConvertidorUtil.DeReaderAEntidad<T>(dataReader);

            Log.Debug(logMensajes.codigoMensaje.ToString(), entidad);
            return entidad;
        }

        public static T Obtener<T>(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);

            DB2DataReader dataReader;
            dataReader = DB2helper.ExecuteReader(transaction, commandType, commandText);
            T entidad = ConvertidorUtil.DeReaderAEntidad<T>(dataReader);

            Log.Debug(logMensajes.codigoMensaje.ToString(), entidad);
            return entidad;
        }

        public static void Ejecutar(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes, params DB2Parameter[] commandParameters)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);
            Log.Debug(logMensajes.codigoMensaje.ToString(), commandParameters);

            DB2helper.ExecuteNonQuery(transaction, commandType, commandText, commandParameters);            
        }

        public static void Ejecutar(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);

            DB2helper.ExecuteNonQuery(transaction, commandType, commandText);
        }

        public static DB2DataReader Reader(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes, params DB2Parameter[] commandParameters)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);
            Log.Debug(logMensajes.codigoMensaje.ToString(), commandParameters);

            DB2DataReader dataReader = DB2helper.ExecuteReader(transaction, commandType, commandText, commandParameters);
            
            Log.Debug(logMensajes.codigoMensaje.ToString(), dataReader);
            return dataReader;
        }

        public static DB2DataReader Reader(DB2Transaction transaction, CommandType commandType, string commandText, LogMensajes logMensajes)
        {
            Log.Info(logMensajes.codigoMensaje.ToString(), commandText);

            DB2DataReader dataReader = DB2helper.ExecuteReader(transaction, commandType, commandText);

            Log.Debug(logMensajes.codigoMensaje.ToString(), dataReader);
            return dataReader;
        }

    }
}
