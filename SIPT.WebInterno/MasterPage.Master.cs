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
                sb.AppendLine("   <nav class='nav d-flex justify-content-between'>");
                sb.AppendLine("        <a class='p-2 text-muted' href='FrmSolicitudAsigna.aspx'>Asignar Solicitud a Analista</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='FrmSolicitudCalifica.aspx'>Calificar Consultas de Zonificación</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='FrmSolicitudAcredita.aspx'>Acreditar Documentación</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='#'>|</a>");
                sb.AppendLine("   </nav>");
            }

            if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
            {
                sb.AppendLine("   <nav class='nav d-flex justify-content-between'>");
                sb.AppendLine("        <a class='p-2 text-muted disabled' href='#'>Asignar Solicitud a Analista</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='FrmSolicitudCalifica.aspx'>Calificar Consultas de Zonificación</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='FrmSolicitudAcredita.aspx'>Acreditar Documentación</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='#'>|</a>");
                sb.AppendLine("   </nav>");
            }

            if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
            {
                sb.AppendLine("   <nav class='nav d-flex justify-content-between'>");
                sb.AppendLine("        <a class='p-2 text-muted' href='FrmSolicitudAsigna.aspx'>Asignar Solicitud a Analista</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='FrmSolicitudCalifica.aspx'>Calificar Consultas de Zonificación</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='#'>Acreditar Documentación</a>");
                sb.AppendLine("        <a class='p-2 text-muted' href='#'>|</a>");
                sb.AppendLine("   </nav>");
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