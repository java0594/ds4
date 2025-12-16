using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public class PerfilMedicoView
    {
        public PerfilMedicoMascota Mascota { get; set; } = new();
        public List<PerfilMedicoVacuna> Vacunas { get; set; } = new();
    }
}
