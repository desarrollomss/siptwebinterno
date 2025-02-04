<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="FrmAsignarInspectores.aspx.cs" Inherits="SIPT.WebInterno.FrmAsignarInspectores" %>

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
            <h3 class="text-themecolor">Asignar Inspectores</h3>
        </div>
        <div class="col-md-7 align-self-center">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">ITSE</a></li>
                <li class="breadcrumb-item active">Asignar Inspectores</li>
            </ol>
        </div>
    </div>
    <!--<nav class="navbar navbar-light bg-black">
        <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="text-white small" ></asp:Label>
    </nav>-->

    <%--    <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="View1" runat="server">--%>

    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

        <div class="card">
            <div class="card-header">
                <span>Filtros de Búsqueda</span>
            </div>
            <div class="card-body">

                <div class="row">

                    <div class="col-md-2">
                        <label for="ddlAnioBus" class="orm-label-sm">Año</label>
                        <asp:DropDownList ID="ddlAnioBus" runat="server" CssClass="select2 form-control custom-select" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <label for="txtNumSolBus" class="form-label-sm">Número</label>
                        <asp:TextBox ID="txtNumSolBus" Text="" runat="server" class="form-control"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <label for="ddlEstadoBus" class="form-label-sm">Estado</label>
                        <asp:DropDownList ID="ddlEstadoBus" runat="server" CssClass="select2 form-control custom-select" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <label for="ddlResultadoBus" class="form-label-sm">Resultado</label>
                        <asp:DropDownList ID="ddlResultadoBus" runat="server" CssClass="select2 form-control custom-select" Width="90%"></asp:DropDownList>
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
                        <asp:DropDownList ID="ddlInspectorBus" runat="server" CssClass="select2 form-control custom-select" Width="90%"></asp:DropDownList>
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
                            <asp:TemplateField HeaderText="Solicitante / Dirección">
                                <ItemTemplate>
                                    <asp:Label ID="lblSolicitante" runat="server" Text='<%# Eval("VCHNOMBRESOLICITANTE") %>' />
                                    </BR>    
                                    <asp:Label ID="lblDireccion" runat="server" Text='<%# Eval("VCHDIRECCSOLICITANTECERT") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:BoundField DataField="VCHRESULTADOCERTIFICACION" HeaderText="Resultado"></asp:BoundField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblCodSolicitud" runat="server" Text='<%# Eval("INTCODSOLICITUD") %>' Visible="false" />
                                    <asp:GridView runat="server" ID="gvInspectores" class="table table-bordered table-condensed table-responsive table-hover" PageSize="5" AutoGenerateColumns="false" ShowHeader="false" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="INTUSUINSPECTOR" HeaderText=""></asp:BoundField>
                                            <asp:BoundField DataField="VCHNOMBREINSPECTOR" HeaderText=""></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUsuInspector" runat="server" Text='<%# Eval("INTUSUINSPECTOR") %>' Visible="false" />
                                                    <asp:Label ID="lblCodSolicitudInspector" runat="server" Text='<%# Eval("INTCODSOLICITUDINSPECTOR") %>' Visible="false" />
                                                    <asp:Button ID="btnQuitarInsp" runat="server" Text=" Quitar " CssClass="btn btn-success" OnClick="btnQuitarInsp_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    <asp:DropDownList ID="ddlInspectores" runat="server" CssClass="select2 form-control custom-select" Width="90%">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnAsignarInsp" runat="server" Text=" Asignar " CssClass="btn btn-success" OnClick="btnAsignarInsp_Click" />
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
    <%--    </asp:View>

    </asp:MultiView>--%>
    <asp:HiddenField ID="hdfCodDiligencia" runat="server" />
    <asp:HiddenField ID="hdfCodSolicitud" runat="server" />
    <asp:HiddenField ID="hdfSolLicEstado" runat="server" />
    <asp:HiddenField ID="hdfSolEmail" runat="server" />



</asp:Content>
