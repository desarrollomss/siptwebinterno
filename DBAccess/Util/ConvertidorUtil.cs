using System;
using System.Data.Common;

namespace DBAccess.Util
{
    public class ConvertidorUtil
    {
        public static TipoEntidad DeReaderAEntidad<TipoEntidad>(DbDataReader dataReader)
        {
            object entidad = RefleccionUtil.CrearObjeto<TipoEntidad>();
            int cantidadDeColumnas = dataReader.FieldCount - 1;
            dataReader.Read();
            if (dataReader.HasRows)
            {
                for (int ordinal = 0, loopTo = cantidadDeColumnas; ordinal <= loopTo; ordinal++)
                {
                    var prop = entidad.GetType().GetProperty(dataReader.GetName(ordinal).ToLower());

                    if (prop.PropertyType.Name.Contains("Nullable"))
                    {
                        if (dataReader.GetValue(ordinal) is DBNull)
                        {
                            prop.SetValue(entidad, null, null);
                        }
                        else
                        {
                            string nombretipo = prop.PropertyType.GenericTypeArguments[0].Name;

                            if (nombretipo == "Int32")
                            {
                                int? valor = Convert.ToInt32(dataReader.GetValue(ordinal));
                                prop.SetValue(entidad, valor, null);
                            }
                            else if (nombretipo == "Int16")
                            {
                                Int16? valor = Convert.ToInt16(dataReader.GetValue(ordinal));
                                prop.SetValue(entidad, valor, null);
                            }
                            else if (nombretipo == "Decimal")
                            {
                                decimal? valor = Convert.ToDecimal(dataReader.GetValue(ordinal));
                                prop.SetValue(entidad, valor, null);
                            }
                            else if (nombretipo == "DateTime")
                            {
                                DateTime? valor = Convert.ToDateTime(dataReader.GetValue(ordinal));
                                prop.SetValue(entidad, valor, null);
                            }
                        }
                    }
                    else
                    {
                        if (prop.PropertyType.Name.Contains("Boolean"))
                        {
                            if (Convert.ToInt16(dataReader.GetValue(ordinal)) == 1)
                            {
                                prop.SetValue(entidad, true, null);
                            }
                            else
                            {
                                prop.SetValue(entidad, false, null);
                            }
                        }
                        else
                        {
                            prop.SetValue(entidad, dataReader.GetValue(ordinal) is DBNull ? null : dataReader.GetValue(ordinal), null);
                        }
                    }
                }
                return (TipoEntidad)entidad;
            }
            else
            {
                return default;
            }
        }

        public static TipoColeccion DeReaderAColeccion<TipoEntidad, TipoColeccion>(DbDataReader dataReader)
        {
            object coleccion = RefleccionUtil.CrearObjeto<TipoColeccion>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    object entidad = RefleccionUtil.CrearObjeto<TipoEntidad>();
                    ((dynamic)coleccion).Add(DeReaderAEntidadInt<TipoEntidad>(dataReader));
                }
            }
            return (TipoColeccion)coleccion;
        }

        private static TipoEntidad DeReaderAEntidadInt<TipoEntidad>(DbDataReader dataReader)
        {
            object entidad = RefleccionUtil.CrearObjeto<TipoEntidad>();
            int cantidadDeColumnas = dataReader.FieldCount - 1;

            for (int ordinal = 0, loopTo = cantidadDeColumnas; ordinal <= loopTo; ordinal++)
            {
                var prop = entidad.GetType().GetProperty(dataReader.GetName(ordinal).ToLower());

                if (prop.PropertyType.Name.Contains("Nullable"))
                {
                    if (dataReader.GetValue(ordinal) is DBNull)
                    {
                        prop.SetValue(entidad, null, null);
                    }
                    else
                    {
                        string nombretipo = prop.PropertyType.GenericTypeArguments[0].Name;

                        if (nombretipo == "Int32")
                        {
                            int? valor = Convert.ToInt32(dataReader.GetValue(ordinal));
                            prop.SetValue(entidad, valor, null);
                        }
                        else if (nombretipo == "Int16")
                        {
                            Int16? valor = Convert.ToInt16(dataReader.GetValue(ordinal));
                            prop.SetValue(entidad, valor, null);
                        }
                        else if (nombretipo == "Decimal")
                        {
                            decimal? valor2 = Convert.ToDecimal(dataReader.GetValue(ordinal));
                            prop.SetValue(entidad, valor2, null);
                        }
                        else if (nombretipo == "DateTime")
                        {
                            DateTime? valor3 = Convert.ToDateTime(dataReader.GetValue(ordinal));
                            prop.SetValue(entidad, valor3, null);
                        }
                    }                    
                }
                else
                {
                    if (prop.PropertyType.Name.Contains("Boolean"))
                    {
                        if (Convert.ToInt16(dataReader.GetValue(ordinal)) == 1)
                        {
                            prop.SetValue(entidad, true, null);
                        }
                        else
                        {
                            prop.SetValue(entidad, false, null);
                        }                        
                    }
                    else
                    {
                        prop.SetValue(entidad, dataReader.GetValue(ordinal) is DBNull ? null : dataReader.GetValue(ordinal), null);
                    }
                        
                }

                
            }
            return (TipoEntidad)entidad;
        }
    }
}