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
    <link href="assets/css/gridview.css" rel="stylesheet" />
    <nav class="navbar navbar-light bg-black">
        <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="text-white small" ></asp:Label>
    </nav>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="table-responsive"> 
                    
                    <asp:GridView runat="server" ID="gvSolicitud" class="table table-bordered table-condensed table-responsive table-hover" PageSize="5" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="INTCODSOLICITUD" OnRowDataBound="gvSolicitud_RowDataBound" Width="100%" OnPageIndexChanging="gvSolicitud_PageIndexChanging">
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


                            <asp:TemplateField HeaderText="Analista">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlAnalista" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnalista_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblCodSolicitud" runat="server" Text='<%# Eval("INTCODSOLICITUD") %>' Visible="false" />
                                    <i class="bi bi-info-circle" onclick="javascript:expandcollapse('div<%# Eval("INTCODSOLICITUD") %>', 'one');"></i>
                                </ItemTemplate>
                            </asp:TemplateField>
<%--                            <asp:TemplateField>
                                <ItemTemplate>
                                    <i class="bi bi-info-square"></i>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

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

<%--<asp:DropDownList ID="ddlPrueba" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPrueba_SelectedIndexChanged">
    </asp:DropDownList>--%>

</asp:Content>
