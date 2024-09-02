using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using SIPT.BL.DTO.DTO;
using System.Configuration;

namespace SIPT.WebInterno
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        private LogMensajes logMensajes;
        private UsuarioDTO ousuarioDTO;
        private Request request;
        private string lstCodUsuario = "PROJAS";
        private string lstPassword = "projas";
        private string lstCodSistema = ConfigurationManager.AppSettings["Sistema"];
        private string lstEquipo = ConfigurationManager.AppSettings["Equipo"];
        private string lstCodModulo = ConfigurationManager.AppSettings["Modulo"];
        private string lstCodOpcion = ConfigurationManager.AppSettings["Opcion"];
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                pfm_ConfiguracionInicial();
                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtUsuario.Focus();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            pbd_Ingresar();
        }

        private void pfm_ConfiguracionInicial()
        {
            lblDerechos.Text = "SIPT ©Copyright 2024.";
            lblCompany.Text = "Municipalidad de Santiago de Surco.";

            /*if (Request.Cookies["Security"] != null)
            {
                FormsAuthentication.RedirectFromLoginPage((string)(Request.Cookies["Security"]["Usuario"]), false);
            }*/
        }

        private void pbd_Ingresar()
        {
            try
            {
                //Cargar Usuario y Validarlo
                lstCodUsuario = txtUsuario.Text.Trim().ToUpper();
                lstPassword = txtPassword.Text.Trim();

                //***IP
                string lstDireccionIP;
                if (Request.ServerVariables["REMOTE_ADDR"] != null)
                    lstDireccionIP = Request.ServerVariables["REMOTE_ADDR"];
                else
                    lstDireccionIP = Request.ServerVariables["REMOTE_HOST"];

                request = new Request();
                request.vchaudprograma = lstCodSistema;
                request.vchaudequipo = lstEquipo;
                request.vchconnombre = lstCodOpcion;
                request.vchaudcodusuario = lstCodUsuario;                

                logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

                ousuarioDTO = new UsuarioDTO();
                //ousuarioDTO = SolicitudFrond.Deserializar<UsuarioDTO>(pSolicitudFrond.objeto);

                try
                {

                    ousuarioDTO.vchusuariologin = lstCodUsuario;
                    ousuarioDTO.vchusuariopassword = lstPassword;

                    Usuario_bo oUsuario_bo = new Usuario_bo(ref logMensajes);
                    UsuarioDTO oUsuarioDTO = oUsuario_bo.Logear(ousuarioDTO, request.vchaudprograma, request.vchaudequipo);
                    //return Resultado.Ok(oUsuarioDTO);
                    //***Autenticación
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        lstCodUsuario,
                        System.DateTime.Now,
                        System.DateTime.Now.AddMinutes(20),
                        false,
                        "",
                        FormsAuthentication.FormsCookiePath);
                    string encTicket;
                    encTicket = FormsAuthentication.Encrypt(ticket);
                    //***Autenticación

                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                    FormsAuthentication.SetAuthCookie(lstCodUsuario, false);
                    Response.Cookies.Add(new HttpCookie("Security"));

                    Response.Cookies["Security"].Values.Add("Usuario", oUsuarioDTO.vchusuariologin);
                    Response.Cookies["Security"].Values.Add("Email", oUsuarioDTO.vchcorreo);
                    Response.Cookies["Security"].Values.Add("Nombres", oUsuarioDTO.vchusuarionombres);
                    Response.Cookies["Security"].Values.Add("CodArea", oUsuarioDTO.intareacodigo.ToString().Trim());
                    Response.Cookies["Security"].Values.Add("Area", oUsuarioDTO.vchareasigla);
                    Response.Cookies["Security"].Values.Add("DireccionIP", oUsuarioDTO.vchequipo);
                    Response.Cookies["Security"].Values.Add("NumSesion", oUsuarioDTO.vchsessionid.ToString().Trim());
                    Response.Cookies["Security"].Values.Add("UsuarioRol", oUsuarioDTO.vchusuariorol.ToString().Trim());
                    Response.Cookies["Security"].Values.Add("UsuarioId", oUsuarioDTO.intusuariocodigo.ToString().Trim());
                    Response.Cookies["Security"].Values.Add("Sistema", oUsuarioDTO.vchaplicacionsigla.ToString().Trim());
                    Response.Cookies["Security"].Values.Add("Modulo", ConfigurationManager.AppSettings["Modulo"]);
                    Response.Cookies["Security"].Values.Add("Opcion", ConfigurationManager.AppSettings["Opcion"]);

                    ////FormsAuthentication.RedirectFromLoginPage(lstCodUsuario, false);
                    //Response.Redirect("FrmSolicitudAsigna.aspx");
                    Response.Redirect("FrmInicio.aspx");


                }
                catch (System.Exception ex)
                {
                    logMensajes.error = ex;
                    Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                    //return Resultado.Error(ex);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "swal('Error!', '" + ex.Message + "', 'error')", true);

                }
                finally
                {
                    logMensajes.FinSolicitud();
                }

            }
            catch (Exception ex)
            {
                //Util.MensajeModal(ex.Message, this);

            }
        }



    }
}