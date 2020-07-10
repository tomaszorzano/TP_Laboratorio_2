using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(archivo, true))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (ArchivosException archExc)
            {
                Console.WriteLine(archExc.Message);
                return false;
            }

        }


        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch (ArchivosException archExc)
            {
                Console.WriteLine(archExc.Message);
                datos = "";
                return false;
            }
        }
    }
}