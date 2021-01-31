<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.DocentesCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Width="1256px"> 
        <h2 style="font-family: calibri; text-align: left">Docentes de &quot;<span style="text-decoration: underline">La Academia</span>&quot;</h2>
      
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="#002b82"
        SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="#FFFFCC" style="font-family: calibri; background-color: #C4E1FF" AutoGenerateSelectButton="True" DataKeyNames="ID">   
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField HeaderText="ID Curso" DataField="IdCurso" />
            <asp:BoundField HeaderText="ID Docente" DataField="IdDocente" />
        </Columns>
        <RowStyle BorderStyle="Groove" ForeColor="Black" />
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>


</asp:Panel>


    <div>

    <asp:Panel ID="gridActionsPanel" runat="server" Width="448px"> 
        <div style="text-align: center; width: 363px">
            <asp:LinkButton ID="nuevoLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="nuevoLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Nuevo</asp:LinkButton>
            
            <asp:LinkButton ID="editarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" Font-Bold="False" ForeColor="White" Height="20px" OnClick="editarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Editar</asp:LinkButton>
            
            <asp:LinkButton ID="eliminarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" ForeColor="White" Height="20px" OnClick="eliminarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Eliminar</asp:LinkButton>
            
            <br />
        </div>
                    
    </asp:Panel>

    </div>

    <asp:Panel ID="formPanel" Visible="false" runat="server" Width="737px" Class="form">
        <div style="text-align: left; height: 354px;">
            <br />
            <asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label>
            &nbsp;<asp:TextBox ID="IDTextBox" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="IDTextBox" ErrorMessage="ID no puede estar vacío" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="ID Docente:"></asp:Label>
            &nbsp;<asp:DropDownList ID="idDocente" runat="server" DataSourceID="objectdocente" DataTextField="Apellido" DataValueField="ID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="objectdocente" runat="server" SelectMethod="GetDocente" TypeName="Data.Database.DocenteCursoAdapter"></asp:ObjectDataSource>

            <asp:Label ID="Label3" runat="server" Text="Curso:"></asp:Label>
            &nbsp;<asp:TextBox ID="CursoTextBox" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="CursoTextBox" ErrorMessage="El curso no puede estar vacío" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Cargo:"></asp:Label>&nbsp;<asp:DropDownList ID="ddlCargo" runat="server">
                <asp:ListItem>Auxiliar</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="cargoTextBox" runat="server" Width="150px"></asp:TextBox>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Height="90px" Width="437px" />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="aceptarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="cancelarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Cancelar</asp:LinkButton>

        </div>
        
    </asp:Panel>
    
</asp:Content>
