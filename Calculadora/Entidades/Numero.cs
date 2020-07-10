using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        /// <summary>
        /// Variable que guardara el numero de la entidad 
        /// </summary>
        private double numero;

        public double Numeros { set { this.numero = ValidarNumero(Convert.ToString(value)); } }

        /// <summary>
        /// Constructor por defecto que asigna numero 0
        /// </summary>
        public Numero() : this(0)
        {

        }
        /// <summary>
        /// Contructor que guarda el numero en la variable
        /// </summary>
        /// <param name="numero">Numero a guardar</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que guarda el numero tras una validacion
        /// </summary>
        /// <param name="strNumero">Numero a guardar en forma de string</param>
        public Numero(string strNumero)
        {
            this.numero = Convert.ToDouble(strNumero); 
        }
        /// <summary>
        /// Setea el numero, previamente realiza una validacion 
        /// </summary>
        /// <param name="strNumero">Numero a guardar en forma de string</param>
        //private void SetNumero(string strNumero)
        //{
        //    this.numero = ValidarNumero(strNumero);
        //}
        /// <summary>
        /// Valida que el valor recibido sea un numero
        /// </summary>
        /// <param name="strNumero">Es el numero en forma de string sobre el que se realiza la validacion</param>
        /// <returns>Devuelve el numero validado, si no es valido, se devuelve un 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double aux;

            if (double.TryParse(strNumero, out aux))
            {

                return aux;
            }
            return 0;
        }
        /// <summary>
        /// Conversion de Binario a Decimal
        /// </summary>
        /// <param name="binario">Numero binario a convertir</param>
        /// <returns>Devuelve el decimal convertido como string, o Error si no puede realizar la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            string salida = "ERROR! Numero no Binario";
            if (Regex.IsMatch(binario, "[^01]"))
            {
                return salida;
            }

            char[] arrayBinario = binario.ToCharArray();
            Array.Reverse(arrayBinario);
            double numero = 0;
            for (int i = 0; i < arrayBinario.Length; i++)
            {
                if (arrayBinario[i] == '1')
                {
                    if (i == 0)
                    {
                        numero += 1;
                    }
                    else
                    {
                        numero += Math.Pow(2, i);
                    }
                }
            }
            return numero.ToString();
        }
        /// <summary>
        /// Conversion de DEcimal a Binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>Devuelve un numero binario en forma de string, o "Valor Invalido" si no se puede realizar la conversion</returns>
        public string DecimalBinario(string numero)
        {
            Numeros = Convert.ToDouble(numero); /// SetNumero es el unico metodo donde se debe validar segun la consigna

            if (numero != "0" && this.numero == 0)
                return "Valor Invalido";
            return DecimalBinario(this.numero);
        }
        /// <summary>
        /// Conversion de Decimal a Binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>Devuelve un numero binario en forma de string</returns>
        public string DecimalBinario(double numero)
        {
            numero = Math.Abs(Math.Floor(numero));
            string binario = "";
            for (int i = 0; numero > 0; i++)
            {
                binario += (numero % 2).ToString();
                numero = Math.Floor(numero / 2);
            }
            if (binario.Equals(""))
                binario = "0";
            char[] arrayBinario = binario.ToCharArray();
            Array.Reverse(arrayBinario);
            return new string(arrayBinario);
        }

        /// <summary>
        /// Divide dos numeros
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>Devuelve el resultado de la division</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            { 
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
        /// <summary>
        /// Multiplica dos numeros
        /// </summary>
        /// <param name="n1">numero 1r</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Devuelve el resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Resta dos numeros
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Devuelve el resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Suma dos numeros
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Devuelve el resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

    }
}
