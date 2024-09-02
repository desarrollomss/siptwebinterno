using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuRequerimientostupa
	{
		public int? intcodrequerimientotupa { get; set; }
		public int? intcodplantilla { get; set; }
		public int? intcodigoprocedimiento { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
