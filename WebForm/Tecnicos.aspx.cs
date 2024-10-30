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
	public partial class Tecnicos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				MostrarTecnicos();

				ddlEspecialidad.DataSource = new List<string> { "Informatica", "Iluminacion", "Electrodomesticos" };
				ddlEspecialidad.DataBind();
			}
		}

		protected void MostrarTecnicos()
		{
			GVTecnicos.DataSource = BaseDeDatos.ListaTecnicos;
			GVTecnicos.DataBind();
		}

		protected void Editar_Click(object sender, EventArgs e)
		{
			LinkButton btn = (LinkButton)sender;
			int idTecnico = Convert.ToInt32(btn.CommandArgument);
			editarAgregarContenedor.Visible = true;
			btnAgregarTecnico.Enabled = false;
			lblEditarAgregar.Text = "Editar Tecnico:";
			btnAgregar.Visible = false;
			btnGuardarCambios.Visible = true;
			Tecnico tecnicoBaseDatos = BaseDeDatos.ObtenerTecnico(idTecnico);
			txtId.Text = tecnicoBaseDatos.ID_Tecnico.ToString();
			txtNombre.Text = tecnicoBaseDatos.Nombre;
			txtApellido.Text = tecnicoBaseDatos.Apellido;
			txtCedula.Text = tecnicoBaseDatos.CI;
			ddlEspecialidad.ClearSelection();
			ddlEspecialidad.Items.FindByText(tecnicoBaseDatos.EspecialidadTecnico).Selected = true;
		}

		protected void GuardarCambios_Click(object sender, EventArgs e)
		{
			int idTecnico = Convert.ToInt32(txtId.Text);
			Tecnico tecnicoBaseDatos = BaseDeDatos.ObtenerTecnico(idTecnico);
			tecnicoBaseDatos.Nombre = txtNombre.Text;
			tecnicoBaseDatos.Apellido = txtApellido.Text;
			tecnicoBaseDatos.CI = txtCedula.Text;
			tecnicoBaseDatos.EspecialidadTecnico = ddlEspecialidad.SelectedItem.Value;
			Response.Redirect("~/Tecnicos");
		}

		protected void AgregarTecnico_Click(object sender, EventArgs e)
		{
			btnAgregarTecnico.Enabled = false;
			editarAgregarContenedor.Visible = true;
			lblEditarAgregar.Text = "Agregar cliente:";
			btnAgregar.Visible = true;
			btnGuardarCambios.Visible = false;

		}

		protected void Agregar_Click(object sender, EventArgs e)
		{
			string especialidad = ddlEspecialidad.SelectedItem.Value;
			Tecnico tecnico = new Tecnico(txtNombre.Text, txtApellido.Text, txtCedula.Text, especialidad);
			BaseDeDatos.ListaTecnicos.Add(tecnico);
			LimpiarTextbox();
			Response.Redirect("~/Tecnicos");
		}

		protected void Volver_Click(object sender, EventArgs e)
		{
			LimpiarTextbox();
			editarAgregarContenedor.Visible = false;
			btnAgregarTecnico.Enabled = true;
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
			txtId.Text = "";
			txtNombre.Text = "";
			txtApellido.Text = "";
			txtCedula.Text = "";
			ddlEspecialidad.ClearSelection();
		}
	}
}