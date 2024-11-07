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
				MostrarOrdenes();

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
			}
		}

		protected void MostrarOrdenes()
		{
			GVOrdenes.DataSource = BaseDeDatos.ListaOrdenes;
			GVOrdenes.DataBind();
		}

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
			ddlEstado.SelectedValue = ordenBaseDeDatos.EstadoOrden.ToString();
			txtId.Text = ordenBaseDeDatos.ID_Orden.ToString();
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
			if (!string.IsNullOrWhiteSpace(txtComentario.Text))
			{
				BaseDeDatos.ObtenerOrden(idOrden).AgregarComentario(txtComentario.Text);
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
			txtAgregarID.Text = (BaseDeDatos.ListaOrdenes.Last().ID_Orden + 1).ToString();
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

			Orden orden = new Orden(cliente,tecnico,txtDescripcion.Text, DateTime.Now, est, new List<string>());   
			BaseDeDatos.ListaOrdenes.Add(orden);
			LimpiarTextbox();
			Response.Redirect("~/Ordenes");
		}

		protected void Volver_Click(object sender, EventArgs e)
		{
			LimpiarTextbox();
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

		private void LimpiarTextbox()
		{

		}
	}
}