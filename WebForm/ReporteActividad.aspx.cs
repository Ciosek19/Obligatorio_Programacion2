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
	public partial class ReporteActividad : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ddlTecnicos.DataSource = BaseDeDatos.ListaTecnicos;
				ddlTecnicos.DataTextField = "Nombre";
				ddlTecnicos.DataValueField = "ID_Tecnico";
				ddlTecnicos.DataBind();

				ddlEstado.DataSource = Enum.GetValues(typeof(Estado));
				ddlEstado.DataBind();

			}
		}

		public void MostrarCantidad(object sender, EventArgs e)
		{
			Tecnico tecnico = BaseDeDatos.ObtenerTecnico(Convert.ToInt32(ddlTecnicos.SelectedValue));
			tcPendiente.Text = BaseDeDatos.CantidadOrdenesEstadoTecnico(tecnico, Estado.Pendiente).ToString();
			tcProgreso.Text = BaseDeDatos.CantidadOrdenesEstadoTecnico(tecnico, Estado.EnProgreso).ToString();
			tcCompletada.Text = BaseDeDatos.CantidadOrdenesEstadoTecnico(tecnico, Estado.Completada).ToString();

		}

		public void MostrarOrdenesPorEstado(object sender, EventArgs e)
		{
			Estado estado = (Estado)Enum.Parse(typeof(Estado), ddlEstado.SelectedValue);
			GVOrdenes.DataSource = BaseDeDatos.FiltrarOrdenesPorEstado(estado);
			GVOrdenes.DataBind();
		}

		
	}
}