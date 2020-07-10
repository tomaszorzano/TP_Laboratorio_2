using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciadas
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion


        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }


        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }


        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }


        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { jornada[i] = value; }
        }
        #endregion


        #region Constructores
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica que la universidad cuente con ese Alumno.
        /// </summary>
        /// <param name="g"></param>Univerisdad a verificar.
        /// <param name="a"></param>Alumno a buscar en la Universidad.
        /// <returns>True si el Alumno ya esta en la Univ. False caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumnoAux in g.Alumnos)
            {
                if (alumnoAux == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica que la universidad no cuente con ese Alumno.
        /// </summary>
        /// <param name="g"></param>Univerisdad a verificar.
        /// <param name="a"></param>Alumno a buscar en la Universidad.
        /// <returns>True si el Alumno No esta en la Univ. False caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        /// <summary>
        /// Verfica si el Profesor ya esta en la Universidad.
        /// </summary>
        /// <param name="g"></param>Universidad a verificar.
        /// <param name="i"></param>Profesor a buscar en la universidad.
        /// <returns>True si esta en la Univ. False caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesorAux in g.Instructores)
            {
                if (profesorAux == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verfica si el Profesor No esta en la Universidad.
        /// </summary>
        /// <param name="g"></param>Universidad a verificar.
        /// <param name="i"></param>Profesor a buscar en la universidad.
        /// <returns>True si No esta en la Univ. False caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Verifica si hay algun Profesor para dar la clase.
        /// </summary>
        /// <param name="u"></param>Universidad en la que se consulta.
        /// <param name="clase"></param>Clase a la que se le busca Profesor.
        /// <returns>Primer Profesor que de la clase, caso contrario lanza la Excpetion SinProfesorException</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profeAux in u.Instructores)
            {
                if (profeAux == clase)
                {
                    return profeAux;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Verifica si No hay algun Profesor para dar la clase.
        /// </summary>
        /// <param name="u"></param>Universidad en la que se consulta.
        /// <param name="clase"></param>Clase a la que se le busca Profesor.
        /// <returns>Primer Profesor que no da la clase, caso contrario Exception SinProfesorException</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profeAux in u.Instructores)
            {
                if (profeAux != clase)
                {
                    return profeAux;
                }
            }
            throw new SinProfesorException();

        }

        /// <summary>
        /// Agrega una clase a la universidad.
        /// </summary>
        /// <param name="g"></param>Universidad a la cual se le agregara la clase.
        /// <param name="clase"></param>Clase a agregar a la Universidad.
        /// <returns>Universidad con la clase</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            g.Jornada.Add(jornada);
            foreach (Alumno alumnoAux in g.Alumnos)
            {
                if (alumnoAux == clase)
                {
                    jornada += alumnoAux;
                }
            }

            return g;
        }

        /// <summary>
        /// Agrega Alumno a la Universidad si este no se encuentra ya en la misma.
        /// </summary>
        /// <param name="u"></param>Universidad a agregar Alumno.
        /// <param name="a"></param>Alumno a agregar a la Universidad.
        /// <returns>Universidad con el Alumno</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// Agrega un Profesor a la Universidad si este no se encuetra ya en la misma.
        /// </summary>
        /// <param name="u"></param>Universidad a agregar Profesor.
        /// <param name="i"></param>Profesor a agregar a la Univ.
        /// <returns>Univ. con Profesor</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Hace publicos los datos de la Universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos de la Universidad.
        /// </summary>
        /// <param name="uni"></param>Universidad a mostrar.
        /// <returns>Los datos de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada auxJornada in uni.Jornada)
            {
                sb.AppendFormat(auxJornada.ToString());
            }

            return sb.ToString();
        }


        /// <summary>
        /// Lee el archivo que contiene la universidad en xml.
        /// </summary>
        /// <returns>la Universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> leerXml = new Xml<Universidad>();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ".\\Universidad.xml";
            if (leerXml.Leer(archivo, out Universidad uni))
            {
                return uni;
            }
            return uni;

        }

        /// <summary>
        /// Guarda la universidad en Xml.
        /// </summary>
        /// <param name="uni"></param>Universidad a Guardar.
        /// <returns>True si logro Guardar, False caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlGuardar = new Xml<Universidad>();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ".\\Universidad.xml";
            if (xmlGuardar.Guardar(archivo, uni))
            {
                return true;
            }
            return false;
        }
        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}