using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using SIPT.BL.DTO.DTO;
using Microsoft.VisualBasic.CompilerServices;

namespace SIPT.WebInterno
{
    public partial class FrmSolicitudAsigna : System.Web.UI.Page
    {
        private LogMensajes logMensajes;
        private Request request;
        private PtuSolLicenciaAnalista oPtuSolLicenciaAnalista;
        private PtuSolLicenciaAnalista_bo oPtuSolLicenciaAnalista_bo;
        private PtuSolicitudDTO oPtuSolicitudDTO;
        private Usuario_bo oUsuario_bo;
        private SicUsuario oSicUsuario;
        private List<SicUsuario> oSicUsuarioList;
        private string lstUsuario;
        private string lstSistema;
        private string lstEquipo;
        private string lstOpcion;
        private string lstNombre;

        private string ltxtUsuarioId;
        private string ltxtUsuarioRol;
 
        PtuSolicitud oPtuSolicitud;
        PtuSolicitud_bo oPtuSolicitud_bo;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblTitulo.Text = ".: Asignar Solicitud a Analista :.";
            ltxtUsuarioId = (string)(Request.Cookies["Security"]["UsuarioId"]);
            ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);

            lstUsuario = (string)(Request.Cookies["Security"]["UsuarioId"]);
            lstSistema = (string)(Request.Cookies["Security"]["Sistema"]);
            lstEquipo = (string)(Request.Cookies["Security"]["DireccionIP"]);
            lstOpcion = (string)(Request.Cookies["Security"]["Opcion"]);
            lstNombre = (string)(Request.Cookies["Security"]["Nombres"]);

            if (!Page.IsPostBack)
            {   
                ViewState["ANALISTA"] =  ListarUsuariosRolAnalista("Page_Load");
                
                pbd_CargarGrillaSolicitud("Page_Load");
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

                gvSCU.DataSource = pbd_CargarGrillaUsos("gvSolicitud", Convert.ToInt32(lblCodSolicitud.Text));
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

        private DataTable ListarUsuariosRolAnalista(string control)
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

            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oSicUsuarioList = new List<SicUsuario>();
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                oUsuario_bo = new Usuario_bo(ref logMensajes);
                List<SicUsuario> oSicUsuarioList = oUsuario_bo.ListarUsuariosAppRol("SIPT", "ANALISTA SIPT");

                foreach (SicUsuario Analista in oSicUsuarioList)
                {

                    row = dtTabla.NewRow();

                    row["INTUSUANALISTA"] = Analista.intusuariocodigo;
                    row["VCHUSUANALISTA"] = Analista.vchusuarionombres;
                    dtTabla.Rows.Add(row);

                }

            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
            return dtTabla;
        }

        protected void ddlAnalista_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow gwrow = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlSCUAnalista = (DropDownList)sender;
            String lstcodSolicitud = gwrow.Cells[0].Text;

            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = "ddlAnalista";
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolLicenciaAnalista = new PtuSolLicenciaAnalista();
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                
                oPtuSolLicenciaAnalista.intcodsolicitudanalista = 0;
                oPtuSolLicenciaAnalista.intusuanalista = Convert.ToInt32(ddlSCUAnalista.SelectedValue);
                oPtuSolLicenciaAnalista.intcodsolicitud = Convert.ToInt32(lstcodSolicitud);
                oPtuSolLicenciaAnalista.smlestado = 1;
                oPtuSolLicenciaAnalista.tmsaudfeccreacion = DateTime.Now;
                oPtuSolLicenciaAnalista.vchaudusucreacion = lstUsuario;
                oPtuSolLicenciaAnalista.vchaudequipo = lstEquipo;
                oPtuSolLicenciaAnalista.vchaudprograma = lstSistema;

                PtuSolLicenciaAnalista_bo oPtuSolLicenciaAnalista_bo = new PtuSolLicenciaAnalista_bo(ref logMensajes);
                oPtuSolLicenciaAnalista_bo.Insertar(oPtuSolLicenciaAnalista);

                pbd_CargarGrillaSolicitud("ddlAnalista");
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }

        }

        protected void gvSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSolicitud.PageIndex = e.NewPageIndex;
            pbd_CargarGrillaSolicitud("gvSolicitud");
        }

        private void pbd_CargarGrillaSolicitud(string control) 
        {
            /* muestra todas las pendientes */
            int lintUsuAnalista = 0;

            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolicitud = new PtuSolicitud();
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
                List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_bo.ListarPendientes(oPtuSolicitud, lintUsuAnalista);
                gvSolicitud.DataSource = oPtuSolicitud_PorAnalistaPorSolicitanteList;
                gvSolicitud.DataBind();
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
        }


        private List<PtuUsoDTO> pbd_CargarGrillaUsos(string control, int pintcodsolicitud)
        {
            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolicitud = new PtuSolicitud();
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<PtuUsoDTO> oPtuUsoDTOList = new List<PtuUsoDTO>();
            try
            {
                PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
                oPtuSolicitudDTO = oPtuSolicitud_bo.ListarPorId(pintcodsolicitud);
                oPtuUsoDTOList = oPtuSolicitudDTO.PtuUsosDTO;
            }
            catch (System.Exception ex)
            {
                logMensajes.error = ex;
                Log.Error(logMensajes.codigoMensaje.ToString(), this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                logMensajes.FinSolicitud();
            }
            return oPtuUsoDTOList;
        }

        protected void ddlPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}