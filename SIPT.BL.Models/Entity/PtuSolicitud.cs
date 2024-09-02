using System;
using System.Collections.Generic;

namespace SIPT.BL.Models.Entity
{
    public class PtuSolicitud
    {
        public int? intcodsolicitud { get; set; }
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
        public string vchobservacion { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }
        public string vchestsolrequerimientos { get; set; }


        //public int? intcodsolicitud { get; set; }
        //public string vchareaoficina { get; set; }
        //public string chranio { get; set; }
        //public string vchnumero { get; set; }
        //public Int16? smltiposolicitud { get; set; }
        //public Int16? smlcondicionsolicitud { get; set; }
        //public int? intcodigoprocedimiento { get; set; }
        //public int? intadmpropietario { get; set; }
        //public string vchnumordenatencion { get; set; }
        //public string vchnumruc { get; set; }
        //public string vchnombrecomercio { get; set; }
        //public int? intcodigosolicitante { get; set; }
        //public string vchnombresolicitante { get; set; }
        //public int? intcodrepresentantelegal { get; set; }
        //public string vchnumexpediente { get; set; }
        //public DateTime? datregexpediente { get; set; }
        //public DateTime? datregsolicitud { get; set; }
        //public decimal? deccosto { get; set; }
        //public string vchnumerorecibo { get; set; }
        //public string vchobservacion { get; set; }
        //public string vchaudusucreacion { get; set; }
        //public DateTime? tmsaudfeccreacion { get; set; }
        //public string vchaudusumodif { get; set; }
        //public DateTime? tmsaudfecmodif { get; set; }
        //public string vchaudequipo { get; set; }
        //public string vchaudprograma { get; set; }

        public virtual ICollection<PtuSolLicenciaUso> PtuSolLicenciaUsos { get; set; }
        public PtuSolLicencia SolicitudLicencia { get; set; }

        /*
        public int? intcodsolicitud { get; set; }
        public string vchareaoficina { get; set; }
        public string chranio { get; set; }
        public string vchnumero { get; set; }
        public int? smltiposolicitud { get; set; }
        public int? smlcondicionsolicitud { get; set; }
        public int? intcodigoprocedimiento { get; set; }
        public int? intadmpropietario { get; set; }

        public string vchadmcompleto { get; set; }

        public string vchnumordenatencion { get; set; }
        public string vchnumruc { get; set; }
        public string vchnombrecomercio { get; set; }
        public int? intcodigosolicitante { get; set; }
        public string vchnombresolicitante { get; set; }
        public int? intcodrepresentantelegal { get; set; }
        public string vchnumexpediente { get; set; }
        public DateTime? datregexpediente { get; set; }
        public DateTime? datregsolicitud { get; set; }
        public decimal? deccosto { get; set; }
        public string vchnumerorecibo { get; set; }
        public string vchobservacion { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }
        public List<PtuSolLicenciaUso> Usos { get; set; }
        public PtuSolLicencia SolicitudLicencia { get; set; }
        */

    }

}