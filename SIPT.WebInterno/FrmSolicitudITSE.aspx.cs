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
    public partial class FrmSolicitudITSE : System.Web.UI.Page
    {
        //private SIPT.WebInterno
        private LogMensajes logMensajes;
        private Request request;
        private PtuTabla oPtuTabla;
        private List<PtuTabla> oPtuTablaList = new List<PtuTabla>();
        private PtuTabla_bo oPtuTabla_bo;

        private PtuSolcertificado oPtuSolcertificado;
        private PtuSolicitud oPtuSolicitud;
        
        private PtuDiligencia oPtuDiligencia;
        private PtuDiligenciaDTO oPtuDiligenciaDTO;
        private PtuDiligencia_bo oPtuDiligencia_bo;

        // depurar
        private PtuSolLicenciaAnalista oPtuSolLicenciaAnalista;
        private PtuSolicitudDTO oPtuSolicitudDTO;
        private PtuSolLicencia oPtuSolLicencia;

        public List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();

        private Usuario_bo oUsuario_bo;
        private string ltxtUsuarioRol;



        PtuSolicitud_bo oPtuSolicitud_bo;

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

            fuNumInf.Attributes["onchange"] = "UploadFile1(this)";
            fuNumActa.Attributes["onchange"] = "UploadFile2(this)";
            fuNumPanFot.Attributes["onchange"] = "UploadFile3(this)";


            if (!Page.IsPostBack)
            {
                ViewState["ANALISTA"] = Funciones.ListarUsuariosRol(request, "ANALISTA SIPT");

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


                    ddlEstadoInsp.DataSource = oPtuTablaList;
                    ddlEstadoInsp.DataTextField = "VCHDESCRIPCION";
                    ddlEstadoInsp.DataValueField = "SMLCODTABLA";
                    ddlEstadoInsp.DataBind();
                    ddlEstadoInsp.Items.Insert(0, new ListItem("(Todos)", "0"));
                    


                    oPtuTabla.vchtabla = "PTUSOLCERTIFICADO";
                    oPtuTabla.vchcampo = "SMLRESULTADOCERTIFICACION";
                    oPtuTablaList = oPtuTabla_bo.ListarGrupo(oPtuTabla);

                    ddlResultadoBus.DataSource = oPtuTablaList;
                    ddlResultadoBus.DataTextField = "VCHDESCRIPCION";
                    ddlResultadoBus.DataValueField = "SMLCODTABLA";
                    ddlResultadoBus.DataBind();
                    ddlResultadoBus.Items.Insert(0, new ListItem("(Todos)", "0"));
                    
                    MultiView1.ActiveViewIndex = 0;

                    APPL.FrondEnd.Response.Ok(logMensajes);
                }
                catch (Exception ex)
                {
                    Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                    response.MensajeSwal(ClientScript);
                }
            }
            //flexSwitchCheckChecked.Checked = true;
        }

        protected void gvSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlSCUAnalista = (DropDownList)e.Row.FindControl("ddlAnalista");

                    Label lblSCUCodAnalista = (Label)e.Row.FindControl("lblCodAnalista");

                    Label lblCodSolicitud = (Label)e.Row.FindControl("lblCodSolicitud");

                    Label lblEstSolCerTxt = (Label)e.Row.FindControl("lblEstSolCerTxt");
                    Label lblEstSolCer = (Label)e.Row.FindControl("lblEstSolCer");

                    Button btnCalifica = (Button)e.Row.FindControl("btnCalifica");

                    //ddlSCUAnalista.DataSource = (DataTable)ViewState["ANALISTA"];
                    //ddlSCUAnalista.DataTextField = "VCHUSUANALISTA";
                    //ddlSCUAnalista.DataValueField = "INTUSUANALISTA";
                    //ddlSCUAnalista.DataBind();
                    //ddlSCUAnalista.Items.Insert(0, new ListItem("(Ninguno)", "0"));

                    //if (lblSCUCodAnalista.Text != "0")
                    //{
                    //    ddlSCUAnalista.SelectedValue = lblSCUCodAnalista.Text;
                    //}

                    GridView gvInspecciones = (GridView)e.Row.FindControl("gvInspecciones");
                    gvInspecciones.DataSource = pbd_CargarGrillaInspecciones(Convert.ToInt32(lblCodSolicitud.Text));
                    gvInspecciones.DataBind();

                }
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }

        /*protected void ddlAnalista_SelectedIndexChanged(object sender, EventArgs e)
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

        }*/

        protected void gvSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                gvSolicitud.PageIndex = e.NewPageIndex;
                pbd_CargarGrillaSolicitud();

                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch(Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }



        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // if (txtNumInf.Text.Equals(string.Empty) || txtNumActa.Text.Equals(string.Empty) || txtNumPanFot.Text.Equals(string.Empty))
            // {
            //    return;
            // }
            
            //string script = "alert(document.getElementById('ContentPlaceHolder1_btnConfirmar'))";
            //ClientScript.RegisterStartupScript(this.GetType(), "xxx", script, true);

            new Response().ConfirmacionSwal(ClientScript, TipoConfirmacion.GUARDAR, "la Diligencia", "btnGuardar");

        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int lintCodDiligencia = Convert.ToInt32(hdfCodDiligencia.Value);
            int lintCodSolicitud = Convert.ToInt32(hdfCodSolicitud.Value);


            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                pbd_GuardarDiligencia(lintCodSolicitud,lintCodDiligencia);

                MultiView1.ActiveViewIndex = 0;


                Response response = APPL.FrondEnd.Response.OkGuardar(logMensajes, "la Calificación");
                response.MensajeSwal(ClientScript);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }
        

        protected void ddlProcedimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }
        }

        #endregion

        #region Métodos

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
            List<PtuSolcertificado_PorInspector> oPtuSolcertificado_PorInspectorList = oPtuSolcertificado_bo.Buscar(oPtuSolcertificado,oPtuSolicitud);
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


        private string pbd_GuardarDiligencia(int? pintcodsolicitud, int? pintcoddiligencia)
        {
            string msg = "";

            string tmpPath = ConfigurationManager.AppSettings["UPLOAD_TMP"];
            string proPath = ConfigurationManager.AppSettings["IPServidorUPLOAD"];
            

            File.Move(tmpPath + txtNumInf.Text , proPath + txtNumInf.Text);
            File.Move(tmpPath + txtNumActa.Text, proPath + txtNumActa.Text);
            File.Move(tmpPath + txtNumPanFot.Text, proPath + txtNumPanFot.Text);

            oPtuDiligenciaDTO = new PtuDiligenciaDTO();
              
            oPtuDiligenciaDTO.intcoddiligencia = pintcoddiligencia;
            oPtuDiligenciaDTO.datfechadiligencia = Convert.ToDateTime(txtFecprog.Text);
            oPtuDiligenciaDTO.smlhoradiligencia = Convert.ToInt16(txtHorprog.Text);
            oPtuDiligenciaDTO.vchfileactadiligencia = txtNumActa.Text;  // Path.GetFileName(txtNumActaFile.FileName);
            oPtuDiligenciaDTO.vchfileinformecumplimiento = txtNumInf.Text;  // Path.GetFileName(txtNumInfFile.FileName);
            oPtuDiligenciaDTO.vchfilepanelfotografico = txtNumPanFot.Text;  // Path.GetFileName(txtNumPanFotFile.FileName);
            oPtuDiligenciaDTO.intcoddocactadiligencia = 0;
            oPtuDiligenciaDTO.intcoddocinfcumplimiento = 0;
            oPtuDiligenciaDTO.intcoddocpanelfotografico = 0;
            oPtuDiligenciaDTO.vchobsinspector = txtObsInspector.Text;
            oPtuDiligenciaDTO.vchobssolicitante = txtObsSolicitante.Text;
            oPtuDiligenciaDTO.smlestdiligencia = Convert.ToInt16(ddlEstadoInsp.SelectedValue);
            oPtuDiligenciaDTO.datfechamaxsubsanacion = Convert.ToDateTime(txtFecSubsana.Text);
            oPtuDiligenciaDTO.datfechareprogramacion = Convert.ToDateTime(txtFecRepro.Text);
            oPtuDiligenciaDTO.intcodsolicitud = pintcodsolicitud;

            PtuDiligencia_bo oPtuDiligencia_bo = new PtuDiligencia_bo(ref logMensajes);
            oPtuDiligencia_bo.Actualizar(oPtuDiligenciaDTO);

            return msg;
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

        private void pbd_ProcesarPlantillas(int? pintcodsolicitud)
        {
            oPtuSolLicencia = new PtuSolLicencia();
            oPtuSolLicencia.intcodsolicitud = pintcodsolicitud;
            //oPtuSolLicencia.vchobservacion = txtObservacion.Text.ToUpper();
           
            PtuSolLicencia_bo oPtuSolLicencia_bo = new PtuSolLicencia_bo(ref logMensajes);
            oPtuSolLicencia_bo.ProcesarPlantillas(oPtuSolLicencia);
        }

        private List<PtuPlantillareqDTO> pbd_CargarComboPlantillas()
        {
            List<PtuPlantillareqDTO> oPtuPlantillareqList = new List<PtuPlantillareqDTO>();
          
            PtuPlantillareq_bo oPtuPlantillareq_bo = new PtuPlantillareq_bo(ref logMensajes);
            oPtuPlantillareqDTOList = oPtuPlantillareq_bo.Listar();

            return oPtuPlantillareqDTOList;
        }


        private List<PtuDiligenciaDTO> pbd_CargarGrillaInspecciones(int pintcodsolicitud)
        {

            PtuDiligencia oPtuDiligencia = new PtuDiligencia();            
            
            PtuDiligencia_bo oPtuDiligencia_bo = new PtuDiligencia_bo(ref logMensajes);

            return oPtuDiligencia_bo.ListarKeys(0,pintcodsolicitud);
        }



        #endregion

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

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlAnioBus.SelectedValue = "0";
            txtNumSolBus.Text = "";
            ddlEstadoBus.SelectedValue = "0";
            ddlResultadoBus.SelectedValue = "0";
            txtNumExpBus.Text = "";
            txtCodAdmBus.Text = "";
            txtNomSolBus.Text = "";

            MultiView1.ActiveViewIndex = 1;

        }

        protected void btnEditar_Click(object sender, EventArgs e)
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

                DateTime dt = Convert.ToDateTime(oPtuDiligenciaDTO.datfechadiligencia.ToString());
                txtFecprog.Text = String.Format("{0:yyyy-MM-dd}", dt);

                txtHorprog.Text = oPtuDiligenciaDTO.smlhoradiligencia.ToString();
                ddlEstadoInsp.SelectedValue = oPtuDiligenciaDTO.smlestdiligencia.ToString();

                dt = Convert.ToDateTime(oPtuDiligenciaDTO.datfechareprogramacion.ToString());
                txtFecRepro.Text = String.Format("{0:yyyy-MM-dd}", dt);

                dt = Convert.ToDateTime(oPtuDiligenciaDTO.datfechamaxsubsanacion.ToString());
                txtFecSubsana.Text = String.Format("{0:yyyy-MM-dd}", dt);

                txtObsInspector.Text = oPtuDiligenciaDTO.vchobsinspector;
                txtObsSolicitante.Text = oPtuDiligenciaDTO.vchobssolicitante;
                hdfCodSolicitud.Value = oPtuDiligenciaDTO.intcodsolicitud.ToString();

                txtNumActa.Text = oPtuDiligenciaDTO.vchfileactadiligencia;
                txtNumInf.Text = oPtuDiligenciaDTO.vchfileinformecumplimiento;
                txtNumPanFot.Text = oPtuDiligenciaDTO.vchfilepanelfotografico;


                gvInspectores.DataSource = pbd_CargarGrillaInspectores(0, oPtuDiligenciaDTO.intcodsolicitud);
                gvInspectores.DataBind();

                fuNumActa.Visible = true;
                fuNumInf.Visible = true;
                fuNumPanFot.Visible = true;

                txtNumActa.Visible = false;
                txtNumInf.Visible = false;
                txtNumPanFot.Visible = false;

                btnNumActa.Visible = false;
                btnNumInf.Visible = false;
                btnNumPanFot.Visible = false;

                txtNumActa.ReadOnly = true;
                txtNumInf.ReadOnly = true;
                txtNumPanFot.ReadOnly = true;

                txtFecprog.ReadOnly = false;
                txtHorprog.ReadOnly = false;
                ddlEstadoInsp.Enabled = false;
                txtFecRepro.ReadOnly = false;
                txtFecSubsana.ReadOnly = false;
                txtObsInspector.ReadOnly = false;
                txtObsSolicitante.ReadOnly = false;


                MultiView1.ActiveViewIndex = 1;

                APPL.FrondEnd.Response.Ok(logMensajes);
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

                DateTime dt = Convert.ToDateTime(oPtuDiligenciaDTO.datfechadiligencia.ToString());
                txtFecprog.Text = String.Format("{0:yyyy-MM-dd}", dt);

                txtHorprog.Text = oPtuDiligenciaDTO.smlhoradiligencia.ToString();
                ddlEstadoInsp.SelectedValue = oPtuDiligenciaDTO.smlestdiligencia.ToString();

                dt = Convert.ToDateTime(oPtuDiligenciaDTO.datfechareprogramacion.ToString());
                txtFecRepro.Text = String.Format("{0:yyyy-MM-dd}", dt); 

                dt = Convert.ToDateTime(oPtuDiligenciaDTO.datfechamaxsubsanacion.ToString());
                txtFecSubsana.Text = String.Format("{0:yyyy-MM-dd}", dt);

                txtObsInspector.Text = oPtuDiligenciaDTO.vchobsinspector;
                txtObsSolicitante.Text = oPtuDiligenciaDTO.vchobssolicitante;
                hdfCodSolicitud.Value = oPtuDiligenciaDTO.intcodsolicitud.ToString();

                txtNumActa.Text = oPtuDiligenciaDTO.vchfileactadiligencia;
                txtNumInf.Text = oPtuDiligenciaDTO.vchfileinformecumplimiento;
                txtNumPanFot.Text = oPtuDiligenciaDTO.vchfilepanelfotografico;


                gvInspectores.DataSource = pbd_CargarGrillaInspectores(0, oPtuDiligenciaDTO.intcodsolicitud);
                gvInspectores.DataBind();

                fuNumActa.Visible = false;
                fuNumInf.Visible = false;
                fuNumPanFot.Visible = false;

                txtNumActa.Visible = true;
                txtNumInf.Visible = true;
                txtNumPanFot.Visible = true;

                btnNumActa.Visible = true;
                btnNumInf.Visible = true;
                btnNumPanFot.Visible = true;

                txtNumActa.ReadOnly = true;
                txtNumInf.ReadOnly = true;
                txtNumPanFot.ReadOnly = true;

                txtFecprog.ReadOnly = true;
                txtHorprog.ReadOnly = true;
                ddlEstadoInsp.Enabled = false;
                txtFecRepro.ReadOnly = true;
                txtFecSubsana.ReadOnly = true;
                txtObsInspector.ReadOnly = true;
                txtObsSolicitante.ReadOnly = true;


                MultiView1.ActiveViewIndex = 1;

                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
            }



        }


        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            string folderPath = ConfigurationManager.AppSettings["UPLOAD_TMP"];

            //Check whether Directory (Folder) exists, although we have created, if it si not created this code will check
            if (!Directory.Exists(folderPath))
            {
                //If folder does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            fuNumInf.SaveAs(folderPath + fuNumInf.FileName);
            txtNumInf.Text = fuNumInf.PostedFile.FileName;
            fuNumInf.Visible = false;
            txtNumInf.Visible = true;
            btnUpload1.Visible = false;

        }

        protected void btnUpload2_Click(object sender, EventArgs e)
        {
            string folderPath = ConfigurationManager.AppSettings["UPLOAD_TMP"];

            //Check whether Directory (Folder) exists, although we have created, if it si not created this code will check
            if (!Directory.Exists(folderPath))
            {
                //If folder does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            fuNumActa.SaveAs(folderPath + fuNumActa.FileName);
            txtNumActa.Text = fuNumActa.PostedFile.FileName;
            fuNumActa.Visible = false;
            txtNumActa.Visible = true;
            btnUpload2.Visible = false;

        }

        protected void btnUpload3_Click(object sender, EventArgs e)
        {
            string folderPath = ConfigurationManager.AppSettings["UPLOAD_TMP"];

            //Check whether Directory (Folder) exists, although we have created, if it si not created this code will check
            if (!Directory.Exists(folderPath))
            {
                //If folder does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            if (fuNumPanFot.PostedFile.ContentLength > 15360)
            {
                return;
            }

            fuNumPanFot.SaveAs(folderPath + fuNumPanFot.FileName);
            txtNumPanFot.Text = fuNumPanFot.PostedFile.FileName;
            fuNumPanFot.Visible = false;
            txtNumPanFot.Visible = true;
            btnUpload3.Visible = false;

        }

        protected void btnRegresaVista_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnNumInf_Click(object sender, EventArgs e)
        {
            string pdfRuta;

            pdfRuta = ConfigurationManager.AppSettings["IPServidorPDF"] +  txtNumInf.Text; 
            reporte.Attributes.Add("src", pdfRuta);
            MultiView1.ActiveViewIndex = 2;

        }

        protected void btnNumActa_Click(object sender, EventArgs e)
        {
            string pdfRuta;

            pdfRuta = ConfigurationManager.AppSettings["IPServidorPDF"] + txtNumActa.Text;
            reporte.Attributes.Add("src", pdfRuta);
            MultiView1.ActiveViewIndex = 2;

        }

        protected void btnNumPanFot_Click(object sender, EventArgs e)
        {
            string pdfRuta;

            pdfRuta = ConfigurationManager.AppSettings["IPServidorPDF"] + txtNumPanFot.Text;
            reporte.Attributes.Add("src", pdfRuta);
            MultiView1.ActiveViewIndex = 2;

        }


        protected void gvInspecciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblEstado = (Label)e.Row.FindControl("lblEstDiligencia");

                Button btnVer = (Button)e.Row.FindControl("btnVer");
                Button btnEditar = (Button)e.Row.FindControl("btnEditar");

                //51  PROGRAMADO
                //52  REPROGRAMADO
                //53  RIESGO
                //54  ACTIVIDAD NO CORRESPONDE
                //55  SUBSANABLE
                //56  APROBADO

                switch (Convert.ToInt32(lblEstado.Text))
                {
                    case 56:
                        btnVer.Visible = true;
                        btnEditar.Visible = false;
                        break;
                    default:
                        {
                            btnVer.Visible = false;
                            btnEditar.Visible = true;
                            break;
                        }

                }

            }
        }
    }
}