<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Login</title>
    <!-- Referencia a Bootstrap (solo CSS) -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="col-md-4 mx-auto">
                <h3 class="text-center mb-4">Login</h3>
                <!-- Usuario -->
                <div class="mb-3">
                    <label for="txtUsername" class="form-label">Usuario</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                </div>
                <!-- Contraseña -->
                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                </div>
                <!-- Botón Login -->
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
                <!-- Mensaje de error -->
                <asp:Label ID="lblError" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
