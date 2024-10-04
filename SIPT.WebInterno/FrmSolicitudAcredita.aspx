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

    </script>
    <!--<link href="assets/css/gridview.css" rel="stylesheet" />-->
    <%--    <nav class="navbar navbar-light bg-black">
    </nav>--%>
    <div class="card">
        <div class="card-header">
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
        </div>

        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">


                <div class="card-header">_</div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
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
                <form class="row">
                    <div class="container">
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
                                <label for="txtCondicion" class="form-label-sm">Condicion</label>
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
                                <label for="txtAreaEst" class="form-label-sm">Area Estructuracion</label>
                                <asp:TextBox ID="txtAreaEst" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label for="txtZonifica" class="form-label-sm">Zonificacion</label>
                                <asp:TextBox ID="txtZonifica" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-10">
                                <label for="ddlProcedimiento" class="form-label-sm">Procedimientos TUPA</label>
                                <asp:DropDownList ID="ddlProcedimiento" runat="server" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                            </div>



                        </div>

                        <div class="card-header">Anexos Requisitos</div>

                        <div class="table-responsive">
                            <asp:Repeater ID="rptResult" runat="server">
                                <HeaderTemplate>

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
                                    <%--<div class="row">--%>
                                </HeaderTemplate>
                                <ItemTemplate>
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
                                                <input class="form-check-input" type="checkbox" id="fscAcredita" runat="server" />
                                            </div>

                                        </div>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtObserva" runat="server" Text='<%# Eval("VCHOBSEVALUACION") %>' TextMode="MultiLine" Width="90%" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%--</div>--%>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>

                        <div class="col-12">
                            <asp:Button ID="btnRegresar" runat="server" Text=" Regresar " CssClass="btn btn-primary" OnClick="btnRegresar_Click" />
                            <asp:Button ID="btnGuardar" runat="server" Text=" Acreditar " CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                        </div>
                    </div>
                    <asp:HiddenField ID="hdfCodSolicitud" runat="server" />
                    <asp:HiddenField ID="hdfSolLicEstado" runat="server" />




                </form>

            </asp:View>
            <asp:View ID="View3" runat="server">

                <div class="card">
                    <%--<div class="card-header">Card Header</div>--%>
                    <div class="card-body">
                        <iframe id="reporte" name="reporte" runat="server" width="100%" height="600px"></iframe>
                    </div>
                    <div class="card-footer text-center">
                        <asp:Button ID="btnRegresaVista" runat="server" Text="Cerrar" CssClass="btn btn-success btn-sm" OnClick="btnRegresaVista_Click" />

                    </div>
                </div>

            </asp:View>
        </asp:MultiView>

    </div>

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
