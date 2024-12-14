<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmMatrizEvaluacion.aspx.cs" Inherits="SIPT.WebInterno.FrmMatrizEvaluacion" %>

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
            console.log(div.style.display);
        }

    </script>

    <div class="row page-titles w-100">
        <div class="col-md-5 align-self-center" style="padding-left:40px">
            <h3 class="text-themecolor">Matriz de Evaluación</h3>
        </div>
        <div class="col-md-7 align-self-center">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">ITSE</a></li>
                <li class="breadcrumb-item active">Matriz de Evaluación</li>
            </ol>
        </div>
    </div>

    <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="View1" runat="server">
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  
                <div class="card">
                    <div class="card-header">
                        <span>Filtros de Búsqueda</span>
                    </div>
                    <div class="card-body">
                        
                        <div class="row">                                                    

                            <div class="col-md-3">                                
                                <asp:TextBox ID="txtDireccion" Text="" runat="server" class="form-control" placeholder="Predio / dirección"></asp:TextBox>                                
                            </div>                            

                            <div class="col-md-9"><asp:Button ID="btnBusDireccion" runat="server" Text=">" CssClass="btn btn-dark btn-rounded" OnClick="btnBusDireccion_Click"/>
                                <asp:DropDownList ID="ddlDireccion" runat="server" CssClass="select2 form-control custom-select" Width="90%"></asp:DropDownList>
                            </div>


                        </div>

                        <div class="row">                                                    

                            <div class="col-md-4">
                                <label for="ddlEstructura" class="form-label-sm">Area tratamiento normativo</label><br />
                                <asp:DropDownList ID="ddlEstructura" runat="server" CssClass="select2 form-control custom-select" Width="75%" OnSelectedIndexChanged="ddlEstructura_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                <asp:Literal ID="litClaves" runat="server"></asp:Literal>         
                            </div>
                            
                            <div class="col-md-1">
                                <label for="txtCodUso" class="form-label-sm">Cod.Uso</label><br />
                                <asp:TextBox ID="txtCodUso" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-3">
                                <label for="txtUso" class="form-label-sm">Uso</label><br />
                                <asp:TextBox ID="txtUso" Text="" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-1"><span>&nbsp;</span></div>
                            
                            <div class="col-md-1"><br />
                                <asp:Button ID="btnLimpiar" runat="server" Text=" Limpiar " CssClass="btn btn-dark btn-rounded"/>
                            </div>

                            <div class="col-md-1"><br />
                                <asp:Button ID="btnBuscar" runat="server" Text=" Buscar " CssClass="btn btn-info btn-rounded" OnClick="btnBuscar_Click"/>
                            </div>

                        </div>
                                                    
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <span>Lista de Usos y Zonificación</span>                        
                    </div>
                    <div class="card-body">                                
                        <div class="table-responsive">

                    <asp:GridView runat="server" ID="gvBusqueda" class="table" PageSize="15" AllowPaging="True" Width="100%" OnPageIndexChanging="gvBusqueda_PageIndexChanging" >
                        <EmptyDataTemplate>
                            <div align="center">No hay registros para mostrar.</div>
                        </EmptyDataTemplate>
                    </asp:GridView>

                        </div>
                    </div>
                </div>
                
            </div>
        
        </asp:View>

    </asp:MultiView>

</asp:Content>
