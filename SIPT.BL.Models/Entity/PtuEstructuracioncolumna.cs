using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuEstructuracioncolumna
	{
		public int? intcodestructuracioncolumna { get; set; }
		public string vchcolumna { get; set; }
		public string vchcolumnazonificacion { get; set; }
		public string vchcolumnadescripcion { get; set; }
		public int? intcodestructuracion { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
