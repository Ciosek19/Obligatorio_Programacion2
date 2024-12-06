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
                     CssClass="btn btn-sm btn-primary" OnClick="Editar_Click" CausesValidation="false" CommandArgument='<%#Eval("ID_Tecnico") %>'>
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
Agregar Tecnico
   </asp:LinkButton>
   <br />
   <br />
   <!-- EDITAR Y AGREGAR - Contenedor -->
<asp:PlaceHolder runat="server" ID="editarAgregarContenedor" Visible="false">
    <asp:Label runat="server" Text="Titulo" Font-Size="40px" ID="lblEditarAgregar"></asp:Label>
    <br />
    <asp:Label runat="server" CssClass="">ID Técnico</asp:Label><br />
    <asp:TextBox runat="server" TextMode="Number" Enabled="false" ID="txtId"></asp:TextBox>
    <br />
    <asp:Label runat="server">Nombre </asp:Label><br />
    <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es requerido." Display="Dynamic" ForeColor="Red" />
    <br />
    <asp:Label runat="server">Apellido </asp:Label><br />
    <asp:TextBox runat="server" ID="txtApellido"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido es requerido." Display="Dynamic" ForeColor="Red" />
    <br />
    <asp:Label runat="server">Cédula </asp:Label><br />
    <asp:TextBox runat="server" ID="txtCedula"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCedula" ErrorMessage="La cédula es requerida." Display="Dynamic" ForeColor="Red" />
    <br />
    <asp:Label runat="server">Especialidad </asp:Label><br />
    <asp:DropDownList runat="server" ID="ddlEspecialidad"></asp:DropDownList>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEspecialidad" InitialValue="" ErrorMessage="La especialidad es requerida." Display="Dynamic" ForeColor="Red" />
    <br />
    <asp:ValidationSummary runat="server" ForeColor="Red" HeaderText="Por favor, corrige los siguientes errores:" />
    <asp:Label runat="server" ID="lblError" Visible="false" ForeColor="Red"></asp:Label>
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
        CssClass="btn btn-sm btn-danger ml-2" OnClick="Volver_Click" CausesValidation="false">
Volver
    </asp:LinkButton>
</asp:PlaceHolder>

</asp:Content>
