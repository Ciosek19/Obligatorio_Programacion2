using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public static class ValidadorCedula
   {
      public static bool EsCedulaValida(string cedula)
      {
         // Remover puntos y guiones
         cedula = cedula.Replace(".", "").Replace("-", "");

         // Verificar que tenga entre 7 y 8 dígitos
         if (cedula.Length < 7 || cedula.Length > 8)
         {
            return false;
         }

         // Separar el cuerpo del dígito verificador
         string cuerpo = cedula.Substring(0, cedula.Length - 1);
         char digitoVerificador = cedula[cedula.Length - 1];

         // Convertir a número el cuerpo y el dígito verificador
         if (!int.TryParse(cuerpo, out int numeroCuerpo) || !int.TryParse(digitoVerificador.ToString(), out int digitoVerificadorNumerico))
         {
            return false;
         }

         // Calcular el dígito verificador esperado
         int digitoCalculado = CalcularDigitoVerificador(numeroCuerpo);

         // Comparar el dígito calculado con el dígito verificador de la cédula
         return digitoCalculado == digitoVerificadorNumerico;
      }

      private static int CalcularDigitoVerificador(int cuerpo)
      {
         int[] pesos = { 2, 9, 8, 7, 6, 3, 4 };
         string cuerpoStr = cuerpo.ToString().PadLeft(7, '0');
         int suma = 0;

         for (int i = 0; i < 7; i++)
         {
            suma += (cuerpoStr[i] - '0') * pesos[i];
         }

         int resto = suma % 10;
         return resto == 0 ? 0 : 10 - resto;
      }
   }

}
