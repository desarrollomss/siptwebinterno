using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
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
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                oPtuEstructuracionuso_bo = new PtuEstructuracionuso_bo(ref logMensajes);
                gvBusqueda.DataSource = oPtuEstructuracionuso_bo.ListarEstructuraPorUso(Convert.ToInt32(ddlEstructura.SelectedValue), txtCodUso.Text.Trim().ToUpper(), txtUso.Text.Trim().ToUpper());
                gvBusqueda.DataBind();

                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }
    }
}