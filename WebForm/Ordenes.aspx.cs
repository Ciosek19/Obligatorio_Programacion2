using BaseDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
   public partial class Ordenes : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            if (Session["Id"].ToString() == "0")
            {

               MostrarOrdenes(null);

               ddlEstado.DataSource = Enum.GetValues(typeof(Estado));
               ddlEstado.DataBind();

               ddlEstadoAgregar.DataSource = Enum.GetValues(typeof(Estado));
               ddlEstadoAgregar.DataBind();

               ddlCliente.DataSource = BaseDeDatos.ListaClientes;
               ddlCliente.DataTextField = "Nombre";
               ddlCliente.DataValueField = "ID_Cliente";
               ddlCliente.DataBind();

               ddlTecnico.DataSource = BaseDeDatos.ListaTecnicos;
               ddlTecnico.DataTextField = "Nombre";
               ddlTecnico.DataValueField = "ID_Tecnico";
               ddlTecnico.DataBind();

               btnAgregarOrden.Visible = true;


            }
            else
            {
               MostrarOrdenes(BaseDeDatos.ObtenerTecnico((int)Session["Id"]));
               TemplateField templateField = (TemplateField)GVOrdenes.Columns[GVOrdenes.Columns.Count - 2];
               templateField.Visible = false;
               btnAgregarOrden.Visible = false;
            }


         }
      }

      protected void MostrarOrdenes(Tecnico tecnico)
      {
         if (tecnico == null)
         {
            GVOrdenes.DataSource = BaseDeDatos.ListaOrdenes;
            GVOrdenes.DataBind();
         }
         else
         {
            GVOrdenes.DataSource = BaseDeDatos.OrdenesTecnico(tecnico);
            GVOrdenes.DataBind();
         }

      }

      // ADMIN CONTENEDOR, AGREGAR - EDITAR - ELIMINAR

      protected void Editar_Click(object sender, EventArgs e)
      {
         LinkButton btn = (LinkButton)sender;
         int idOrden = Convert.ToInt32(btn.CommandArgument);
         editarContenedor.Visible = true;
         guardarContenedor.Visible = false;
         btnAgregar.Enabled = false;
         lblEditarAgregar.Text = "Editar Orden:";
         btnAgregar.Visible = false;
         btnGuardarCambios.Visible = true;
         Orden ordenBaseDeDatos = BaseDeDatos.ObtenerOrden(idOrden);
         ddlEstado.ClearSelection();
         ddlEstado.SelectedValue = ordenBaseDeDatos.getEstadoOrden().ToString();
         txtId.Text = ordenBaseDeDatos.getID_Orden().ToString();
      }

      protected void GuardarCambios_Click(object sender, EventArgs e)
      {

         int idOrden = Convert.ToInt32(txtId.Text);
         Orden ordenBaseDatos = BaseDeDatos.ObtenerOrden(idOrden);
         Estado est;
         if (Enum.TryParse(ddlEstado.SelectedValue, out est))
         {
            ordenBaseDatos.EstadoOrden = est;
         }
         Response.Redirect("~/Ordenes");

      }

      protected void AgregarOrden_Click(object sender, EventArgs e)
      {
         btnAgregarOrden.Enabled = false;
         btnAgregar.Enabled = true;
         guardarContenedor.Visible = true;
         lblEditarAgregar.Text = "Agregar Orden:";
         btnAgregar.Visible = true;
         btnGuardarCambios.Visible = false;
         txtAgregarID.Text = (BaseDeDatos.ListaOrdenes.Last().getID_Orden() + 1).ToString();
      }

      protected void Agregar_Click(object sender, EventArgs e)
      {
         string estado = ddlEstadoAgregar.SelectedValue;
         Estado est;
         Enum.TryParse(ddlEstadoAgregar.SelectedValue, out est);

         int clienteId = Convert.ToInt32(ddlCliente.SelectedValue);
         Cliente cliente = BaseDeDatos.ObtenerCliente(clienteId);

         int tecnicoId = Convert.ToInt32(ddlTecnico.SelectedValue);
         Tecnico tecnico = BaseDeDatos.ObtenerTecnico(tecnicoId);

         Orden orden = new Orden(cliente, tecnico, txtDescripcion.Text, DateTime.Now, est, new List<string>());
         BaseDeDatos.ListaOrdenes.Add(orden);
         Response.Redirect("~/Ordenes");
      }

      protected void Volver_Click(object sender, EventArgs e)
      {
         editarContenedor.Visible = false;
         guardarContenedor.Visible = false;
         btnAgregarOrden.Enabled = true;
      }

      protected void Eliminar_Click(object sender, EventArgs e)
      {
         LinkButton btn = (LinkButton)sender;
         int idOrden = Convert.ToInt32(btn.CommandArgument);
         BaseDeDatos.EliminarOrden(idOrden);
         Response.Redirect("~/Ordenes");
      }
      // ----------------

      // TECNICOS, CONTENEDOR AGREGAR COMENTARIO

      protected void AgregarComentario_Click(object sender, EventArgs e)
      {
         LinkButton btn = (LinkButton)sender;
         int idOrden = Convert.ToInt32(btn.CommandArgument);
         AgregarComentarioContenedor.Visible = true;
         txtId.Text = idOrden.ToString();
      }

      protected void CancelarComentario_Click(object sender, EventArgs e)
      {
         txtComentario.Text = "";
         AgregarComentarioContenedor.Visible = false;
      }

      protected void GuardarComentario_Click(object sender, EventArgs e)
      {
         Orden orden = BaseDeDatos.ObtenerOrden(Convert.ToInt32(txtId.Text));
         if (!string.IsNullOrEmpty(txtComentario.Text))
         {
            orden.AgregarComentario(txtComentario.Text);
            txtComentario.Text = "";
            Response.Redirect("~/Ordenes");
         }
      }

   }
}