using SIPT.BL.Models.Entity;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
    public abstract class PtuSolLicencia_dao
    {
        public abstract void Insertar(PtuSolLicencia pPtuSolLicencia);

        public abstract void Actualizar(PtuSolLicencia pPtuSolLicencia);

        public abstract void Eliminar(PtuSolLicencia pPtuSolLicencia);

        public abstract List<PtuSolLicencia> Listar();

        public abstract PtuSolLicencia ListarPorId(int? intcodsolicitud);

        public abstract void Desistir(PtuSolLicencia pPtuSolLicencia);
                
        public abstract void Calificar(PtuSolLicencia pPtuSolLicencia, int pintcodigoprocedimiento);

        public abstract void ProcesarPlantillas(PtuSolLicencia pPtuSolLicencia);
        
        public abstract void Acreditar(PtuSolLicencia pPtuSolLicencia, int pintcodigoprocedimiento);
    }
}