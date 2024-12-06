using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDatos;
using Entidades;

namespace WebForm
{
   public partial class Clientes : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         MostrarClientes();

         if (Session["Id"].ToString() != "0")
         {
            Response.Redirect("~/Default");
         }
      }

      protected void MostrarClientes()
      {
         GVClientes.DataSource = BaseDeDatos.ListaClientes;
         GVClientes.DataBind();
      }

      protected void Editar_Click(object sender, EventArgs e)
      {
         LinkButton btn = (LinkButton)sender;
         int idCliente = Convert.ToInt32(btn.CommandArgument);
         editarAgregarContenedor.Visible = true;
         btnAgregarCliente.Enabled = false;
         lblEditarAgregar.Text = "Editar cliente:";
         btnAgregar.Visible = false;
         btnGuardarCambios.Visible = true;
         Cliente clienteBaseDatos = BaseDeDatos.ObtenerCliente(idCliente);
         txtId.Text = clienteBaseDatos.getID_Cliente().ToString();
         txtNombre.Text = clienteBaseDatos.getNombre();
         txtApellido.Text = clienteBaseDatos.getApellido();
         txtCedula.Text = clienteBaseDatos.getCI();
         txtDireccion.Text = clienteBaseDatos.getDireccion();
         txtTelefono.Text = clienteBaseDatos.getTelefono();
         txtEmail.Text = clienteBaseDatos.getEmail();
      }

      protected void GuardarCambios_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            string cedula = txtCedula.Text.Trim();
            if (ValidadorCedula.EsCedulaValida(cedula))
            {
               LinkButton btn = (LinkButton)sender;
               int idCliente = Convert.ToInt32(txtId.Text);
               Cliente clienteBaseDatos = BaseDeDatos.ObtenerCliente(idCliente);
               clienteBaseDatos.Nombre = txtNombre.Text;
               clienteBaseDatos.Apellido = txtApellido.Text;
               clienteBaseDatos.CI = txtCedula.Text;
               clienteBaseDatos.Direccion = txtDireccion.Text;
               clienteBaseDatos.Telefono = txtTelefono.Text;
               clienteBaseDatos.Email = txtEmail.Text;
               Response.Redirect("~/Clientes");
            }
            else
            {
               lblError.Text = "La cédula ingresada no es válida.";
               lblError.Visible = true;
            }
         }
      }

      protected void AgregarCliente_Click(object sender, EventArgs e)
      {
         btnAgregarCliente.Enabled = false;
         editarAgregarContenedor.Visible = true;
         lblEditarAgregar.Text = "Agregar cliente:";
         btnAgregar.Visible = true;
         btnGuardarCambios.Visible = false;
         txtId.Text = (Cliente.IdIncremental + 1).ToString();
      }

      protected void Agregar_Click(object sender, EventArgs e)
      {

         if (Page.IsValid)
         {
            string cedula = txtCedula.Text.Trim();
            if (ValidadorCedula.EsCedulaValida(cedula))
            {
               Cliente cliente = new Cliente(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
               BaseDeDatos.ListaClientes.Add(cliente);
               LimpiarTextbox();
               Response.Redirect("~/Clientes");
            }
            else
            {
               lblError.Text = "La cédula ingresada no es válida.";
               lblError.Visible = true;
            }
         }
      }

      protected void Volver_Click(object sender, EventArgs e)
      {
         LimpiarTextbox();
         editarAgregarContenedor.Visible = false;
         btnAgregarCliente.Enabled = true;
      }

      protected void Eliminar_Click(object sender, EventArgs e)
      {
         LinkButton btn = (LinkButton)sender;
         int idCliente = Convert.ToInt32(btn.CommandArgument);
         BaseDeDatos.EliminarCliente(idCliente);
         Response.Redirect("~/Clientes");
      }

      private void LimpiarTextbox()
      {
         txtId.Text = "";
         txtNombre.Text = "";
         txtApellido.Text = "";
         txtCedula.Text = "";
         txtDireccion.Text = "";
         txtTelefono.Text = "";
         txtEmail.Text = "";
      }
   }
}