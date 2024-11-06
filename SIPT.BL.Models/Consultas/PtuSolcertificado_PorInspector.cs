using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPT.BL.Models.Consultas
{
    public class PtuSolcertificado_PorInspector
    {
        public int? intcodsolicitud { get; set; }
        public string vchnomcomercialsolcert { get; set; }
        public string vchdireccsolicitantecert { get; set; }
        public DateTime? datfechaprogramacion { get; set; }
        public DateTime? datfechavencimiento { get; set; }
        public Int16? smlestsolcertificado { get; set; }
        public string vchestsolcertificado { get; set; }

        public Int16? smlresultadocertificacion { get; set; }
        public string vchresultadocertificacion { get; set; }

        public string vchzonificacion { get; set; }
        public string vchestructuracion { get; set; }
        public string vchobservacion { get; set; }
        public int? intcodsolicitudlicencia { get; set; }
        public string vchreporteresolucion { get; set; }
        public int? intcodlicencia { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }

        // Solicitud
        public string vchareaoficina { get; set; }
        public string chranio { get; set; }
        public string vchnumero { get; set; }
        public Int16? smltiposolicitud { get; set; }
        public Int16? smlcondicionsolicitud { get; set; }
        public int? intcodigoprocedimiento { get; set; }
        public int? intadmpropietario { get; set; }
        public string vchnumordenatencion { get; set; }
        public string vchnumruc { get; set; }
        public string vchnombrecomercio { get; set; }
        public int? intcodrepresentantelegal { get; set; }
        public string vchnomrepresentantelegal { get; set; }
        public string vchdocumentoreprelegal { get; set; }
        public string vchnropartidasunarprlegal { get; set; }
        public int? intdoccodigoexpediente { get; set; }
        public string vchnumexpediente { get; set; }
        public DateTime? datregexpediente { get; set; }
        public DateTime? datregsolicitud { get; set; }
        public decimal? deccosto { get; set; }
        public string vchnumerorecibo { get; set; }
        public int? intcodigosolicitante { get; set; }
        public string vchnombresolicitante { get; set; }
        public string vchtidcodigosol { get; set; }
        public string vchnrodocumentosol { get; set; }
        public string vchnrorucsol { get; set; }
        public string vchnrotelefonosol { get; set; }
        public string vchemailsol { get; set; }
        public string vchdireccionsol { get; set; }
        public string vchestsolrequerimientos { get; set; }

        // Licencia

        public string chlicanio { get; set; }
        public string vchlicnumero  { get; set; }

    }
}