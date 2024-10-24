using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Cliente
  {
    private static int IdIncremental = 0;
    public int ID_Cliente { get; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string CI { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public Cliente(string nombre, string apellido, string cI, string direccion, string telefono)
    {
      ID_Cliente = ++IdIncremental;
      Nombre = nombre;
      Apellido = apellido;
      CI = cI;
      Direccion = direccion;
      Telefono = telefono;
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
  }
}
