using System;

namespace SIPT.BL.Models.Entity
{
    public class PtuIndicadores
    {
        public int? intcodigoindicador { get; set; }
        public string vcnombreindicador { get; set; }
        public int? intcodigoprocedimiento { get; set; }
        public string vchtabla { get; set; }
        public string vchcampotiempoinicio { get; set; }
        public int? intalertaahoras { get; set; }
        public int? intalertachoras { get; set; }
        public int? smlestado { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }
    }
}



