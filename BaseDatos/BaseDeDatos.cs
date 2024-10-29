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
		public static List<Cliente> ListaClientes = new List<Cliente>
		{
			new Cliente("Pepe", "Sanchez", "30302553", "Carlos Paez 2204", "095989898", "pepesanchez@gmail.com"),
			new Cliente("Carlos", "Garcia", "30503553", "18 de Julio 204", "099123591"),
			new Cliente("Marta", "De Leon", "40015532", "Rincon 305", "093982112")
		};

		public static List<Tecnico> ListaTecnicos { get; set; } = new List<Tecnico>
		{
			new Tecnico("Nacho", "Culebra", "33490543", Especialidad.Informatica),
			new Tecnico("Julia", "Lopez", "43223541", Especialidad.Electrodomesticos),
			new Tecnico("Pablo", "Clavito", "52518522", Especialidad.Iluminacion)
		};

		public static List<Orden> ListaOrdenes = new List<Orden>
		{
			new Orden(ListaClientes[0], ListaTecnicos[0], "Limpiar virus", DateTime.Now, Estado.Completada, ListaTecnicos[0].ListaComentarios),
			new Orden(ListaClientes[1], ListaTecnicos[1], "Arreglar Heladera", DateTime.Now, Estado.EnProgreso, ListaTecnicos[1].ListaComentarios),
			new Orden(ListaClientes[2], ListaTecnicos[2], "Instalar luces", DateTime.Now, Estado.Pendiente, ListaTecnicos[2].ListaComentarios)
		};

		public static Cliente ObtenerCliente(int idCliente)
		{
			foreach (Cliente cliente in ListaClientes)
			{
				if (cliente.ID_Cliente == idCliente)
				{
					return cliente;
				}
			}
			return null;
		}
		
		public static void EditarCliente(Cliente cliente, Cliente nuevoCliente)
		{
		}
	}
}
