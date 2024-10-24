﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Tecnico
  {
    private static int IdIncremental = 0;
    public int ID_Tecnico { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string CI { get; set; }
    public Especialidad EspecialidadTecnico;
    public List<string> ListaComentarios { get; set; }

    public Tecnico(string nombre, string apellido, string cI, Especialidad especialidadTecnico)
    {
      ID_Tecnico = ++IdIncremental;
      Nombre = nombre;
      Apellido = apellido;
      CI = cI;
      EspecialidadTecnico = especialidadTecnico;
      ListaComentarios = new List<string>();
    }
  }

  
}
