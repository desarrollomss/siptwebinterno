using System.Configuration;

namespace DBAccess
{
    public class Conexion
    {
        private static string _cadena;
        private static string _servidor;

        public static string CadenaConexion
        {
            get
            {
                _servidor = ConfigurationManager.AppSettings["Server"];
                if (_servidor == "SqlServer")
                {
                    ConnectionStringSettings MiCnx = ConfigurationManager.ConnectionStrings["SqlServer"];
                    _cadena = MiCnx.ConnectionString;
                }
                else if (_servidor == "Db2")
                {
                    ConnectionStringSettings MiCnx = ConfigurationManager.ConnectionStrings["Db2"];
                    _cadena = MiCnx.ConnectionString;
                }
                else if (_servidor == "Oracle")
                {
                    ConnectionStringSettings MiCnx = ConfigurationManager.ConnectionStrings["Oracle"];
                    _cadena = MiCnx.ConnectionString;
                }
                return _cadena;
            }
        }

        
        public static string Servidor
        {
            get
            {
                _servidor = ConfigurationManager.AppSettings["Server"];
                return _servidor;
            }
        }
    }
}