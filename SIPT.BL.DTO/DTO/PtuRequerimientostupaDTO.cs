using System;
using System.Collections.Generic;

namespace SIPT.BL.DTO.DTO
{
	public class PtuRequerimientostupaDTO
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
		public string vchnombreplantilla { get; set; }

		public virtual List<PtuPlantillareqDTO> PtuPlantillareqDTO  { get; set; }
	}
}
