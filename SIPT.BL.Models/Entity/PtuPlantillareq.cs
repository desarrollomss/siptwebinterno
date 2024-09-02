using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuPlantillareq
	{
		public int? intcodplantilla { get; set; }
		public string vchnombreplantilla { get; set; }
		public string vchdocplantilla { get; set; }
		public byte[] blbdocplantilla { get; set; }
		public Int16? smltipodocumentoreq { get; set; }
		public string vchnotareq { get; set; }
		public string vchprocedimientoalm { get; set; }
		public Int16? smlestado { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
