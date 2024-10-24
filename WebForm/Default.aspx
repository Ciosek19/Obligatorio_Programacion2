<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <header>
  <link href="Content/defaultStyle.css" rel="stylesheet" type="text/css"/>
</header>
<div class="row">
  <div class="col-12">
    <asp:Button runat="server" CssClass="btn btn-sm btn-success" Text="Nuevo" />
  </div>
</div>

<div class="row">
  <div class="col-12"></div>
  <asp:GridView ID="GVOrdenes" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
    <Columns>
      <asp:BoundField DataField="ID_Orden" HeaderText="Nro Orden"/>
      <asp:TemplateField HeaderText="Cliente">
            <ItemTemplate>
                <%# Eval("OCliente.Nombre") + " " + Eval("OCliente.Apellido") %>
            </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="Tecnico">
      <ItemTemplate>
          <%# Eval("OTecnico.Nombre") + " " + Eval("OTecnico.Apellido") %>
      </ItemTemplate>
  </asp:TemplateField>
      <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
      <asp:TemplateField HeaderText="Estado de Orden">
            <ItemTemplate>
                <%# Eval("EstadoOrden") %> <!-- O el método personalizado que necesites -->
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
</asp:Content>
