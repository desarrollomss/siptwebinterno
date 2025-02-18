using SIPT.APPL.FrondEnd;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIPT.WebInterno
{
    public partial class FrmSolicitudAcredita : System.Web.UI.Page
    {
        //private SIPT.WebInterno
        private LogMensajes logMensajes;
        private Request request;
        private PtuSolLicenciaAnalista oPtuSolLicenciaAnalista;
        private PtuSolicitudDTO oPtuSolicitudDTO;
        private PtuSolLicencia oPtuSolLicencia;

        private List<PtuSolrequerimiento> oPtuSolrequerimientoList;
        private PtuSolrequerimiento oPtuSolrequerimiento;

        public List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();

        private Usuario_bo oUsuario_bo;
              
        private string ltxtUsuarioRol;

        PtuSolicitud oPtuSolicitud;

        private PtuTabla oPtuTabla;
        private List<PtuTabla> oPtuTablaList = new List<PtuTabla>();
        private PtuTabla_bo oPtuTabla_bo;


        #region eventos

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
                //btnGuardar.Attributes.Add("onclick", "return confirm('¿Está seguro de Guardar Acreditación?')");

                logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
                try
                {
                    ViewState["ANALISTA"] = ListarUsuariosRolAnalista();

                    pbd_CargarGrillaSolicitud();
                    MultiView1.ActiveViewIndex = 0;

                    APPL.FrondEnd.Response.Ok(logMensajes);
                }
                catch(Exception ex)
                {
                    Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                    response.MensajeSwal(ClientScript);
                }
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
                Label lblEstSolLic = (Label)e.Row.FindControl("lblEstSolLic");

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
            gvSolicitud.PageIndex = e.NewPageIndex;
            try
            {
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
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            new Response().ConfirmacionSwal(ClientScript, TipoConfirmacion.GUARDAR, "la Acreditación", "btnGuardar");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {           
            int lintCodSolicitud = Convert.ToInt32(hdfCodSolicitud.Value);
            Int16 lintEstSolLicencia = Convert.ToInt16(hdfSolLicEstado.Value);
            int lintCodProcedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
            //Int16 lintCondicionSolic = Convert.ToInt16(ddlSolCondicion.SelectedValue);

            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                pbd_GuardarAcreditacion(lintCodSolicitud, lintEstSolLicencia, lintCodProcedimiento,  oPtuSolrequerimientoList);
                Response response = APPL.FrondEnd.Response.OkGuardar(logMensajes, "la Acreditación");
                response.MensajeSwal(ClientScript);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }

            MultiView1.ActiveViewIndex = 0;
            
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            if(((MultiView)sender).ActiveViewIndex == 0)
            {
                logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
                try
                {
                    pbd_CargarGrillaSolicitud();
                    APPL.FrondEnd.Response.Ok(logMensajes);
                }
                catch (Exception ex)
                {
                    Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                    response.MensajeSwal(ClientScript);
                }                
            }
        }

        protected void ddlProcedimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                pbd_CargarGrillaPlantillas();
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch(Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }            
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
        
        protected void btnCalifica_Click(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                int lintCodSolicitud = Convert.ToInt32(gvSolicitud.DataKeys[row.RowIndex].Values["INTCODSOLICITUD"]);
                int lintEstSolLicencia = Convert.ToInt16(gvSolicitud.DataKeys[row.RowIndex].Values["SMLESTSOLLICENCIA"]);
                hdfCodSolicitud.Value = lintCodSolicitud.ToString();
                hdfSolLicEstado.Value = lintEstSolLicencia.ToString();
                
                MultiView1.ActiveViewIndex = 1;
                pbd_CargarGrillaUsos(lintCodSolicitud, lintEstSolLicencia);

                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch(Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }

        #endregion


        #region Métodos

        private void pbd_CargarGrillaSolicitud()
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

            oPtuSolicitud = new PtuSolicitud();
            PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
            List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_bo.ListarAcreditar(oPtuSolicitud, lintUsuAnalista);
            gvSolicitud.DataSource = oPtuSolicitud_PorAnalistaPorSolicitanteList;
            gvSolicitud.DataBind();

        }

        private List<PtuUsoDTO> pbd_CargarGrillaUsos(int? pintcodsolicitud, int? pintEstSolLicencia)
        {
            oPtuSolicitud = new PtuSolicitud();            
            List<PtuUsoDTO> oPtuUsoDTOList = new List<PtuUsoDTO>();
            
            ddlProcedimiento.DataSource = pbd_CargarComboProcTupa();
            ddlProcedimiento.DataTextField = "VCHCONCEPTO";
            ddlProcedimiento.DataValueField = "INTCODIGOPROCEDIMIENTO";
            ddlProcedimiento.DataBind();
            ddlProcedimiento.Items.Insert(0, new ListItem("(Ninguno)", "0"));

            oPtuTabla = new PtuTabla();
            oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);

            // CONDICION DE SOLICITUD
            oPtuTabla.vchtabla = "PTUSOLICITUD";
            oPtuTabla.vchcampo = "SMLCONDICIONSOLICITUD";
            oPtuTablaList = oPtuTabla_bo.ListarGrupo(oPtuTabla);

//            ddlSolCondicion.DataSource = oPtuTablaList;
//            ddlSolCondicion.DataTextField = "VCHDESCRIPCION";
//            ddlSolCondicion.DataValueField = "SMLCODTABLA";
//            ddlSolCondicion.DataBind();
//            ddlSolCondicion.Items.Insert(0, new ListItem("(Ninguno)", "0"));

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
//            ddlSolCondicion.SelectedValue = oPtuSolicitudDTO.smlcondicionsolicitud.ToString();
            pbd_CargarGrillaPlantillas();

            return oPtuUsoDTOList;
        }        

        private List<PtuProcedimientostupaDTO> pbd_CargarComboProcTupa()
        {
            oPtuSolicitud = new PtuSolicitud();            
            List<PtuProcedimientostupaDTO> oPtuProcedimientostupaDTOList = new List<PtuProcedimientostupaDTO>();
           
            PtuProcedimientostupa_bo oPtuProcedimientostupa_bo = new PtuProcedimientostupa_bo(ref logMensajes);
            oPtuProcedimientostupaDTOList = oPtuProcedimientostupa_bo.Listar();
               
            return oPtuProcedimientostupaDTOList;
        }

     

        private void pbd_CargarGrillaPlantillas()
        {
            int intcodProcedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
            int intcodSolicitud = Convert.ToInt32(txtCodSolicitud.Text);
            
            rptResult.DataSource = pbd_CargarPlantillaSolLicencia(intcodSolicitud);
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

        private void pbd_GuardarAcreditacion(int? pintcodsolicitud, Int16? pintEstSolLicencia, int pintcodprocedimiento, List<PtuSolrequerimiento> oPtuSolrequerimientoList)
        {
            oPtuSolrequerimiento = new PtuSolrequerimiento();
            oPtuSolrequerimientoList = new List<PtuSolrequerimiento>();
            Boolean flgCompleto = true;

            oPtuSolLicencia = new PtuSolLicencia();
            oPtuSolLicencia.intcodsolicitud = pintcodsolicitud;
            oPtuSolLicencia.smlestsollicencia = pintEstSolLicencia;
            


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

            PtuSolLicencia_bo oPtuSolLicencia_bo = new PtuSolLicencia_bo(ref logMensajes);
            oPtuSolLicencia_bo.Acreditar(oPtuSolLicencia, pintcodprocedimiento, oPtuSolrequerimientoList);

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
    
        private List<PtuSolrequerimientoDTO> pbd_CargarPlantillaSolLicencia(int? intcodsolicitud)
        {
            List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = new List<PtuSolrequerimientoDTO>();
            
            PtuSolrequerimiento_bo oPtuSolrequerimiento_bo = new PtuSolrequerimiento_bo(ref logMensajes);
            oPtuSolrequerimientoDTOList = oPtuSolrequerimiento_bo.ListarAcredita(intcodsolicitud);            
            
            return oPtuSolrequerimientoDTOList;
        }

        #endregion

        
    }
}