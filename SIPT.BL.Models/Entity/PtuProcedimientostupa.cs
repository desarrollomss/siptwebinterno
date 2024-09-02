using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
	public class PtuProcedimientostupa
	{
		public int? intcodigoprocedimiento { get; set; }
		public string vchareaoficina { get; set; }
		public string vchconcepto { get; set; }
		public Int16? smltiposolicitud { get; set; }
		public Int16? smlnivel { get; set; }
		public decimal? decpagoapertura { get; set; }
		public decimal? decpagorenovacion { get; set; }
		public decimal? decpagovencimiento { get; set; }
		public string vchcodderechoapertura { get; set; }
		public string vchcodderechorenovacion { get; set; }
		public string vchcodderechovencimiento { get; set; }
		public int? inttupcodigo { get; set; }
		public string vchoficodigo { get; set; }
		public int? intprocodigo { get; set; }
		public Int16? smlcalificacionautomatica { get; set; }
		public Int16? smlevalpreviapositiva { get; set; }
		public Int16? smlevalprevianegativa { get; set; }
		public Int16? smldiasplazo { get; set; }
		public string vchinstanciasreconsideracion { get; set; }
		public string vchinstanciasapelacion { get; set; }
		public Int16? smlproctupaactivo { get; set; }
		public string vchaudusucreacion { get; set; }
		public DateTime? tmsaudfeccreacion { get; set; }
		public string vchaudusumodif { get; set; }
		public DateTime? tmsaudfecmodif { get; set; }
		public string vchaudequipo { get; set; }
		public string vchaudprograma { get; set; }

	}
}
