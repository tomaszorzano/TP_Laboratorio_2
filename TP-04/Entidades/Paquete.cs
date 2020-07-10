using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }


        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }


        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }


        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }



        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }



        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                switch (this.Estado)
                {
                    case EEstado.Ingresado:
                        this.Estado = EEstado.EnViaje;
                        break;

                    case EEstado.EnViaje:
                        this.Estado = EEstado.Entregado;
                        break;

                }
                DelegadoEstado delegado = this.InformaEstado;
                delegado(this, null);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public string MostrarDatos(IMostrar<Paquete> elemento)
        {

            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);

        }



        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TrackingID == p2.TrackingID)
            {
                return true;
            }
            return false;
        }


        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


        public override string ToString()
        {
            return this.MostrarDatos((IMostrar<Paquete>)this);
        }








    }
}
