using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Models.Entity
{
    public class DjuPredio
    {
        public int? intprecodigo { get; set; }
        public decimal? decprevaloriza { get; set; }
        public Int16? smlanoaniopro { get; set; }
        public int? intdjunumddjj { get; set; }
        public int? intprerelacionado { get; set; }
        public string vchpredireccion { get; set; }
        public DateTime? datpreultmodif { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }

    }
}
