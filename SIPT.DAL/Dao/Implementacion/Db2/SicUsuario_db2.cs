using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using System;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Implementacion.Db2
{
    public class SicUsuario_db2 : SicUsuario_dao
    {
        ServiceSicu.GandalfsoftSecurityServiceClient miServicio;
        private LogMensajes logMensajes;
        private SicUsuario sicUsuario;
        private List<SicUsuario> oSicUsuarioList;
        private SicOpcion sicOpcion;

        public SicUsuario_db2(ref LogMensajes logMensajes)
        {
            miServicio = new ServiceSicu.GandalfsoftSecurityServiceClient();
            this.logMensajes = logMensajes;
        }

        public override SicUsuario Login(string username, string password, string aplicacion, string equipo)
        {
            try
            {
                ServiceSicu.securityUser user = miServicio.login(username, username == "ADMINISTRADO" ? "ADMINISTRADO" : password, aplicacion, equipo);
           
                if (user.vchstatus == "ERROR")
                {
                    Log.Error("Error al logear en el servicio soap (sicu)", user.vchmensaje);
                    throw new Exception("Error al logear en el servicio soap (sicu): " + user.vchmensaje);
                }
                else
                {
                    sicUsuario = new SicUsuario();
                    
                    sicUsuario.vchusuariologin = user.vchusulogin;
                    sicUsuario.vchusuarionombres = user.vchusunombre;
                    sicUsuario.vchusuariorol = user.vchusurol;                    
                    sicUsuario.vchsessionid = user.vchsessionid;

                    foreach (ServiceSicu.securityUserEntry dato in user.masDatosUser)
                    {
                        if (dato.key == "INTAPLCODIGO") sicUsuario.intaplicacioncodigo = Convert.ToInt32(dato.value);
                        if (dato.key == "VCHUSUCORREO") sicUsuario.vchcorreo = dato.value;
                        if (dato.key == "INTORGCODIGO") sicUsuario.intareacodigo = Convert.ToInt32(dato.value);
                        if (dato.key == "VCHAPLSIGLA") sicUsuario.vchaplicacionsigla = dato.value;
                        if (dato.key == "VCHORGSIGLA") sicUsuario.vchareasigla = dato.value;
                        if (dato.key == "VCHUSUCODIGO") sicUsuario.intusuariocodigo = Convert.ToInt32(dato.value);
                    }

                    List<SicOpcion> sicOpcionList = new List<SicOpcion>();
                    foreach (ServiceSicu.securityOption opcion in user.listaSecurityOption)
                    {
                        sicOpcion = new SicOpcion();
                        sicOpcion.intopccodigo = opcion.intopccodigo;
                        sicOpcion.intopccodigopadre = opcion.intopccodigopadre;
                        sicOpcion.vchopcaccion = opcion.vchopcaccion;
                        sicOpcion.intopcnivel = opcion.intopcnivel;
                        sicOpcion.intopcorden = opcion.intopcorden;
                        sicOpcion.vchopcnombre = opcion.vchopcnombre;
                        sicOpcion.vchopcdescrip = opcion.vchopcdescrip;
                        sicOpcion.vchopctipo = opcion.vchopctipo;
                        sicOpcionList.Add(sicOpcion);
                    }
                    sicUsuario.sicOpciones = sicOpcionList;
                }
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            return sicUsuario;
        }


        public override List<SicUsuario> ListarUsuariosAppRol(string aplicacion, string usuariorol)
        {
            try
            {
                ServiceSicu.securityUser[] userslist = miServicio.listarUsuariosPorAplicacion(aplicacion);

                    sicUsuario = new SicUsuario();
                    oSicUsuarioList = new List<SicUsuario>();

                    foreach (ServiceSicu.securityUser dato in userslist)
                    {
                        sicUsuario = new SicUsuario();
                        sicUsuario.intusuariocodigo = Convert.ToInt32(dato.usucodigo);
                        sicUsuario.vchareasigla = dato.nombreArea;
                        sicUsuario.vchusuariologin = dato.vchusulogin;
                        sicUsuario.vchusuarionombres = dato.vchusunombre;
                        sicUsuario.vchusuariorol = dato.vchusurol;
                    //dato.area
                    //dato.usuestado
                        if (sicUsuario.vchusuariorol.ToUpper().Equals(usuariorol.ToUpper()))    oSicUsuarioList.Add(sicUsuario);

                    }
  
            }
            catch (Exception ex)
            {
                Log.Error(this.logMensajes.codigoMensaje.ToString(), ex.Message);
                throw ex;
            }
            return oSicUsuarioList;
        }
    }
}
