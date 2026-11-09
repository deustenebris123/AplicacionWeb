<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRUEBAasp1._Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Pagina principal</title>
    <style>
        body { font-family: Segoe UI, Arial; background:#f0f2f5; text-align:center; margin:0; }
        h1 { margin-top:60px; color:#333; }
        .menu { display:flex; justify-content:center; gap:30px; margin-top:50px; }
        .tarjeta { background:#fff; width:220px; padding:30px; border-radius:12px;
                   box-shadow:0 2px 8px rgba(0,0,0,.15); text-decoration:none; color:#333; }
        .tarjeta:hover { background:#e8f0fe; }
        .icono { font-size:60px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Bienvenido a mi sitio web</h1>
        <p>Elige una opcion:</p>
        <div class="menu">
            <asp:HyperLink ID="lnkPrincipal" runat="server" NavigateUrl="~/Principal.aspx" CssClass="tarjeta">
                <div class="icono"></div><h2>Principal</h2>
            </asp:HyperLink>
            <asp:HyperLink ID="lnkCalculadora" runat="server" NavigateUrl="~/Calculadora.aspx" CssClass="tarjeta">
                <div class="icono"></div><h2>Calculadora</h2>
            </asp:HyperLink>
            <asp:HyperLink ID="lnkJuego" runat="server" NavigateUrl="~/Buscaminas.aspx" CssClass="tarjeta">
                <div class="icono"></div><h2>Buscaminas</h2>
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>
