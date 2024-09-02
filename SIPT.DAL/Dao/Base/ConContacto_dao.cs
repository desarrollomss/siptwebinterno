using SIPT.BL.Models.Entity;

namespace SIPT.DAL.Dao.Base
{
    public abstract class ConContacto_dao
    {
        public abstract ConContacto ListarPlataformaPorId(int intadmcodigo, string vchtipodato);
    }
}
