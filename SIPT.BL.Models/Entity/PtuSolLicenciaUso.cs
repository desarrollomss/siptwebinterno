using System;

namespace SIPT.BL.Models.Entity
{
    public class PtuSolLicenciaUso
    {

        public int? intcodsolicitud { get; set; }
        public int? intcoduso { get; set; }
        public Int16? smlusoprincipal { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }
        public string vchcoduso { get; set; }
    }
}


