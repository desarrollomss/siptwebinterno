<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="FrmSolicitudAsigna.aspx.cs" Inherits="SIPT.WebInterno.FrmSolicitudAsigna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.1/css/all.css" crossorigin="anonymous">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">    

<script type="text/javascript" language="javascript">

    function expandcollapse(obj, row) {
        var div = document.getElementById(obj);
        //var img = document.getElementById('img' + obj);

        if (div.style.display == "none") {
            div.style.display = "block";
        }
        else {
            div.style.display = "none";
        }
    }

</script>
    
    <div class="row page-titles w-100">
        <div class="col-md-5 align-self-center" style="padding-left:40px">
            <h3 class="text-themecolor">Asignar de solicitudes</h3>
        </div>
        <div class="col-md-7 align-self-center">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">Licencias</a></li>
                <li class="breadcrumb-item active">Asignar Solicitud a Analista</li>
            </ol>
        </div>
    </div>

    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="card-header">
                        <span>Lista de Solicitudes a acreditar</span>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                    
                    <asp:GridView runat="server" ID="gvSolicitud" class="table" PageSize="5" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="INTCODSOLICITUD" Width="100%" OnPageIndexChanging="gvSolicitud_PageIndexChanging" OnRowDataBound="gvSolicitud_RowDataBound">
                    <HeaderStyle CssClass="" />
                        <Columns>
                            <asp:BoundField DataField="INTCODSOLICITUD" HeaderText="Id"></asp:BoundField>
                            <asp:BoundField DataField="VCHANIONUMERO" HeaderText="Solicitud"></asp:BoundField>
                            <asp:BoundField DataField="VCHADMCOMPLETO" HeaderText="Administrado"></asp:BoundField>
                            <asp:BoundField DataField="VCHPREDIRECCION" HeaderText="Ubicación"></asp:BoundField>
                            <asp:BoundField DataField="DECAREAOCUPAR" HeaderText="Area Ocupar"></asp:BoundField>
                            <asp:TemplateField HeaderText="Id.Analista">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodAnalista" runat="server" Text ='<%# Eval("INTUSUANALISTA") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Est.Solicitud">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstSolLic" runat="server" Text='<%# Eval("SMLESTSOLLICENCIA") %>' Visible="false" />
                                    <asp:Label ID="lblEstSolLicTxt" runat="server" Text='<%# Eval("VCHESTSOLLICENCIA") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="DECAREAOCUPAR" HeaderText="Area Ocupar"></asp:BoundField>
                            <asp:BoundField DataField="VCHNOMBREANALISTA" HeaderText="Analista"></asp:BoundField>
                           
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
                                                <asp:GridView runat="server" ID="gvUsos" class="table table-bordered table-condensed table-responsive table-hover" PageSize="5" AutoGenerateColumns="False" Width="100%">
                                                    <HeaderStyle CssClass="" />
                                                    <Columns>
                                                        <asp:BoundField DataField="VCHCODUSO" HeaderText="Código CIIU"></asp:BoundField>
                                                        <asp:BoundField DataField="VCHNOMBREUSO" HeaderText="Giros"></asp:BoundField>
                                                        <asp:BoundField DataField="SMLUSOPRINCIPAL" HeaderText="Principal"></asp:BoundField>
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


</asp:Content>
