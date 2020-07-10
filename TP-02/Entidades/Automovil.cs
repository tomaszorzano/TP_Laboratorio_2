using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        public enum ETipo { Monovolumen, Sedan }
        private ETipo tipo;

        /// <summary>
        /// Automovil con sus atributos seteados
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="chasis">chasis to set</param>
        /// <param name="color">color to set</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color) : base(marca, chasis, color)
        {
                
        }
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="chasis">chasis to set</param>
        /// <param name="color">color to set</param>
         /// <param name="tipo">tipo to set</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo ): this (marca,chasis,color)
        {
            tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio 
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Publica todos los datos de Automovil.
        /// </summary>
        /// <returns>Un String con los datos de Automovil</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
