using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.DTO.Mapper
{
    public class Mapeos
    {
        public TDestino Map<TOrigen, TDestino>(TOrigen objetoOrigen)
        {
            var objetoDestino = Activator.CreateInstance<TDestino>();
            if (objetoOrigen != null)
            {
                foreach (var objetoOrigenPropiedad in typeof(TOrigen).GetProperties())
                {
                    var objetoDestinoPropiedad = typeof(TDestino).GetProperty(objetoOrigenPropiedad.Name);
                    if (objetoDestinoPropiedad != null)
                    {
                        objetoDestinoPropiedad.SetValue(objetoDestino, objetoOrigenPropiedad.GetValue(objetoOrigen));
                    }
                }
            }
            return objetoDestino;
        }

        public List<TDestino> MapList<TOrigen, TDestino>(List<TOrigen> objetoOrigenList)
        {
            List<TDestino> objetoDestinoList = new List<TDestino>();
            foreach (TOrigen objetoOrigen in objetoOrigenList)
            {
                var objetoDestino = Activator.CreateInstance<TDestino>();
                if (objetoOrigen != null)
                {
                    foreach (var objetoOrigenPropiedad in typeof(TOrigen).GetProperties())
                    {
                        var objetoDestinoPropiedad = typeof(TDestino).GetProperty(objetoOrigenPropiedad.Name);
                        if (objetoDestinoPropiedad != null)
                        {
                            objetoDestinoPropiedad.SetValue(objetoDestino, objetoOrigenPropiedad.GetValue(objetoOrigen));
                        }
                    }
                    objetoDestinoList.Add(objetoDestino);
                }
            }
            return objetoDestinoList;
        }

        public TDestino Map<TOrigen1, TOrigen2, TDestino>(TOrigen1 objetoOrigen1, TOrigen2 objetoOrigen2)
        {
            var objetoDestino = Activator.CreateInstance<TDestino>();
            if (objetoOrigen1 != null)
            {
                foreach (var objetoOrigenPropiedad in typeof(TOrigen1).GetProperties())
                {
                    var objetoDestinoPropiedad = typeof(TDestino).GetProperty(objetoOrigenPropiedad.Name);
                    if (objetoDestinoPropiedad != null)
                    {
                        objetoDestinoPropiedad.SetValue(objetoDestino, objetoOrigenPropiedad.GetValue(objetoOrigen1));
                    }
                }
            }

            if (objetoOrigen2 != null)
            {
                foreach (var objetoOrigenPropiedad in typeof(TOrigen2).GetProperties())
                {
                    var objetoDestinoPropiedad = typeof(TDestino).GetProperty(objetoOrigenPropiedad.Name);
                    if (objetoDestinoPropiedad != null)
                    {
                        objetoDestinoPropiedad.SetValue(objetoDestino, objetoOrigenPropiedad.GetValue(objetoOrigen2));
                    }
                }
            }

            return objetoDestino;
        }
    }
}
