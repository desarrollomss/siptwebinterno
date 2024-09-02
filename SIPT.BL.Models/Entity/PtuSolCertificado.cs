using System;

namespace SIPT.BL.Models.Entity
{
    public class PtuSolCertificado
    {
        public int? intcodsolcertificado { get; set; }
        public int? intcodigosolicitantecert { get; set; }
        public string vchnomsolicitantecert { get; set; }
        public string vchnomcomercialsolcert { get; set; }
        public string vchdireccsolicitantecert { get; set; }
        public string vchgirossolicitantecert { get; set; }
        public decimal? deccosto { get; set; }
        public string vchnumerorecibo { get; set; }
        public DateTime? datfechaprogramacion { get; set; }
        public DateTime? datfechavencimiento { get; set; }
        public int? smlprogramacionestado { get; set; }
        public string vchobservacion { get; set; }
        public int? inttipocertificado { get; set; }
        public int? intcodlicencia { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }

    }
}