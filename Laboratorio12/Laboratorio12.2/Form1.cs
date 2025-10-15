using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
           
            if (!double.TryParse(txtNota1.Text, out double nota1) || nota1 < 0 || nota1 > 100)
            {
                MessageBox.Show("Por favor ingresa una nota 1 válida entre 0 y 100.");
                txtNota1.Focus();
                return;
            }

           
            if (!double.TryParse(txtNota2.Text, out double nota2) || nota2 < 0 || nota2 > 100)
            {
                MessageBox.Show("Por favor ingresa una nota 2 válida entre 0 y 100.");
                txtNota2.Focus();
                return;
            }

            if (!double.TryParse(txtNota3.Text, out double nota3) || nota2 < 0 || nota2 > 100)
            {
                MessageBox.Show("Por favor ingresa una nota 3 válida entre 0 y 100.");
                txtNota3.Focus();
                return;
            }

            
            double promedio = (nota1 + nota2 + nota3) / 3;

            
            txtResultado.Text = $"Promedio: {promedio:F2}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtResultado.Text = "";
            txtNota1.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
