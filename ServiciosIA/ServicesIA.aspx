<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServicesIA.aspx.cs" Inherits="ServiciosIA.ServicesIA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AnalisisFinancieroIA</title>
<link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="containertop">
            <div class ="header">
                Analisis Financiero
                <asp:Label ID="lblServicio" runat="server" CssClass="servicio" Text="" />
            </div>
            <div>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
