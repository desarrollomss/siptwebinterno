using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace SIPT.APPL.FrondEnd
{
    public class Request
    {   
        public string vchopcion { get; set; }
        public string vchconnombre { get; set; }


        public string vchaudcodusuario { get; set; }  //public string vchusuario { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }


        public object objeto { get; set; }


        public static T Deserializar3<T>(object valor)
        {
            Newtonsoft.Json.Linq.JObject objeto = (Newtonsoft.Json.Linq.JObject)valor;            
            return JsonConvert.DeserializeObject<T>(objeto.ToString());
        }

        public static T Deserializar<T>(Request request)
        {
            Newtonsoft.Json.Linq.JObject objeto = (Newtonsoft.Json.Linq.JObject)request.objeto;
            
            var miobjeto = JsonConvert.DeserializeObject<T>(objeto.ToString());

            var prop1 = miobjeto.GetType().GetProperty("vchaudusucreacion");
            AdicionarPropiedad(miobjeto, ref prop1, request.vchaudcodusuario);
            var prop2 = miobjeto.GetType().GetProperty("vchaudusumodif");
            AdicionarPropiedad(miobjeto, ref prop2, request.vchaudcodusuario);
            var prop3 = miobjeto.GetType().GetProperty("vchaudequipo");
            AdicionarPropiedad(miobjeto, ref prop3, request.vchaudequipo);
            var prop4 = miobjeto.GetType().GetProperty("vchaudprograma");
            AdicionarPropiedad(miobjeto, ref prop4, request.vchaudprograma);

            return miobjeto;
		}

        private static void AdicionarPropiedad(object entidad, ref PropertyInfo prop, string valor)
        {
            if (prop is null)
                return;

            if (valor is null)
            {
                prop.SetValue(entidad, null, null);
            }
            else
            {
                string nombretipo = prop.PropertyType.Name;

                if (nombretipo == "Int32")
                {
                    int? _valor = Convert.ToInt32(valor);
                    prop.SetValue(entidad, _valor, null);
                }
                else if (nombretipo == "Int16")
                {
                    Int16? _valor = Convert.ToInt16(valor);
                    prop.SetValue(entidad, _valor, null);
                }
                else if (nombretipo == "Decimal")
                {
                    decimal? _valor = Convert.ToDecimal(valor);
                    prop.SetValue(entidad, _valor, null);
                }
                else if (nombretipo == "DateTime")
                {
                    DateTime? _valor = Convert.ToDateTime(valor);
                    prop.SetValue(entidad, _valor, null);
                }
                else if (nombretipo == "String")
                {
                    prop.SetValue(entidad, valor, null);
                }
            }
        }


        public static Dictionary<string, object> DeserializarDictionary(string jo)
		{
			var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jo);
			var values2 = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> d in values)
			{
				if (d.Value is JObject)
				{
					values2.Add(d.Key, DeserializarDictionary(d.Value.ToString()));
				}
				else
				{
					values2.Add(d.Key, d.Value);
				}
			}
			return values2;
		}
	}
}