using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuDiligencia
	{
		public int? intcoddiligencia { get; set; }
		public DateTime? datfechadiligencia { get; set; }
		public Int16? smlhoradiligencia { get; set; }
		public string vchfileactadiligencia { get; set; }
		public string vchfileinformecumplimiento { get; set; }
		public string vchfilepanelfotografico { get; set; }

		public string vchobsinspector { get; set; }
		public string vchobssolicitante { get; set; }
		public Int16? smlestdiligencia { get; set; }
		public DateTime? datfechamaxsubsanacion { get; set; }
		public DateTime? datfechareprogramacion { get; set; }
		public int? intcodsolicitud { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
