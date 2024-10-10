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

        public static string GetClientIP(this System.Web.UI.Page page)
        {
            string _ipList = page.Request.Headers["CF-CONNECTING-IP"].ToString();
            if (!string.IsNullOrWhiteSpace(_ipList))
            {
                return _ipList.Split(',')[0].Trim();
            }
            else
            {
                _ipList = page.Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"];
                if (!string.IsNullOrWhiteSpace(_ipList))
                {
                    return _ipList.Split(',')[0].Trim();
                }
                else
                {
                    _ipList = page.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (!string.IsNullOrWhiteSpace(_ipList))
                    {
                        return _ipList.Split(',')[0].Trim();
                    }
                    else
                    {
                        return page.Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();
                    }
                }
            }
        }

    }
}