using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DAL;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacunaController : ControllerBase
    {
        private readonly VacunaDAL _vacunaDal;

        public VacunaController(VacunaDAL vacunaDal)
        {
            _vacunaDal = vacunaDal;
        }

        // GET: api/Vacuna/PorMascota/1
        [HttpGet("PorMascota/{mascotaId:int}")]
        public async Task<IActionResult> GetPorMascota(int mascotaId)
        {
            if (mascotaId <= 0)
                return BadRequest("Id de mascota inválido");

            var vacunas = await _vacunaDal.PorMascota(mascotaId);
            return Ok(vacunas);
        }

        // POST: api/Vacuna
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vacuna vacuna)
        {
            if (vacuna == null || vacuna.MascotaId <= 0)
                return BadRequest("Datos de vacuna inválidos");

            await _vacunaDal.Insertar(vacuna);
            return Ok(new { mensaje = "Vacuna registrada correctamente" });
        }
    }
}
