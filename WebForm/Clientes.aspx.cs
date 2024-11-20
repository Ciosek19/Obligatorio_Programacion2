using System;
using System.Collections.Generic;
using System.Linq;
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
         txtId.Text = clienteBaseDatos.ID_Cliente.ToString();
         txtNombre.Text = clienteBaseDatos.Nombre;
         txtApellido.Text = clienteBaseDatos.Apellido;
         txtCedula.Text = clienteBaseDatos.CI;
         txtDireccion.Text = clienteBaseDatos.Direccion;
         txtTelefono.Text = clienteBaseDatos.Telefono;
         txtEmail.Text = clienteBaseDatos.Email;
      }

      protected void GuardarCambios_Click(object sender, EventArgs e)
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

      protected void AgregarCliente_Click(object sender, EventArgs e)
      {
         btnAgregarCliente.Enabled = false;
         editarAgregarContenedor.Visible = true;
         lblEditarAgregar.Text = "Agregar cliente:";
         btnAgregar.Visible = true;
         btnGuardarCambios.Visible = false;
      }

      protected void Agregar_Click(object sender, EventArgs e)
      {
         Cliente cliente = new Cliente(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
         BaseDeDatos.ListaClientes.Add(cliente);
         LimpiarTextbox();
         Response.Redirect("~/Clientes");
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