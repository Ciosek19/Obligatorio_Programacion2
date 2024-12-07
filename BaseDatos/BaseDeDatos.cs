using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
   public static class BaseDeDatos
   {
      public static List<Cliente> ListaClientes { get; set; } = new List<Cliente>
      {
         new Cliente("Pepe", "Sanchez", "30302553", "Carlos Paez 2204", "095989898", "pepesanchez@gmail.com"),
         new Cliente("Carlos", "Garcia", "30503553", "18 de Julio 204", "099123591"),
         new Cliente("Marta", "De Leon", "40015532", "Rincon 305", "093982112")
      };

      public static List<Tecnico> ListaTecnicos { get; set; } = new List<Tecnico>
      {
         new Tecnico("Nacho", "Culebra", "33490543", Especialidad.Informatica),
         new Tecnico("Julia", "Lopez", "43223541", Especialidad.Redes),
         new Tecnico("Pablo", "Clavito", "52518522", Especialidad.Electrodomesticos)
      };

      public static List<Orden> ListaOrdenes = new List<Orden>
      {
         new Orden(ListaClientes[0], ListaTecnicos[0], "Limpiar virus",new DateTime(2024,11,5), Estado.Completada, new List<string>(){"Habia descargado por ares","Se tuvo que hacer una limpieza total"}),
         new Orden(ListaClientes[1], ListaTecnicos[1], "Arreglar Heladera",new DateTime(2024,12,1), Estado.EnProgreso, new List<string>(){"Se necesita una nueva pieza","Se tiene que mandar a montevideo"}),
         new Orden(ListaClientes[2], ListaTecnicos[2], "Instalar luces",new DateTime(2024,12,7), Estado.Pendiente, new List<string>(){"No me abre la puerta","No era la direccion correcta" })
      };

      public static List<Usuario> ListaUsuarios = new List<Usuario>
      {
         new Usuario("admin","123"),
         new Usuario("NachoCulebra","123",ListaTecnicos[0]),
         new Usuario("JuliaLopez","123",ListaTecnicos[1]),
         new Usuario("PabloClavito","123",ListaTecnicos[2])
      };

      /////////////// CLIENTES
      ///
      public static Cliente ObtenerCliente(int idCliente)
      {
         foreach (Cliente cliente in ListaClientes)
         {
            if (cliente.getID_Cliente() == idCliente)
            {
               return cliente;
            }
         }
         return null;
      }

      public static void EliminarCliente(int idCliente)
      {
         foreach (var cliente in ListaClientes)
         {
            if (cliente.getID_Cliente() == idCliente)
            {
               ListaClientes.Remove(cliente);
               break;
            }
         }
      }
      ////////////////////////

      /////////////// TECNICOS
      ///
      public static Tecnico ObtenerTecnico(int idTecnico)
      {
         foreach (Tecnico tecnico in ListaTecnicos)
         {
            if (tecnico.getID_Tecnico() == idTecnico)
            {
               return tecnico;
            }
         }
         return null;
      }

      public static void EliminarTecnico(int idTecnico)
      {
         foreach (Tecnico tecnico in ListaTecnicos)
         {
            if (tecnico.getID_Tecnico() == idTecnico)
            {
               ListaTecnicos.Remove(tecnico);
               break;
            }
         }
      }
      /////////////// ORDENES
      ///
      public static Orden ObtenerOrden(int idOrden)
      {
         foreach (Orden orden in ListaOrdenes)
         {
            if (orden.ID_Orden == idOrden)
            {
               return orden;
            }
         }
         return null;
      }

      public static void EliminarOrden(int idOrden)
      {
         foreach (var orden in ListaOrdenes)
         {
            if (orden.ID_Orden == idOrden)
            {
               ListaOrdenes.Remove(orden);
               break;
            }
         }
      }

      public static List<Orden> OrdenesUltimoMes()
      {
         List<Orden> ordenes = new List<Orden>();
         foreach (Orden orden in ListaOrdenes)
         {
            if (orden.Fecha.Month == DateTime.Now.Month)
            {
               ordenes.Add(orden);
            }
         }
         return ordenes;
      }

      public static List<Orden> OrdenesCompletadasUltimoMes()
      {
         List<Orden> ordenes = new List<Orden>();
         foreach (Orden orden in ListaOrdenes)
         {
            if (orden.Fecha.Month == DateTime.Now.Month && orden.EstadoOrden == Estado.Completada)
            {
               ordenes.Add(orden);
            }
         }
         return ordenes;
      }

      ////////////////////////
      /// REPORTES ACTIVIDAD

      public static List<Orden> OrdenesTecnico(Tecnico tecnico)
      {
         List<Orden> listaOrdenes = new List<Orden>();
         foreach (Orden orden in ListaOrdenes)
         {
            if (orden.getOTecnico().ID_Tecnico == tecnico.ID_Tecnico)
            {
               listaOrdenes.Add(orden);
            }
         }
         return listaOrdenes;
      }

      public static int CantidadOrdenesEstadoTecnico(Tecnico tecnico, Estado estado)
      {
         int cantidad = 0;
         foreach (Orden orden in OrdenesTecnico(tecnico))
         {
            if (orden.getEstadoOrden() == estado)
            {
               cantidad++;
            }
         }
         return cantidad;
      }

      public static List<Orden> FiltrarOrdenesPorEstado(Estado estado)
      {
         List<Orden> listaFiltrada = new List<Orden>();
         foreach (Orden orden in ListaOrdenes)
         {
            if (orden.getEstadoOrden() == estado)
            {
               listaFiltrada.Add(orden);
            }
         }
         return listaFiltrada;
      }

      public static Usuario getUsuario(string nombre, string clave)
      {
         foreach (Usuario u in ListaUsuarios)
         {
            if (nombre == u.getNombre() && clave == u.getClave())
            {
               return u;
            }
         }
         return null;
      }

   }
}

