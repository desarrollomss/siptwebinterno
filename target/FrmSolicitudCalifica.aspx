<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="FrmSolicitudCalifica.aspx.cs" Inherits="SIPT.WebInterno.FrmSolicitudCalifica" %>
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

    function ChangeTextA(obj) {
        if (document.getElementById('<%=fscAnalista.ClientID %>').checked == true) {
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
    <div class="row page-titles w-100">
        <div class="col-md-5 align-self-center" style="padding-left:40px">
            <h3 class="text-themecolor">Calificar Consultas de Zonificación</h3>
        </div>
        <div class="col-md-7 align-self-center">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">Licencias</a></li>
                <li class="breadcrumb-item active">Calificar Consultas de Zonificación</li>
            </ol>
        </div>
    </div>
    
    <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="View1" runat="server">
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        
                <div class="card">
                    <div class="card-header">
                        <span>Lista de Solicitudes a Calificar</span>
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
                                    <asp:Button ID="btnCalifica" runat="server" Text="" OnClick="btnCalifica_Click" CssClass="btn waves-effect waves-light btn-warning" Visible="false"/>
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

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="card">
                    <div class="card-header">
                        <span>Solicitud</span>
                    </div>
                    <div class="card-body">
                
                    <div class="row">
                        <div class="col-md-1">
                            <label for="txtCodSolicitud" class="form-label-sm">Id.Solicitud</label>
                            <asp:TextBox ID="txtCodSolicitud" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <label for="txtNumSolicitud" class="form-label-sm">Nro.Solicitud</label>
                            <asp:TextBox ID="txtNumSolicitud" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>

                        <div class="col-md-6">
                            <label for="txtAdministrado" class="form-label-sm">Administrado</label>
                            <asp:TextBox ID="txtAdministrado" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <label for="txtCondicion" class="form-label-sm">Condicion</label>
                            <asp:TextBox ID="txtCondicion" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-1">
                            <label for="txtAreaOcupa" class="form-label-sm">Area</label>
                            <asp:TextBox ID="txtAreaOcupa" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-7">
                            <label for="txtDireccion" class="form-label-sm">Direccion</label>
                            <asp:TextBox ID="txtDireccion" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>


                        <div class="col-md-4">
                            <label for="txtEmail" class="form-label-sm">Correo</label>
                            <asp:TextBox ID="txtEmail" Text="" runat="server" class="form-control"></asp:TextBox>
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-md-8">
                                <br />
                                <asp:GridView runat="server" ID="gvUsos" class="table" Width="100%" PageSize="5" AutoGenerateColumns="False" HorizontalAlign="Center">
                                    <HeaderStyle Width="100%" />
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

                            <div class="form-group">
                                <h5>Observaciones <span class="text-danger">*</span></h5>
                                <div class="controls">
                                    <asp:TextBox ID="txtObservacion" Text="" runat="server" class="form-control" TextMode="MultiLine"
                                    required data-validation-required-message="El campo es obligatorio"></asp:TextBox>
                                </div>                                
                            </div>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="lblTitAnalista" runat="server" Text="Calificación Analista"></asp:Label>
                            <br />
                            <div class="form-check form-switch">                              
                                <input type="checkbox" id="fscAnalista" runat="server" class="js-switch" data-color="#26c6da" data-secondary-color="#f62d51" onchange="ChangeTextA(this);"/>
                              <label class="form-check-label" for="fscAnalista" id="lblForAnalista" runat="server">No Procede</label>
                            </div>
                            <br />
                        </div>
                        <div class="col">
                            <asp:Label ID="lblTitCordinador" runat="server" Text="Calificación Coordinador"></asp:Label>
                            <br />
                            <div class="form-check form-switch">
                              <input type="checkbox" id="fscCordinador" runat="server" class="js-switch" data-color="#26c6da" data-secondary-color="#f62d51" onchange="ChangeTextC(this);">
                              <label class="form-check-label" for="fscCordinador" id="lblForCoordinador" runat="server">No Procede</label>
                            </div>
                            <br />
                        </div>
                        <div class="col">
                        </div>
                    </div>
                        
                    <div class="card-footer" style="background-color:white">
                        <asp:LinkButton ID="btnRegresar" runat="server" type="reset" CssClass="btn btn-inverse btn-rounded" OnClick="btnRegresar_Click"><i class="fa fa-chevron-left"></i>&nbsp;&nbsp;Regresar</asp:LinkButton>
                        <div class="btn btn-info btn-rounded" style="cursor:pointer" onclick="<%=btnConfirmar.ClientID %>.click()">
                            <i class="fa fa-check"></i>                                
                            <asp:Button type="submit" ID="btnConfirmar" runat="server" Text=" Guardar " ClientIDMode="Static" CssClass="btnHidden" OnClick="btnConfirmar_Click" />           
                        </div>
                        <asp:Button ID="btnGuardar" runat="server" Text="" CssClass="btnHidden" OnClick="btnGuardar_Click"/>
                        <asp:HiddenField ID="hdfCodSolicitud" runat="server" />
                        <asp:HiddenField ID="hdfSolLicEstado" runat="server" />
                        <asp:HiddenField ID="hdfSolEmail" runat="server" />
                        <asp:ValidationSummary ID="vsError" runat="server" 
                            HeaderText="No se puede realizar esta Operación:" 
                            ShowMessageBox="True" ShowSummary="False" ForeColor="#FF3300" />       
                    </div>
                
                                </div>
                        </div>
                    </div>
           

        </asp:View>
    </asp:MultiView>

</asp:Content>
