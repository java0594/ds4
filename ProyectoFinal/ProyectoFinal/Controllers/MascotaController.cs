using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DAL;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotaController : ControllerBase
    {
        private readonly MascotaDAL _mascotaDal;

        public MascotaController(MascotaDAL mascotaDal)
        {
            _mascotaDal = mascotaDal;
        }

        // GET: api/Mascota
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mascotas = await _mascotaDal.Listar();
            return Ok(mascotas);
        }

        // POST: api/Mascota
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mascota mascota)
        {
            if (mascota == null || mascota.DuenoId <= 0)
                return BadRequest("Datos de mascota inválidos");

            await _mascotaDal.Insertar(mascota);
            return Ok(new { mensaje = "Mascota registrada correctamente" });
        }
    }
}
