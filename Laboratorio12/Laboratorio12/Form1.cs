using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtVelocidad.Clear();
            txtTiempo.Clear();
            txtResultado.Clear();
            txtVelocidad.Focus();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
           
            if (!double.TryParse(txtVelocidad.Text, out double velocidad) || velocidad < 0)
            {
                MessageBox.Show("Por favor ingresa una velocidad válida.");
                return;
            }

           
            if (!double.TryParse(txtTiempo.Text, out double tiempo) || tiempo <= 0)
            {
                MessageBox.Show("Por favor ingresa un tiempo válido mayor a cero.");
                return;
            }

            
            double distancia = velocidad * tiempo;
            txtResultado.Text = $"Distancia: {distancia:F2} km";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
