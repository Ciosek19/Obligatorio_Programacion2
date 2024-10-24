using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
  public static class BaseDeDatos
  {
    public static List<Cliente> ListaClientes { get; set; } = new List<Cliente>();
    public static List<Orden> ListaOrdenes { get; set; } = new List<Orden>();
    public static List<Tecnico> ListaTecnicos { get; set; } = new List<Tecnico>();

    public static void AgregarDatosAutomaticos()
    {
      Cliente cliente1 = new Cliente("Pepe","Sanchez","30302553","Carlos Paez 2204","095989898","pepesanchez@gmail.com");
      Cliente cliente2 = new Cliente("Carlos","Garcia","30503553","18 de Julio 204","099123591");
      Cliente cliente3 = new Cliente("Marta","De Leon","40015532","Rincon 305","093982112");

      Tecnico tecnico1 = new Tecnico("Nacho", "Culebra", "33490543", Especialidad.Informatica);
      Tecnico tecnico2 = new Tecnico("Julia", "Lopez", "43223541", Especialidad.Electrodomesticos);
      Tecnico tecnico3 = new Tecnico("Pablo", "Clavito", "52518522", Especialidad.Iluminacion);

      Orden orden1 = new Orden(cliente1, tecnico1, "Limpiar virus", DateTime.Now, Estado.Completada, tecnico1.ListaComentarios);
      Orden orden2 = new Orden(cliente2, tecnico2, "Arreglar Heladera", DateTime.Now, Estado.EnProgreso, tecnico2.ListaComentarios);
      Orden orden3 = new Orden(cliente3, tecnico3, "Instalar luces", DateTime.Now, Estado.Pendiente, tecnico3.ListaComentarios);

      ListaClientes.Add(cliente1);
      ListaClientes.Add(cliente2);
      ListaClientes.Add(cliente3);

      ListaTecnicos.Add(tecnico1);
      ListaTecnicos.Add(tecnico2);
      ListaTecnicos.Add(tecnico3);

      ListaOrdenes.Add(orden1);
      ListaOrdenes.Add(orden2);
      ListaOrdenes.Add(orden3);
    }
  }
}
