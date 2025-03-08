<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="FrmSolicitudAcredita.aspx.cs" Inherits="SIPT.WebInterno.FrmSolicitudAcredita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.1/css/all.css" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <script type="text/javascript" language="javascript">

        /*function expandcollapse(obj, row) {
            var div = document.getElementById(obj);
            if (div.style.display == "none") {
                div.style.display = "block";
            }
            else {
                div.style.display = "none";
            }
        }*/
        function validarSelect() {
            const select = document.getElementById("ContentPlaceHolder1_ddlProcedimiento");
            
            if (select.value === "0") {
                alert('Seleccione un Procedimiento.')
                return false;
            } else {
                return true;
            }
        }
    </script>

    <div class="row page-titles w-100">
        <div class="col-md-5 align-self-center" style="padding-left:40px">
            <h3 class="text-themecolor">Acreditar Documentación</h3>
        </div>
        <div class="col-md-7 align-self-center">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">Licencias</a></li>
                <li class="breadcrumb-item active">Acreditar Documentación</li>
            </ol>
        </div>
    </div>
                

        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">            
            <asp:View ID="View1" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="card-header">
                        <span>Lista de Solicitudes a acreditar</span>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">

                            <asp:GridView runat="server" ID="gvSolicitud" class="table" PageSize="5" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="INTCODSOLICITUD, SMLESTSOLLICENCIA" OnRowDataBound="gvSolicitud_RowDataBound" Width="100%" OnPageIndexChanging="gvSolicitud_PageIndexChanging">
                                <HeaderStyle CssClass="" />
                                <Columns>
                                    <asp:BoundField DataField="INTCODSOLICITUD" HeaderText="Id"></asp:BoundField>
                                    <asp:BoundField DataField="VCHANIONUMERO" HeaderText="Solicitud"></asp:BoundField>
                                    <asp:BoundField DataField="VCHADMCOMPLETO" HeaderText="Administrado"></asp:BoundField>
                                    <asp:BoundField DataField="VCHPREDIRECCION" HeaderText="Ubicación"></asp:BoundField>
                                    <asp:BoundField DataField="DECAREAOCUPAR" HeaderText="Area Ocupar"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Id.Analista">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodAnalista" runat="server" Text='<%# Eval("INTUSUANALISTA") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Analista">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlAnalista" runat="server" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="ddlAnalista_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEstSolLic" runat="server" Text='<%# Eval("SMLESTSOLLICENCIA") %>' Visible="false" />
                                            <asp:Label ID="lblEstSolLicTxt" runat="server" Text='<%# Eval("VCHESTSOLLICENCIA") %>' Visible="false" />
                                            <asp:Button ID="btnCalifica" runat="server" Text="" OnClick="btnCalifica_Click" CssClass="btn btn-outline-success btn-sm" Visible="false" />
                                            <%--<asp:Button ID="btnCalifica2" runat="server" Text=" 2da. Calificación " OnClick="btnCalifica_Click" CssClass="btn btn-outline-success btn-sm" Visible="false"/>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center">No hay registros para mostrar.</div>
                                </EmptyDataTemplate>

                                <PagerStyle HorizontalAlign="Center" />
                            </asp:GridView>

                        </div>
                    </div>
                </div>                    
                </div> 
            </asp:View>               

            <asp:View ID="View2" runat="server">                    
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="card-header">
                            <span>Solicitud</span>
                        </div>
                        <div class="card-body">
                                    
                            <div class="row">                                        
                                <div class="col-md-2">
                                    <label for="txtCodSolicitud" class="form-label-sm">Id.Solicitud</label>
                                    <asp:TextBox ID="txtCodSolicitud" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label for="txtNumSolicitud" class="form-label-sm">Nro.Solicitud</label>
                                    <asp:TextBox ID="txtNumSolicitud" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtAdministrado" class="form-label-sm">Administrado</label>
                                    <asp:TextBox ID="txtAdministrado" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label for="txtCondicion" class="form-label-sm">Condición</label>
                                    <asp:TextBox ID="txtCondicion" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>                            
                            </div>

                            <div class="row">
                                <div class="col-md-2">
                                    <label for="txtAreaOcupa" class="form-label-sm">Area</label>
                                    <asp:TextBox ID="txtAreaOcupa" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtDireccion" class="form-label-sm">Direccion</label>
                                    <asp:TextBox ID="txtDireccion" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label for="txtAreaEst" class="form-label-sm">Area Tratamiento Normativo</label>
                                    <asp:TextBox ID="txtAreaEst" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>

                                <div class="col-md-2">
                                    <label for="txtZonifica" class="form-label-sm">Zonificación</label>
                                    <asp:TextBox ID="txtZonifica" Text="" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-10"><label for="ddlProcedimiento" class="form-label-sm">Procedimientos TUPA</label></div>
                                <div class="col-md-2">
                                </div>
                            </div>
                                    
                            <div class="row">
                                <div class="col-md-10">
                                    <asp:DropDownList ID="ddlProcedimiento" runat="server" class="select2 form-control custom-select"></asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>                                       
                                        
                        </div>
                    </div>
                
                    <div class="card">
                        <div class="card-header">
                            <span>Anexos a acreditar</span>
                        </div>
                        <div class="card-body">
                            <asp:Repeater ID="rptResult" runat="server">
                                    <HeaderTemplate>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="row">
                                            <div class="col-md-1">
                                                <span class="badge badge-secondary">Item</span>
                                            </div>
                                            <div class="col-md-4">
                                                <span class="badge badge-secondary">Documento</span>
                                            </div>
                                            <div class="col-md-1">
                                                <span class="badge badge-secondary">Ver</span>
                                            </div>
                                            <div class="col-md-1">
                                                <span class="badge badge-secondary">Vo.Bo.</span>
                                            </div>
                                            <div class="col-md-5">
                                                <span class="badge badge-secondary">Observaciones</span>
                                            </div>
                                        </div>
                                            </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="row">
                                            <div class="col-md-1">
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("SMLEVALUACION") %>' Visible="false" />
                                                <asp:Label ID="lblSOLPLA" runat="server" Text='<%# Eval("INTSOLICITUDPLANTILLA") %>' Visible="false" />
                                                <asp:Label ID="lblCODPLA" runat="server" Text='<%# Eval("INTCODPLANTILLA") %>' Visible="false" />

                                                <%#Eval("INTCODPLANTILLA") %>
                                            </div>
                                            <div class="col-md-4">
                                                <%#Eval("VCHNOMBREPLANTILLA") %>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lblNomArchivo" runat="server" Text='<%# Eval("VCHDOCREQUERIMIENTO") %>' Visible="false" />
                                                <!-- Button IMAGE -->
                                                <asp:ImageButton ID="bimgVisualiza" runat="server" OnClick="bimgVisualiza_Click" ImageUrl="~/assets/images/pdf.png" Width="24px" Height="24px" />

                                            </div>
                                            <div class="col-md-1">
                                                <div class="form-check form-switch">
                                                    <input type="checkbox" id="fscAcredita" runat="server" class="js-switch" data-color="#26c6da" data-secondary-color="#f62d51"/>
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="txtObserva" runat="server" Text='<%# Eval("VCHOBSEVALUACION") %>' TextMode="MultiLine" Width="90%" />
                                            </div>
                                        </div>
                                            </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            <div class="card-footer" style="background-color:white">
                                <asp:LinkButton ID="btnRegresar" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i>&nbsp;&nbsp;Regresar</asp:LinkButton>
                                <div class="btn btn-info btn-rounded" style="cursor:pointer" onclick="<%=btnConfirmar.ClientID %>.click()">
                                    <i class="fa fa-check"></i>                                
                                    <asp:Button type="submit" ID="btnConfirmar" runat="server" Text=" Guardar " ClientIDMode="Static" CssClass="btnHidden" style="cursor:pointer" OnClick="btnConfirmar_Click" />           
                                </div>
                                <asp:Button ID="btnGuardar" runat="server" Text="" CssClass="btnHidden" OnClick="btnGuardar_Click"/>
                                <asp:HiddenField ID="hdfCodSolicitud" runat="server" />
                                <asp:HiddenField ID="hdfSolLicEstado" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>

            <asp:View ID="View3" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                
                    <div class="card">
                        <div class="card-header">
                            <span>Anexo</span>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <iframe id="reporte" name="reporte" runat="server" width="100%" height="750px"></iframe>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnRegresaVista" runat="server" Text="Cerrar" CssClass="btn btn-success btn-sm" OnClick="btnRegresaVista_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            
    </asp:MultiView>

    

    <%--<asp:DropDownList ID="ddlPrueba" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPrueba_SelectedIndexChanged">
    </asp:DropDownList>--%>
    <script type="text/javascript">

        function muestra() {
            const mymodal = document.getElementById('staticBackdrop');
            console.log(mymodal);
            mymodal.show();
        }

        function Reporte() {
            window.open('rpt/ReporteGenerico.aspx?pReporte=AcumHorasMOxMoldePDF', 'reporte');
        }

    </script>
</asp:Content>
