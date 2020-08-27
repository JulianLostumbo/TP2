<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" Theme="Azul" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .nuevoEstilo1 {
            font-size: large;
            font-family: Calibri;
        }
        .nuevoEstilo2 {
            font-family: calibri;
        }
        .nuevoEstilo3 {
            font-family: calibri;
        }
        .nuevoEstilo4 {
            font-family: calibri;
        }
        .auto-style2 {
            width: 164px;
        }
        .auto-style3 {
            text-align: right;
            width: 164px;
            height: 46px;
        }
        .auto-style7 {
            width: 953px;
        }
        .auto-style10 {
            width: 164px;
            height: 46px;
        }
        .auto-style15 {
            width: 953px;
            height: 46px;
        }
        .nuevoEstilo5 {
            font-family: calibri;
        }
        .auto-style16 {
            width: 184px;
            height: 46px;
        }
        .auto-style17 {
            width: 184px;
        }
        .auto-style18 {
            text-align: right;
            width: 184px;
            height: 46px;
        }
        .nuevoEstilo6 {
            font-family: calibri;
        }
        .auto-style19 {
            font-family: calibri;
            font-size: xx-large;
        }
        .auto-style20 {
            height: 46px;
            text-align: center;
        }
        .nuevoEstilo7 {
            background-color: #99CCFF;
        }
        .nuevoEstilo8 {
            background-color: #CCFFFF;
        }
        .nuevoEstilo9 {
            background-color: #CCFFFF;
        }
        .nuevoEstilo10 {
            background-color: #FFFFCC;
        }
        .nuevoEstilo11 {
            background-color: #FFFFCC;
        }
    </style>
</head>
<body style="width: 903px">
    <form id="form1" runat="server" class="nuevoEstilo8">
        <div class="nuevoEstilo10">
        </div>
        <table class="nuevoEstilo11">
            <tr>
                <td class="auto-style20" colspan="3">
                    <strong>
        <asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenido a la Academia!" CssClass="auto-style19"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style18">
                    <span class="nuevoEstilo2">Nombre de Usuario</span></td>
                <td class="auto-style15">
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style18">
                    <span class="nuevoEstilo5">Contraseña</span></td>
                <td class="auto-style15">
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style16"></td>
                <td class="auto-style15">
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="nuevoEstilo2" Font-Bold="False" BackColor="#0033CC" Font-Size="Large" ForeColor="White" Height="29px" Width="70px" /> 
                </td>
            </tr>
            <tr>
                <td class="auto-style10"> 
        <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click"></asp:LinkButton> 
                </td>
                <td class="auto-style16"></td>
                <td class="auto-style15"></td>
            </tr>
        </table>
    </form>
</body>
</html>
