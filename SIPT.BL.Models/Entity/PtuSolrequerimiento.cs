using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuSolrequerimiento
	{
		public int? intsolicitudplantilla { get; set; }
		public int? intcodplantilla { get; set; }
		public int? intcodsolicitud { get; set; }
		public string vchobsevaluacion { get; set; }
		public Int16? smlevaluacion { get; set; }
		public string vchdocrequerimiento { get; set; }
		public DateTime? tmsfechadocumento { get; set; }
		public Int16? smlestadodocumento { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }

		public string vchnombreplantilla { get; set; }
		
	}
}
