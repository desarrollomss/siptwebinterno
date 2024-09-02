using SIPT.BL.Models.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Base
{
    public abstract class StdDocumento_dao
    {
        public abstract List<StdDocumento_InsertaResultado> Insertar(StdDocumento_InsertaDocWebSipt stdDocumento_InsertaDocWebSipt);
    }
}
