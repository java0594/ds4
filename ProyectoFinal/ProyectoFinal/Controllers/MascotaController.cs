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

        // GET: api/Mascota/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mascota = await _mascotaDal.ObtenerPorId(id);

            if (mascota == null)
                return NotFound();

            return Ok(mascota);
        }

        // POST: api/Mascota
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mascota mascota)
        {
            if (mascota == null || mascota.DuenoId <= 0)
                return BadRequest("Datos de mascota inválidos");

            var id = await _mascotaDal.Insertar(mascota);
            mascota.MascotaId = id;

            return Ok(mascota);
        }

        // PUT: api/Mascota/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Mascota mascota)
        {
            if (id != mascota.MascotaId)
                return BadRequest("ID de mascota no coincide");

            await _mascotaDal.Actualizar(mascota);
            return Ok(new { mensaje = "Mascota actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mascotaDal.Eliminar(id);
            return Ok(new { mensaje = "Mascota eliminada" });
        }

    }
}
