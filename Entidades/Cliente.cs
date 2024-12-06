using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Cliente
  {
    public static int IdIncremental = 0;
    public int ID_Cliente { get; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string CI { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public Cliente() { }

    public Cliente(string nombre, string apellido, string cI, string direccion, string telefono)
    {
      ID_Cliente = ++IdIncremental;
      Nombre = nombre;
      Apellido = apellido;
      CI = cI;
      Direccion = direccion;
      Telefono = telefono;
      Email = "";
    }

    public Cliente(string nombre, string apellido, string cI, string direccion, string telefono, string email)
    {
      ID_Cliente = ++IdIncremental;
      Nombre = nombre;
      Apellido = apellido;
      CI = cI;
      Direccion = direccion;
      Telefono = telefono;
      Email = email;
    }

      public int getID_Cliente() { return ID_Cliente; }
      public string getNombre() { return Nombre; }
      public void setNombre(string Nombre) { this.Nombre = Nombre; }
      public string getApellido() { return Apellido; }
      public void setApellido(string Apellido) { this.Apellido = Apellido; }
      public string getCI() { return CI; }
      public void setCI(string CI) { this.CI = CI; }
      public string getDireccion() { return Direccion; }
      public void setDireccion(string Direccion) { this.Direccion = Direccion; }
      public string getTelefono() { return Telefono; }
      public void setTelefono(string Telefono) { this.Telefono = Telefono; }
      public string getEmail() { return Email; }
      public void setEmail(string Email) { this.Email = Email; }
   }
}
