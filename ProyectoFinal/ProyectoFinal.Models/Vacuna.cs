namespace ProyectoFinal.Models
{
    public class Vacuna
    {
        public int VacunaId { get; set; }
        public int MascotaId { get; set; }
        public string NombreVacuna { get; set; } = string.Empty;
        public DateTime FechaAplicada { get; set; }
        public DateTime? ProximaFecha { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
