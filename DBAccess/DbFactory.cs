using System;
using System.Configuration;

namespace DBAccess
{
    public class DbFactory
    {
        private static string daoImplement;
       
        public static T Instanciar<T>(object entidad, object @params = null)
        {
            daoImplement = System.Configuration.ConfigurationManager.AppSettings["DaoImplement"];
            
            Type objectType;

            string nombre = entidad.ToString().Substring(entidad.ToString().LastIndexOf(".")+1, entidad.ToString().Length-(entidad.ToString().LastIndexOf(".")+1));

            if (Conexion.Servidor == "SqlServer")
            {
                nombre = nombre + "_sql";
            }
            else if (Conexion.Servidor == "Db2")
            {
                nombre = nombre + "_db2";
            }
            else if (Conexion.Servidor == "Oracle")
            {
                nombre = nombre + "_ora";
            }

            objectType = Type.GetType(daoImplement + "." + Conexion.Servidor + "." + nombre, true);
            entidad = null;

            if (@params is null)
            {
                return (T)Activator.CreateInstance(objectType, false);
            }
            else
            {
                return (T)Activator.CreateInstance(objectType, @params);
            }
        }

        /*public static object Instanciar(object objeto, object @params = null)
        {
            Type objectType;
            string nombre = NomObjeto(objeto);
            if (Conexion.Servidor == "SqlServer")
            {
                nombre = nombre.Replace("_dao", "_sql");
            }
            else if (Conexion.Servidor == "Db2")
            {
                nombre = nombre.Replace("_dao", "_db2");
            }
            else if (Conexion.Servidor == "Oracle")
            {
                nombre = nombre.Replace("_dao", "_ora");
            }

            objectType = Type.GetType("SIPT.Api.Dao.Implementacion." + Conexion.Servidor + "." + nombre, true);
            object myObject;
            if (@params is null)
            {
                myObject = Activator.CreateInstance(objectType, false);                
            }
            else
            {
                myObject = Activator.CreateInstance(objectType, @params);
            }


            return myObject;

        }*/

        private static string NomObjeto(object objeto)
        {
            string xx = objeto.ToString();
            var tipoObjeto = objeto.GetType();
            int pos = 0;
            int cont = 0;
            for (int i = 0, loopTo = tipoObjeto.ToString().Length - 1; i <= loopTo; i++)
            {
                string caracter = tipoObjeto.ToString().Substring(i, 1);
                if (caracter == ".")
                {
                    cont = 0;
                    pos = i;
                }
                cont += 1;
            }
            return tipoObjeto.ToString().Substring(pos + 1, cont - 1);
        }
    }
}