using System;

namespace SIPT.BL.DTO.DTO
{
    public class TestOrdenAtencionDTO
    {
        public int intordennumero { get; set; }
        public int? intcodsolicitud { get; set; }
        public string vchestadodescripcion { get; set; } 
        public DateTime datfechacreacion { get; set; }
        public decimal decordentotalpagar { get; set; }


        public string vchaudusucreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }
    }
}