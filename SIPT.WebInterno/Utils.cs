using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPT.WebInterno
{
    public class Utils
    {
    
        public static string fap_RolAnalista()
        {
            return System.Configuration.ConfigurationManager.AppSettings["RolAnalista"].ToUpper();
        }
        public static string fap_RolCoordinador()
        {
            return System.Configuration.ConfigurationManager.AppSettings["RolCoordinador"].ToUpper();
        }

    }
}