using System;

namespace SIPT.BL.Models.Entity
{
    public class PtuSolLicencia
    {
		public int? intcodsolicitud { get; set; }
		public decimal? decareaocupar { get; set; }
		public Int16? smlcondicionsolicitante { get; set; }
		public int? intcodigopredio { get; set; }
		public int? intnumpredio { get; set; }
		public string chrcodlotecatastral { get; set; }
		public string vchdireccionpredio { get; set; }
		public string vchlocalidad { get; set; }
		public string vchdiscodigo { get; set; }
		public string vchnomdistrito { get; set; }
		public string vchnomprovincia { get; set; }
		public string vchdepartamento { get; set; }
		public DateTime? datvigenciaini { get; set; }
		public DateTime? datvigenciafin { get; set; }
		public int? intnumtrabajadores { get; set; }
		public string vchobservacion { get; set; }
		public string vchnumcolegio { get; set; }
		public Int16? smlrequiereinspec { get; set; }
		public int? intnumestacionamientos { get; set; }
		public string vchtipoempresa { get; set; }
		public string vchzonificacion { get; set; }
		public string vchconclusion { get; set; }
		public string vchnumlicenciaconstr { get; set; }
		public string vchnumdeclfabrica { get; set; }
		public string vchcesenumerolic { get; set; }
		public string chrceseaniolic { get; set; }
		public string vchceseexpenumero { get; set; }
		public DateTime? datceseexpefecha { get; set; }
		public Int16? smlcesecodmotivo { get; set; }
		public Int16? smlestsollicencia { get; set; }
		public Int16? smlresultado { get; set; }
		public Int16? smlestlicencia { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }
	}
}
