using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.DTO.DTO
{
    public class PtuSolicitudDTO
    {
        public DateTime? datceseexpefecha { get; set; }
        public DateTime? datregexpediente { get; set; }
        public DateTime? datregsolicitud { get; set; }
        public DateTime? datvigenciafin { get; set; }
        public DateTime? datvigenciaini { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public decimal? decareaocupar { get; set; }
        public decimal? deccosto { get; set; }
        public int? intadmpropietario { get; set; }
        public int? intcodigopredio { get; set; }
        public int? intcodigoprocedimiento { get; set; }
        public int? intcodigosolicitante { get; set; }
        public int? intcodrepresentantelegal { get; set; }
        public int? intcodsolicitud { get; set; }
        public int? intcodsolicitudanalista { get; set; }
        public int? intnumestacionamientos { get; set; }
        public int? intnumpredio { get; set; }
        public int? intnumtrabajadores { get; set; }
        public int? intusuanalista { get; set; }
        public Int16? smlcesecodmotivo { get; set; }
        public Int16? smlcondicionsolicitante { get; set; }
        public Int16? smlcondicionsolicitud { get; set; }
        public Int16? smlestlicencia { get; set; }
        public Int16? smlestsollicencia { get; set; }
        public Int16? smlrequiereinspec { get; set; }
        public Int16? smlresultado { get; set; }
        public Int16? smltiposolicitud { get; set; }
        public string chranio { get; set; }
        public string chrceseaniolic { get; set; }
        public string chrcodlotecatastral { get; set; }
        public string vchadmcompleto { get; set; }
        public string vchareaoficina { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }
        public string vchaudusucreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public string vchceseexpenumero { get; set; }
        public string vchcesenumerolic { get; set; }
        public string vchconclusion { get; set; }
        public string vchcondicionsolicitante { get; set; }
        public string vchdireccionsol { get; set; }
        public string vchdocumentoreprelegal { get; set; }
        public string vchemailsol { get; set; }
        public string vchnombrecomercio { get; set; }
        public string vchnombresolicitante { get; set; }
        public string vchnomrepresentantelegal { get; set; }
        public string vchnrodocumentosol { get; set; }
        public string vchnropartidasunarprlegal { get; set; }
        public string vchnrorucsol { get; set; }
        public string vchnumcolegio { get; set; }
        public string vchnumdeclfabrica { get; set; }
        public string vchnrotelefonosol { get; set; }
        public string vchnumero { get; set; }
        public string vchnumerorecibo { get; set; }
        public int? intdoccodigoexpediente { get; set; }
        public string vchnumexpediente { get; set; }
        public string vchnumlicenciaconstr { get; set; }
        public string vchnumordenatencion { get; set; }
        public string vchnumruc { get; set; }
        public string vchobservacion { get; set; }
        public string vchtidcodigosol { get; set; }
        public string vchtipoempresa { get; set; }
        public string vchubicacionpredio { get; set; }
        public string vchzonificacion { get; set; }
        public string vchestructuracion { get; set; }
        public string vchestsolrequerimientos { get; set; }
        public Int16? smlpuertaacalle { get; set; }
        public virtual List<PtuUsoDTO> PtuUsosDTO { get; set; }
    }
}
