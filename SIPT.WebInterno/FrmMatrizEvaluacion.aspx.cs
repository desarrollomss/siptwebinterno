using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using System;
using System.Collections.Generic;

namespace SIPT.WebInterno
{
    public partial class FrmMatrizEvaluacion : System.Web.UI.Page
    {
        private PtuEstructuracionuso_bo oPtuEstructuracionuso_bo;
        private LogMensajes logMensajes;
        private Request request;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Auditoria
            request = new Request();
            request.vchaudprograma = (string)(Request.Cookies["Security"]["Programa"]);
            request.vchopcion = this.GetType().ToString();
            request.vchaudcodusuario = (string)(Request.Cookies["Security"]["UsuarioId"]);
            request.vchaudequipo = (string)(Request.Cookies["Security"]["DireccionIP"]);
            #endregion

            if (!Page.IsPostBack)
            {
                logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
                try
                {
                    oPtuEstructuracionuso_bo = new PtuEstructuracionuso_bo(ref logMensajes);
                    if (ViewState["ESTRUCTURAS"] is null)
                    {
                        ViewState["ESTRUCTURAS"] = oPtuEstructuracionuso_bo.ListarEstructurasActivas();
                    }
                    ddlEstructura.DataSource = (List<PtuEstructuracionDTO>)ViewState["ESTRUCTURAS"];
                    ddlEstructura.DataTextField = "vchnomestructuracion";
                    ddlEstructura.DataValueField = "intcodestructuracion";
                    ddlEstructura.DataBind();
                    ddlEstructura.SelectedValue = "1";

                    MultiView1.ActiveViewIndex = 0;

                    APPL.FrondEnd.Response.Ok(logMensajes);
                }
                catch (Exception ex)
                {
                    Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                    response.MensajeSwal(ClientScript);
                }
            }
            string clave = litClaves.Text;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                pbd_CargarGrilla();
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }

        protected void gvBusqueda_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvBusqueda.PageIndex = e.NewPageIndex;
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                pbd_CargarGrilla();
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }

        private void pbd_CargarGrilla()
        {
            oPtuEstructuracionuso_bo = new PtuEstructuracionuso_bo(ref logMensajes);
            gvBusqueda.DataSource = oPtuEstructuracionuso_bo.ListarEstructuraPorUso(Convert.ToInt32(ddlEstructura.SelectedValue), txtCodUso.Text.Trim().ToUpper(), txtUso.Text.Trim().ToUpper());
            gvBusqueda.DataBind();
        }

        protected void btnBusDireccion_Click(object sender, EventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            PtuUbicaciones oPtuUbicaciones = new PtuUbicaciones();
            try
            {
                oPtuUbicaciones.vchubipre = txtDireccion.Text.Trim();
                DjuPredio_bo oDjuPredio_bo = new DjuPredio_bo(ref logMensajes);                
                List<PtuUbicaciones> oPtuUbicacionesList = oDjuPredio_bo.Ubicaciones_ListarPorFiltro(oPtuUbicaciones);
                Session["PtuUbicacionesList"] = oPtuUbicacionesList;

                ddlDireccion.DataSource = oPtuUbicacionesList;
                ddlDireccion.DataTextField = "vchubipre";
                ddlDireccion.DataValueField = "intprecodigo";
                ddlDireccion.DataBind();
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }

        protected void ddlEstructura_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codEstructura = ddlEstructura.SelectedValue;
            string tooltip = "";
            if(tooltip == "")
            {
                //tooltip = "<a class=\"mytooltip\" href=\"javascript: void(0)\">(?)<span class=\"tooltip-content5\" ><span class=\"tooltip-text3\" ><span class=\"tooltip-inner2\">";
                //tooltip = tooltip + "<ul>";
                //tooltip = tooltip + "<li>X - Ubicación Conforme.</li>";
                //tooltip = tooltip + "<li>O - Frente a Vias Expesas, Arterias, Colectoras o Avenidas.</li>";
                //tooltip = tooltip + "<li>H - Actividad a desarrollarse a nivel artesanal y con un máximo de 3 personas ocupadas.</li>";
                //tooltip = tooltip + "<li>R - Actividades restringidas sólo para oficinas comerciales y adminstrativas, no se permiten la venta ni almacenamiento de mercaderías.</li>";
                //tooltip = tooltip + "<li>- Actividades que requieren de estudio específico para definir su localización.</li>";
                //tooltip = tooltip + "</ul>";
                //tooltip  = tooltip +"</span></span></span></a>";

                tooltip = tooltip + "<button type=\"button\" data-bs-html=\"true\" class=\"btn btn-secondary\" data-container=\"body\" title=\"Claves\" data-toggle=\"popover\" data-placement=\"bottom\" data-content=\"";                
                tooltip = tooltip + "X - Ubicación Conforme.<br />";
                tooltip = tooltip + "O - Frente a Vias Expesas, Arterias, Colectoras o Avenidas.";
                tooltip = tooltip + "H - Actividad a desarrollarse a nivel artesanal y con un máximo de 3 personas ocupadas.";
                tooltip = tooltip + "R - Actividades restringidas sólo para oficinas comerciales y adminstrativas, no se permiten la venta ni almacenamiento de mercaderías.";
                tooltip = tooltip + "- Actividades que requieren de estudio específico para definir su localización.";
                tooltip = tooltip + "\">";
                tooltip = tooltip + "?";
                tooltip = tooltip + "</button>";

                //tooltip = "<span>HOLA</span>";
            }
            litClaves.Text = tooltip;
        }
    }
}