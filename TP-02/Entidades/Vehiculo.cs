using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public enum ETamanio
    {
        Chico, Mediano, Grande
    }
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public  abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }

        private EMarca marca;
       private string chasis;
       private ConsoleColor color;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Vehiculo con sus 3 atributos setteados
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="chasis"> chasis to set</param>
        /// <param name="color">color to set</param>
        public Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Convierte el Vehiculo en un string con todos sus datos
        /// </summary>
        /// <param name="p">Vehiculo del que obtenemos los datos</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendLine();
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendLine();
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine();
            sb.AppendLine("---------------------");

            return sb.ToString() ;
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer Vehiculo a comparar</param>
        /// <param name="v2">Segundo Vehiculo a comparar</param>
        /// <returns>True si son iguales, false en caso que no sean iguales</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer Vehiculo a comparar</param>
        /// <param name="v2">Segundo Vehiculo a comparar</param>
        /// <returns>True si no son iguales, false si son iguales</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
    }
}
