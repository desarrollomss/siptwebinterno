using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Models.Consultas
{
    public class AutSolicitud_Resultado
    {
        public string estado { get; set; }
        public string msg { get; set; }
        public string sql_estado { get; set; }
        public int? sql_codigo { get; set; }
        public string p_chrsolanio { get; set; }
        public string p_vchsolnumero { get; set; }

    }
}
