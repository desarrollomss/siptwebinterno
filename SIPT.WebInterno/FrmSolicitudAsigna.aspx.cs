using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIPT.WebInterno
{
    public partial class FrmSolicitudAsigna : System.Web.UI.Page
    {
        private LogMensajes logMensajes;
        private Request request;
        private PtuSolLicenciaAnalista oPtuSolLicenciaAnalista;
        private PtuSolicitudDTO oPtuSolicitudDTO;
        private Usuario_bo oUsuario_bo;

        private string ltxtUsuarioRol;
 
        PtuSolicitud oPtuSolicitud;

        #region Eventos

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
                logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
                try
                {
                    ViewState["ANALISTA"] = ListarUsuariosRolAnalista();
                    pbd_CargarGrillaSolicitud();
                    APPL.FrondEnd.Response.OkGuardar(logMensajes);
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlSCUAnalista = (DropDownList)e.Row.FindControl("ddlAnalista");

                Label lblSCUCodAnalista = (Label)e.Row.FindControl("lblCodAnalista");
                Label lblEstSolLic = (Label)e.Row.FindControl("lblEstSolLic");
                Label lblCodSolicitud = (Label)e.Row.FindControl("lblCodSolicitud");


                GridView gvSCU = (GridView)e.Row.FindControl("gvUsos");

                //DataTable oDt = (DataTable)ListarUsuariosRolAnalista();


                ddlSCUAnalista.DataSource = (DataTable)ViewState["ANALISTA"];
                ddlSCUAnalista.DataTextField = "VCHUSUANALISTA";
                ddlSCUAnalista.DataValueField = "INTUSUANALISTA";
                ddlSCUAnalista.DataBind();
                ddlSCUAnalista.Items.Insert(0, new ListItem("(Ninguno)", "0"));

                if (lblSCUCodAnalista.Text != "0")
                {
                    ddlSCUAnalista.SelectedValue = lblSCUCodAnalista.Text;
                }

                gvSCU.DataSource = pbd_CargarGrillaUsos(Convert.ToInt32(lblCodSolicitud.Text));
                gvSCU.DataBind();

                if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
                {
                    switch (Convert.ToInt32(lblEstSolLic.Text))
                    {
                        case 10:    /* 10	1	REGISTRADO              */
                            ddlSCUAnalista.Enabled = true;
                            break;
                        case 11:    /* 11	2	EN 1ERAEVALUACION       */
                            ddlSCUAnalista.Enabled = true;
                            break;
                        case 12:    /* 12	3	TERMINADO               */
                            ddlSCUAnalista.Enabled = false;
                            break;
                        case 13:    /* 13	4	DESISTIDO               */
                            ddlSCUAnalista.Enabled = false;
                            break;
                        case 14:    /* 14	5	EN 2DAEVALUACION        */
                            ddlSCUAnalista.Enabled = false;
                            break;
                    }
                }
                else
                {
                    ddlSCUAnalista.Enabled = false;
                }
            }
        }

        protected void ddlAnalista_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow gwrow = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlSCUAnalista = (DropDownList)sender;
            String lstcodSolicitud = gwrow.Cells[0].Text;

            oPtuSolLicenciaAnalista = new PtuSolLicenciaAnalista();
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                oPtuSolLicenciaAnalista.intcodsolicitudanalista = 0;
                oPtuSolLicenciaAnalista.intusuanalista = Convert.ToInt32(ddlSCUAnalista.SelectedValue);
                oPtuSolLicenciaAnalista.intcodsolicitud = Convert.ToInt32(lstcodSolicitud);
                oPtuSolLicenciaAnalista.smlestado = 1;

                PtuSolLicenciaAnalista_bo oPtuSolLicenciaAnalista_bo = new PtuSolLicenciaAnalista_bo(ref logMensajes);
                oPtuSolLicenciaAnalista_bo.Insertar(oPtuSolLicenciaAnalista);

                pbd_CargarGrillaSolicitud();

                Response response = APPL.FrondEnd.Response.OkGuardar(logMensajes, "la Asignación");
                response.MensajeSwal(ClientScript);
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

        protected void ddlPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion


        #region Métodos

        private void pbd_CargarGrillaSolicitud()
        {
            /* muestra todas las pendientes */
            int lintUsuAnalista = 0;

            oPtuSolicitud = new PtuSolicitud();
           
            PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
            List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_bo.ListarPendientes(oPtuSolicitud, lintUsuAnalista);
            gvSolicitud.DataSource = oPtuSolicitud_PorAnalistaPorSolicitanteList;
            gvSolicitud.DataBind();
        }

        private List<PtuUsoDTO> pbd_CargarGrillaUsos(int pintcodsolicitud)
        {
            oPtuSolicitud = new PtuSolicitud();
            List<PtuUsoDTO> oPtuUsoDTOList = new List<PtuUsoDTO>();

            PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
            oPtuSolicitudDTO = oPtuSolicitud_bo.ListarPorId(pintcodsolicitud);
            oPtuUsoDTOList = oPtuSolicitudDTO.PtuUsosDTO;

            return oPtuUsoDTOList;
        }

        private DataTable ListarUsuariosRolAnalista()
        {
            DataTable dtTabla = null;
            DataColumn dcColumna;
            DataRow row;

            dtTabla = new DataTable("ANALISTA");

            dcColumna = new DataColumn();
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "INTUSUANALISTA";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);


            dcColumna = new DataColumn();
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "VCHUSUANALISTA";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);

            row = dtTabla.NewRow();

            oUsuario_bo = new Usuario_bo(ref logMensajes);
            List<SicUsuario> oSicUsuarioList = oUsuario_bo.ListarUsuariosAppRol("SIPT", "ANALISTA SIPT");

            foreach (SicUsuario Analista in oSicUsuarioList)
            {
                row = dtTabla.NewRow();

                row["INTUSUANALISTA"] = Analista.intusuariocodigo;
                row["VCHUSUANALISTA"] = Analista.vchusuarionombres;
                dtTabla.Rows.Add(row);
            }
            return dtTabla;
        }

        #endregion
                
    }
}