<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Width="1256px"> 
        <h2 style="font-family: calibri; text-align: left">Comisiones de &quot;<span style="text-decoration: underline">La Academia</span>&quot;</h2>
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="#002b82"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="#FFFFCC" style="font-family: calibri; background-color: #C4E1FF">   
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID Comision" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Año de Especialidad" DataField="AnioEspecialidad" />
            <asp:BoundField DataField="IdPlan" HeaderText="ID Plan" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
        <RowStyle BorderStyle="Groove" ForeColor="Black" />
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>

</asp:Panel>

    <div>

    <asp:Panel ID="gridActionsPanel" runat="server" Width="448px"> 
        <div style="text-align: center; width: 363px">
            <asp:LinkButton ID="nuevoLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="nuevoLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Nuevo</asp:LinkButton>
            <strong>
            <asp:LinkButton ID="editarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" Font-Bold="False" ForeColor="White" Height="20px" OnClick="editarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Editar</asp:LinkButton>
            </strong>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" ForeColor="White" Height="20px" OnClick="eliminarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Eliminar</asp:LinkButton>
        </div>
    </asp:Panel>

    </div>

    <asp:Panel ID="formPanel" Visible="false" runat="server" Width="737px" Class="form">
        <div style="text-align: left; height: 85px;">
            <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server" Height="16px" Width="363px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripción no puede estar vacía" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Año de Especialidad: "></asp:Label>
            <asp:TextBox ID="anioEspecialidadTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="anioEspecialidadTextBox" ErrorMessage="El año de especialidad no puede estar vacío" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="idPlanLabel" runat="server" Text="ID Plan: "></asp:Label>
            <asp:TextBox ID="idPlanTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="idPlanTextBox" ErrorMessage="El ID plan no puede estar vacío" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
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
