<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaOrdenes.aspx.cs" Inherits="WebForm.BusquedaOrdenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<label>Ingrese Nro Orden:</label>
	<asp:TextBox runat="server" ID="txtNro" TextMode="Number" OnTextChanged="BuscarOrden"></asp:TextBox>
	<asp:label Text="" runat="server" Visible="true" ForeColor="Red" ID="lblResultado"></asp:label>
	<asp:GridView ID="GVOrdenes" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
		<Columns>
			<asp:BoundField DataField="ID_Orden" HeaderText="ID" />
			<asp:TemplateField HeaderText="Cliente">
				<ItemTemplate>
					<%#Eval("OCliente.Nombre")%> <%#Eval("OCliente.Apellido")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Tecnico">
				<ItemTemplate>
					<%#Eval("OTecnico.Nombre")%> <%#Eval("OTecnico.Apellido")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
			<asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" />
			<asp:BoundField DataField="EstadoOrden" HeaderText="Estado" />
			<asp:TemplateField HeaderText="Comentarios">
				<ItemTemplate>
				<asp:Repeater ID="Repetidor" runat="server" DataSource='<%#Eval("Comentarios") %>'>
					<ItemTemplate>
						<%# Container.DataItem %> <br />
						<br />
					</ItemTemplate>
				</asp:Repeater>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
</asp:GridView>
</asp:Content>
