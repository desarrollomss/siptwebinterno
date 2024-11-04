using System;
using System.Collections.Generic;

namespace SIPT.BL.DTO.DTO
{
	public class PtuSolcertificadoDTO
	{
		public int? intcodsolicitud { get; set; }
		public string vchnomcomercialsolcert { get; set; }
		public string vchdireccsolicitantecert { get; set; }
		public DateTime? datfechaprogramacion { get; set; }
		public DateTime? datfechavencimiento { get; set; }
		public Int16? smlestsolcertificado { get; set; }
        public Int16? smlresultadocertificacion { get; set; }
        public string vchzonificacion { get; set; }
		public string vchestructuracion { get; set; }
		public string vchobservacion { get; set; }
		public int? intcodsolicitudlicencia { get; set; }
		public string vchreporteresolucion { get; set; }
		public int? intcodlicencia { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
		
    }
}
