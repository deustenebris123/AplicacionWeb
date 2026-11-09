<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscaminas.aspx.cs" Inherits="PRUEBAasp1.Buscaminas" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Buscaminas</title>
    <style>
        body { font-family: Segoe UI, Arial; background:#f0f2f5; text-align:center; }
        .tablero { display:inline-block; background:#fff; padding:15px; border-radius:12px;
                   box-shadow:0 2px 8px rgba(0,0,0,.15); }
        .fila { white-space:nowrap; }
        .celda { width:42px; height:42px; font-size:18px; font-weight:bold; margin:1px;
                 border:1px solid #888; background:#cfd8dc; cursor:pointer; }
        .abierta { background:#fff; cursor:default; }
        .mina { background:#ef5350; }
        .n1 { color:#1976d2; } .n2 { color:#388e3c; } .n3 { color:#d32f2f; }
        .n4 { color:#512da8; } .n5 { color:#8d6e63; } .n6 { color:#00838f; }
        .mensaje { font-size:22px; font-weight:bold; margin:15px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Buscaminas</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
        <p>
            <asp:CheckBox ID="chkBandera" runat="server" Text="Modo bandera" />
            &nbsp;|&nbsp;
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </p>
        <div class="tablero">
            <asp:PlaceHolder ID="phTablero" runat="server"></asp:PlaceHolder>
        </div>
        <p>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo juego" OnClick="btnNuevo_Click" />
            <asp:HyperLink ID="lnkInicio" runat="server" NavigateUrl="~/Default.aspx">Volver al inicio</asp:HyperLink>
        </p>
    </form>
</body>
</html>
