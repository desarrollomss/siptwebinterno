using System;

namespace SIPT.BL.Models.Entity
{
    public class PtuSolLicenciaAnalista
    {
        public int? intcodsolicitudanalista { get; set; }
        public int? intusuanalista { get; set; }
        public int? intcodsolicitud { get; set; }
        public int? smlestado { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }
    }
}