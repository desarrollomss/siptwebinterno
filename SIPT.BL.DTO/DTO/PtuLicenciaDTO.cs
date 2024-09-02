using System;
using System.Collections.Generic;

namespace SIPT.BL.DTO.DTO
{
	public class PtuLicenciaDTO
	{
		public int? intcodlicencia { get; set; }
		public string chlicanio { get; set; }
		public string vchlicnumero { get; set; }
		public DateTime? datvigenciaini { get; set; }
		public DateTime? datvigenciafin { get; set; }
		public DateTime? tmsregistrolicencia { get; set; }
		public Int16? smlvigencia { get; set; }
		public string vchobservacion { get; set; }
		public int? intaforo { get; set; }
		public int? intdoccodigo { get; set; }
		public DateTime? datfechaprogramacion { get; set; }
		public string vchhoraprogramacion { get; set; }
		public string vchliccategoria { get; set; }
		public Int16? smlameritaprogramacion { get; set; }
		public string vchzonacod { get; set; }
		public string vchestrcodigo { get; set; }
		public string vchsolgerencia { get; set; }
		public string vchsolsubgerencia { get; set; }
		public int? intcodsolicitud { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }


		public string vchnumexpediente { get; set; }
		public int? intreporteid { get; set; }

	}
}
