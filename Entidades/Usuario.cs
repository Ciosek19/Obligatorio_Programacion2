using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Usuario
   {
      public int IdUsuario { get; set; }
      public string Nombre { get; set; }
      public string Clave { get; set; }

      public Usuario(string nombre, string clave)
      {
         Nombre = nombre;
         Clave = clave;
         IdUsuario = 0;
      }
      public Usuario(string nombre, string clave, Tecnico tecnico)
      {
         Nombre = nombre;
         Clave = clave;
         IdUsuario = tecnico.ID_Tecnico;
      }

      public int getIdUsuario() { return IdUsuario; }
      public void setIdUsuario(int IdUsuario) { this.IdUsuario = IdUsuario; }
      public string getNombre() { return Nombre; }
      public void setNombre(string Nombre) { this.Nombre = Nombre; }
      public string getClave() { return Clave; }
      public void setClave(string Clave) { this.Clave = Clave; }
   }
}
