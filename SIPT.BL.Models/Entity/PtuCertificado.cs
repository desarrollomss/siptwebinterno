using System;

namespace SIPT.BL.Models.Entity
{
    public class PtuCertificado
    {

        public int? intcodcertificado { get; set; }
        public string chrceranio { get; set; }
        public string vchcernumero { get; set; }
        public int? intcerttipo { get; set; }
        public int? intcertestado { get; set; }
        public string vchnumexpediente { get; set; }
        public DateTime? datfeccertificado { get; set; }
        public DateTime? datfecvencimientocert { get; set; }
        public string chrresolucionanio { get; set; }
        public string vchresolucionnumero { get; set; }
        public DateTime? datresolucionfecha { get; set; }
        public int? intcodsolcertificado { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }

    }
}