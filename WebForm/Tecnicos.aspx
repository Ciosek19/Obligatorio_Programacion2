<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="WebForm.Tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
	<h1>Tecnicos:</h1>
	<div class="row">
		<div class="col-12"></div>
		<asp:GridView ID="GVTecnicos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
			<Columns>
				<asp:BoundField DataField="ID_Tecnico" HeaderText="ID" />
				<asp:BoundField DataField="Nombre" HeaderText="Nombre" />
				<asp:BoundField DataField="Apellido" HeaderText="Apellido" />
				<asp:BoundField DataField="CI" HeaderText="Cedula" />
				<asp:BoundField DataField="EspecialidadTecnico" HeaderText="Especialidad" />
				<asp:TemplateField>
					<ItemTemplate>
						<asp:LinkButton runat="server"
							CssClass="btn btn-sm btn-primary" OnClick="Editar_Click" CommandArgument='<%#Eval("ID_Tecnico") %>'>
						Editar</asp:LinkButton>
						<asp:LinkButton runat="server" OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Desea eliminar?')" CommandArgument='<%#Eval("ID_Tecnico") %>'>
						Eliminar
						</asp:LinkButton>

					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
	<asp:LinkButton runat="server" ID="btnAgregarTecnico"
		CssClass="btn btn-sm btn-success" Enabled="true" OnClick="AgregarTecnico_Click">
Agregar Cliente
	</asp:LinkButton>
	<br />
	<br />
	<!-- EDITAR Y AGREGAR - Contenedor -->
	<asp:PlaceHolder runat="server" ID="editarAgregarContenedor" Visible="false">
		<asp:Label runat="server" Text="Titulo" Font-Size="40px" ID="lblEditarAgregar"></asp:Label>
		<br />
		<asp:Label runat="server" CssClass="">ID Tecnico</asp:Label><br />
		<asp:TextBox runat="server" TextMode="Number" Enabled="false" ID="txtId"></asp:TextBox>
		<br />
		<asp:Label runat="server">Nombre </asp:Label><br />
		<asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
		<br />
		<asp:Label runat="server">Apellido </asp:Label><br />
		<asp:TextBox runat="server" ID="txtApellido"></asp:TextBox>
		<br />
		<asp:Label runat="server">Cedula </asp:Label><br />
		<asp:TextBox runat="server" ID="txtCedula"></asp:TextBox>
		<br />
		<asp:Label runat="server">Especialidad </asp:Label><br />
		<asp:DropDownList runat="server" ID="ddlEspecialidad" >
		</asp:DropDownList>

		<br />
		<br />
		<asp:LinkButton runat="server" ID="btnGuardarCambios"
			CssClass="btn btn-sm btn-success" OnClick="GuardarCambios_Click">
Guardar
		</asp:LinkButton>
		<asp:LinkButton runat="server" ID="btnAgregar"
			CssClass="btn btn-sm btn-success" OnClick="Agregar_Click">
Agregar
		</asp:LinkButton>
		<asp:LinkButton runat="server" ID="btnVolver"
			CssClass="btn btn-sm btn-danger ml-2" OnClick="Volver_Click">
Volver
		</asp:LinkButton>
	</asp:PlaceHolder>
</asp:Content>
