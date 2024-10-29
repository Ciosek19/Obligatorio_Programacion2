<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="WebForm.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Ordenes:</h1>
	<div class="row">
		<div class="col-12"></div>
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
				<asp:TemplateField HeaderText="Estado">
					<ItemTemplate>
						<%#Eval("EstadoOrden") %>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField>
					<ItemTemplate>
						<asp:LinkButton runat="server"
							CssClass="btn btn-sm btn-primary">
						Editar
						</asp:LinkButton>
						<asp:LinkButton runat="server"
							CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Desea eliminar?')">
						Eliminar
						</asp:LinkButton>

					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
	<asp:LinkButton runat="server"
		CssClass="btn btn-sm btn-success" OnClientClick="return confirm('Desea eliminar?')">
Agregar Orden
	</asp:LinkButton>
</asp:Content>
