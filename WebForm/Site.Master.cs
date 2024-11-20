using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebForm
{
   public partial class SiteMaster : MasterPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            if (Session["Nombre"] != null)
            {
               lblUsuario.Text = $"Usuario: {Session["Nombre"].ToString()}";
               if (Session["Id"].ToString() == "0")
               {
                  lblUsuario.ForeColor = Color.Green;
               }
               else
               {
                  lblUsuario.ForeColor = Color.White;
                  hlClientes.Visible = false;
                  hlTecnicos.Visible = false;
               }
            }
            else
            {
               Response.Redirect("~/Login.aspx");
            }
         }
      }
      protected void btnCerrarSesion_Click(object sender, EventArgs e)
      {
         Session.Clear();
         Session.Abandon();

         Response.Redirect("~/Login.aspx");
      }
   }
}