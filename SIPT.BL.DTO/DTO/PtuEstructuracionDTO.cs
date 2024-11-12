using System;
using System.Collections.Generic;

namespace SIPT.BL.DTO.DTO
{
	[Serializable]
	public class PtuEstructuracionDTO
	{
		public int? intcodestructuracion { get; set; }
		public string vchabrevestructuracion { get; set; }
		public string vchnomestructuracion { get; set; }
		public string vchnotascomplementarias { get; set; }
		public Int16? smlestado { get; set; }
	}
}
