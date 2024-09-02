using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuUbicaciones_dao
    {
        public abstract List<PtuUbicaciones> ListarPorFiltro(PtuUbicaciones pPtuUbicaciones);
        public abstract List<PtuRequerimiento_Editables> ListarEditables(int intsolicitudplantilla);
        public abstract void EjecutarScript(string query);
        public abstract List<PtuPlantillareqvalores> ListarValores(int intsolicitudplantilla);
    }
}