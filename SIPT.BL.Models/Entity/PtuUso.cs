﻿using System;

namespace SIPT.BL.Models.Entity
{
    public class PtuUso
    {
        public int? intcoduso { get; set; }
        public string vchcoduso { get; set; }
        public string vchnombreuso { get; set; }
        public string chrtipo { get; set; }
        public Int16? smlnivel { get; set; }
        public int? intcodusopadre { get; set; }
        public Int16? smlestado { get; set; }
        public string vchcodgrupo { get; set; }
        public string vchnombregrupo { get; set; }
        public string vchcodcategoria1 { get; set; }
        public string vchnombrecategoria1 { get; set; }
        public string vchcodcategoria2 { get; set; }
        public string vchnombrecategoria2 { get; set; }
        public string vchcodcategoria3 { get; set; }
        public string vchnombrecategoria3 { get; set; }
        public string vchaudusucreacion { get; set; }
        public DateTime? tmsaudfeccreacion { get; set; }
        public string vchaudusumodif { get; set; }
        public DateTime? tmsaudfecmodif { get; set; }
        public string vchaudequipo { get; set; }
        public string vchaudprograma { get; set; }

    }
}


