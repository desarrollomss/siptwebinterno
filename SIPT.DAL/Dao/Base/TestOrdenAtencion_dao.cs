using SIPT.BL.Models.Entity;
using System;

namespace SIPT.DAL.Dao.Base
{
    public abstract class TestOrdenAtencion_dao
    {
        public abstract int RegistrarOrden(string vchtidcodigo, string vchoradocumento, string vchoranombre, int? intadmcodigo, 
            decimal? decoratotpagar, Int16 smltricodigo, string vchaudequipo, string vchaudprograma, string vchusuario);

        public abstract TestOrdenAtencion ConsultarOrden(int intoranumero);
        public abstract int ObtenerIdReporteLicencia(int? intintcodlicencia);
    }
}
