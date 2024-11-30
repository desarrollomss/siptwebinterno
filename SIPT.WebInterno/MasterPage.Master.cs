using System;
using System.Web;

namespace SIPT.WebInterno
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private string ltxtUsuarioId;
        private string ltxtUsuarioRol;
        private string ltxtMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            pfm_ConfiguracionInicial();

            ltxtUsuarioId = (string)(Request.Cookies["Security"]["UsuarioId"]);
            ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);

            if (Session["Menu"] is null)
            {
                btnSalir_Click(sender, e);
            }
            else
            {
                ltxtMenu = Session["Menu"].ToString();
            }

            ltrMenu.Text = ltxtMenu.Replace("<![CDATA[", string.Empty).Replace("]]>", string.Empty);
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

            Session.RemoveAll();
            Response.Redirect("frmLogin.aspx");
        }


        private void pfm_ConfiguracionInicial()
        {            
            lblUsuario.Text = (string)(Request.Cookies["Security"]["Usuario"]);
            lblCorreo.Text = (string)(Request.Cookies["Security"]["Email"]);
            lblNombre.Text = (string)(Request.Cookies["Security"]["Nombres"]);
            lblUsuarioId.Text = (string)(Request.Cookies["Security"]["UsuarioId"]);
            lblUsuarioRol.Text = (string)(Request.Cookies["Security"]["UsuarioRol"]);

        }

    }
}