using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio13
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=.\sqlexpress;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* SqlConnection conexion = new SqlConnection(connectionString);
             conexion.Open();
             MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
             conexion.Close();
             MessageBox.Show("Se cerró la conexión.");*/
            string query = "SELECT ProductName FROM [dbo].[Products]";

            // Usamos using para manejar la conexión y recursos correctamente
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Agrega cada nombre de producto al ListBox
                            listBox1.Items.Add(reader["ProductName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
        }
    }
}
