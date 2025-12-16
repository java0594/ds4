using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ProyectoFinal.Models;

namespace ProyectoFinal.DAL
{
    public class MascotaDAL
    {
        private readonly AppDbConnection _db;

        public MascotaDAL(AppDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MascotaView>> Listar()
        {
            using var connection = _db.CreateConnection();
            return await connection.QueryAsync<MascotaView>(
                "sp_Mascota_Listar",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Insertar(Mascota mascota)
        {
            using var connection = _db.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(
                "sp_Mascota_Insertar",
                new
                {
                    mascota.DuenoId,
                    mascota.Nombre,
                    mascota.Especie,
                    mascota.Raza,
                    mascota.Sexo,
                    mascota.FechaNacimiento
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task Actualizar(Mascota mascota)
        {
            using var conn = _db.CreateConnection();

            await conn.ExecuteAsync(
                "sp_Mascota_Actualizar",
                mascota,
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Mascota?> ObtenerPorId(int id)
        {
            using var conn = _db.CreateConnection();

            return await conn.QueryFirstOrDefaultAsync<Mascota>(
                "sp_Mascota_ObtenerPorId",
                new { MascotaId = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task Eliminar(int id)
        {
            using var conn = _db.CreateConnection();
            await conn.ExecuteAsync(
                "sp_Mascota_Eliminar",
                new { MascotaId = id },
                commandType: CommandType.StoredProcedure
            );
        }



    }
}
