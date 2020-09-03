<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Width="1256px"> 
        <h2 style="font-family: calibri; text-align: left">Usuarios de &quot;<span style="text-decoration: underline">La Academia</span>&quot;</h2>
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="#002b82"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="#FFFFCC" style="font-family: calibri; background-color: #C4E1FF">   
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
        <RowStyle BorderStyle="Groove" ForeColor="Black" />
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>

</asp:Panel>

    <div>

    <asp:Panel ID="gridActionsPanel" runat="server" Width="448px"> 
        <div style="text-align: center; width: 363px">
            <asp:LinkButton ID="imprimirLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="imprimirLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Imprimir</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="nuevoLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Nuevo</asp:LinkButton>
            <strong>
            <asp:LinkButton ID="editarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" Font-Bold="False" ForeColor="White" Height="20px" OnClick="editarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Editar</asp:LinkButton>
            </strong>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" ForeColor="White" Height="20px" OnClick="eliminarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Eliminar</asp:LinkButton>
        </div>
    </asp:Panel>

    </div>

    <asp:Panel ID="formPanel" Visible="false" runat="server" Width="737px" Class="form">
        <div style="text-align: left">
            <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacío" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar vacío" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email no puede estar vacío" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Email ingresado inválido" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate" ValidateEmptyText="True" ValidationGroup="vg">Email ingresado inválido</asp:CustomValidator>
            <asp:Label ID="lblErrorEmail" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
            <br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar vacío" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave debe tener 8 o más caracteres" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" ValidationGroup="vg">La clave debe tener 8 o más caracteres</asp:CustomValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave no puede estar vacía" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="lblErrorClave" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ErrorMessage="Las claves no coinciden" ForeColor="Red"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="repetirClaveTextBox" ErrorMessage="La clave de confirmación no puede estar vacía" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>
        <asp:Panel ID="formActionsPanel" runat="server" Width="449px">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" BorderStyle="Ridge" BorderWidth="2px" Height="20px" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" BorderStyle="Ridge" BorderWidth="2px" Height="20px" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Cancelar</asp:LinkButton>
            <div style="text-align: left">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Height="45px" ValidationGroup="vg" Width="437px" />
            </div>
    </asp:Panel>
    </asp:Panel>

    

</asp:Content>


