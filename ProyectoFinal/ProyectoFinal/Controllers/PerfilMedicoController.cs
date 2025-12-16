using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DAL;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilMedicoController : ControllerBase
    {
        private readonly PerfilMedicoDAL _dal;

        public PerfilMedicoController(PerfilMedicoDAL dal)
        {
            _dal = dal;
        }

        [HttpGet("{mascotaId}")]
        public async Task<IActionResult> Get(int mascotaId)
        {
            var perfil = await _dal.ObtenerPerfilMedico(mascotaId);

            if (perfil == null)
                return NotFound(new { mensaje = "Mascota no encontrada" });

            return Ok(perfil);
        }
    }
}
