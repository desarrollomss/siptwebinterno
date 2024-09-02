using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class ConAdministrado_dao
    {
        public abstract List<ConAdministrado> ListarPorFiltro(ConAdministrado pConAdministrado);
        public abstract ConAdministrado ListarplataformaPorId(int? intadmcodigo);
    }
}