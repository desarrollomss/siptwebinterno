using System;
using System.Collections.Generic;

namespace SIPT.BL.DTO.DTO
{
	public class PtuCertificadoDTO
	{
		public int? intcodcertificado { get; set; }
		public string chrceranio { get; set; }
		public string vchcernumero { get; set; }
		public int? intcerttipo { get; set; }
		public int? smlcertvigencia { get; set; }
		public string chrresolucionanio { get; set; }
		public string vchmunicipalidad { get; set; }
		public string vchnombrecomercial { get; set; }
		public string vchubicacion { get; set; }
		public string vchdistrito { get; set; }
		public string vchprovincia { get; set; }
		public string vchdepartamento { get; set; }
		public string vchsolicitante { get; set; }
		public int? intcapacidadnumero { get; set; }
		public string vchcapacidadletras { get; set; }
		public string vchnombreuso { get; set; }
		public string vchnumexpediente { get; set; }
		public string vchnumresolucion { get; set; }
		public DateTime? datfechaexpedicion { get; set; }
		public DateTime? datfechasolicitudrenovacion { get; set; }
		public DateTime? datfechavencimiento { get; set; }
		public Int16? smlvigencia { get; set; }
		public string vchreporte { get; set; }
		public int? intcodsolicitud { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
