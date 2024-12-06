using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Orden
  {
    public static int IdAutoincremental = 0;
    public int ID_Orden { get; set; }
    public Cliente OCliente { get; set; }
    public Tecnico OTecnico { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public Estado EstadoOrden { get; set; }
    public List<string> Comentarios { get; set; } = new List<string>();

    public Orden(Cliente oCliente, Tecnico oTecnico, string descripcion, DateTime fecha, Estado estadoOrden, List<string> comentarios)
    {
      ID_Orden = ++IdAutoincremental;
      OCliente = oCliente;
      OTecnico = oTecnico;
      Descripcion = descripcion;
      Fecha = fecha;
      EstadoOrden = estadoOrden;
      Comentarios = comentarios;
    }

    public void AgregarComentario(string comentario){
      Comentarios.Add(comentario);
    }

   
  }
}
