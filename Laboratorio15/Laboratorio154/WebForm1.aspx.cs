using System;
using System.Web.UI;

namespace Laboratorio154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            int numero1, numero2;

            bool esNumero1 = int.TryParse(txtNumero1.Text, out numero1);
            bool esNumero2 = int.TryParse(txtNumero2.Text, out numero2);

            if (esNumero1 && esNumero2)
            {
                int suma = numero1 + numero2;
                lblResultado.Text = "La suma es: " + suma.ToString();
            }
            else
            {
                lblResultado.Text = "Por favor, ingrese números válidos.";
            }
        }
    }
}
