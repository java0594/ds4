using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DAL;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuenoController : ControllerBase
    {
        private readonly DuenoDAL _duenoDal;

        public DuenoController(DuenoDAL duenoDal)
        {
            _duenoDal = duenoDal;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var duenos = await _duenoDal.Listar();
            return Ok(duenos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dueno dueno)
        {
            await _duenoDal.Insertar(dueno);
            return Ok(new { mensaje = "Dueño registrado correctamente" });
        }
    }
}
