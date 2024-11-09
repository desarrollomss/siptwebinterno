using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Services;
using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace SIPT.WebInterno
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        private LogMensajes logMensajes;
        private UsuarioDTO ousuarioDTO;
        private Request request;
        private string lstCodUsuario = "";
        private string lstPassword = "";

        private string lstCodSistema = ConfigurationManager.AppSettings["Sistema"];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Auditoria
            request = new Request();
            request.vchopcion = this.GetType().ToString();
            #endregion
            if (!Page.IsPostBack)
            {
                pfm_ConfiguracionInicial();
                txtUsuario.Text = "";
                txtPassword.Text = "";                
            }
            txtUsuario.Focus();
        }

        protected void btnLogear_Click(object sender, EventArgs e)
        {
            pbd_Ingresar();
        }

        private void pfm_ConfiguracionInicial()
        {
            //lblDerechos.Text = "SIPT ©Copyright 2024.";
            //lblCompany.Text = "Municipalidad de Santiago de Surco.";

            /*if (Request.Cookies["Security"] != null)
            {
                FormsAuthentication.RedirectFromLoginPage((string)(Request.Cookies["Security"]["Usuario"]), false);
            }*/
        }

        private void pbd_Ingresar()
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


            request.vchaudprograma = lstCodSistema;
            request.vchaudequipo = lstDireccionIP;
            request.vchconnombre = System.Reflection.MethodBase.GetCurrentMethod().Name;
            request.vchaudcodusuario = lstCodUsuario;

            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ousuarioDTO = new UsuarioDTO();

            try
            {
                ousuarioDTO.vchusuariologin = lstCodUsuario;
                ousuarioDTO.vchusuariopassword = lstPassword;

                Usuario_bo oUsuario_bo = new Usuario_bo(ref logMensajes);
                UsuarioDTO oUsuarioDTO = oUsuario_bo.Logear(ousuarioDTO, request.vchaudprograma, ConfigurationManager.AppSettings["Equipo"]);
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
                Response.Cookies["Security"].Values.Add("Email", oUsuarioDTO.vchcorreo.ToLower());
                Response.Cookies["Security"].Values.Add("Nombres", oUsuarioDTO.vchusuarionombres);
                Response.Cookies["Security"].Values.Add("CodArea", oUsuarioDTO.intareacodigo.ToString().Trim());
                Response.Cookies["Security"].Values.Add("Area", oUsuarioDTO.vchareasigla);
                Response.Cookies["Security"].Values.Add("DireccionIP", lstDireccionIP);
                Response.Cookies["Security"].Values.Add("NumSesion", oUsuarioDTO.vchsessionid.ToString().Trim());
                Response.Cookies["Security"].Values.Add("UsuarioRol", oUsuarioDTO.vchusuariorol.ToString().Trim());
                Response.Cookies["Security"].Values.Add("UsuarioId", oUsuarioDTO.intusuariocodigo.ToString().Trim());
                Response.Cookies["Security"].Values.Add("Sistema", lstCodSistema);
                Response.Cookies["Security"].Values.Add("Modulo", ConfigurationManager.AppSettings["Modulo"]);
                Response.Cookies["Security"].Values.Add("Opcion", ConfigurationManager.AppSettings["Opcion"]);

                APPL.FrondEnd.Response.Ok(logMensajes);
                
                Response.Redirect("FrmInicio.aspx");

            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }

        }

    }
}