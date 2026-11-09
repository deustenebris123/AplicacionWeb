<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="PRUEBAasp1.Principal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Pagina Principal</title>
    <style>
        body { font-family: Segoe UI, Arial; background:#f0f2f5; text-align:center; margin:0; }
        .contenedor { max-width:600px; margin:80px auto; background:#fff; padding:40px; border-radius:12px;
                      box-shadow:0 2px 8px rgba(0,0,0,.15); }
        h1 { color:#333; margin-top:0; }
        p { color:#666; font-size:18px; line-height:1.6; }
        .enlace { display:inline-block; margin-top:20px; padding:12px 30px; background:#007bff;
                  color:#fff; text-decoration:none; border-radius:8px; font-weight:bold; }
        .enlace:hover { background:#0056b3; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <h1>Pagina Principal</h1>
            <p>Bienvenido a mi aplicacion web</p>
            <p>Esta es la pagina principal. Utiliza el menu para navegar a las diferentes secciones.</p>
            <asp:HyperLink ID="lnkMenu" runat="server" NavigateUrl="~/Default.aspx" CssClass="enlace">
                Volver al menu
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>
