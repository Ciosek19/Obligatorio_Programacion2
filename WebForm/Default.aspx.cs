using Entidades;
using BaseDatos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
	public partial class _Default : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			MostrarOrdenes();
		}

		private void MostrarOrdenes()
		{
			List<Orden> lista = BaseDeDatos.OrdenesUltimoMes();
			GVOrdenes.DataSource = lista;
			GVOrdenes.DataBind();
		}
	}
}