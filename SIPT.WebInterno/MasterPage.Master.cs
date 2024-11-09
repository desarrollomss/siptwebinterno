using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIPT.WebInterno
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private string ltxtUsuarioId;
        private string ltxtUsuarioRol;
        protected void Page_Load(object sender, EventArgs e)
        {
            pfm_ConfiguracionInicial();

            ltxtUsuarioId = (string)(Request.Cookies["Security"]["UsuarioId"]);
            ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);

            // hardcode

            StringBuilder sb = new StringBuilder();


            if (ltxtUsuarioRol.ToUpper().Equals("ADMINISTRADOR SIPT"))
            {
                sb.AppendLine("<li class='nav-small-cap'>LICENCIAS</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudAsigna.aspx' aria-expanded='false'><i class='mdi mdi-bullseye'></i><span class='hide-menu'>Asignar Solicitud</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudCalifica.aspx' aria-expanded='false'><i class='mdi mdi-arrange-send-backward'></i><span class='hide-menu'>Calificar Consultas</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudAcredita.aspx' aria-expanded='false'><i class='mdi mdi-table'></i><span class='hide-menu'>Acreditar Docs.</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li class='nav-small-cap'>ITSE</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudITSE.aspx' aria-expanded='false'><i class='mdi mdi-file'></i><span class='hide-menu'>Solicitudes</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='#' aria-expanded='false'><i class='mdi mdi-widgets'></i><span class='hide-menu'>Inspectores</span></a>");
                sb.AppendLine("</li>");
            }

            if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
            {
                sb.AppendLine("<li class='nav-small-cap'>LICENCIAS</li>");                
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudCalifica.aspx' aria-expanded='false'><i class='mdi mdi-arrange-send-backward'></i><span class='hide-menu'>Calificar Consultas</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudAcredita.aspx' aria-expanded='false'><i class='mdi mdi-table'></i><span class='hide-menu'>Acreditar Docs.</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li class='nav-small-cap'>ITSE</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudITSE.aspx' aria-expanded='false'><i class='mdi mdi-file'></i><span class='hide-menu'>Solicitudes</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='#' aria-expanded='false'><i class='mdi mdi-widgets'></i><span class='hide-menu'>Inspectores</span></a>");
                sb.AppendLine("</li>");
            }

            if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
            {
                sb.AppendLine("<li class='nav-small-cap'>LICENCIAS</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudAsigna.aspx' aria-expanded='false'><i class='mdi mdi-bullseye'></i><span class='hide-menu'>Asignar Solicitud</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudCalifica.aspx' aria-expanded='false'><i class='mdi mdi-arrange-send-backward'></i><span class='hide-menu'>Calificar Consultas</span></a>");
                sb.AppendLine("</li>");                
                sb.AppendLine("<li class='nav-small-cap'>ITSE</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='FrmSolicitudITSE.aspx' aria-expanded='false'><i class='mdi mdi-file'></i><span class='hide-menu'>Solicitudes</span></a>");
                sb.AppendLine("</li>");
                sb.AppendLine("<li> <a class='has-arrow waves-effect waves-dark' href='#' aria-expanded='false'><i class='mdi mdi-widgets'></i><span class='hide-menu'>Inspectores</span></a>");
                sb.AppendLine("</li>");
            }


            ltrMenu.Text = sb.ToString();


        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            //***
            HttpCookie cookie = Request.Cookies["Security"];
            Response.Cookies.Remove("Security");
            cookie.Expires = DateTime.Now.AddDays(-10);
            cookie.Value = null;
            Response.SetCookie(cookie);

            //pbd_CerrarSesion();
            Session.RemoveAll();
            Response.Redirect("frmLogin.aspx");

        }


        private void pfm_ConfiguracionInicial()
        {
            //lblFecha.Text = "Santiago de Surco - " + DateTime.Now.ToLongDateString().ToUpper();
            //string lstCodUsuario = (string)(Request.Cookies["Security"]["Usuario"]);
            
            lblUsuario.Text = (string)(Request.Cookies["Security"]["Usuario"]);
            lblCorreo.Text = (string)(Request.Cookies["Security"]["Email"]);
            lblNombre.Text = (string)(Request.Cookies["Security"]["Nombres"]);
            lblUsuarioId.Text = (string)(Request.Cookies["Security"]["UsuarioId"]);
            lblUsuarioRol.Text = (string)(Request.Cookies["Security"]["UsuarioRol"]);



            //Response.Cookies["Security"].Values.Add("Usuario", oUsuarioDTO.vchusuariologin);
            //Response.Cookies["Security"].Values.Add("Email", oUsuarioDTO.vchcorreo);
            //Response.Cookies["Security"].Values.Add("Nombres", oUsuarioDTO.vchusuarionombres);
            //Response.Cookies["Security"].Values.Add("CodArea", oUsuarioDTO.intareacodigo.ToString().Trim());
            //Response.Cookies["Security"].Values.Add("Area", oUsuarioDTO.vchareasigla);
            //Response.Cookies["Security"].Values.Add("DireccionIP", oUsuarioDTO.vchequipo);
            //Response.Cookies["Security"].Values.Add("NumSesion", oUsuarioDTO.vchsessionid.ToString().Trim());


            //pbd_CargarMenu(ref mnuPrincipal);
        }

    }
}