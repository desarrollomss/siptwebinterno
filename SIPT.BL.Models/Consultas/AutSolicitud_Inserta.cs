using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Models.Consultas
{
    public class AutSolicitud_Inserta
    {
        public Int16? p_smltipautcodigo { get; set; }
        public int? p_intprecodigo { get; set; }
        public int? p_intadmcodigo { get; set; }
        public decimal? p_decslicareocup { get; set; }
        public Int16? p_smlcodtabla { get; set; }
        public int? p_intdoccodigo { get; set; }
        public int? p_intcodsolicitud { get; set; }
        public string p_vchaudusucreacion { get; set; }
        public string p_vchaudequipo { get; set; }
        public string p_vchaudprograma { get; set; }
    }
}
