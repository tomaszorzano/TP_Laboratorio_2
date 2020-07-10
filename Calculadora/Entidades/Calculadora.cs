using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// Realiza el calculo de dos numeros.
        /// </summary>
        /// <param name="num1">Primer argumento de la operacion</param>
        /// <param name="num2">Segundo argumento de la operacion</param>
        /// <param name="operador">Indica la operacion entre los numeros</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Valida que el operador sea (+ - * /) 
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Devuelve el operador, si no es valido devuelve la letra n </returns>
        private static string ValidarOperador(string operador)
        {
            string salida = "n";

            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                salida = operador;
            }
            return salida;
        }

        
    }
}
