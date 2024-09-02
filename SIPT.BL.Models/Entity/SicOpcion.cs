using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.Models.Entity
{
    public class SicOpcion
    {
        public int? intopccodigo { get; set; }
        public int? intopccodigopadre { get; set; }        
        public int? intopcorden { get; set; }        
        public string vchopcaccion { get; set; }
        public int? intopcnivel { get; set; }
        public string vchopcnombre { get; set; }
        public string vchopcdescrip { get; set; }
        public string vchopctipo { get; set; }
    }
}
