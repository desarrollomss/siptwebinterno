<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebFormDemo.aspx.cs" Inherits="SIPT.WebInterno.WebFormDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<script>
    function okk($) {
        swal("Good job!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.", "success");
    }

    function mostrarMensaje() {
        $('#archivo_descargado_mensaje').show();
    }

    function UpdateTime(time) {
        document.getElementById("<%=lblTime.ClientID %>").innerHTML = time;
    }


</script>

    <div id="main-wrapper">
       
        <div class="page-wrapper">
            
            
            <div class="container-fluid">
                <asp:Button ID="btnUpdate" Text="Update Time" runat="server" OnClick="UpdateTime" />
                <asp:Label ID="lblTime" runat="server" />

                <asp:Button ID="btn_descargar_archivo" ClientIDMode="Static" runat="server" Text="Descargar Archivo" CssClass="btn btn-primary btn-block" onclick="btn_descargar_archivo_Click" />

                <a href="#" onclick="javascript:okk();">DEMO</a>
                <div class="row">
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">A basic message <small>(Click on image)</small> </h4>
                                <img src="assets/images/alert/alert.png" alt="alert" class="img-responsive model_img" id="sa-basic">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Title with a text under <small>(Click on image)</small></h4>
                                <img src="assets/images/alert/alert2.png" alt="alert" class="img-responsive model_img" id="sa-title">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Success Message <small>(Click on image)</small></h4>
                                <img src="assets/images/alert/alert3.png" alt="alert" class="img-responsive model_img" id="sa-success">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Warning message <small>(Click on image)</small></h4>
                                <img src="assets/images/alert/alert4.png" alt="alert" class="img-responsive model_img" id="sa-warning">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">A basic message <small>(Click on image)</small> </h4>
                                <img src="assets/images/alert/alert5.png" alt="alert" class="img-responsive model_img" id="sa-params">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Alert with Image <small>(Click on image)</small></h4>
                                <img src="assets/images/alert/alert7.png" alt="alert" class="img-responsive model_img" id="sa-image">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Alert with time <small>(Click on image)</small></h4>
                                <img src="assets/images/alert/alert6.png" alt="alert" class="img-responsive model_img" id="sa-close">
                            </div>
                        </div>
                    </div>
                </div>
               
            </div>
           
            <footer class="footer">
                © 2017 Admin Pro by wrappixel.com
            </footer>
            
        </div>
       
    </div>

</asp:Content>
