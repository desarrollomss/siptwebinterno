using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;
using System.Reflection;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuSolicitud_dao
    {
        /*public bool Verificar(PtuSolicitud pPtuSolicitud)
        {
            bool valido = false;

            PropertyInfo[] properties = typeof(PtuSolicitud).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string NombreAtributo = property.Name;

                var valor = property.GetValue(pPtuSolicitud);
                if (!valor.Equals(null))
                {
                    valido = true;
                    break;
                }                    
            }
            return valido;
        }*/

        public abstract int Insertar(PtuSolicitud pPtuSolicitud);

        public abstract PtuSolicitud Actualizar(PtuSolicitud pPtuSolicitud);

        public abstract void Eliminar(PtuSolicitud pPtuSolicitud);

        public abstract List<PtuSolicitud> Listar();

        public abstract PtuSolicitud ListarPorId(int? intcodsolicitud);

        public abstract List<PtuSolicitud_PorAnalistaPorSolicitante> ListarPorAnalistaPorSolicitante(int? intcodigosolicitante, int? intusuanalista);

        public abstract List<PtuSolicitud_PorAnalistaPorSolicitante> ListarPendientes(PtuSolicitud pPtuSolicitud, int? intusuanalista);

        public abstract List<PtuSolicitud_PorAnalistaPorSolicitante> ListarCalificar(PtuSolicitud pPtuSolicitud, int? intusuanalista);

        public abstract List<PtuSolicitud_PorAnalistaPorSolicitante> ListarAcreditar(PtuSolicitud pPtuSolicitud, int? intusuanalista);

    }
}