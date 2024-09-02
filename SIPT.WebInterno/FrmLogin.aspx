<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="SIPT.WebInterno.FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="canonical" href="https://getbootstrap.com/docs/4.6/examples/sign-in/"/>

        <!-- Bootstrap core CSS -->
        <link href="Content/bootstrap.min.css" rel="stylesheet"/>
        <link href="assets/css/sweetalert.css" rel="stylesheet" />
        <script src="Scripts/sweetalert.min.js"></script>
        <style>
          .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
          }

          @media (min-width: 768px) {
            .bd-placeholder-img-lg {
              font-size: 3.5rem;
            }
          }
        </style>
    <!-- Custom styles for this template -->
    <link href="assets/css/signin.css" rel="stylesheet"/>
    <script serc="https://code.jquery.com/jquery-3.1.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</head>
<body class="text-center">
    <form id="form1" runat="server" class="form-signin">
        <img class="mb-4" src="assets/images/usuario_avatar.png" alt="" width="100" height="100">
        <h1 class="h3 mb-3 font-weight-normal">Login</h1>
        <label for="txtUsuario" class="sr-only">Usuario</label>
        <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario" required autofocus></asp:TextBox>
        <label for="txtPassword" class="sr-only">Password</label>
        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" required TextMode="Password"></asp:TextBox>
        <div class="checkbox mb-3">
            <label>
                <input type="checkbox" value="remember-me">
                Recordarme
            </label>
        </div>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-lg btn-primary btn-block" OnClick="btnIngresar_Click" />
        <p class="mt-5 mb-3 text-muted">
            <asp:Label ID="lblDerechos" runat="server"></asp:Label><br />
            <asp:Label ID="lblCompany" runat="server"></asp:Label>
        </p>

    </form>
</body>
</html>
