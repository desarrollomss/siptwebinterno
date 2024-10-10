using System;

namespace SIPT.APPL.Logs
{
    public class SisLogmensajes
    {
        public string vchcodlogmensajes { get; set; }
        public DateTime datfecha { get; set; }
        public DateTime tmsfecha { get; set; }
        public int intcodsistema { get; set; }
        public int intcodmodulo { get; set; }
        public int intcodfuncion { get; set; }
        public int intcodopcion { get; set; }
        public decimal dectiempo { get; set; }
        public string vchcodmensaje { get; set; }
        public string vchmensaje { get; set; }
        public string vchcodusuario { get; set; }
        public string vchequipo { get; set; }
        public string vchnodo { get; set; }
    }
}