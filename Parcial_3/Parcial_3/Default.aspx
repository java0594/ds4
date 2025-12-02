<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial_3._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Preguntas y Respuestas</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 30px; }
        .container { max-width: 700px; margin: auto; }
        .labelRespuesta { display: block; margin-top: 20px; font-weight: bold; }
        select, button { font-size: 16px; padding: 5px; margin-top: 10px; width: 100%; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Preguntas y Respuestas</h2>

            <asp:DropDownList ID="DropDownListPreguntas" runat="server"></asp:DropDownList>

            <asp:Button ID="ButtonMostrar" runat="server" Text="Mostrar Respuesta" OnClick="ButtonMostrar_Click" />

            <asp:Label ID="LabelRespuesta" runat="server" Text="" CssClass="labelRespuesta"></asp:Label>
        </div>
    </form>
</body>
</html>
