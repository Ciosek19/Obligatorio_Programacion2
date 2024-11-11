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
	<asp:DropDownList runat="server" ID="ddlTecnicos" OnSelectedIndexChanged="MostrarCantidad" AutoPostBack="true"></asp:DropDownList><br />
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
	<h3>Ordenes por estado</h3>
	<label style="font-size: 20px">Seleccione al tecnico</label><br />
	<label>Estado: </label>
	<asp:DropDownList runat="server" ID="ddlEstado" AutoPostBack="true"></asp:DropDownList><br />
<br />

</asp:Content>
