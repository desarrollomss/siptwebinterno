using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuTabla
	{
		public Int16? smlcodtabla { get; set; }
		public Int16? smlorden { get; set; }
		public string vchdescripcion { get; set; }
		public string vchdescripcionalterna { get; set; }
		public string vchenlace { get; set; }
		public string vchtabla { get; set; }
		public string vchcampo { get; set; }
		public Int16? smlestado { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
