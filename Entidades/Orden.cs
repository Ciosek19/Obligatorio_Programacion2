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
      public int getID_Orden() { return ID_Orden; }
      public void setID_Orden(int ID_Orden) { this.ID_Orden = ID_Orden; }
      public Cliente getOCliente() { return OCliente; }
      public void setOCliente(Cliente OCliente) { this.OCliente = OCliente; }
      public Tecnico getOTecnico() { return OTecnico; }
      public void setOTecnico(Tecnico OTecnico) { this.OTecnico = OTecnico; }
      public string getDescripcion() { return Descripcion; }
      public void setDescripcion(string Descripcion) { this.Descripcion = Descripcion; }
      public DateTime getFecha() { return Fecha; }
      public void setFecha(DateTime Fecha) { this.Fecha = Fecha; }
      public Estado getEstadoOrden() { return EstadoOrden; }
      public void setEstadoOrden(Estado EstadoOrden) { this.EstadoOrden = EstadoOrden; }
      public List<string> getComentarios() { return Comentarios; }
      public void setComentarios(List<string> Comentarios) { this.Comentarios = Comentarios; }

   }
}
