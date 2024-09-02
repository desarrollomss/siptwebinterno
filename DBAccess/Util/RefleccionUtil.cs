using System;
using System.Reflection;

namespace DBAccess.Util
{
    public class RefleccionUtil
    {
        public static TipoObjeto CrearObjeto<TipoObjeto>(params object[] parametrosConstructorEnOrden)
        {
            var tipo = typeof(TipoObjeto);
            int cantidadDeParametros = parametrosConstructorEnOrden.Length - 1;
            var tiposDeParametrosDeConstructor = new Type[cantidadDeParametros + 1];

            for (int indice = 0, loopTo = cantidadDeParametros; indice <= loopTo; indice++)
                tiposDeParametrosDeConstructor[indice] = parametrosConstructorEnOrden[indice].GetType();

            ConstructorInfo constructor = tipo.GetConstructor(tiposDeParametrosDeConstructor);
            return (TipoObjeto)constructor.Invoke(parametrosConstructorEnOrden);
        }
    }
}