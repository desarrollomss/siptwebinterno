using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuUso_dao
    {
        public abstract void Insertar(PtuUso pPtuUso);

        public abstract void Actualizar(PtuUso pPtuUso);

        public abstract void Eliminar(PtuUso pPtuUso);

        public abstract List<PtuUso> Listar();

        public abstract PtuUso ListarPorId(int? intcoduso);

        public abstract List<PtuUso> ListarPorFiltro(PtuUso pPtuUso);

    }
}