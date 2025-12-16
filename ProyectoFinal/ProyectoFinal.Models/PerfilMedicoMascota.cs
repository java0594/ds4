namespace ProyectoFinal.Models
{
    public class PerfilMedicoMascota
    {
        public int MascotaId { get; set; }
        public string Mascota { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;

        public string Dueno { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
    }
}
