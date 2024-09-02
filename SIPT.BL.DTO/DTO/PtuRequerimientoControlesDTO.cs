using System.Collections.Generic;

namespace SIPT.BL.DTO.DTO
{
    public class PtuRequerimientoControlesDTO
    {
        public string intsolicitudplantilla { get; set; }
        public object control { get; set; }
    }

    public class Control
    {
        public string nombre { get; set; }
        public object valor { get; set; }
    }
}
