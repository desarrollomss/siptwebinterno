using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SIPT.APPL;
using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using SIPT.BL.DTO.DTO;
using Newtonsoft.Json;
using System.Configuration;

namespace SIPT.WebInterno
{
    public partial class FrmSolicitudAcredita : System.Web.UI.Page
    {
        //private SIPT.WebInterno
        private LogMensajes logMensajes;
        private Request request;
        private PtuSolLicenciaAnalista oPtuSolLicenciaAnalista;
        private PtuSolLicenciaAnalista_bo oPtuSolLicenciaAnalista_bo;
        private PtuProcedimientostupa_bo oPtuProcedimientostupa_bo;
        private PtuSolicitudDTO oPtuSolicitudDTO;
        private PtuSolLicencia oPtuSolLicencia;
        private PtuPlantillareq_bo oPtuPlantillareq_bo;

        private List<PtuSolrequerimiento> oPtuSolrequerimientoList;
        private PtuSolrequerimiento oPtuSolrequerimiento;
        private PtuSolrequerimiento_bo oPtuSolrequerimiento_bo;

        public List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();

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


            ltxtUsuarioId = (string)(Request.Cookies["Security"]["UsuarioId"]);
            ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);

            lstUsuario = (string)(Request.Cookies["Security"]["UsuarioId"]);
            lstSistema = (string)(Request.Cookies["Security"]["Sistema"]);
            lstEquipo = (string)(Request.Cookies["Security"]["DireccionIP"]);
            lstOpcion = (string)(Request.Cookies["Security"]["Opcion"]);
            lstNombre = (string)(Request.Cookies["Security"]["Nombres"]);

