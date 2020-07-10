using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion 

        #region Propiedades
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }


        public string Nombre
        {
            get { return this.nombre; }
            set
            {

                if (this.ValidarNombreApellido(value) == 1)
                {
                    this.nombre = value;
                }
            }
        }


        public string Apellido
        {
            get { return this.apellido; }
            set
            {

                if (this.ValidarNombreApellido(value) == 1)
                {
                    this.apellido = value;
                }
            }
        }


        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }
        }


        public string stringToDNI
        {
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }
        }


        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        #endregion 


        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }


        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido,
            nacionalidad)
        {
            this.DNI = dni;
        }


        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido,
            nacionalidad)
        {
            this.stringToDNI = dni;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Retorna la informacion de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);

            return sb.ToString();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica si es el dni es valido.
        /// </summary>
        /// <param name="nacionalidad"></param> Nacionalidad de la Persona.
        /// <param name="dato"></param> Dni a validar.
        /// <returns>Si es valido rerorna el Dni, sino lanza la Exception</returns> 
        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato > 1 && dato < 99999999)
            {
                if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) ||
                    (nacionalidad == ENacionalidad.Extranjero && dato <= 99999999 && dato >= 90000000))
                {
                    return dni;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La Nacionalidad no se condice con el numero de DNI");
                }

            }
            else
            {
                throw new DniInvalidoException("Dni Invalido");
            }
        }

        /// <summary>
        /// Valida si el dato es un numero.
        /// </summary>
        /// <param name="nacionalidad"></param> Nacionalidad de la Persona.
        /// <param name="dato"></param> Dni a validar.
        /// <returns>Si es valido retorna el Dni, caso contrario lanza la Exception</returns>
        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length > 1 && dato.Length < 9 && int.TryParse(dato, out int dni))
            {
                this.ValidarDni(this.nacionalidad, dni);
                return dni;
            }
            else
            {
                throw new DniInvalidoException("Dni Invalido");
            }
        }

        /// <summary>
        /// Valida si el nombre/apellido es una cadena valida.
        /// </summary>
        /// <param name="dato"></param>Cadena Nombre/Apellido a Validar.
        /// <returns>retorna 1 si es correcto, 0 sino lo es</returns>
        public int ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            // Valido el dato
            Match match = regex.Match(dato);

            if (match.Success)
            {
                return 1;
            }
            return 0;
        }
        #endregion

    }
}