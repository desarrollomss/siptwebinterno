using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Models.Consultas
{
    public class PtuRequerimiento_Editables
    {
        public int? intcodsolicitud { get; set; }
        public int? intcodplantilla { get; set; }
        public int? intcodsolreqdetalle { get; set; }
        public string vchetiqueta { get; set; }
        public string vchtipovalor { get; set; }
        public int? smltipogrupo { get; set; }        
        public string vchtabla { get; set; }
        public string vchcampo { get; set; }
        public string vchvalor { get; set; }

    }
}
