<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Width="1256px" Height="314px" style="margin-bottom: 0px" OnLoad="gridPanel_Load"> 
        <h2 style="font-family: calibri; text-align: left">Inscribirse a un Curso</h2>
        </strong>
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="#002b82"
        SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="#FFFFCC" style="font-family: calibri; background-color: #C4E1FF" AutoGenerateSelectButton="True" DataKeyNames="ID">   
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID Curso" />
            <asp:BoundField HeaderText="Comisión" DataField="DescComision" />
            <asp:BoundField HeaderText="Materia" DataField="DescMateria" />
            <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" />
            <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
        </Columns>
        <RowStyle BorderStyle="Groove" ForeColor="Black" />
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>   

</asp:Panel>

                    <strong> 

    <asp:Panel ID="gridActionsPanel" runat="server" Width="511px" Height="120px"> 
        <div style="width: 498px; height: 88px;">
             <br />
            <asp:Button ID="ButtonInsc" runat="server" Text="INSCRIBIRSE" BorderStyle="Ridge" style="font-weight: bold; font-family: Calibri; font-size: large; color: #FFFFFF; background-color: #003366" OnClick="ButtonInsc_Click" />
            <br />
             </strong>
             <br />
             <asp:Label ID="LabelError" runat="server" style="font-family: CALibri; color: #FF0000; background-color: #FFFFFF" Text="Error! Usted no es alumno de &quot;La Academia&quot;"></asp:Label>
             <strong>
             <br />
             </strong>
        </div>
    </asp:Panel>

                    </strong>
            
</asp:Content>

