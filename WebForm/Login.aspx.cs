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
   public partial class Login : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {

      }

      protected void btnLogin_Click(object sender, EventArgs e)
      {
         string nombre = txtUsername.Text.Trim();
         string clave = txtPassword.Text;

         if (BaseDeDatos.getUsuario(nombre,clave) != null)
         {
            Usuario usuario = BaseDeDatos.getUsuario(nombre, clave);
            Session["Nombre"] = usuario.getNombre();
            Session["Id"] = usuario.getIdUsuario();
            Response.Redirect("Default.aspx");
         }
         else
         {
            lblError.Text = "Usuario o contraseña incorrectos.";
         }
      }
   }
}