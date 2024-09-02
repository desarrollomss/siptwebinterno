using SIPT.BL.Models.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Base
{
    public abstract class AutSolicitud_dao
    {
        public abstract List<AutSolicitud_Resultado> Insertar(AutSolicitud_Inserta autSolicitud_Inserta);
    }
}
