<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="FrmSolicitudITSE.aspx.cs" Inherits="SIPT.WebInterno.FrmSolicitudITSE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.1/css/all.css" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <script type="text/javascript" language="javascript">

        function expandcollapse(obj, row) {
            var div = document.getElementById(obj);
            if (div.style.display == "none") {
                div.style.display = "block";
            }
            else {
                div.style.display = "none";
            }
            console.log(div.style.display);
        }




    </script>
    <div class="row page-titles w-100">
        <div class="col-md-5 align-self-center" style="padding-left: 40px">
            <h3 class="text-themecolor">Solicitud de Certificaciones ITSE</h3>
        </div>
        <div class="col-md-7 align-self-center">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">ITSE</a></li>
                <li class="breadcrumb-item active">Solicitud de Certificaciones ITSE</li>
            </ol>
        </div>
    </div>
    <!--<nav class="navbar navbar-light bg-black">
        <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="text-white small" ></asp:Label>
    </nav>-->

    <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="View1" runat="server">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="card">
                    <div class="card-header">
                        <span>Filtros de Búsqueda</span>
                    </div>
                    <div class="card-body">

                        <div class="row">

                            <div class="col-md-2">
                                <label for="ddlAnioBus" class="orm-label-sm">Año</label>
                                <asp:DropDownList ID="ddlAnioBus" runat="server" CssClass="select2 form-control custom-select"></asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <label for="txtNumSolBus" class="form-label-sm">Número</label>
                                <asp:TextBox ID="txtNumSolBus" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label for="ddlEstadoBus" class="form-label-sm">Estado</label>
                                <asp:DropDownList ID="ddlEstadoBus" runat="server" CssClass="select2 form-control custom-select"></asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <label for="ddlResultadoBus" class="form-label-sm">Resultado</label>
                                <asp:DropDownList ID="ddlResultadoBus" runat="server" CssClass="select2 form-control custom-select"></asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <label for="txtNumExpBus" class="form-label-sm">Expediente</label>
                                <asp:TextBox ID="txtNumExpBus" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <asp:Button ID="btnLimpiar" runat="server" Text=" Limpiar " CssClass="btn btn-primary" OnClick="btnLimpiar_Click" />
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-2">
                                <label for="txtCodAdmBus" class="form-label-sm">Administrado</label>
                                <asp:TextBox ID="txtCodAdmBus" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="txtNomSolBus" class="form-label-sm">Solicitante</label>
                                <asp:TextBox ID="txtNomSolBus" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label for="ddlInspectorBus" class="form-label-sm">Inspector</label>
                                <asp:DropDownList ID="ddlInspectorBus" runat="server" CssClass="select2 form-control custom-select"></asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <asp:Button ID="btnBuscar" runat="server" Text=" Buscar " CssClass="btn btn-success" OnClick="btnBuscar_Click" />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="card">
                    <div class="card-header">
                        <span>Lista de Solicitudes ITSE</span>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">

                            <asp:GridView runat="server" ID="gvSolicitud" class="table" PageSize="5" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="INTCODSOLICITUD" OnRowDataBound="gvSolicitud_RowDataBound" Width="100%" OnPageIndexChanging="gvSolicitud_PageIndexChanging">
                                <HeaderStyle CssClass="" />
                                <Columns>


                                    <asp:BoundField DataField="INTCODSOLICITUD" HeaderText="Id"></asp:BoundField>
                                    <asp:BoundField DataField="CHRANIO" HeaderText="Año"></asp:BoundField>
                                    <asp:BoundField DataField="VCHNUMERO" HeaderText="Numero"></asp:BoundField>
                                    <asp:BoundField DataField="VCHNOMBRESOLICITANTE" HeaderText="Administrado"></asp:BoundField>

                                    <asp:TemplateField HeaderText="Nro.Licencia">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAnoLic" runat="server" Text='<%# Eval("CHLICANIO") %>' />
                                            <asp:Label ID="lblNroLic" runat="server" Text='<%# Eval("VCHLICNUMERO") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Est.Solicitud">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEstSolCer" runat="server" Text='<%# Eval("SMLESTSOLCERTIFICADO") %>' Visible="false" />
                                            <asp:Label ID="lblEstSolCerTxt" runat="server" Text='<%# Eval("VCHESTSOLCERTIFICADO") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="VCHESTSOLCERTIFICADO" HeaderText="Estado"></asp:BoundField>--%>
                                    <asp:BoundField DataField="VCHRESULTADOCERTIFICACION" HeaderText="Resultado"></asp:BoundField>


                                    <asp:TemplateField HeaderText="Analista">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlAnalista" class="select2 form-control custom-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnalista_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodSolicitud" runat="server" Text='<%# Eval("INTCODSOLICITUD") %>' Visible="false" />
                                            <i class="bi bi-info-circle" onclick="javascript:expandcollapse('div<%# Eval("INTCODSOLICITUD") %>', 'one');"></i>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <tr>
                                                <td colspan="100%">
                                                    <div id="div<%# Eval("INTCODSOLICITUD") %>" style="display: none; position: relative; left: 15px; overflow: auto; width: 95%">
                                                        <asp:GridView runat="server" ID="gvInspecciones" class="table table-bordered table-condensed table-responsive table-hover" PageSize="5" AutoGenerateColumns="False" Width="100%">
                                                            <HeaderStyle CssClass="" />
                                                            <Columns>
                                                                <asp:BoundField DataField="INTCODDILIGENCIA" HeaderText="Nro.Inspecc."></asp:BoundField>
                                                                <asp:BoundField DataField="DATFECHADILIGENCIA" HeaderText="Fec.Program."></asp:BoundField>
                                                                <asp:BoundField DataField="SMLHORADILIGENCIA" HeaderText="Hora Program."></asp:BoundField>
                                                                <asp:BoundField DataField="SMLESTDILIGENCIA" HeaderText="Estado"></asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCodDiligencia" runat="server" Text='<%# Eval("INTCODDILIGENCIA") %>' Visible="false" />
                                                                        <asp:Button ID="btnVer" runat="server" Text=" Ver " OnClick="btnVer_Click" CssClass="btn waves-effect waves-light btn-warning" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnEditar" runat="server" Text=" Editar "  OnClick="btnEditar_Click" CssClass="btn waves-effect waves-light btn-warning" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
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
                        <span>Inspeccion</span>
                    </div>
                    <div class="card-body">

                        <div class="row">

                            <div class="col-md-2">
                                <label for="txtFecprog" class="form-label-sm">Fecha de Prog.</label>
                                <asp:TextBox ID="txtFecprog" Text="" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label for="txtHorprog" class="form-label-sm">Hora de Prog.</label>
                                <asp:TextBox ID="txtHorprog" Text="" TextMode="Time" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label for="ddlInspector" class="form-label-sm">Inspector</label>
                                <asp:DropDownList ID="ddlInspector" runat="server" CssClass="select2 form-control custom-select"></asp:DropDownList>
                            </div>
                            <div class="col-6">
                                <label for="txtObsInspector" class="form-label-sm">Inspectores</label>
                                <asp:TextBox ID="TextBox1" Text="" runat="server" class="form-control" TextMode="MultiLine" required data-validation-required-message="El campo es obligatorio"></asp:TextBox>

                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-5">
                                <label for="txtNumInf" class="form-label-sm">Informe de Verificacion de cumplimiento</label>
                                <asp:TextBox ID="txtNumInf" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="LinkButton1" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i></asp:LinkButton>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton ID="LinkButton2" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i></asp:LinkButton>
                            </div>

                            <div class="col-md-2">
                                <label for="ddlEstadoInsp" class="form-label-sm">Estado</label>
                                <asp:DropDownList ID="ddlEstadoInsp" runat="server" CssClass="select2 form-control custom-select"></asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <label for="txtFecSubsana" class="form-label-sm">Fecha de Sunsanacion</label>
                                <asp:TextBox ID="txtFecSubsana" Text="" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-5">
                                <label for="txtNumActa" class="form-label-sm">Acta de Diligencia</label>
                                <asp:TextBox ID="txtNumActa" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="LinkButton3" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i></asp:LinkButton>
                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="LinkButton4" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i></asp:LinkButton>
                            </div>

                            <div class="col-md-6">
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-5">
                                <label for="txtNumPanFot" class="form-label-sm">Panel Fotografico</label>
                                <asp:TextBox ID="txtNumPanFot" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="LinkButton5" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i></asp:LinkButton>
                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="LinkButton6" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i></asp:LinkButton>
                            </div>

                            <div class="col-md-2">
                            </div>

                            <div class="col-md-3">
                                <label for="txtFecRepro" class="form-label-sm">Fecha de Reprogramacion</label>
                                <asp:TextBox ID="txtFecRepro" TextMode="Date" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <label for="txtObsInspector" class="form-label-sm">Observaciones del Inspector</label>
                                <asp:TextBox ID="txtObsInspector" Text="" runat="server" class="form-control" TextMode="MultiLine" required data-validation-required-message="El campo es obligatorio"></asp:TextBox>

                            </div>

                            <div class="col-6">
                                <label for="txtObsSolicitante" class="form-label-sm">Observaciones del Solicitante</label>
                                <asp:TextBox ID="txtObsSolicitante" Text="" runat="server" class="form-control" TextMode="MultiLine" required data-validation-required-message="El campo es obligatorio"></asp:TextBox>
                            </div>
                        </div>

                        <div class="card-footer" style="background-color: white">
                            <asp:LinkButton ID="btnRegresar" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i>&nbsp;&nbsp;Regresar</asp:LinkButton>
                            <div class="btn btn-info btn-rounded" style="cursor: pointer" onclick="<%=btnConfirmar.ClientID %>.click()">
                                <i class="fa fa-check"></i>
                                <asp:Button type="submit" ID="btnConfirmar" runat="server" Text=" Guardar " ClientIDMode="Static" CssClass="btnHidden" Style="cursor: pointer" OnClick="btnConfirmar_Click" />
                            </div>

                            <asp:HiddenField ID="hdfCodSolicitud" runat="server" />
                            <asp:HiddenField ID="hdfSolLicEstado" runat="server" />
                            <asp:HiddenField ID="hdfSolEmail" runat="server" />
                        </div>

                    </div>
                </div>
            </div>

        </asp:View>
    </asp:MultiView>


</asp:Content>
