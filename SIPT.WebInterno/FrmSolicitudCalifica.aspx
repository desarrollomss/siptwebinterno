<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="FrmSolicitudCalifica.aspx.cs" Inherits="SIPT.WebInterno.FrmSolicitudCalifica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    }

    function ChangeTextA(obj) {
        if (document.getElementById('<%=fscAnalista.ClientID %>').checked == true ) {
            document.getElementById('<%=lblForAnalista.ClientID %>').innerHTML = 'Procede';
        }
        else {
            document.getElementById('<%=lblForAnalista.ClientID %>').innerHTML = 'No Procede';
        }
    }

    function ChangeTextC(obj) {
        if (document.getElementById('<%=fscCordinador.ClientID %>').checked == true) {
            document.getElementById('<%=lblForCoordinador.ClientID %>').innerHTML = 'Procede';
        }
        else {
            document.getElementById('<%=lblForCoordinador.ClientID %>').innerHTML = 'No Procede';
        }

    }


</script>
    <link href="assets/css/gridview.css" rel="stylesheet" />
    <nav class="navbar navbar-light bg-black">
        <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="text-white small" ></asp:Label>
    </nav>

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="table-responsive">

                            <asp:GridView runat="server" ID="gvSolicitud" class="table table-bordered table-condensed table-responsive table-hover font-weight-light" PageSize="5" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="INTCODSOLICITUD, SMLESTSOLLICENCIA" OnRowDataBound="gvSolicitud_RowDataBound" Width="100%" OnPageIndexChanging="gvSolicitud_PageIndexChanging">
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
                                            <asp:Button ID="btnCalifica" runat="server" Text="" OnClick="btnCalifica_Click" CssClass="btn btn-outline-success btn-sm" Visible="false"/>
                                            <%--<asp:Button ID="btnCalifica2" runat="server" Text=" 2da. Calificación " OnClick="btnCalifica_Click" CssClass="btn btn-outline-success btn-sm" Visible="false"/>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="VCHRESULTADO" HeaderText="Resultado"></asp:BoundField>

                                </Columns>
                                <PagerStyle HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    <div align="center">No hay registros para mostrar.</div>
                                </EmptyDataTemplate>

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
                        <div class="col-md-8">
                            <label for="txtDireccion" class="form-label-sm">Direccion</label>
                            <asp:TextBox ID="txtDireccion" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>


                        <div class="col-md-2">
                            <label for="txtEmail" class="form-label-sm">Correo</label>
                            <asp:TextBox ID="txtEmail" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-md-8">
                                <label for="gvUsos" class="form-label-sm">Usos</label>
                                <asp:GridView runat="server" ID="gvUsos" class="table table-bordered table-condensed table-hover table-responsive" PageSize="5" AutoGenerateColumns="False" Width="100%">
                                    <HeaderStyle CssClass="table-primary" />
                                    <Columns>
                                        <asp:BoundField DataField="VCHCODUSO" HeaderText="Código CIIU"></asp:BoundField>
                                        <asp:BoundField DataField="VCHNOMBREUSO" HeaderText="Giros"></asp:BoundField>
                                        <asp:BoundField DataField="SMLUSOPRINCIPAL" HeaderText="Principal"></asp:BoundField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" />
                                </asp:GridView>
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
                        <div class="col-8">
                            <label for="txtObservacion" class="form-label-sm">Observaciones</label>
                            <asp:TextBox ID="txtObservacion" Text="" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                           
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <br />
                            <asp:Label ID="lblTitAnalista" runat="server" Text="Calificación Analista"></asp:Label>
                            <br />
                            <div class="form-check form-switch">
                              <input class="form-check-input" type="checkbox" id="fscAnalista" runat="server" onchange="ChangeTextA(this);">
                              <label class="form-check-label" for="fscAnalista" id="lblForAnalista" runat="server">No Procede</label>
                            </div>
                            <br />
                        </div>
                        <div class="col">
                            <br />
                            <asp:Label ID="lblTitCordinador" runat="server" Text="Calificación Coordinador"></asp:Label>
                            <br />
                            <div class="form-check form-switch">
                              <input class="form-check-input" type="checkbox" id="fscCordinador" runat="server" onchange="ChangeTextC(this);">
                              <label class="form-check-label" for="fscCordinador" id="lblForCoordinador" runat="server">Procede</label>
                            </div>
                            <br />
                        </div>
                        <div class="col">
                        </div>
                    </div>

                        <div class="col-12">
                            <asp:Button ID="btnRegresar" runat="server" Text=" Regresar " CssClass="btn btn-primary" OnClick="btnRegresar_Click" />
                            <asp:Button ID="btnGuardar" runat="server" Text=" Guardar " CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                        </div>
                </div>
                <asp:HiddenField ID="hdfCodSolicitud" runat="server" />
                <asp:HiddenField ID="hdfSolLicEstado" runat="server" />
                <asp:HiddenField ID="hdfSolEmail" runat="server" />
                <asp:ValidationSummary ID="vsError" runat="server" 
                    HeaderText="No se puede realizar esta Operación:" 
                    ShowMessageBox="True" ShowSummary="False" ForeColor="#FF3300" />       
            </form>

        </asp:View>
    </asp:MultiView>




</asp:Content>
