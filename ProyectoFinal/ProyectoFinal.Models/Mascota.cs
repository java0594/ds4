namespace ProyectoFinal.Models
{
    public class Mascota
    {
        public int MascotaId { get; set; }
        public int DuenoId { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}
