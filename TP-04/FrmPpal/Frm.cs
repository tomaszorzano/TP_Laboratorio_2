using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmPpal
{
    public partial class Frm : Form
    {
        public Correo correo;

        public Frm()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        

        private void ActualizarEstados()
        {
            lstEstadoIngersado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in correo.Paquetes)
            {
                if (paquete.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngersado.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.Entregado)
                {
                    lstEstadoEntregado.Items.Add(paquete);
                }
            }
        }


        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + "\\salida.txt";
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                GuardarString.Guardar(rtbMostrar.Text, archivo);
            }
        }


       


        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { // Llamar al método
                this.ActualizarEstados();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;

            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException trE)
            {
                MessageBox.Show(trE.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ActualizarEstados();
        }

        private void btnMostrarTodos_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
    }
}