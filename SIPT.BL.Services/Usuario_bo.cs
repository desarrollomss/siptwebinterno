using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using Newtonsoft.Json;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;
using SIPT.BL.DTO.Mapper;

namespace SIPT.BL.Services
{
    public class Usuario_bo
    {
        private SicUsuario_dao sicUsuario_dao;
        private SicUsuario sicUsuario;
        private List<SicUsuario> sicUsuarioList;
        private UsuarioDTO usuarioDTO;
        private LogMensajes logMensajes;
        private ConAdministrado_bo conAdministrado_bo;
        private ConContacto_bo conContacto_bo;
        public Usuario_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public UsuarioDTO Logear(UsuarioDTO pUsuarioDTO, string vchaplicacion, string vchequipo)
        {
            sicUsuario_dao = ObjectFactory.Instanciar<SicUsuario_dao>(new SicUsuario(), this.logMensajes);
            sicUsuario = sicUsuario_dao.Login(pUsuarioDTO.vchusuariologin, pUsuarioDTO.vchusuariopassword, vchaplicacion, vchequipo);
                
            Mapeos mapeo = new Mapeos();
            usuarioDTO = mapeo.Map<SicUsuario, UsuarioDTO>(sicUsuario);
            usuarioDTO.vchusuariopassword = pUsuarioDTO.vchusuariopassword;

            List<MenuFuse> menu = CargaOpciones(sicUsuario, 0);
            string jsonMenu = JsonConvert.SerializeObject(menu, Formatting.Indented);
            usuarioDTO.vchmenu = jsonMenu;

            if (usuarioDTO.vchusuariologin == "ADMINISTRADO")
            {
                conAdministrado_bo = new ConAdministrado_bo(ref logMensajes);
                ConAdministrado oConAdministrado = conAdministrado_bo.ListarplataformaPorId(Convert.ToInt32(usuarioDTO.vchusuariopassword));

                conContacto_bo = new ConContacto_bo(ref logMensajes);
                ConContacto oConContacto = conContacto_bo.ListarPlataformaPorId(Convert.ToInt32(usuarioDTO.vchusuariopassword), TipoContacto.Email);

                usuarioDTO.vchusuarionombres = oConAdministrado.vchadmcompleto;
                usuarioDTO.vchcorreo = oConContacto.vchcondescri;
            }

            return usuarioDTO;
        }

        private List<MenuFuse> CargaOpciones(SicUsuario sicUsuario, int? intopccodigopadre)
        {
            List<MenuFuse> mimenu = new List<MenuFuse>();
            List<SicOpcion> sicOpciones = sicUsuario.sicOpciones;
            MenuFuse nodo = null;

            if (intopccodigopadre == 0)
            {
                nodo = new MenuFuse();
                nodo.id = "0";
                nodo.title = "Inicio";
                nodo.link = "inicio";
                nodo.type = "basic";
                nodo.icon = "heroicons_outline:home";
                mimenu.Add(nodo);
            }

            foreach (SicOpcion opcion in sicOpciones)
            {
                if (opcion.intopccodigopadre == intopccodigopadre)
                {
                    nodo = new MenuFuse();
                    nodo.id = opcion.intopccodigo.ToString();
                    nodo.title = opcion.vchopcnombre;
                    nodo.icon = "heroicons_outline:" + opcion.vchopcdescrip.ToLower();                   

                    if (opcion.vchopcaccion is null || opcion.vchopcaccion == "-")
                    {
                        if (opcion.intopcnivel == 1) nodo.type = "collapsable";
                        else nodo.type = "aside";
                    }
                    else
                    {
                        nodo.link = opcion.vchopcaccion;
                        nodo.type = "basic";
                    }
                    nodo.children = CargaOpciones(sicUsuario, opcion.intopccodigo);

                    mimenu.Add(nodo);
                }
            }
            return mimenu;
        }

        private class MenuFuse
        {
            public string id { get; set; }
            public string title { get; set; }
            public string link { get; set; }            
            public string type { get; set; }
            public string icon { get; set; }            
            public List<MenuFuse> children { get; set; }

            //public string tooltip { get; set; }
            //public bool disabled { get; set; }
        }

        public List<SicUsuario> ListarUsuariosAppRol(string aplicacion, string usuariorol)
        {
            sicUsuario_dao = ObjectFactory.Instanciar<SicUsuario_dao>(new SicUsuario(), this.logMensajes);
            sicUsuarioList = sicUsuario_dao.ListarUsuariosAppRol(aplicacion, usuariorol);

            return sicUsuarioList;

        }



    }
}
