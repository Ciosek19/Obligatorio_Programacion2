<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebForm.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
	<h1>Clientes:</h1>
	<div class="row">
		<div class="col-12"></div>
		<asp:GridView ID="GVClientes" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
			<Columns>
				<asp:BoundField DataField="ID_Cliente" HeaderText="ID" />
				<asp:BoundField DataField="Nombre" HeaderText="Nombre" />
				<asp:BoundField DataField="Apellido" HeaderText="Apellido" />
				<asp:BoundField DataField="CI" HeaderText="Cedula" />
				<asp:BoundField DataField="Direccion" HeaderText="Direccion" />
				<asp:BoundField DataField="Telefono" HeaderText="Telefono" />
				<asp:BoundField DataField="Email" HeaderText="Email*" />
				<asp:TemplateField>
					<ItemTemplate>
						<asp:LinkButton runat="server" OnClick="Editar_Click"
							CssClass="btn btn-sm btn-primary" CommandArgument='<%#Eval("ID_Cliente") %>'>
						Editar</asp:LinkButton>
						<asp:LinkButton runat="server"
							CssClass="btn btn-sm btn-danger" OnClick="Eliminar_Click" OnClientClick="return confirm('Desea eliminar?')" CommandArgument='<%#Eval("ID_Cliente") %>'>
						Eliminar
						</asp:LinkButton>

					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
	<asp:LinkButton runat="server" ID="btnAgregarCliente"
		CssClass="btn btn-sm btn-success" Enabled="true" OnClick="AgregarCliente_Click">
Agregar Cliente
	</asp:LinkButton>
	<br />
	<br />
	<!-- EDITAR Y AGREGAR - Contenedor -->
	<asp:PlaceHolder runat="server" ID="editarAgregarContenedor" Visible="false">
		<asp:Label runat="server" Text="Titulo" Font-Size="40px" ID="lblEditarAgregar"></asp:Label>
		<br />
		<asp:Label runat="server" CssClass="">ID Cliente</asp:Label><br />
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
		<asp:Label runat="server">Direccion </asp:Label><br />
		<asp:TextBox runat="server" ID="txtDireccion"></asp:TextBox>
		<br />
		<asp:Label runat="server">Telefono </asp:Label><br />
		<asp:TextBox runat="server" ID="txtTelefono"></asp:TextBox>
		<br />
		<asp:Label runat="server">Email*</asp:Label><br />
		<asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>

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
