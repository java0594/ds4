using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Parcial_3
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPreguntas();
            }
        }

        private void CargarPreguntas()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Pregunta FROM JV_PreguntasRespuestas", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownListPreguntas.DataSource = reader;
                DropDownListPreguntas.DataTextField = "Pregunta";
                DropDownListPreguntas.DataValueField = "Id";
                DropDownListPreguntas.DataBind();
            }
            DropDownListPreguntas.Items.Insert(0, "--Selecciona una pregunta--");
        }

        protected void ButtonMostrar_Click(object sender, EventArgs e)
        {
            if (DropDownListPreguntas.SelectedIndex > 0)
            {
                int id = int.Parse(DropDownListPreguntas.SelectedValue);
                MostrarRespuesta(id);
            }
        }

        private void MostrarRespuesta(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT Respuesta FROM JV_PreguntasRespuestas WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                object result = cmd.ExecuteScalar();
                LabelRespuesta.Text = result?.ToString() ?? "No hay respuesta.";
            }
        }
    }
}
