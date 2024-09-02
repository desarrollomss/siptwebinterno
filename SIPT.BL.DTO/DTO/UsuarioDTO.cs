using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPT.BL.DTO.DTO
{
    public class UsuarioDTO
    {
        public int? intusuariocodigo { get; set; }
        public string vchusuariologin { get; set; }
        public string vchusuariopassword { get; set; }
        public string vchusuarionombres { get; set; }
        public string vchusuariorol { get; set; }
        public string vchcorreo { get; set; }
        public int? intareacodigo { get; set; }
        public string vchareasigla { get; set; }
        public int? intaplicacioncodigo { get; set; }
        public string vchaplicacionsigla { get; set; }
        public string vchsessionid { get; set; }
        public string vchequipo { get; set; }
        public string vchmenu { get; set; }

    }
}
