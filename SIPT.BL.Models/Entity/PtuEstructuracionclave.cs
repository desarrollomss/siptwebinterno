using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuEstructuracionclave
	{
		public int? intcodestructuracionclave { get; set; }
		public string vchabrevestructuracionclave { get; set; }
		public string vchdescestructuracionclave { get; set; }
		public Int16? smlestado { get; set; }
		public int? intcodestructuracion { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
