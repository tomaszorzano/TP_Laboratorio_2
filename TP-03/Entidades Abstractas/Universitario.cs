using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        public Universitario() : base()
        {
        }


        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si 2 universitarios son iguales, al coincidir el tipo y dni o legajo.
        /// </summary>
        /// <param name="pg1"></param>Universitario a comparar.
        /// <param name="pg2"></param>Universitario a comparar.
        /// <returns>True si son iguales, False si no son iguales</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ((Equals(pg1, pg2)) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                throw new AlumnoRepetidoException();
            }
            return false;
        }

        /// <summary>
        /// Verifica si 2 universitarios no son iguales, al no coincidir en el tipo y en el dni o legajo.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si no son iguales, False si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Verifica que 2 unniversitarios sean iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True sison iguales, False si no son iguales</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        #endregion

        #region Abstractos
        protected abstract string ParticiparEnClase();
        #endregion

        #region Metodos
        /// <summary>
        /// muestra los datos del universitario.
        /// </summary>
        /// <returns>Los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("\nLEGAJO NUMERO: {0}", this.legajo);

            return sb.ToString();
        }
        #endregion




    }
}