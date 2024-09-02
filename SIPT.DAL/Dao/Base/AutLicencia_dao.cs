using SIPT.BL.Models.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Base
{
    public abstract class AutLicencia_dao
    {
        public abstract List<AutLicencia_Resultado> Insertar(AutLicencia_Inserta autLiciencia_Inserta);
    }
}
