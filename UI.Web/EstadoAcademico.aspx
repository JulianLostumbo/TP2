<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Width="1256px" Height="180px" style="margin-bottom: 0px" OnLoad="gridPanel_Load"> 
        <h2 style="font-family: calibri; text-align: left">
            <asp:Label ID="lbl" runat="server" Text="Estado Académico del Alumno"></asp:Label>
        </h2>
        </strong>
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="#002b82"
        SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="#FFFFCC" style="font-family: calibri; background-color: #C4E1FF" DataKeyNames="ID">   
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID Inscripción" />
            <asp:BoundField DataField="IdCurso" HeaderText="ID Curso" />
            <asp:BoundField HeaderText="Comisión" DataField="DescComision" />
            <asp:BoundField HeaderText="Materia" DataField="DescMateria" />
            <asp:BoundField DataField="nota" HeaderText="Nota" />
            <asp:BoundField DataField="Condicion" HeaderText="Condición" />
        </Columns>
        <RowStyle BorderStyle="Groove" ForeColor="Black" />
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>   

</asp:Panel>

                    </asp:Content>
