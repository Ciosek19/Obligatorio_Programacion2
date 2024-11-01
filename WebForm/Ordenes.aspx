<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="WebForm.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
	<h1>Ordenes:</h1>
	<div class="row">
		<div class="col-12"></div>
		<asp:GridView ID="GVOrdenes" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
			<Columns>
				<asp:BoundField DataField="ID_Orden" HeaderText="ID" />
				<asp:TemplateField>
					<ItemTemplate>
						<%#Eval("OCliente.Nombre")%> <%#Eval("OCliente.Apellido")%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField>
					<ItemTemplate>
						<%#Eval("OTecnico.Nombre")%> <%#Eval("OTecnico.Apellido")%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
				<asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" />
				<asp:BoundField DataField="EstadoOrden" HeaderText="Estado" />
				<asp:TemplateField>
					<ItemTemplate>
						<asp:LinkButton runat="server"
							CssClass="btn btn-sm btn-primary" OnClick="Editar_Click" CommandArgument='<%#Eval("ID_Orden") %>'>
						Editar</asp:LinkButton>
						<asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Desea eliminar?')" CommandArgument='<%#Eval("ID_Orden") %>'>
						Eliminar
						</asp:LinkButton>

					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
	<asp:LinkButton runat="server" ID="btnAgregarOrden"
		CssClass="btn btn-sm btn-success" Enabled="true" OnClick="AgregarTecnico_Click">
Agregar Cliente
	</asp:LinkButton>
	<br />
	<br />
	<!-- EDITAR Y AGREGAR - Contenedor -->
	<asp:PlaceHolder runat="server" ID="editarAgregarContenedor" Visible="false">
		<asp:Label ID="lblEditarAgregar" runat="server" Font-Size="30px">Titulo</asp:Label><br />
		<asp:Label runat="server">ID</asp:Label><br />
		<asp:TextBox runat="server" TextMode="Number" Enabled="false" ID="txtId"></asp:TextBox><br />

		<asp:Label runat="server">Estado: </asp:Label><br />
		<asp:DropDownList runat="server" ID="ddlEstado">
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
