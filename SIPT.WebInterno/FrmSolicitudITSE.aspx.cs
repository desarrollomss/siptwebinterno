using RestSharp;
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
using System.Text;
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

        // depurar
        private PtuSolLicenciaAnalista oPtuSolLicenciaAnalista;
        private PtuSolLicenciaAnalista_bo oPtuSolLicenciaAnalista_bo;
        private PtuProcedimientostupa_bo oPtuProcedimientostupa_bo;
        private PtuSolicitudDTO oPtuSolicitudDTO;
        private PtuSolLicencia oPtuSolLicencia;
        private PtuPlantillareq_bo oPtuPlantillareq_bo;

        private List<PtuSolrequerimiento> oPtuSolrequerimientoList;
        private PtuSolrequerimiento oPtuSolrequerimiento;

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

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            ltxtUsuarioId = (string)(Request.Cookies["Security"]["UsuarioId"]);
            ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);

            lstUsuario = (string)(Request.Cookies["Security"]["UsuarioId"]);
            lstSistema = (string)(Request.Cookies["Security"]["Sistema"]);
            lstEquipo = (string)(Request.Cookies["Security"]["DireccionIP"]);
            lstOpcion = (string)(Request.Cookies["Security"]["Opcion"]);
            lstNombre = (string)(Request.Cookies["Security"]["Nombres"]);
            */
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

                    ddlInspectorBus.DataSource = (DataTable)ViewState["ANALISTA"];
                    ddlInspectorBus.DataTextField = "VCHUSUANALISTA";
                    ddlInspectorBus.DataValueField = "INTUSUANALISTA";
                    ddlInspectorBus.DataBind();
                    ddlInspectorBus.Items.Insert(0, new ListItem("(Todos)", "0"));


                    ddlAnioBus.DataSource = (DataTable)ViewState["ANALISTA"];
                    ddlAnioBus.DataTextField = "VCHUSUANALISTA";
                    ddlAnioBus.DataValueField = "INTUSUANALISTA";
                    ddlAnioBus.DataBind();
                    ddlAnioBus.Items.Insert(0, new ListItem("(Todos)", "0"));

                    oPtuTabla = new PtuTabla();
                    oPtuTabla_bo = new PtuTabla_bo(ref logMensajes);

                    oPtuTabla.vchtabla = "PTUSOLCERTIFICADO";
                    oPtuTabla.vchcampo = "SMLESTSOLCERTIFICADO";
                    oPtuTablaList = oPtuTabla_bo.ListarGrupo(oPtuTabla);

                    ddlEstadoBus.DataSource = oPtuTablaList;
                    ddlEstadoBus.DataTextField = "VCHDESCRIPCION";
                    ddlEstadoBus.DataValueField = "SMLCODTABLA";
                    ddlEstadoBus.DataBind();
                    ddlEstadoBus.Items.Insert(0, new ListItem("(Todos)", "0"));

                    oPtuTabla.vchtabla = "PTUSOLCERTIFICADO";
                    oPtuTabla.vchcampo = "SMLRESULTADOCERTIFICACION";
                    oPtuTablaList = oPtuTabla_bo.ListarGrupo(oPtuTabla);

                    ddlResultadoBus.DataSource = oPtuTablaList;
                    ddlResultadoBus.DataTextField = "VCHDESCRIPCION";
                    ddlResultadoBus.DataValueField = "SMLCODTABLA";
                    ddlResultadoBus.DataBind();
                    ddlResultadoBus.Items.Insert(0, new ListItem("(Todos)", "0"));


                    pbd_CargarGrillaSolicitud();
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

                    GridView gvSCU = (GridView)e.Row.FindControl("gvUsos");

                    gvSCU.DataSource = pbd_CargarGrillaUsos(Convert.ToInt32(lblCodSolicitud.Text));
                    gvSCU.DataBind();

                }
                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
            {
                Response response = APPL.FrondEnd.Response.Error(ex, logMensajes);
                response.MensajeSwal(ClientScript);
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
            request.vchconnombre = "ddlAnalista_SelectedIndexChanged";
            request.vchaudcodusuario = lstUsuario;
            request.vchaudequipo = lstEquipo;

            oPtuSolLicenciaAnalista = new PtuSolLicenciaAnalista();
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
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

        protected void btnCalifica_Click(object sender, EventArgs e)
        {
            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Button btn = sender as Button;
                GridViewRow row = btn.NamingContainer as GridViewRow;
                int lintCodSolicitud = Convert.ToInt32(gvSolicitud.DataKeys[row.RowIndex].Values["INTCODSOLICITUD"]);
                int lintEstSolLicencia = Convert.ToInt16(gvSolicitud.DataKeys[row.RowIndex].Values["SMLESTSOLLICENCIA"]);
                hdfCodSolicitud.Value = lintCodSolicitud.ToString();
                hdfSolLicEstado.Value = lintEstSolLicencia.ToString();

                MultiView1.ActiveViewIndex = 1;

                pbd_CargarGrillaUsos(lintCodSolicitud, lintEstSolLicencia);

                APPL.FrondEnd.Response.Ok(logMensajes);
            }
            catch (Exception ex)
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
            new Response().ConfirmacionSwal(ClientScript, TipoConfirmacion.GUARDAR, "la Calificación", "btnGuardar");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int lintCodSolicitud = Convert.ToInt32(hdfCodSolicitud.Value);
            Int16 lintEstSolLicencia = Convert.ToInt16(hdfSolLicEstado.Value);

            logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                pbd_GuardarCalificacion(lintCodSolicitud, lintEstSolLicencia);

                // Procesa Plantillas
                if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
                {
                    pbd_ProcesarPlantillas(lintCodSolicitud);
                }

                MultiView1.ActiveViewIndex = 0;
                pbd_CargarGrillaSolicitud();

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
                pbd_CargarGrillaPlantillas();
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
            string ltxtUsuarioId = (string)(Request.Cookies["Security"]["UsuarioId"]);
            string ltxtUsuarioRol = (string)(Request.Cookies["Security"]["UsuarioRol"]);
            int lintUsuAnalista = 0;
            /* Lista pendientes por Rol o Analista*/
            if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
            {
                lintUsuAnalista = Convert.ToInt32(ltxtUsuarioId);
                /*fscAnalista.Visible = true;
                lblForAnalista.Visible = true;*/
                lblTitAnalista.Visible = true;

                fscCordinador.Visible = false;
                lblForCoordinador.Visible = false;
                lblTitCordinador.Visible = false;

            }

            if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
            {
                lintUsuAnalista = 0;

                /*fscAnalista.Visible = true;
                lblForAnalista.Visible = true;
                lblTitAnalista.Visible = true;

                fscAnalista.Disabled = true;*/


                fscCordinador.Visible = true;
                lblForCoordinador.Visible = true;
                lblTitCordinador.Visible = true;

            }

            oPtuSolicitud = new PtuSolicitud();
            
            PtuSolicitud_bo oPtuSolicitud_bo = new PtuSolicitud_bo(ref logMensajes);
            List<PtuSolicitud_PorAnalistaPorSolicitante> oPtuSolicitud_PorAnalistaPorSolicitanteList = oPtuSolicitud_bo.ListarCalificar(oPtuSolicitud, lintUsuAnalista);
            gvSolicitud.DataSource = oPtuSolicitud_PorAnalistaPorSolicitanteList;
            gvSolicitud.DataBind();
           
        }

        private List<PtuUsoDTO> pbd_CargarGrillaUsos(int? pintcodsolicitud, int? pintEstSolLicencia)
        {

            oPtuSolicitud = new PtuSolicitud();
            
            List<PtuUsoDTO> oPtuUsoDTOList = new List<PtuUsoDTO>();
           
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
            txtEmail.Text = oPtuSolicitudDTO.vchemailsol;

            txtObservacion.Text = oPtuSolicitudDTO.vchobservacion;

            if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
            {
                /*fscAnalista.Checked = false;
                fscCordinador.Checked = false;
                lblForAnalista.InnerText = "No Procede";
                lblForCoordinador.InnerText = "No Procede";*/
            }

            /*if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
            {
                fscAnalista.Checked = false;
                lblForAnalista.InnerText = "No Procede";
                fscCordinador.Checked = false;
                lblForCoordinador.InnerText = "No Procede";

                if (oPtuSolicitudDTO.smlresultado == 22)
                {  fscAnalista.Checked = true;   // Procede
                    lblForAnalista.InnerText = "Procede";
                }

                if (oPtuSolicitudDTO.smlresultado == 23)
                {
                    fscAnalista.Checked = false;  // No Procede
                    lblForAnalista.InnerText = "No Procede";
                }
            }*/

            gvUsos.DataSource = oPtuUsoDTOList;
            gvUsos.DataBind();

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

        private DataTable pbd_CargarGrillaPlantillaProcTupa(int? intcodplantilla, int? intcodigoprocedimiento, int? intcodsolicitud)
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

            oPtuSolicitud = new PtuSolicitud();
            
            List<PtuPlantillareqDTO> oPtuPlantillareqDTOList = new List<PtuPlantillareqDTO>();
            
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

            return dtTabla;
        }

        private void pbd_CargarGrillaPlantillas()
        {
            int intcodPlantilla = -1;
            //int intcodProcedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
            int intcodProcedimiento;
            int intcodSolicitud = Convert.ToInt32(txtCodSolicitud.Text);

            //oPtuPlantillareqDTOList = pbd_CargarGrillaPlantillaProcTupa(intcodPlantilla, intcodProcedimiento, intcodSolicitud);

        }

        private string pbd_GuardarCalificacion(int? pintcodsolicitud, Int16? pintEstSolLicencia)
        {
            string msg = "";

            oPtuSolLicencia = new PtuSolLicencia();
            oPtuSolLicencia.intcodsolicitud = pintcodsolicitud;
            oPtuSolLicencia.vchobservacion = txtObservacion.Text.ToUpper();
            oPtuSolLicencia.smlestsollicencia = pintEstSolLicencia;
            oPtuSolLicencia.vchaudusumodif = lstUsuario;
            oPtuSolLicencia.vchaudequipo = lstEquipo;
            oPtuSolLicencia.vchaudprograma = lstSistema;
            oPtuSolLicencia.tmsaudfecmodif = DateTime.Now;


            //int lintcodigoprocedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
            int lintcodigoprocedimiento = 0;
            if (ltxtUsuarioRol.ToUpper().Equals("ANALISTA SIPT"))
            {
                //if (fscAnalista.Checked) oPtuSolLicencia.smlresultado = 22; else oPtuSolLicencia.smlresultado = 23;
            }

            if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
            {
                if (fscCordinador.Checked) oPtuSolLicencia.smlresultado = 22; else oPtuSolLicencia.smlresultado = 23;
            }

            PtuSolLicencia_bo oPtuSolLicencia_bo = new PtuSolLicencia_bo(ref logMensajes);
            oPtuSolLicencia_bo.Calificar(oPtuSolLicencia, lintcodigoprocedimiento, ltxtUsuarioRol.ToUpper());

            if (ltxtUsuarioRol.ToUpper().Equals("COORDINADOR SIPT"))
            {
                CorreoCalificacion();
            }
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
            oPtuSolLicencia.vchobservacion = txtObservacion.Text.ToUpper();
            oPtuSolLicencia.vchaudusumodif = lstUsuario;
            oPtuSolLicencia.tmsaudfecmodif = DateTime.Now;

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

        public void EnviarCorreo(string pPara, string pAsunto, string pContenido)
        {
            string urlApiMail = ConfigurationManager.AppSettings["UrlApiMail"];
           
            var client = new RestClient(urlApiMail);
            var request = new RestRequest("EnviarEmail");
            request.AddBody(
                new
                {
                    para = pPara,
                    asunto = pAsunto,
                    contenido = pContenido
                });

            var response = client.ExecutePost(request);
           
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

        public void CorreoCalificacion()
        {

            string oPara = "marco.vivas@munisurco.gob.pe, pedro.rojas@munisurco.gob.pe";
            //oPara = txtEmail.Text.ToUpper();
            string oAsunto = "SIPT";
            StringBuilder oContenido = new StringBuilder("");

            oContenido.Append("<table width='1000px' border='1'><colgroup><col width='20%'/><col width='20%' /><col width='20%' /><col width='20%' /><col width='20%' /></colgroup>");
            oContenido.Append("<tr><td align='center'><img src='https://www.munisurco.gob.pe/wp-content/uploads/2020/07/ESCUDO-RGB.png' style='width:180px; height:180px'/></td>");
            oContenido.Append("<td colspan='4'>");
            oContenido.Append("<center><h3>Municipalidad de Santiago de Surco</h3></center></br>");
            oContenido.Append("<center><h3>Sistema de Procedimientos TUPA</h3></center></td></tr>");
            oContenido.Append("<tr><td colspan='5'><center>");
            oContenido.Append("Otorgar personería municipal a las organizaciones sociales sin fines de lucro, ser sujetos de derechos y obligaciones, atendiendo intereses vecinales");
            oContenido.Append("y contribuyendo en actividades que promuevan el desarrollo individual, colectivo y local.");
            oContenido.Append("- El procedimiento administrativo puede ser solicitado por organizaciones debidamente formalizadas: Organizaciones Sociales de Vecinos,");
            oContenido.Append("Organizaciones Sociales de Base, Organizaciones Culturales y Educativas, Organizaciones Juveniles, Organizaciones Deportivas y otras formas de");
            oContenido.Append("organizaciones se constituyan en el distrito de Santiago de Surco.");
            oContenido.Append("- El procedimiento administrativo culmina con la emisión de una Resolución Gerencial y está sujeto a renovación.");
            oContenido.Append("</center></td></tr>");
            oContenido.Append("</table>");

            EnviarCorreo(oPara, oAsunto, oContenido.ToString());

        }

        #endregion

    }
}