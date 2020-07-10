using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        public static bool Guardar(this string texto, string archivo)
        {

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(archivo, true))
            {
                sw.WriteLine(texto);
            }

            return true;
        }
    }
}
