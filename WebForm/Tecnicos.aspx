<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="WebForm.Tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Tecnicos:</h1>
	<div class="row">
		<div class="col-12"></div>
		<asp:GridView ID="GVTecnicos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
			<Columns>
				<asp:BoundField DataField="ID_Tecnico" HeaderText="Identificador" />
				<asp:BoundField DataField="Nombre" HeaderText="Nombre" />
				<asp:BoundField DataField="Apellido" HeaderText="Apellido" />
				<asp:BoundField DataField="CI" HeaderText="Cedula" />
				<asp:TemplateField HeaderText="Especialidad">
					<ItemTemplate>
						<%#Eval("EspecialidadTecnico")%>
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
Agregar Tecnico
	</asp:LinkButton>
</asp:Content>
