using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDatos;

namespace WebForm
{
	public partial class Tecnicos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			MostrarTecnicos();
		}

		protected void MostrarTecnicos()
		{
			GVTecnicos.DataSource = BaseDeDatos.ListaTecnicos;
			GVTecnicos.DataBind();
		}
	}
}