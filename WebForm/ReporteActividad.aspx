<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteActividad.aspx.cs" Inherits="WebForm.ReporteActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<!--
		Mostrar:
			1. Tecnico y cantidad de ordenes en cada estado
			2. Mostar listado ordenes que estan como completada
		-->
	<h3>Reporte de Actividad</h3>
	<label style="font-size: 20px">Seleccione al tecnico</label><br />
	<br />
	<label>Tecnico: </label>
	<asp:DropDownList runat="server" ID="ddlTecnicos" OnSelectedIndexChanged="MostrarCantidad" AutoPostBack="true">
		<asp:ListItem Text="Seleccionar técnico" Value="" Selected="True"></asp:ListItem>
	</asp:DropDownList><br />
	<br />
	<asp:Table runat="server" CssClass="table table-bordered">
		<asp:TableRow>
			<asp:TableHeaderCell runat="server" Text="Pendiente"></asp:TableHeaderCell>
			<asp:TableHeaderCell runat="server" Text="En Progreso"></asp:TableHeaderCell>
			<asp:TableHeaderCell runat="server" Text="Completada"></asp:TableHeaderCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell runat="server" Text="-" ID="tcPendiente"></asp:TableCell>
			<asp:TableCell runat="server" Text="-" ID="tcProgreso"></asp:TableCell>
			<asp:TableCell runat="server" Text="-" ID="tcCompletada"></asp:TableCell>
		</asp:TableRow>
	</asp:Table>
	<hr />
	<h3>Ordenes completadas ultimo mes: </h3>
	<asp:GridView ID="GVOrdenes" runat="server" CssClass="table table-bordered mt-3" AutoGenerateColumns="false">
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
							<%# Container.DataItem %>
							<br />
							<br />
						</ItemTemplate>
					</asp:Repeater>
				</ItemTemplate>
			</asp:TemplateField>

		</Columns>
	</asp:GridView>
	<br />
</asp:Content>
