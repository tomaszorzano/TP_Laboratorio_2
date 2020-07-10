using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta :Vehiculo
    {
        /// <summary>
        /// Camioneta con sus atributos seteados
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="chasis">chasis to set</param>
        /// <param name="color">color to set</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color) : base(marca, chasis, color)
        {
        }
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        /// <summary>
        /// Publica todos los datos de Camioneta.
        /// </summary>
        /// <returns>Un String con los datos de Camioneta</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
