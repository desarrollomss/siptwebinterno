using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuSolreqgrupo
	{
		public int? intcodsolreqgrupo { get; set; }
		public string vchcodgrupo { get; set; }
		public string vchnombregrupo { get; set; }
		public string chreditable { get; set; }
		public Int16? smltipogrupo { get; set; }
		public Int16? smlmostrartitulo { get; set; }
		public Int16? smlnivel { get; set; }
		public Int16? smlultimonivel { get; set; }
		public int? intcodigofuncion { get; set; }
		public int? intsolicitudplantilla { get; set; }
		public int? intcodsolreqgrppadre { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
