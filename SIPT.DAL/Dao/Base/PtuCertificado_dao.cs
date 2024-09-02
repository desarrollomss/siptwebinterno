using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuCertificado_dao
    {
        public abstract int Insertar(PtuCertificado pPtuCertidicado);

        public abstract void Actualizar(PtuCertificado pPtuCertidicado);

        public abstract void Eliminar(PtuCertificado pPtuCertidicado);

        public abstract List<PtuCertificado> Listar();

        public abstract PtuCertificado ListarPorId(PtuCertificado pPtuCertidicado);

    }
}