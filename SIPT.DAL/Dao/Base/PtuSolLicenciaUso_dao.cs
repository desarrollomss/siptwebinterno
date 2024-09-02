using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuSolLicenciaUso_dao
    {
        public abstract void Insertar(PtuSolLicenciaUso pPtuSolLicenciaUso);

        public abstract void Actualizar(PtuSolLicenciaUso pPtuSolLicenciaUso);

        public abstract void Eliminar(PtuSolLicenciaUso pPtuSolLicenciaUso);

        public abstract List<PtuSolLicenciaUso> Listar();

        public abstract PtuSolLicenciaUso ListarPorId(PtuSolLicenciaUso pPtuSolLicenciaUso);
        public abstract List<PtuSolLicenciaUso> ListarPorSolicitud(int? intcodsolicitud);

    }
}