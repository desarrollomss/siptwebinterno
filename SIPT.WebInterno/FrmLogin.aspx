<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="SIPT.WebInterno.FrmLogin" %>

<!DOCTYPE html>
<html>
<head>
	<title>Login V18</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="assets/login/util.css">
	<link rel="stylesheet" type="text/css" href="assets/login/main.css">
	<link href="Content/bootstrap.min.css" rel="stylesheet"/>
	<link href="assets/css/sweetalert.css" rel="stylesheet" />
	<script src="Scripts/sweetalert.min.js"></script>
</head>
<body style="background-color: #666666;">

	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<form id="form1" runat="server" class="login100-form">
					<span class="login100-form-title p-b-43">
						<a href="javascript:void(0)" class="text-center db"><img src="assets/images/logo-icon2.png" alt="Home" /><br/><img src="assets/images/logo-text.png" alt="Home" /></a>
					</span>


					<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
						
						<asp:TextBox ID="txtUsuario" runat="server" class="input100" required="" autocomplete="off"></asp:TextBox>
						<span class="focus-input100"></span>
						<span class="label-input100">Usuario</span>
					</div>


					<div class="wrap-input100 validate-input" data-validate="Password is required">
						
						<asp:TextBox ID="txtPassword" runat="server" class="input100" TextMode="Password" required="" autocomplete="off"></asp:TextBox>
						<span class="focus-input100"></span>
						<span class="label-input100">Password</span>
					</div>

					<div class="flex-sb-m w-full p-t-3 p-b-32">
						<div class="contact100-form-checkbox">
							<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
							<label class="label-checkbox100" for="ckb1">
								Remember me
							</label>
						</div>

						<div>
							<a href="#" class="txt1">
								Forgot Password?
							</a>
						</div>
					</div>


					<div class="container-login100-form-btn">
						

					    <asp:Button ID="btnLogear" runat="server" Text="INGRESAR" class="login100-form-btn" OnClick="btnLogear_Click" />
						

					</div>

					<div class="text-center p-t-46 p-b-20">
						<span class="txt2">
							
						</span>
					</div>

					<div class="login100-form-social flex-c-m">
						<a href="#" class="login100-form-social-item flex-c-m bg1 m-r-5">
							<i class="fa fa-facebook-f" aria-hidden="true"></i>
						</a>

						<a href="#" class="login100-form-social-item flex-c-m bg2 m-r-5">
							<i class="fa fa-twitter" aria-hidden="true"></i>
						</a>
					</div>
				</form>

				<div class="login100-more" style="background-image: url('assets/images/bg-01.jpg');">
				</div>
			</div>
		</div>
	</div>
	<script src="assets/login/jquery-3.2.1.min.js"></script>
	<script src="assets/login/main.js"></script>

</body>
</html>
