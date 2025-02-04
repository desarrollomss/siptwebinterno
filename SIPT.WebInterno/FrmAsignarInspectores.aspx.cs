using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using SIPT.WebInterno.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SIPT.WebInterno
{
    public partial class FrmAsignarInspectores : System.Web.UI.Page
    {

        //private SIPT.WebInterno
        private LogMensajes logMensajes;
        private Request request;
        private PtuTabla oPtuTabla;
        private List<PtuTabla> oPtuTablaList = new List<PtuTabla>();
        private PtuTabla_bo oPtuTabla_bo;

        private PtuSolcertificado oPtuSolcertificado;
        private PtuSolicitud oPtuSolicitud;

        private PtuSolcertificadoinspector_bo oPtuSolcertificadoinspector_bo;
        private PtuSolcertificadoinspectorDTO oPtuSolcertificadoinspectorDTO;



        private PtuDiligencia oPtuDiligencia;
        private PtuDiligenciaDTO oPtuDiligenciaDTO;
        private PtuDiligencia_bo oPtuDiligencia_bo;

        public List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();

        private Usuario_bo oUsuario_bo;
        private string ltxtUsuarioRol;



        PtuSolicitud_bo oPtuSolicitud_bo;



        protected void Page_Load(object sender, EventArgs e)
        {
            #region Auditoria
            ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);

            request = new Request();
            request.vchaudprograma = (string)(Request.Cookies["Security"]["Sistema"]);
            request.vchopcion = this.GetType().ToString();
            request.vchaudcodusuario = (string)(Request.Cookies["Security"]["UsuarioId"]);
            request.vchaudequipo = (string)(Request.Cookies["Security"]["DireccionIP"]);
            #endregion


            if (!Page.IsPostBack)
            {
                ViewState["ANALISTA"] = Funciones.ListarUsuariosRol(request, "INSPECTOR SIPT");

                logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
                try
                {

                    ddlInspectorBus.DataSource = (DataTable)ViewState["ANALISTA"];
                    ddlInspectorBus.DataTextField = "VCHUSUANALISTA";
                    ddlInspectorBus.DataValueField = "INTUSUANALISTA";
                    ddlInspectorBus.DataBind();
                    ddlInspectorBus.Items.Insert(0, new ListItem("(Todos)", "0"));


                    ddlAnioBus.DataSource = Funciones.ListarAnio();
                    ddlAnioBus.DataTextField = "TXTANIO";
                    ddlAnioBus.DataValueField = "INTANIO";
                    ddlAnioBus.DataBind();
                    ddlAnioBus.Items.Insert(0, new ListItem("(Todos)", "0"));

                    oPtuTabla = new PtuTabla();
                    oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);

                    // ESTADO SOLICITUD
                    oPtuTabla.vchtabla = "PTUSOLCERTIFICADO";
                    oPtuTabla.vchcampo = "SMLESTSOLCERTIFICADO";
                    oPtuTablaList = oPtuTabla_bo.ListarGrupo(oPtuTabla);

                    ddlEstadoBus.DataSource = oPtuTablaList;
                    ddlEstadoBus.DataTextField = "VCHDESCRIPCION";
                    ddlEstadoBus.DataValueField = "SMLCODTABLA";
                    ddlEstadoBus.DataBind();
                    ddlEstadoBus.Items.Insert(0, new ListItem("(Todos)", "0"));

                    // ESTADO DILIGENCIA
                    oPtuTabla.vchtabla = "PTUDILIGENCIA";
                    oPtuTabla.vchcampo = "SMLESTDILIGENCIA";
                    oPtuTablaList = oPtuTabla_bo.ListarGrupo(oPtuTabla);

                    oPtuTabla.vchtabla = "PTUSOLCERTIFICADO";
                    oPtuTabla.vchcampo = "SMLRESULTADOCERTIFICACION";
                    oPtuTablaList = oPtuTabla_bo.ListarGrupo(oPtuTabla);

                    ddlResultadoBus.DataSource = oPtuTablaList;
                    ddlResultadoBus.DataTextField = "VCHDESCRIPCION";
                    ddlResultadoBus.DataValueField = "SMLCODTABLA";
                    ddlResultadoBus.DataBind();
                    ddlResultadoBus.Items.Insert(0, new ListItem("(Todos)", "0"));

                    APPL.FrondEnd.Response.Ok(logMensajes);
                }
                catch (Exception ex)
                {
                    Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                    response.MensajeSwal(ClientScript);
                }
            }



        }


        protected void gvSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlInspectores = (DropDownList)e.Row.FindControl("ddlInspectores");

                    Label lblSCUCodAnalista = (Label)e.Row.FindControl("lblCodAnalista");

                    Label lblCodSolicitud = (Label)e.Row.FindControl("lblCodSolicitud");

                    Label lblEstSolCerTxt = (Label)e.Row.FindControl("lblEstSolCerTxt");
                    Label lblEstSolCer = (Label)e.Row.FindControl("lblEstSolCer");

                    Button btnCalifica = (Button)e.Row.FindControl("btnCalifica");
                    int lintCodSolicitud = Convert.ToInt32(lblCodSolicitud.Text);

                    ddlInspectores.DataSource = (DataTable)ViewState["ANALISTA"];
                    ddlInspectores.DataTextField = "VCHUSUANALISTA";
                    ddlInspectores.DataValueField = "INTUSUANALISTA";
                    ddlInspectores.DataBind();
                    ddlInspectores.Items.Insert(0, new ListItem("(Seleccione)", "0"));

                    //if (lblSCUCodAnalista.Text != "0")
                    //{
                    //    ddlSCUAnalista.SelectedValue = lblSCUCodAnalista.Text;
                    //}

                    GridView gvInspectores = (GridView)e.Row.FindControl("gvInspectores");
                    

                    gvInspectores.DataSource = pbd_CargarGrillaInspectores(0, lintCodSolicitud);
                    gvInspectores.DataBind();


                    


                }
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }


        protected void gvSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                gvSolicitud.PageIndex = e.NewPageIndex;
                pbd_CargarGrillaSolicitud();

                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }


        private void pbd_CargarGrillaSolicitud()
        {
            /* Lista pendientes por Rol o Analista*/

            oPtuSolicitud = new PtuSolicitud();
            oPtuSolcertificado = new PtuSolcertificado();


            oPtuSolicitud.chranio = ddlAnioBus.SelectedValue;
            oPtuSolicitud.vchnumero = txtNumSolBus.Text;
            oPtuSolicitud.vchnumexpediente = txtNumExpBus.Text;
            if (txtCodAdmBus.Text.Length > 0)
            {
                oPtuSolicitud.intcodigosolicitante = Convert.ToInt32(txtCodAdmBus.Text);
            }

            oPtuSolicitud.vchnombresolicitante = txtNomSolBus.Text;
            oPtuSolcertificado.smlestsolcertificado = Convert.ToInt16(ddlEstadoBus.SelectedValue);
            oPtuSolcertificado.smlresultadocertificacion = Convert.ToInt16(ddlResultadoBus.SelectedValue);

            PtuSolcertificado_bo oPtuSolcertificado_bo = new PtuSolcertificado_bo(ref logMensajes);
            List<PtuSolcertificado_PorInspector> oPtuSolcertificado_PorInspectorList = oPtuSolcertificado_bo.Buscar(oPtuSolcertificado, oPtuSolicitud);
            gvSolicitud.DataSource = oPtuSolcertificado_PorInspectorList;
            gvSolicitud.DataBind();

        }

        private List<PtuSolcertificadoinspectorDTO> pbd_CargarGrillaInspectores(int? pintcodsolicitudinspector, int? pintcodsolicitud)
        {

            List<PtuSolcertificadoinspectorDTO> oPtuSolcertificadoinspectorDTOList = new List<PtuSolcertificadoinspectorDTO>();
            PtuSolcertificadoinspector_bo oPtuSolcertificadoinspector_bo = new PtuSolcertificadoinspector_bo(ref logMensajes);

            oPtuSolcertificadoinspectorDTOList = oPtuSolcertificadoinspector_bo.ListarKeys(pintcodsolicitudinspector, pintcodsolicitud);

            return oPtuSolcertificadoinspectorDTOList;

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlAnioBus.SelectedValue = "0";
            txtNumSolBus.Text = "";
            ddlEstadoBus.SelectedValue = "0";
            ddlResultadoBus.SelectedValue = "0";
            txtNumExpBus.Text = "";
            txtCodAdmBus.Text = "";
            txtNomSolBus.Text = "";

            //MultiView1.ActiveViewIndex = 1;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                pbd_CargarGrillaSolicitud();

                Response response = APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            PtuDiligenciaDTO oPtuDiligenciaDTO = new PtuDiligenciaDTO();

            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                GridViewRow gwrow = (GridViewRow)((Button)sender).NamingContainer;
                int lintCodDiligencia = Convert.ToInt32(gwrow.Cells[0].Text);
                hdfCodDiligencia.Value = lintCodDiligencia.ToString();

                PtuDiligencia_bo oPtuDiligencia_bo = new PtuDiligencia_bo(ref logMensajes);

                oPtuDiligenciaDTO = oPtuDiligencia_bo.ListarKey(lintCodDiligencia);

                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }

        }

        protected void btnAsignarInsp_Click(object sender, EventArgs e)
        {
            GridViewRow gwrow = (GridViewRow)((Button)sender).NamingContainer;

            DropDownList ddlInspectores = (DropDownList)gwrow.FindControl("ddlInspectores");
            Label lblCodSolicitud = (Label)gwrow.FindControl("lblCodSolicitud");
            GridView gv = (GridView)gwrow.FindControl("gvInspectores");

            if (ddlInspectores.SelectedValue.Equals("0"))
            {
                return;
            }

            foreach (GridViewRow fila in gv.Rows)
            {
                //Si el dato esta en un control, en este caso un Label
                
                if (fila.Cells[0].Text.Equals(ddlInspectores.SelectedValue))
                {
                    return;
                }
            }


            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                PtuSolcertificadoinspectorDTO oPtuSolcertificadoinspectorDTO;
                oPtuSolcertificadoinspectorDTO = new PtuSolcertificadoinspectorDTO();

                oPtuSolcertificadoinspectorDTO.intcodsolicitudinspector = 0;
                oPtuSolcertificadoinspectorDTO.intusuinspector = Convert.ToInt32(ddlInspectores.SelectedValue);
                oPtuSolcertificadoinspectorDTO.vchnombreinspector = ddlInspectores.SelectedItem.Text;
                oPtuSolcertificadoinspectorDTO.intcodsolicitud = Convert.ToInt32(lblCodSolicitud.Text);
                oPtuSolcertificadoinspectorDTO.smlestado = 1;

                oPtuSolcertificadoinspector_bo = new PtuSolcertificadoinspector_bo(ref logMensajes);
                oPtuSolcertificadoinspectorDTO = oPtuSolcertificadoinspector_bo.Insertar(oPtuSolcertificadoinspectorDTO);

                pbd_CargarGrillaSolicitud();

                Response response = APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }

        }

        protected void btnQuitarInsp_Click(object sender, EventArgs e)
        {
            GridViewRow gwrow = (GridViewRow)((Button)sender).NamingContainer;

            Label lblCodSolicitudInspector = (Label)gwrow.FindControl("lblCodSolicitudInspector");
            int intCodSolicitudInspector = Convert.ToInt32(lblCodSolicitudInspector.Text);

            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                oPtuSolcertificadoinspector_bo = new PtuSolcertificadoinspector_bo(ref logMensajes);
                oPtuSolcertificadoinspector_bo.Eliminar(intCodSolicitudInspector);

                pbd_CargarGrillaSolicitud();

                Response response = APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }






        }


    }
}