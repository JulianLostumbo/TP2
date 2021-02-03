<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Width="1256px"> 
        <strong>
        <h2 style="font-family: calibri; text-align: left">Cursos de &quot;<span style="text-decoration: underline">La Academia</span>&quot;</h2>
        </strong>
        </strong>
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="#002b82"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="#FFFFCC" style="font-family: calibri; background-color: #C4E1FF" AutoGenerateSelectButton="True">   
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID Curso" />
            <asp:BoundField HeaderText="ID Comisión" DataField="IdComision" />
            <asp:BoundField HeaderText="Descripción de Comisión" DataField="DescComision" />
            <asp:BoundField HeaderText="ID Materia" DataField="IdMateria" />
            <asp:BoundField HeaderText="Descripción de Materia" DataField="DescMateria" />
            <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario" />
            <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
        </Columns>
        <RowStyle BorderStyle="Groove" ForeColor="Black" />
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>


</asp:Panel>

                    <strong> 

    <div>

    <asp:Panel ID="gridActionsPanel" runat="server" Width="524px"> 
        <div style="width: 524px">
            <strong>
            <asp:LinkButton ID="imprimirLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="imprimirLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Imprimir</asp:LinkButton>
            </strong>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="nuevoLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Nuevo</asp:LinkButton>
            <strong>
            <asp:LinkButton ID="editarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" Font-Bold="False" ForeColor="White" Height="20px" OnClick="editarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Editar</asp:LinkButton>
            </strong>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" ForeColor="White" Height="20px" OnClick="eliminarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Eliminar</asp:LinkButton>
            <strong>
            <asp:LinkButton ID="notasLinkButton" runat="server" BackColor="#003399" BorderStyle="Ridge" BorderWidth="2px" ForeColor="White" Height="20px" OnClick="notasLinkButton_Click" style="text-decoration: none; color: #000000; font-family: Calibri; background-color: #FFFFFF" Width="80px">Notas</asp:LinkButton>
            <strong>
            <br />
            </strong>
            </strong>
        </div>
                    </strong>
</strong>
        </strong>
    </strong>
    </asp:Panel>

    </div>

    <asp:Panel ID="formPanel" Visible="false" runat="server" Width="737px" Class="form" Height="401px">
        <div style="text-align: left; height: 361px;">
            <br />
            </strong>
            </strong>
            <asp:Label ID="ID" runat="server" Text="ID: "></asp:Label>
            <strong>
            <asp:TextBox ID="IDTextBox" runat="server"></asp:TextBox>
            <br />
            </strong>
            <asp:Label ID="añoCalLbl" runat="server" Text="Año calendario: "></asp:Label>
            <strong>
            <asp:TextBox ID="añocalTxt" runat="server" CausesValidation="true" type="number" ValidationGroup="btnAceptar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="añocalTxt" ErrorMessage="El año calendario no puede estar vacío" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            </strong>
            <asp:Label ID="CupoLbl" runat="server" Text="Cupo: "></asp:Label>
            <strong>
            <asp:TextBox ID="CupoTxt" runat="server" CausesValidation="true" type="number" ValidationGroup="btnAceptar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CupoTxt" ErrorMessage="El cupo no puede estar vacío" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            </strong>
            <asp:Label ID="ComisionLbl" runat="server" Text="Comision: "></asp:Label>
            <strong>
            <asp:DropDownList ID="idComi" runat="server" DataSourceID="objectcomision" DataTextField="Descripcion" DataValueField="ID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="objectcomision" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.ComisionLogic"></asp:ObjectDataSource>
            </strong>
            <asp:Label ID="MateLbl" runat="server" Text="Materia: "></asp:Label>
            <strong>
            <asp:DropDownList ID="idMate" runat="server" DataSourceID="objectmateria" DataTextField="Descripcion" DataValueField="ID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="objectmateria" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.MateriaLogic"></asp:ObjectDataSource>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Height="106px" Width="437px" />
            <strong>
            <br />
            </strong></strong>
            <asp:LinkButton ID="aceptarLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="aceptarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" BorderStyle="Ridge" BorderWidth="2px" Height="20px" OnClick="cancelarLinkButton_Click" style="text-decoration: none; color: #000000; font-family: calibri; background-color: #FFFFFF" Width="80px">Cancelar</asp:LinkButton>

        </div>
        
    </asp:Panel>
    </strong></asp:Content>
