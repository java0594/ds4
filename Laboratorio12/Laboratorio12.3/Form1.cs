using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool ValidarLados(out double a, out double b, out double c)
        {
            a = b = c = 0;

            if (!double.TryParse(txtLado1.Text, out a) || a <= 0)
            {
                MessageBox.Show("Ingresa un lado 1 válido y mayor que 0.");
                txtLado1.Focus();
                return false;
            }
            if (!double.TryParse(txtLado2.Text, out b) || b <= 0)
            {
                MessageBox.Show("Ingresa un lado 2 válido y mayor que 0.");
                txtLado2.Focus();
                return false;
            }
            if (!double.TryParse(txtLado3.Text, out c) || c <= 0)
            {
                MessageBox.Show("Ingresa un lado 3 válido y mayor que 0.");
                txtLado3.Focus();
                return false;
            }

            
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                MessageBox.Show("Los lados no pueden formar un triángulo.");
                return false;
            }

            return true;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcularSemiperimetro_Click(object sender, EventArgs e)
        {
            {
                if (!ValidarLados(out double a, out double b, out double c))
                    return;

                double semiperimetro = (a + b + c) / 2;
                txtSemiperimetro.Text = $"Semiperímetro: {semiperimetro:F2}";
            }
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            if (!ValidarLados(out double a, out double b, out double c))
                return;

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            if (double.IsNaN(area))
            {
                MessageBox.Show("Los lados ingresados no forman un triángulo válido.");
                txtArea.Text = "";
                return;
            }

            txtArea.Text = area.ToString("F2");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtLado1.Clear();
            txtLado2.Clear();
            txtLado3.Clear();
            txtSemiperimetro.Clear();
            txtArea.Clear();
            txtLado1.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
