using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPT.BL.Models.Consultas
{
    public class PtuSolicitud_PorAnalistaPorSolicitante
    {
        public int? intnumerofila { get; set; }
        public int? intcodsolicitud { get; set; }
        public string vchareaoficina { get; set; }
        public string vchanionumero { get; set; }
        public Int16? smltiposolicitud { get; set; }
        public string vchtiposolicitud { get; set; }
        public Int16? smlcondicionsolicitud { get; set; }
        public string vchcondicionsolicitud { get; set; }
        public int? intcodigoprocedimiento { get; set; }
        public string vchconcepto { get; set; }
        public int? intadmpropietario { get; set; }
        public string vchadmcompleto { get; set; }
        public string vchnumordenatencion { get; set; }
        public string vchnumruc { get; set; }
        public string vchnombrecomercio { get; set; }
        public int? intcodigosolicitante { get; set; }
        public string vchnombresolicitante { get; set; }
        public Int16? smlcondicionsolicitante { get; set; }
        public string vchcondicionsolicitante { get; set; }
        public int? intcodrepresentantelegal { get; set; }
        public int? intdoccodigoexpediente { get; set; }
        public string vchnumexpediente { get; set; }
        public DateTime? datregexpediente { get; set; }
        public DateTime? datregsolicitud { get; set; }
        public decimal? deccosto { get; set; }
        public decimal? decareaocupar { get; set; }
        public string vchnumerorecibo { get; set; }
        public string vchobservacion { get; set; }
        public Int16? smlestsollicencia { get; set; }
        public string vchestsollicencia { get; set; }
        public Int16? smlresultado { get; set; }
        public string vchresultado { get; set; }
        //public Int16? smlestlicencia { get; set; }
        //public string vchestlicencia { get; set; }
        public int? intusuanalista { get; set; }
        public string vchusuanalista { get; set; }
        public int? intcodigopredio { get; set; }
        public string vchpredireccion { get; set; }
        public string vchanionumerolic { get; set; }        
        public string vchestsolrequerimientos { get; set; }
        public string vchemailsol { get; set; }
        public Int16? smlorden { get; set; }
    }
}