using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;


        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }


        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach (Thread h in mockPaquetes)
            {
                h.Abort();
            }
        }


        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in ((Correo)elementos).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega,
                 paquete.Estado.ToString()));
            }
            return sb.ToString();
        }


        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete auxPaquete in c.paquetes)
            {
                if (p == auxPaquete)
                {
                    throw new TrackingIdRepetidoException("ID Repetido" + p.TrackingID);
                }
            }
            c.paquetes.Add(p);

            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }

    }
}