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

        public async Task Insertar(Mascota mascota)
        {
            using var connection = _db.CreateConnection();
            await connection.ExecuteAsync(
                "sp_Mascota_Insertar",
                new
                {
                    mascota.DuenoId,
                    mascota.Nombre,
                    mascota.Especie,
                    mascota.Raza,
                    mascota.FechaNacimiento,
                    mascota.Sexo
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
