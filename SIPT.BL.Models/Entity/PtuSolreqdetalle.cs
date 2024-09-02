using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuSolreqdetalle
	{
		public int? intcodsolreqdetalle { get; set; }
		public string vchetiqueta { get; set; }
		public string vchdescripcion { get; set; }
		public string vchnota { get; set; }
		public string chreditable { get; set; }
		public string chrobligatorio { get; set; }
		public string vchtipovalor { get; set; }
		public string vchvalor { get; set; }
		public int? intcodsolreqgrupo { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
