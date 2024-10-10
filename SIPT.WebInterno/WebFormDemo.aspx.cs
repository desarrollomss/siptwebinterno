using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIPT.WebInterno
{
    public partial class WebFormDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void UpdateTime(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("hh:mm:ss tt");
            string script = "window.onload = function() { UpdateTime('" + time + "'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateTime", script, true);
        }

        protected void btn_descargar_archivo_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { swal('Good job!', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed lorem erat eleifend ex semper, lobortis purus sed.', 'success'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "swal", script, true);
        }
    }
}