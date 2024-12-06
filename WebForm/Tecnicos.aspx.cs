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
				ddlEspecialidad.DataSource = Enum.GetValues(typeof(Especialidad));
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
			ddlEspecialidad.SelectedValue = tecnicoBaseDatos.EspecialidadTecnico.ToString();
		}

		protected void GuardarCambios_Click(object sender, EventArgs e)
		{
			
         if (Page.IsValid)
         {
            string cedula = txtCedula.Text.Trim();
            if (ValidadorCedula.EsCedulaValida(cedula))
            {
               int idTecnico = Convert.ToInt32(txtId.Text);
               Tecnico tecnicoBaseDatos = BaseDeDatos.ObtenerTecnico(idTecnico);
               tecnicoBaseDatos.Nombre = txtNombre.Text;
               tecnicoBaseDatos.Apellido = txtApellido.Text;
               tecnicoBaseDatos.CI = txtCedula.Text;
               Especialidad esp;
               if (Enum.TryParse(ddlEspecialidad.SelectedValue, out esp))
               {
                  tecnicoBaseDatos.EspecialidadTecnico = esp;
               }
               Response.Redirect("~/Tecnicos");
            }
            else
            {
               lblError.Text = "La cédula ingresada no es válida.";
               lblError.Visible = true;
            }
         }

      }

      protected void AgregarTecnico_Click(object sender, EventArgs e)
		{
			btnAgregarTecnico.Enabled = false;
			editarAgregarContenedor.Visible = true;
			lblEditarAgregar.Text = "Agregar tecnico:";
			txtId.Text = (Tecnico.IdIncremental + 1).ToString();
			btnAgregar.Visible = true;
			btnGuardarCambios.Visible = false;


		}

		protected void Agregar_Click(object sender, EventArgs e)
		{
         if (Page.IsValid)
         {
            string cedula = txtCedula.Text.Trim();
            if (ValidadorCedula.EsCedulaValida(cedula))
            {
               string especialidad = ddlEspecialidad.SelectedValue;
               Especialidad esp;
               Enum.TryParse(ddlEspecialidad.SelectedValue, out esp);
               Tecnico tecnico = new Tecnico(txtNombre.Text, txtApellido.Text, txtCedula.Text, esp);
               BaseDeDatos.ListaTecnicos.Add(tecnico);
               LimpiarTextbox();
               Response.Redirect("~/Tecnicos");
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