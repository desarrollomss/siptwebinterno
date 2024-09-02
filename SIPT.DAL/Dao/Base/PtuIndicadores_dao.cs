using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuIndicadores_dao
    {
        public abstract int Insertar(PtuIndicadores pPtuIndicadores);

        public abstract PtuIndicadores Actualizar(PtuIndicadores pPtuIndicadores);

        public abstract void Eliminar(PtuIndicadores pPtuIndicadores);

        public abstract List<PtuIndicadores> Listar();

        public abstract PtuIndicadores ListarPorId(PtuIndicadores pPtuIndicadores);

    }
}