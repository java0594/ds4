using Dapper;
using ProyectoFinal.Models;

namespace ProyectoFinal.DAL
{
    public class PerfilMedicoDAL
    {
        private readonly AppDbConnection _db;

        public PerfilMedicoDAL(AppDbConnection db)
        {
            _db = db;
        }

        public async Task<PerfilMedicoView?> ObtenerPerfilMedico(int mascotaId)
        {
            using var connection = _db.CreateConnection();

            using var multi = await connection.QueryMultipleAsync(
                "dbo.sp_PerfilMedico_PorMascota",
                new { MascotaId = mascotaId },
                commandType: System.Data.CommandType.StoredProcedure
            );

            var mascota = await multi.ReadFirstOrDefaultAsync<PerfilMedicoMascota>();
            var vacunas = (await multi.ReadAsync<PerfilMedicoVacuna>()).ToList();

            if (mascota == null) return null;

            return new PerfilMedicoView
            {
                Mascota = mascota,
                Vacunas = vacunas
            };
        }
    }
}
