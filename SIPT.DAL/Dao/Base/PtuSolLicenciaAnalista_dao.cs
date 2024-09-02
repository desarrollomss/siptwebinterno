using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuSolLicenciaAnalista_dao
    {
        public abstract int Insertar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista);

        public abstract void Actualizar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista);

        public abstract void Eliminar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista);

        public abstract List<PtuSolLicenciaAnalista> Listar();

        public abstract PtuSolLicenciaAnalista ListarPorId(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista);
        
    }
}