            this.lblTitulo.Text = ".: Acreditar Documentación :.";
            if (!Page.IsPostBack)
            {
                btnGuardar.Attributes.Add("onclick", "return confirm('¿Está seguro de Guardar Acreditación?')");
                
                ViewState["ANALISTA"] = ListarUsuariosRolAnalista("Page_Load");

                pbd_CargarGrillaSolicitud("Page_Load");
                MultiView1.ActiveViewIndex = 0;

            }
            //flexSwitchCheckChecked.Checked = true;
        }

        protected void gvSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlSCUAnalista = (DropDownList)e.Row.FindControl("ddlAnalista");

                Label lblSCUCodAnalista = (Label)e.Row.FindControl("lblCodAnalista");

                Label lblEstSolLicTxt = (Label)e.Row.FindControl("lblEstSolLicTxt");
                Label lblEstSolLic= (Label)e.Row.FindControl("lblEstSolLic");
                
                Button btnCalifica = (Button)e.Row.FindControl("btnCalifica");  

                ddlSCUAnalista.DataSource = (DataTable)ViewState["ANALISTA"];
                ddlSCUAnalista.DataTextField = "VCHUSUANALISTA";
                ddlSCUAnalista.DataValueField = "INTUSUANALISTA";
                ddlSCUAnalista.DataBind();
                ddlSCUAnalista.Items.Insert(0, new ListItem("(Ninguno)", "0"));

                if (lblSCUCodAnalista.Text != "0")
                {
                    ddlSCUAnalista.SelectedValue = lblSCUCodAnalista.Text;
                }

                btnCalifica.Text = lblEstSolLicTxt.Text;
                btnCalifica.Visible = true;
                switch (Convert.ToInt32(lblEstSolLic.Text))
                {
                    case 10:    /* 10	1	REGISTRADO              */
                        btnCalifica.Visible = false;
                        lblEstSolLicTxt.Visible = true;
                        break;
                    case 11:    /* 11	2	EN 1ERAEVALUACION       */
                        if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
                        {
                            btnCalifica.Visible = true;
                            lblEstSolLicTxt.Visible = false;
                            btnCalifica.CssClass = "btn btn-success btn-sm";

                        }
                        else
                        {
                            btnCalifica.Visible = false;
                            lblEstSolLicTxt.Visible = true;
                            btnCalifica.CssClass = "btn btn-success btn-sm";
                        }

                        break;
                    case 12:    /* 12	3	TERMINADO               */
                        btnCalifica.Visible = false;
                        lblEstSolLicTxt.Visible = true;
                        break;
                    case 13:    /* 13	4	DESISTIDO               */
                        btnCalifica.Visible = false;
                        lblEstSolLicTxt.Visible = true;
                        break;
                    case 14:    /* 14	5	EN 2DAEVALUACION        */


                        if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
                        {
                            btnCalifica.Visible = true;
                            lblEstSolLicTxt.Visible = false;
                            btnCalifica.CssClass = "btn btn-danger btn-sm";
                        }
                        else
                        {
                            btnCalifica.Visible = false;
                            lblEstSolLicTxt.Visible = true;
                            btnCalifica.CssClass = "btn btn-danger btn-sm";
                        }
                        break;
                    case 38:    /* 38   NO PROCEDE ACREDITACION    */
                        { 
                            btnCalifica.Visible = true;
                            lblEstSolLicTxt.Visible = false;
                            btnCalifica.CssClass = "btn btn-danger btn-sm";
                            break;
                        }

                }

            }

        }

         protected void ddlAnalista_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow gwrow = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlSCUAnalista = (DropDownList)sender;
            String lstcodSolicitud = gwrow.Cells[0].Text;

            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = lstNombre;
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

                pbd_CargarGrillaSolicitud("ddlAnalista_SelectedIndexChanged");
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
            pbd_CargarGrillaSolicitud("gvSolicitud_PageIndexChanging");
        }

        private void pbd_CargarGrillaSolicitud(string control)
        {
            string ltxtUsuarioId = (string)(Request.Cookies["Security"]["UsuarioId"]);
            string ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);
            int lintUsuAnalista = 0;
            /* Lista pendientes por Rol o Analista*/
            if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
            {
                lintUsuAnalista = Convert.ToInt32(ltxtUsuarioId);

            }

            if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
            {
                lintUsuAnalista = 0;

            }

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
                List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_bo.ListarAcreditar(oPtuSolicitud, lintUsuAnalista);
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

        private List<PtuUsoDTO> pbd_CargarGrillaUsos(string control, int? pintcodsolicitud, int? pintEstSolLicencia)
        {

            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = lstNombre;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolicitud = new PtuSolicitud();
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<PtuUsoDTO> oPtuUsoDTOList = new List<PtuUsoDTO>();
            try
            {
                ddlProcedimiento.DataSource = pbd_CargarComboProcTupa(control);
                ddlProcedimiento.DataTextField = "VCHCONCEPTO";
                ddlProcedimiento.DataValueField = "INTCODIGOPROCEDIMIENTO";
                ddlProcedimiento.DataBind();
                ddlProcedimiento.Items.Insert(0, new ListItem("(Ninguno)", "0"));

                PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
                oPtuSolicitudDTO = oPtuSolicitud_bo.ListarPorId(pintcodsolicitud);
                oPtuUsoDTOList = oPtuSolicitudDTO.PtuUsosDTO;
                hdfCodSolicitud.Value = pintcodsolicitud.ToString();
                hdfSolLicEstado.Value = pintEstSolLicencia.ToString();

                txtCodSolicitud.Text = oPtuSolicitudDTO.intcodsolicitud.ToString();
                txtNumSolicitud.Text = oPtuSolicitudDTO.chranio + " " + oPtuSolicitudDTO.vchnumero;
                txtAdministrado.Text = oPtuSolicitudDTO.vchadmcompleto;
                txtAreaOcupa.Text = oPtuSolicitudDTO.decareaocupar.ToString();
                txtDireccion.Text = oPtuSolicitudDTO.vchubicacionpredio;
                txtCondicion.Text = oPtuSolicitudDTO.vchcondicionsolicitante;
                txtZonifica.Text = oPtuSolicitudDTO.vchzonificacion;
                ddlProcedimiento.SelectedValue = oPtuSolicitudDTO.intcodigoprocedimiento.ToString();
                //txtObservacion.Text = oPtuSolicitudDTO.vchobservacion; 


                if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
                {
                }

                if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
                {
                }


                pbd_CargarGrillaPlantillas(control);


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

        protected void btnCalifica_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            int lintCodSolicitud = Convert.ToInt32(gvSolicitud.DataKeys[row.RowIndex].Values["INTCODSOLICITUD"]);
            int lintEstSolLicencia = Convert.ToInt16(gvSolicitud.DataKeys[row.RowIndex].Values["SMLESTSOLLICENCIA"]);
            hdfCodSolicitud.Value = lintCodSolicitud.ToString();
            hdfSolLicEstado.Value = lintEstSolLicencia.ToString();

            MultiView1.ActiveViewIndex = 1;
            pbd_CargarGrillaUsos("btnCalifica_Click", lintCodSolicitud, lintEstSolLicencia);

        }

        private List<PtuProcedimientostupaDTO> pbd_CargarComboProcTupa(string control) 
        {

            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolicitud = new PtuSolicitud();
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<PtuProcedimientostupaDTO> oPtuProcedimientostupaDTOList = new List<PtuProcedimientostupaDTO>();
            try
            {
                PtuProcedimientostupa_bo oPtuProcedimientostupa_bo = new PtuProcedimientostupa_bo(ref logMensajes);
                oPtuProcedimientostupaDTOList = oPtuProcedimientostupa_bo.Listar();
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
            return oPtuProcedimientostupaDTOList;
        }

        private DataTable pbd_CargarGrillaPlantillaProcTupa(string control, int? intcodplantilla, int? intcodigoprocedimiento, int? intcodsolicitud)
        {

            DataTable dtTabla = null;
            DataColumn dcColumna;
            DataRow row;

            dtTabla = new DataTable("PLANTILLA");

            dcColumna = new DataColumn();
            
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "INTCODPLANTILLA";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);


            dcColumna = new DataColumn();
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "VCHNOMBREPLANTILLA";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);

            row = dtTabla.NewRow();

            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolicitud = new PtuSolicitud();
            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();
            try
            {
                PtuPlantillareq_bo oPtuPlantillareq_bo = new PtuPlantillareq_bo(ref logMensajes);

                oPtuPlantillareqDTOList = oPtuPlantillareq_bo.ListarPlantillas(intcodplantilla, intcodigoprocedimiento, intcodsolicitud);


                foreach (PtuPlantillareqDTO objeto in oPtuPlantillareqDTOList)
                {
                    row = dtTabla.NewRow();

                    row["INTCODPLANTILLA"] = objeto.intcodplantilla.ToString();
                    row["VCHNOMBREPLANTILLA"] = objeto.vchnombreplantilla;
                    dtTabla.Rows.Add(row);

                }

                ViewState["PLANTILLA"] = dtTabla;

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


        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string txtMensaje = "";

            if (ddlProcedimiento.SelectedValue.Equals("0"))
            {
                txtMensaje = txtMensaje + "* Seleccione el procedimiento" + "</BR>";
            }

            if (!txtMensaje.Length.Equals(0))   /* Si no esta vacio */
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                "swal('Error!', '" + txtMensaje + "', 'error')", true);
            }
            else
            {
                int lintCodSolicitud = Convert.ToInt32(hdfCodSolicitud.Value);
                Int16 lintEstSolLicencia = Convert.ToInt16(hdfSolLicEstado.Value);
 
                pbd_GuardarAcreditacion(lintCodSolicitud, lintEstSolLicencia, oPtuSolrequerimientoList);

                MultiView1.ActiveViewIndex = 0;
                pbd_CargarGrillaSolicitud("Page_Load");

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                "swal('Notificación', 'Informacion y Acreditación Registrada.', 'success')", true);

            }
        }

        protected void ddlProcedimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbd_CargarGrillaPlantillas("ddlProcedimiento_SelectedIndexChanged");
        }

        private void pbd_CargarGrillaPlantillas(string control)
        {
            int intcodPlantilla = -1;
            int intcodProcedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
            int intcodSolicitud = Convert.ToInt32(txtCodSolicitud.Text);
            

            //gvPlantilla.DataSource = pbd_CargarPlantillaSolLicencia(intcodSolicitud);
            //gvPlantilla.DataBind();

            rptResult.DataSource = pbd_CargarPlantillaSolLicencia(control, intcodSolicitud);
            rptResult.DataBind();

            // Actualiza estado

            for (int i = 0; i < rptResult.Items.Count; i++)
            {
                Label lblEstado = (Label)rptResult.Items[i].FindControl("lblEstado");
                System.Web.UI.HtmlControls.HtmlInputCheckBox ck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptResult.Items[i].FindControl("fscAcredita");
                // Correcto
                if (Convert.ToInt32(lblEstado.Text) == 28)
                {
                    ck.Checked = true;
                }
                else
                {
                    ck.Checked = false;
                }
            }

        }

        private void pbd_GuardarAcreditacion(int? pintcodsolicitud, Int16? pintEstSolLicencia, List<PtuSolrequerimiento> oPtuSolrequerimientoList)
        {
            oPtuSolrequerimiento = new PtuSolrequerimiento();
            oPtuSolrequerimientoList = new List<PtuSolrequerimiento>();
            Boolean flgCompleto = true;
            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = lstNombre;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolLicencia = new PtuSolLicencia();
            oPtuSolLicencia.intcodsolicitud = pintcodsolicitud;
            oPtuSolLicencia.smlestsollicencia = pintEstSolLicencia;
            oPtuSolLicencia.vchaudusumodif = lstUsuario;
            oPtuSolLicencia.tmsaudfecmodif = DateTime.Now;

            for (int i = 0; i < rptResult.Items.Count; i++)
            {
                TextBox lblObserva = (TextBox)rptResult.Items[i].FindControl("txtObserva");
                Label lblSolPla = (Label)rptResult.Items[i].FindControl("lblSOLPLA");
                Label lblCodPla = (Label)rptResult.Items[i].FindControl("lblCODPLA");
                System.Web.UI.HtmlControls.HtmlInputCheckBox ck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rptResult.Items[i].FindControl("fscAcredita");

                oPtuSolrequerimiento = new PtuSolrequerimiento();
                oPtuSolrequerimiento.intsolicitudplantilla = Convert.ToInt32(lblSolPla.Text);
                oPtuSolrequerimiento.intcodplantilla = Convert.ToInt32(lblCodPla.Text);
                oPtuSolrequerimiento.intcodsolicitud = pintcodsolicitud;
                oPtuSolrequerimiento.vchobsevaluacion = lblObserva.Text.ToUpper();
                if (ck.Checked)
                {
                    oPtuSolrequerimiento.smlevaluacion = 28;  // Correcto

                }
                else 
                {
                    oPtuSolrequerimiento.smlevaluacion = 29;   // Observado
                    flgCompleto = false;
                }
                oPtuSolrequerimiento.vchaudusumodif = lstUsuario;
                oPtuSolrequerimiento.tmsaudfecmodif = DateTime.Now;

                oPtuSolrequerimientoList.Add(oPtuSolrequerimiento);
            }
            // verifica si hay observaciones
            if (flgCompleto == true)
            {
                oPtuSolLicencia.smlestsollicencia = 25; //En Pago
            }
            else 
            {
                oPtuSolLicencia.smlestsollicencia = 38; //NO PROCEDE ACREDITACION
            }
            // Empieza a grabar

            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                PtuSolLicencia_bo oPtuSolLicencia_bo = new PtuSolLicencia_bo(ref logMensajes);
                oPtuSolLicencia_bo.Acreditar(oPtuSolLicencia, oPtuSolrequerimientoList);

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

        private void pbd_ProcesarPlantillas(string control, int? pintcodsolicitud)
        {
            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolLicencia = new PtuSolLicencia();
            oPtuSolLicencia.intcodsolicitud = pintcodsolicitud;
            //oPtuSolLicencia.vchobservacion = txtObservacion.Text.ToUpper();
            oPtuSolLicencia.vchaudusumodif = lstUsuario;
            oPtuSolLicencia.tmsaudfecmodif = DateTime.Now;

            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                PtuSolLicencia_bo oPtuSolLicencia_bo = new PtuSolLicencia_bo(ref logMensajes);
                oPtuSolLicencia_bo.ProcesarPlantillas(oPtuSolLicencia);

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

        private List<PtuPlantillareqDTO> pbd_CargarComboPlantillas(string control)
        {
            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<PtuPlantillareqDTO> oPtuPlantillareqList = new List<PtuPlantillareqDTO>();
            try
            {
                PtuPlantillareq_bo oPtuPlantillareq_bo = new PtuPlantillareq_bo(ref logMensajes);
                oPtuPlantillareqDTOList = oPtuPlantillareq_bo.Listar();

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
            return oPtuPlantillareqDTOList;
        }

        private List<PtuSolrequerimientoDTO> pbd_CargarPlantillaSolLicencia(string control, int? intcodsolicitud)
        {
            request = new Request();
            request.vchaudprograma = lstSistema;
            request.vchopcion = lstOpcion;
            request.vchconnombre = control;
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

             logMensajes = new LogMensajes(request, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = new List<PtuSolrequerimientoDTO>();
            try
            {
                PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);

                oPtuSolrequerimientoDTOList = oPtuSolrequerimiento_bo.ListarAcredita(intcodsolicitud);

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
            return oPtuSolrequerimientoDTOList;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }


        protected void btnVisual_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnRegresaVista_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void bimgVisualiza_Click(object sender, ImageClickEventArgs e)
        {
            //reporte.Src = "http://192.0.0.143/archivos/pladig/ManualUsuario_PlataformaDigitalSurcana.pdf";
            String pdfRuta;

            RepeaterItem item = (sender as ImageButton).NamingContainer as RepeaterItem;
            string NombrePDF = (item.FindControl("lblNomArchivo") as Label).Text;

            pdfRuta = ConfigurationManager.AppSettings["IPServidorPDF"] + NombrePDF;

            reporte.Attributes.Add("src", pdfRuta);

            MultiView1.ActiveViewIndex = 2;
        }
    }
}