<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" Theme="Azul" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        :root {
	/* COLORS */
	--white: #e9e9e9;
	--gray: #333;
	--blue: #0367a6;
	--lightblue: #008997;

	/* RADII */
	--button-radius: 0.7rem;

	/* SIZES */
	--max-width: 758px;
	--max-height: 420px;

	font-size: 16px;
	font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
		Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
}
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
        .auto-style3 {
            text-align: right;
            width: 639px;
            height: 46px;
            background-color: #C4E1FF;
        }
        .auto-style10 {
            width: 639px;
            height: 46px;
        }
        .auto-style15 {
            width: 982px;
            height: 46px;
        }
        .nuevoEstilo5 {
            font-family: calibri;
        }
        .nuevoEstilo6 {
            font-family: calibri;
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
        .btn {
    background-color: var(--blue);
    background-image: linear-gradient(90deg, var(--blue) 0%, var(--lightblue) 74%);
    border-radius: 20px;
    border: 1px solid var(--blue);
    color: var(--white);
    cursor: pointer;
    font-size: large;
    font-weight: bold;
    letter-spacing: 0.1rem;
    padding: 0.9rem 4rem;
    text-transform: uppercase;
    transition: transform 80ms ease-in;
        }
       .form__title {
    font-size:xx-large;
	font-weight: bold;
	margin: 0;
	margin-bottom: 1.25rem;
        }

        .auto-style21 {
            width: 639px;
            height: 46px;
            background-color: #C4E1FF;
        }
        .auto-style22 {
            width: 982px;
            height: 46px;
            background-color: #C4E1FF;
        }
        .auto-style23 {
            background-color: #C4E1FF;
        }
        .auto-style25 {
            font-family: calibri;
            background-color: #C4E1FF;
        }
        .auto-style26 {
            font-size: xx-large;
            font-weight: bold;
            margin-bottom: 1.25rem;
            margin-left: 0;
            margin-right: 0;
            margin-top: 0;
            background-color: #C4E1FF;
            text-align: center;
            font-family: calibri;
        }

        .auto-style27 {
            font-family: calibri;
            background-color: #C4E1FF;
            font-size: 16pt;
            text-align: center;
        }

    </style>
</head>
<body style="width: 992px">
    <form id="form1" runat="server" class="auto-style23">
        <div class="auto-style23">
             <h2 class="auto-style26">¡Bienvenido a la Academia!</h2>
        </div>
        <table class="auto-style23">
            
            <tr>
                <td class="auto-style27" colspan="2">Por favor, digite su información de ingreso:</td>
                <td class="auto-style27" rowspan="5">
                    <asp:Image ID="Image1" runat="server" Height="247px" ImageUrl="~/Images/login.png" Width="232px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <span class="auto-style25">Nombre de Usuario</span></td>
                <td class="auto-style22">
        <asp:TextBox ID="txtUsuario" runat="server" Width="206px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <span class="auto-style25">Contraseña</span></td>
                <td class="auto-style22">
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="206px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style15">
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn"  />                 

                </td>
            </tr>
            <tr>
                <td class="auto-style10"> 
        <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click" CssClass="auto-style23"></asp:LinkButton> 
                </td>
                <td class="auto-style15"></td>
            </tr>
        </table>
    </form>
</body>
</html>
