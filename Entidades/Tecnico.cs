using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Tecnico
   {
      public static int IdIncremental = 0;
      public int ID_Tecnico { get; set; }
      public string Nombre { get; set; }
      public string Apellido { get; set; }
      public string CI { get; set; }
      public Especialidad EspecialidadTecnico { get; set; }

      public Tecnico(string nombre, string apellido, string cI, Especialidad especialidad)
      {
         ID_Tecnico = ++IdIncremental;
         Nombre = nombre;
         Apellido = apellido;
         CI = cI;
         EspecialidadTecnico = especialidad;
      }
      public int getID_Tecnico() { return ID_Tecnico; }
      public void setID_Tecnico(int ID_Tecnico) { this.ID_Tecnico = ID_Tecnico; }
      public string getNombre() { return Nombre; }
      public void setNombre(string Nombre) { this.Nombre = Nombre; }
      public string getApellido() { return Apellido; }
      public void setApellido(string Apellido) { this.Apellido = Apellido; }
      public string getCI() { return CI; }
      public void setCI(string CI) { this.CI = CI; }
      public Especialidad getEspecialidadTecnico() { return EspecialidadTecnico; }
      public void setEspecialidadTecnico(Especialidad EspecialidadTecnico)
      {
         this.EspecialidadTecnico = EspecialidadTecnico;
      }
   }
}
