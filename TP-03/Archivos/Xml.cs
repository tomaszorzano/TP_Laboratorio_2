using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(archivo);

                ser.Serialize(writer, datos);
                writer.Close();

                return true;
            }
            catch (ArchivosException archExc)
            {
                Console.WriteLine(archExc.Message);
                return false;
            }


        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(archivo);

                datos = (T)ser.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (ArchivosException archExc)
            {
                Console.WriteLine(archExc.Message);
                datos = default(T);
                return false;
            }
        }
    }
}