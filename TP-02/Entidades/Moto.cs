using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Vehiculo con sus 3 atributos setteados
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="chasis"> chasis to set</param>
        /// <param name="color">color to set</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color) : base (marca, chasis, color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio 
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        /// <summary>
        /// Publica todos los datos del la Moto.
        /// </summary>
        /// <returns>Un String con los datos del la moto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
