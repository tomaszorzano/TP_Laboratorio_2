using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;


namespace EntidadesInstanciadas
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }


        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }


        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion


        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Lee la Jornada en texto.
        /// </summary>
        /// <returns>La Jornada Leida</returns>
        public static string Leer()
        {
            Texto leerTxt = new Texto();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ".\\Jornada.txt";
            if (leerTxt.Leer(archivo, out string jornada))
            {
                return jornada;
            }
            return jornada;

        }

        /// <summary>
        /// Guarda la Jornada en texto.
        /// </summary>
        /// <param name="jornada"></param>Jornada a Guardar.
        /// <returns>True si pudo Guardar, False caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto guardarTxt = new Texto();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ".\\Jornada.txt";
            if (guardarTxt.Guardar(archivo, jornada.ToString()))
            {
                return true;
            }
            return false;
        }
        #endregion 

        #region Sobrecargas
        /// <summary>
        /// Verifica que el alumno y la Jornada tengan la misma clase.
        /// </summary>
        /// <param name="j"></param>Jornada a verificar.
        /// <param name="a"></param>Alumno a verificar
        /// <returns>Ture si coinciden, False caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno aAux in j.Alumnos)
            {
                if (a == aAux)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica que la Jornada y el Alumno no tengan la misma clase.
        /// </summary>
        /// <param name="j"></param>Jornada a verificar.
        /// <param name="a"></param>Alumno a verificar
        /// <returns>True si no coinciden, False caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega el Alumno a la Jornada si este no esta ya en ella.
        /// </summary>
        /// <param name="j"></param>Jornada a agergar Alumno.
        /// <param name="a"></param>Alumno a agregar a la Jornada.
        /// <returns>Retorna la Jornada con o sin el Alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Muestra toda la informacion de la Jornada.
        /// </summary>
        /// <returns>Retorna la informacion de la Jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase, this.Instructor);
            sb.AppendFormat("\nALUMNOS: \n");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("<------------------------------>");
            return sb.ToString();
        }
        #endregion



    }
}