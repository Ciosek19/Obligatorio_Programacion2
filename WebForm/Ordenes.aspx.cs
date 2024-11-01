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
			editarAgregarContenedor.Visible = true;
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
			Response.Redirect("~/Ordenes");
		}

		protected void AgregarTecnico_Click(object sender, EventArgs e)
		{
			btnAgregarOrden.Enabled = false;
			editarAgregarContenedor.Visible = true;
			lblEditarAgregar.Text = "Agregar cliente:";
			btnAgregar.Visible = true;
			btnGuardarCambios.Visible = false;

		}

		protected void Agregar_Click(object sender, EventArgs e)
		{
			string estado = ddlEstado.SelectedValue;
			Estado est;
			LimpiarTextbox();
			Response.Redirect("~/Tecnicos");
		}

		protected void Volver_Click(object sender, EventArgs e)
		{
			LimpiarTextbox();
			editarAgregarContenedor.Visible = false;
			btnAgregarOrden.Enabled = true;
		}

		protected void Eliminar_Click(object sender, EventArgs e)
		{
			LinkButton btn = (LinkButton)sender;
			int idTecnico = Convert.ToInt32(btn.CommandArgument);
			BaseDeDatos.EliminarTecnico(idTecnico);
			Response.Redirect("~/Tecnicos");
		}

		private void LimpiarTextbox()
		{
		
		}
	}
}