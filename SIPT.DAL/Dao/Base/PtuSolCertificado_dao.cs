using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuSolCertificado_dao
    {
        public abstract void Insertar(PtuSolCertificado pPtuSolCertidicado);

        public abstract void Actualizar(PtuSolCertificado pPtuSolCertidicado);

        public abstract void Eliminar(PtuSolCertificado pPtuSolCertidicado);

        public abstract List<PtuSolCertificado> Listar();

        public abstract PtuSolCertificado ListarPorId(PtuSolCertificado pPtuSolCertidicado);

    }
}