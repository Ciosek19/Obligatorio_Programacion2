using BaseDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
	public partial class BusquedaOrdenes : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void BuscarOrden(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtNro.Text))
			{
				lblResultado.Text = "Tienes que ingresar un numero";
				lblResultado.ForeColor = Color.Orange;
				return;
			}

			if (BaseDeDatos.ObtenerOrden(Convert.ToInt32(txtNro.Text)) != null)
			{
				List<Orden> listaOrdenes = new List<Orden>();
				listaOrdenes.Add(BaseDeDatos.ObtenerOrden(Convert.ToInt32(txtNro.Text)));
				GVOrdenes.DataSource = listaOrdenes;
				GVOrdenes.DataBind();
				lblResultado.Text = "Disponible";
				lblResultado.ForeColor = Color.Green;
			}
			else
			{
				GVOrdenes.DataSource = null;
				GVOrdenes.DataBind();
				lblResultado.Text = "No existe esa orden";
				lblResultado.ForeColor = Color.Red;
			}
		}

	}
}