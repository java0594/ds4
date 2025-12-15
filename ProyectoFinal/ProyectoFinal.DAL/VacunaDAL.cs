using Dapper;
using ProyectoFinal.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace ProyectoFinal.DAL
{
    public class VacunaDAL
    {
        private readonly AppDbConnection _db;

        public VacunaDAL(AppDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Vacuna>> PorMascota(int mascotaId)
        {
            using var connection = _db.CreateConnection();
            return await connection.QueryAsync<Vacuna>(
                "sp_Vacuna_PorMascota",
                new { MascotaId = mascotaId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task Insertar(Vacuna vacuna)
        {
            using var connection = _db.CreateConnection();
            await connection.ExecuteAsync(
                "sp_Vacuna_Insertar",
                new
                {
                    vacuna.MascotaId,
                    vacuna.NombreVacuna,
                    vacuna.FechaAplicada,
                    vacuna.ProximaFecha,
                    vacuna.Observaciones
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
