using SIPT.BL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Base
{
    public abstract class DjuPredio_dao
    {
        public abstract DjuPredio ListarPorId(int? intprecodigo);
    }
}
